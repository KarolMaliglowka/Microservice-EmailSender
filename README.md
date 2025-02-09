![API mail sender](accessories/readme-image.jpg)

## Microservice-EmailSender

#### API for sending email messages


### Configuration

You need to configure either the `appsettings.json` file

```json
"Smtp": {
    "SmtpHost": "",
    "SmtpPort": 0,
    "UseSsl": true,
    "EmailAddress": "",
    "Password": ""
  }
```

or the `docker-composer.yaml` file

```yaml
environment:
  - SMTPHOST=<smtp_host>
  - SMTPPORT=<port>
  - USESSL=<bool_value>
  - EMAILADDRESS=<email_address>
  - PASSWORD=<password>
```
`SMTPHOST - server smtp`

`SMTPPORT - smtp server port`

`USESSL - is ssl is used`

`EMAILADDRESS - your email address`

`PASSWORD - password to addres`

### How to work with the application

To run the application, we need to have [Docker](https://docs.docker.com/get-started/get-docker/) or [ASP.NET Core Runtime 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed.

If we plan to run the application as a container from an image in the dock, we use scripts:

`build-docker.ps1` for windows

`build-docker.sh` for linux


### Examples

<details>
  <summary>PowerShell</summary>

  This is a example for powershell:

```powershell
$url = "http://host:4040/sendmail"
$contentType = "application/json"

$json = @{
  aliasFrom = "information come from send"
  to = @("email1@x.com", "email2@y.com")
  cc = @("email1@x.com", "email2@y.com")
  bcc = @("email1@x.com", "email2@y.com")
  subject = "subject message"
  bodyishtml = $False
  body = "body message"
} | ConvertTo-Json

Invoke-RestMethod -Uri $url -Method Post -Body $json -ContentType $contentType
```

</details>

<details>
  <summary>C#</summary>

  This is a example for C#:

```cs
using System.Text;
using System.Text.Json;

public class Program
{
    public static async Task Main()
    {
        var url = "http://host:4040/sendmail";
        var contentType = "application/json";

        using var client = new HttpClient();
        var values = new
        {
            Name = "information come from send",
            To = new List<string>(){ "email1@x.com", "email2@y.com" },
            Cc = new List<string>(),
            Bcc = new List<string>(),
            Subject = "subject message",
            BodyIsHtml = false,
            Body = "body message"
        };

        var jsonString = JsonSerializer.Serialize(values);
        var stringContent = new StringContent(jsonString, Encoding.UTF8, contentType);
        await client.PostAsync(url, stringContent);
    }
}
```

</details>

<details>
  <summary>Python</summary>
  
  This is a example for Python:

```python
import requests

url = 'http://host:4040/sendmail'
data = {
  "name": "information come from send",
  "to": ["email1@x.com", "email2@y.com"],
  "cc": ["email1@x.com", "email2@y.com"],
  "bcc": ["email1@x.com", "email2@y.com"],
  "subject": "subject message",
  "bodyishtml": False,
  "body": "body message"
}
headers = {'Content-type': 'application/json'}

response = requests.post(url, json=data, headers=headers)

print(response)
```

</details>
