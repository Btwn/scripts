
export NEW_USER=myuser

openssl genrsa -out ${NEW_USER}.key 2048

openssl req -new -key ${NEW_USER}.key -out ${NEW_USER}.csr -subj "/CN=${NEW_USER}/O=korifi"

openssl x509 -CA /etc/kubernetes/pki/ca.crt -CAkey /etc/kubernetes/pki/ca.key -CAcreateserial -req -in ${NEW_USER}.csr -out ${NEW_USER}.crt
