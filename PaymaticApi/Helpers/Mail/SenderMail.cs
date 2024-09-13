using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Cl.Intertrade.ActivPay.Helpers.Mail
{
    public class SenderMail
    {
        public List<AttachmentElement> AttachFiles { get; set; }
        public MailCredentials Credentials { get; set; }
        public string From { get; set; }
        public string FromName { get; set; }
        public string Host { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public bool EnableSSL { get; set; }
        public string To { get; set; }
        private System.Text.Encoding subjectEncoding = System.Text.Encoding.UTF8;
        private System.Text.Encoding messageEncoding = System.Text.Encoding.UTF8;

        public SenderMail()
        {
            this.Host = string.Empty;
            this.Subject = string.Empty;
            this.Message = string.Empty;
            this.From = string.Empty;
            this.FromName = string.Empty;
            this.To = string.Empty;
            this.AttachFiles = new List<AttachmentElement>();
        }

        public SenderMail(MailCredentials credentials)
        {
            this.Host = string.Empty;
            this.Subject = string.Empty;
            this.Message = string.Empty;
            this.From = string.Empty;
            this.FromName = string.Empty;
            this.EnableSSL = false;
            this.To = string.Empty;
            this.AttachFiles = new List<AttachmentElement>();
            this.Credentials = credentials;
        }

        public void AddAttachFile(AttachmentElement element)
        {
            this.AttachFiles.Add(element);
        }

        public bool SendMail()
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                MailMessage mail = new MailMessage();
                if (!string.IsNullOrEmpty(this.From))
                {
                    mail.From = new MailAddress(this.From, this.FromName);
                }

                string[] listTo = this.To.Split(';');
                if (listTo.Length > 0)
                {
                    foreach (var to in listTo)
                    {
                        if (to == "")
                            continue;

                        mail.To.Add(to);
                    }
                }
                else
                {
                    mail.To.Add(this.To);
                }

                mail.Subject = this.Subject;
                mail.BodyEncoding = messageEncoding;
                mail.SubjectEncoding = subjectEncoding;
                smtp.EnableSsl = EnableSSL;
                mail.Body = this.Message;
                if (this.Credentials.loginSmtp != null)
                {

                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(this.Credentials.loginSmtp, this.Credentials.passwordSmtp);
                }
                else
                {
                    smtp.UseDefaultCredentials = true;
                }

                mail.IsBodyHtml = true;
                if (smtp.Host == null)
                {
                    smtp.Host = this.Host;
                }
                if (this.AttachFiles.Count > 0)
                {
                    foreach (AttachmentElement attach in this.AttachFiles)
                    {
                        var attachment = new Attachment(attach.StreamElement, attach.FileName, attach.ContentType);
                        attach.StreamElement.Seek(0, SeekOrigin.Begin);
                        mail.Attachments.Add(attachment);
                    }
                }
                //smtp.SendAsync(mail, null);
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }



        public System.Text.Encoding SubjectEncoding
        {
            set
            {
                this.subjectEncoding = value;
            }
        }

        public System.Text.Encoding MessageEncoding
        {
            set
            {
                this.messageEncoding = value;
            }
        }

    }

    public class AttachmentElement
    {
        public Stream StreamElement { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }

    public struct MailCredentials
    {
        public string loginSmtp;
        public string passwordSmtp;
    }
}
