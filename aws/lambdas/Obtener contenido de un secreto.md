## Para poder ver el contenido de un secreto y poder programar un layer

```python
import json
import boto3

def lambda_handler(event, context):
    
    session = boto3.session.Session()
    client = session.client(
        service_name='secretsmanager',
        region_name='us-east-1'
    )
    
    secret = client.get_secret_value(
            SecretId='secrets/postgres/dev'
        )
        
    print(secret)
    data = json.loads(secret['SecretString'])
    print(data)
```
