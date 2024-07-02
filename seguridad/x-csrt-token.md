[How does CSRF token work? SAP Gateway](https://community.sap.com/t5/technology-blogs-by-sap/how-does-csrf-token-work-sap-gateway/ba-p/13520186)

- En un metodo get, enviar en el header lo siguiete: `x-csrf-token = Fetch`
- Retorna en la cabecera un valor similar a: `x-csrf-token = S8CgBCJQa83x0cAmM0G3e6kED-OYHgFI`
- Si no se envia retorna un codigo 403 Forbiden y en la cabecera `x-csrf-token = required`
- Si se activa, se ejecuta en cualquier metodo de modificacion (CUD)(POST,PUT,DELETE, etc)