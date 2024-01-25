# get certificate wit certboot

```bash
certbot certonly --manual --preferred-challenges dns -d "*.DOMAIN"
```

## Installing a root CA certificate in the trust store

```bash
sudo apt-get install -y ca-certificates
sudo cp local-ca.crt /usr/local/share/ca-certificates
sudo update-ca-certificates
```

```javascript

```
