## Se usa la libreria [psycopg2](https://pypi.org/project/psycopg2/)

```python
import json
import psycopg2

def lambda_handler(event, context):
    conn = psycopg2.connect("dbname=MyDB user=postgres password=mypassword host=<host or ip>")
    cur = conn.cursor()
    cur.execute("SELECT CURRENT_TIMESTAMP AS Tiempo;")
    result = cur.fetchone()
    print(result)
    
    cur.close()
    conn.close()
```

conn = psycopg2.connect("dbname=AdminDoc user=postgres password=dbapostgres#$ host=172.16.202.75")



```python
import json
from ConexionBD import *
import tools

def lambda_handler(event, context):
    try:
        # Valiadion de parametros
        keys = [
            {"nombre": "cliente", "tipo": str}
        ]
        args = tools.obtenerArgumentos(event)

        tools.validarParametros(args, keys)
        parms = args["cliente"]

        # Obtencion de datos
        conexionIntelisis = Conexion("IntelisisTmp", "Intelisis")

        sql = f"""SELECT CURRENT_TIMESTAMP AS Tiempo;"""

        result = conexionIntelisis.procedure(sql, parms)

        # Respuesta
        return tools.responseJson(200, result['result'])

    except Exception as e:
        return tools.responseJson(402, e, Default=str)

```






    
    conexionIntelisis = Conexion("AdminDoc")
    
    sql = "SELECT CURRENT_TIMESTAMP AS Tiempo;"
    result = conexionIntelisis.procedure(sql)

    # Respuesta
    return tools.responseJson(200, result['result'])


    You can mark the path chart.js/auto as external to exclude it from
  the bundle, which will remove this error and leave the unresolved path
  in the bundle. You can also add .catch() here to handle this failure
  at run-time instead of bundle-time.

  p-datatable-header-cell

http://single-spa-playground.org/playground/instant-test?name=@single-spa/app1-react&url=8500
http://localhost:8500/single-app1.js
https://single-spa-playground.org/playground/instant-test?name=vite-test&framework=vue&useNativeModules=true&url=https%3A%2F%2Flocalhost%3A3000%2Fsrc%2Fmain.js


http://localhost:8501/js/app.js
Navigate


application died in status LOADING_SOURCE_CODE: Unable to resolve bare specifier 'vue' from  (SystemJS Error#8 https://git.io/JvFET#8)
Error: Unable to resolve bare specifier 'vue' from (SystemJS Error#8 https://git.io/JvFET#8)

