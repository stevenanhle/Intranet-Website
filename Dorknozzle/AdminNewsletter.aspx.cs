using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace Dorknozzle
{
    public partial class AdminNewsletter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendNewsLetterButton_Click(object sender, EventArgs e)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            try
            {
                MailAddress fromAddress = new MailAddress("dorknozzle@example.com", "Your Friends at Dorknozzle");
                MailAddress toAddress = new MailAddress(toTextBox.Text);
                message.From = fromAddress;
                message.To.Add(toAddress);
                message.Subject = subjectTextBox.Text;
                message.IsBodyHtml = true;
                message.Body = "<html><head><title>" + HttpUtility.HtmlEncode(subjectTextBox.Text) + "</title></head><body>" + "<img src=\"http://www.cristiandarie.ro/Dorknozzle" + "/Images/newsletter_header.gif\"/>" + "<p>" + HttpUtility.HtmlEncode(introTextBox.Text) + "</p>"
                    + "<p>Employee of the month: " + HttpUtility.HtmlEncode(employeeTextBox.Text) + "</p>" + "<p> This month featured event: " + HttpUtility.HtmlEncode(eventTextBox.Text) + "</p>" + "</body></html>";
                smtpClient.Host = "localhost";
                smtpClient.Credentials = new System.Net.NetworkCredential("username", "password");
                smtpClient.Send(message);
                resultLabel.Text = "Email sent!<br/>";
            }
            catch (Exception ex)
            {
                resultLabel.Text = "Couldn't send message";
            }
        }
    }
}