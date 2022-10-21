using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;

namespace MusicApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RecoverPassword(object sender, EventArgs e)
        {
            using (MailMessage mail = new MailMessage())
            {
                string email = "";
                string pass="";
                using (SqlConnection connection = new SqlConnection())
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                    conn.Open();
                    string temp = "Select Email from UserData where UserName = '" + UserLogin.Text + "'";
                    SqlCommand com = new SqlCommand(temp, conn);
                    email = com.ExecuteScalar().ToString();

                    temp = "Select Password from UserData where UserName = '" + UserLogin.Text + "'";
                    SqlCommand cm = new SqlCommand(temp, conn);
                    pass = cm.ExecuteScalar().ToString();
                 
                }
                try
                {
                    if (email != null) {
                        mail.From = new MailAddress("forampdalsaniya@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = "Password Change";
                        string userMessage = "";
                        userMessage = userMessage + "<br/><b>Login Id:</b> " + email;
                        userMessage = userMessage + "<br/><b>Passsword: </b>" + pass;

                        string Body = "Dear " + UserLogin.Text + ", <br/><br/>Login detail for your account is a follows:<br/></br> " + userMessage + "<br/><br/>Thanks";
                        mail.Body = Body;
                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com"; //SMTP Server Address of gmail
                        smtp.Port = 587;
                        smtp.Credentials = new System.Net.NetworkCredential("forampdalsaniya@gmail.com", "vpjutndphmluklbg");
                        // Smtp Email ID and Password For authentication
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        msg.InnerHtml = "<span>Please check your email for account login detail.</span>";

                    }
                    else
                    {
                        msg.InnerHtml = "<span style='color:red'>User Name is not correct</span>";
                    }

                }
                catch(Exception ex)
                {
                    Response.Write("Error: " + ex.ToString());
                }
            }
        }
        protected void Button_login_Click(object sender, EventArgs e)
        {
           
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();

            string checkUser = "Select count(*) from UserData Where UserName= '" + UserLogin.Text + "'";
            SqlCommand cmd = new SqlCommand(checkUser, conn);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            conn.Close();
            if (temp == 1)
            {
                conn.Open();
                string checkPassowrdQuery = "select Password from UserData where UserName='" + UserLogin.Text + "'";
                SqlCommand com = new SqlCommand(checkPassowrdQuery, conn);
                string password = com.ExecuteScalar().ToString().Replace(" ", "");
                if (password == PasswordLogin.Text)
                {
                    Session["UserName"] = UserLogin.Text;
                    /*Response.Write("Password is correct");*/
                    if (UserLogin.Text == "admin" && password == "admin123")
                    {
                        Response.Redirect("AdminHome.aspx");
                    }
                    Response.Redirect("HomeScreen.aspx");
                }
                else
                {
                    /*Response.Write("Password is not correct");*/
                    msg.InnerHtml = "<span style='color:red'>Password is not correct</span>";
                }


            }
            else
            {
                /* Response.Write("Username is not correct");*/
                msg.InnerHtml = "<span style='color:red'>Username is not correct</span>";
            }

            conn.Close();
        }
    }
}