using System;
using System.Collections.Generic;
using ASPSnippets.SmsAPI;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using BusinessLogic;

public partial class PassRecoveryOption : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Request.QueryString["type"].Equals("Email")) { Label1.Text = "Enter Email Id"; }
        else { Label1.Text = "Enter Phone Number"; }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["type"].Equals("Email"))
        {
            SendEmail(TextBox1.Text, "Bullion@passwordRecovery", "");
        }
        else
        {
            SendMsg(Convert.ToInt64(TextBox1.Text));
        }
    }

    protected void SendEmail(string toAddress, string subject, string body)
    {
        //TextBox1.Text = "started";
        EmployeeLogic el = new EmployeeLogic();
        Employee e1 = el.SelectEmail(toAddress);
        string result = "Message Sent Successfully..!!";
        string senderID = "hiteshsteel98@gmail.com";// use sender’s email id here..
        const string senderPassword = "hitesh1234"; // sender password here…

        string str1 = Guid.NewGuid().ToString();
        e1.EmailCode = str1;
        el.Update(e1);

        body = "Dear " + e1.Name + ", <br/><br/>Your request for password recovery has been successful!<br/><br/>Click on below link to reset your password..<br/>http://192.168.43.111/OAPP/ResetPassword.aspx?uic=" + str1 + "<br/><br/>Regards,<br/><br/>Bullion Flexipack Pvt Ltd";
        try
        {
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com", // smtp server address here…
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential(senderID, senderPassword)
            };
            MailMessage message = new MailMessage(senderID, toAddress, subject, body);
            message.IsBodyHtml = true;
            smtp.Send(message);

        }
        catch (Exception ex)
        {
            TextBox1.Text = ex.Message + "##" + ex.Data;
            result = "Error sending email.!!!";

        }
        finally
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + result + ")", true);
        }
        
    }
    
    protected void SendMsg(Int64 toNo)
    {
        String result = "SMS sent successfully!!";
        EmployeeLogic el = new EmployeeLogic();
        Employee e1 = el.SelectPhone(toNo);
        
        try
        {
            SMS.APIType = SMSGateway.Site2SMS;

            SMS.MashapeKey = "v4srqxZ6drmshFbuHpmBTRAEM12Yp1zHxB4jsnXVXxzm7DxXCJ";

            SMS.Username = "7567569123";
            SMS.Password = "baps1234";

            Random r = new Random();
            int randomNumber = r.Next(1001, 9999);
            e1.SMSCode = randomNumber.ToString();
            el.Update(e1);
            
            SMS.SendSms(toNo.ToString(), "Dear Customer ! Please find your recovery code here : " + randomNumber.ToString());
            Response.Redirect("SCode.aspx");
            
        }
        catch (Exception ex)
        {
            result = "SMS sending failed!!";
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + result + ")", true);


    }
 
}