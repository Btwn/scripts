## Incrementar el espacio en el disco de una maquina virtual de ubuntu en vmware

primero checar si las particiones estan bien y cuales hay

```bash
sudo parted -l
```

ver un mapeo del espacio

```bash
lsblk
```

You can't resize an extN filesystem on /dev/sda3 because it's not a filesystem partition. If you look at the lsblk output it's marked as a partition containing an LV, which means it's a partition containing Logical Volumes. The LV is what you want to resize, but you first need to resize the partition.

```bash
sudo parted /dev/sda print # Check you have exactly three partitions
sudo parted /dev/sda resizepart 3 100% # Extend the third
sudo parted /dev/sda print # Confirm the new partition size
```

Resize the PV (Physical Volume) that contains the Volume Group ("ubuntu-vg") containing Logical Volumes:

```bash
sudo pvresize /dev/sda3
```

extender el espacio

```bash
sudo lvextend -l +100%FREE /dev/ubuntu-vg/ubuntu-lv

sudo resize2fs /dev/mapper/ubuntu--vg-ubuntu--lv
```

revisar el espacio

```bash
sudo df -h
```

- referencia

[In an Ubuntu VM in VMWare I increased the hard disk space, how do I add that to the file system?](https://unix.stackexchange.com/questions/678677/in-an-ubuntu-vm-in-vmware-i-increased-the-hard-disk-space-how-do-i-add-that-to)
