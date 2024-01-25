## SSH passwordless



1. Generate a key pair
   
   ```bash
   ssh-keygen -t rsa
   ```

2. Create SSH directory on server
   
   ```bash
   cd ~
   ls .ssh
   ```

3. Upload public key to remote server
   
   ```bash
   ssh-copy-id user@somedomain
   ```
   
   if fail
   
   ```bash
   scp ~/.ssh/id_rsa.pub user@somedomain:temp.pub
   ssh user@somedomain
   # logon in the remote machine
   sudo su -
   cat /home/user/temp.pub >> /home/user/.ssh/authorized_keys
   rm /home/user/temp.pub
   exit
   ```
   
   
