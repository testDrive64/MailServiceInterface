# MailServiceInterface

### Startup

- Create a MailSettings.yaml
The file should look like this:
```
SmtpAddress: "smtp web address"
SmtpPassword: "App Password"
SmtpPort: port like [587]
SSLEnabled: true/false
EmailFrom: "Your@mailAddress"
```

- In Terminal run command
```
dotnet run
```

- Connect to web address: [Swagger](http://localhost:5147/swagger/index.html) to test API.
