# Microservice-EmailSender

- [About application](#about-application)
- [Technology](#technology)
- [Configuration](#configuration)
- [Examples](#examples)

## About application


## Technology
to use:
- minimal api (dotnet)
- MailKit
- Docker
- RabbitMQ


## Configuration


## Examples

<details>
  <summary>PowerShell</summary>

  This is a example for powershell

```powershell
$url = "http://host:4040/sendmail"
$contentType = "application/json"

$json = @{
  aliasFrom = "information come from send"
  to = @("email1@x.com", "email2@y.com")
  cc = @("email1@x.com", "email2@y.com")
  bcc = @("email1@x.com", "email2@y.com")
  subject = "subject message"
  body = "body message"
} | ConvertTo-Json

Invoke-RestMethod -Uri $url -Method Post -Body $json -ContentType $contentType
```

</details>

<details>
  <summary>C#</summary>

  This is a example for C#

</details>

<details>
  <summary>Python</summary>
  
  This is a example for Python

```python
import requests

url = 'http://host:4040/sendmail'
data = {
  "name": "information come from send",
  "to": ["email1@x.com", "email2@y.com"],
  "cc": ["email1@x.com", "email2@y.com"],
  "bcc": ["email1@x.com", "email2@y.com"],
  "subject": "subject message",
  "body": "body message"
}
headers = {'Content-type': 'application/json'}

response = requests.post(url, json=data, headers=headers)

print(response)
```

</details>