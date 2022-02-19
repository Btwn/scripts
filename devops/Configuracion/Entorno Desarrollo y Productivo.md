## Configurar una app sencilla para el el entorno de produccion usando kubernetes y desarrollo con docker-compose

- Primero aqui esta una aplicacion sencilla de hola mundo en python, archivo: app.py

```python
from flask import Flask
app = Flask(__name__)

@app.route('/')
def hello_world():
	return 'Hello World\n'

if __name__ == '__main__':
	app.run(debug=True, host='0.0.0.0')
```
- Luego el archivo Dockerfile

hay dos puntos importantes, crea un usuario nuevo con menos privilegios, y al final deja ese usuario en uso
otra es que corre el archivo cmd.sh

```Dockerfile
FROM python:3.9

RUN groupadd -r uwsgi && useradd -r -g uwsgi uwsgi
RUN pip install Flask uWSGI
WORKDIR /app
COPY app /app
COPY cmd.sh /

EXPOSE 9090 9091
USER uwsgi

CMD ["/cmd.sh"]
```

- El archivo cmd.sh para correr en entorno de desarrollo o de produccion con una variable de entorno

```sh
#!/bin/bash
set -e

if [ "$ENV" = 'DEV' ]; then
  echo "Running Development Server"
  exec python "identidock.py"
else
  echo "Running Production Server"
  exec uwsgi --http 0.0.0.0:9090 --wsgi-file /app/identidock.py --callable app --stats 0.0.0.0:9191
fi
```


- y finalmente el archivo docker-compose.yml para correr en desarrollo creando la variable de entorno ENV

```yml
identidock:
  build: .
  ports:
   - "5000:5000"
  environment:
    ENV: DEV
  volumes:
   - ./app:/app
```