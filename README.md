# MailServiceInterface

### Startup

- Create a MailSettings.yaml
The file should look like this:
```
<<<<<<< HEAD
SmtpAddress: "smtp web address"
SmtpPassword: "App Password"
SmtpPort: port like [587]
SSLEnabled: true/false
EmailFrom: "Yout@mailAddress"
=======
- SmtpAddress: "smtp web address"
  SmtpPassword: "App Password"
  SmtpPort: port like [587]
  SSLEnabled: true/false
  EmailFrom: "Your@mailAddress"
>>>>>>> 41e62cf97c105b020e43661a26cb70d7630aeb28
```

- In Terminal run command
```
dotnet run
```

- Connect to web address: [Swagger](http://localhost:5147/swagger/index.html) to test API.
