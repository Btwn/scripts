Con wget en linux se puede descargar un istio completo

```bash
wget -r -np -k -p http://ejemplo.com
```

donde:
- `-r` permite la descarga recursiva (esto es, sigue los enlaces dentro del sitio).
- `-np` evita que Wget suba por directorios a nivel superior al de la URL inicial.
- `-k` convierte los enlaces en el sitio para que puedas navegarlo offline.
- `-p` descarga todos los recursos necesarios para la visualización correcta del sitio (imágenes, scripts, etc.).

opcionalmente se puede correr en docker con nginx

```bash
docker run --rm -it -v /path/to/site:/usr/share/nginx/html -p 8080:80 nginx
```
