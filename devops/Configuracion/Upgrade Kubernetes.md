## Upgrade Kubernetes

[link](https://kubernetes.io/docs/tasks/administer-cluster/kubeadm/kubeadm-upgrade/) to upgrade

[link](https://v1-30.docs.kubernetes.io/docs/setup/production-environment/tools/kubeadm/install-kubeadm/) to install

> Get keyrings

```bash
curl -fsSL https://pkgs.k8s.io/core:/stable:/v1.30/deb/Release.key | sudo gpg --dearmor -o /etc/apt/keyrings/kubernetes-apt-keyring.gpg
```

> Get repository with specific version

```bash
echo 'deb [signed-by=/etc/apt/keyrings/kubernetes-apt-keyring.gpg] https://pkgs.k8s.io/core:/stable:/v1.29/deb/ /' | sudo tee /etc/apt/sources.list.d/kubernetes.list
echo 'deb [signed-by=/etc/apt/keyrings/kubernetes-apt-keyring.gpg] https://pkgs.k8s.io/core:/stable:/v1.30/deb/ /' | sudo tee /etc/apt/sources.list.d/kubernetes.list
echo 'deb [signed-by=/etc/apt/keyrings/kubernetes-apt-keyring.gpg] https://pkgs.k8s.io/core:/stable:/v1.31/deb/ /' | sudo tee /etc/apt/sources.list.d/kubernetes.list

sudo apt update
sudo apt-cache madison kubeadm
```

> Upgrade kubeadm

```bash
sudo kubeadm upgrade plan

sudo apt-mark unhold kubeadm
sudo apt-get install -y kubeadm='1.31.1-*'
sudo apt-mark hold kubeadm

# MASTER
sudo kubeadm upgrade apply v1.31.0

# NODO
sudo kubeadm upgrade node
```

> Upgrade kubelet and kubectl

```bash
sudo apt-mark unhold kubelet kubectl
sudo apt-get install -y kubelet='1.31.1-*' kubectl='1.31.1-*'
sudo apt-mark hold kubelet kubectl

sudo systemctl daemon-reload
sudo systemctl restart kubelet
```

> Comprobation

```bash
kubectl version
kubeadm version
kubelet --version
```


kubectl run postgresql-client --rm --tty -i --restart='Never' --namespace openproject --image docker.io/bitnami/postgresql:16.4.0-debian-12-r11 --env="PGPASSWORD=Abc123**" --command -- psql --host postgresql -U openproject -d openproject -p 5432