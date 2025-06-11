using System.Net;
using System.Net.Mail;
using YamlDotNet.Serialization;

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
        public MailService(List<string> to, string subject, string body) 
        {
            var deserializer = new DeserializerBuilder()
                .Build();
            string settingsFile = "MailSettings.yaml";
            if (!File.Exists(settingsFile)) {
                throw new Exception("Settings File does not exists.");
            }
            using (var sr = File.OpenText(settingsFile)) {
                MailSettings currentSettings = deserializer.Deserialize<MailSettings>(sr);
                this.smtpAddress = currentSettings.SmtpAddress;
                this.portNumber = currentSettings.SmtpPort;
                this.password = currentSettings.SmtpPassword;
                this.enableSSL = currentSettings.SSLEnabled;
                this.emailFromAddress = currentSettings.EmailFrom;
            }
            this.To = to;
            this.subject = subject;
            this.body = body;
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
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
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
