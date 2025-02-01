# Microservice-EmailSender
to use:
- minimal api (dotnet)
- MailKit
- Docker
- RabbitMQ








Examples

<details>
  <summary>PowerShell</summary>

  This is a example for powershell

```powershell
$url = "http://localhost:5248/sendmail"
$contentType = "application/json"

$json = @{
  from = "Your_email@xyz.com"
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