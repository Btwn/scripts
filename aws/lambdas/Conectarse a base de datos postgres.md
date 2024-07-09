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
