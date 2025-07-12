using System.Net;
using System.Net.Mail;
using YamlDotNet.Serialization;
using SendMail.Models;

namespace SendMail {  
public class MailService {  
        private string smtpAddress = "";
        private int portNumber;  
        private bool enableSSL;  
        private string emailFromAddress = "";
        private string password = ""; //Sender Password, like AppPassword from Gmail

        private List<string> To = new List<string>();
        private string subject = "";  
        private string body = "";  
<<<<<<< HEAD
        private string attachments = "";

        public MailService(List<string> receivers, string subject, string body, string attachments) 
=======
        public MailService(List<string> to, string subject, string body) 
>>>>>>> 41e62cf97c105b020e43661a26cb70d7630aeb28
        {
            var deserializer = new DeserializerBuilder()
                .Build();
            string settingsFile = "MailSettings.yaml";
            if (!File.Exists(settingsFile)) {
                throw new Exception("Settings File does not exists.");
            }
<<<<<<< HEAD
            using (StreamReader sr = File.OpenText(settingsFile)) {
                try
                {
                    MailSettings currentSettings = deserializer.Deserialize<MailSettings>(sr);
                    this.smtpAddress = currentSettings.SmtpAddress;
                    this.portNumber = currentSettings.SmtpPort;
                    this.password = currentSettings.SmtpPassword;
                    this.enableSSL = currentSettings.SSLEnabled;
                    this.emailFromAddress = currentSettings.EmailFrom;
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"Error reading Yaml file: {ex.Message}\n{ex.StackTrace}\n{ex.InnerException}");
                    throw ex;
                }
                            }
            this.Receivers = receivers;
=======
            using (var sr = File.OpenText(settingsFile)) {
                MailSettings currentSettings = deserializer.Deserialize<MailSettings>(sr);
                this.smtpAddress = currentSettings.SmtpAddress;
                this.portNumber = currentSettings.SmtpPort;
                this.password = currentSettings.SmtpPassword;
                this.enableSSL = currentSettings.SSLEnabled;
                this.emailFromAddress = currentSettings.EmailFrom;
            }
            this.To = to;
>>>>>>> 41e62cf97c105b020e43661a26cb70d7630aeb28
            this.subject = subject;
            this.body = body;
            this.attachments = attachments;
        }  

        public bool SendEmail() {  
            using(MailMessage mail = new MailMessage()) {  
                mail.From = new MailAddress(emailFromAddress);  
                foreach(var receiver in To) {
                    mail.To.Add(receiver); 
                }
                mail.Subject = subject;  
                mail.Body = body;  
                mail.IsBodyHtml = true;  
                if (!String.IsNullOrWhiteSpace(attachments)) {
                    if (File.Exists(attachments) || Directory.Exists(attachments)) {

                        Console.WriteLine("File found");
                        var attr = File.GetAttributes(attachments);
                        if ((attr & FileAttributes.Directory) == FileAttributes.Directory) {
                            foreach(var file in Directory.GetFiles(attachments)) {
                                mail.Attachments.Add(new Attachment(file));
                            }
                        } else {
                            mail.Attachments.Add(new Attachment(attachments));
                        }
                    } else {
                        Console.WriteLine($"The file {attachments} does not exists.");
                    }
                }
                try 
                {
                    using(SmtpClient smtp = new SmtpClient(smtpAddress, portNumber)) {  
                        smtp.Credentials = new NetworkCredential(emailFromAddress, password);  
                        smtp.EnableSsl = enableSSL;  
                        smtp.Send(mail);
                        Console.WriteLine("Send Mail successfully.");
                        return true;
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                    return false;
                }              
            }  
        }  
    }  
} 
