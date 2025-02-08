![API mail sender](readme-image.jpg)

# Microservice-EmailSender

### API for sending email messages


## Configuration



## How to work with the application



## Examples

<details>
  <summary>PowerShell</summary>

  This is a example for powershell with minimal context:

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

  This is a example for C# with minimal context:

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
  
  This is a example for Python with minimal context:

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
