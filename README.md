# Microservice-EmailSender
to use:
- minimal api (dotnet)
- MailKit
- Docker
- RabbitMQ




```powershell
$url = "http://localhost:5248/sendmail"

$json = @{
  from = "william@o2.pl"
  aliasFrom = "INFORMACJA - wazne powiadomienie"
  to = @("william@o2.pl")
  cc = @("karol_maliglowka@o2.pl", "maliglowkakarol@gmail.com")
  bcc = @("william@tlen.pl")
  subject = "wiadomo testowa"
  body = "trec wiadomoci1111"
} | ConvertTo-Json

Invoke-RestMethod -Uri $url -Method Post -Body $json -ContentType application/json
```
