using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicApplication
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using(MailMessage mail = new MailMessage())
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ToString();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;

                    string query = "Select Email from UserData where Us";
                }
                    try
                {
                    mail.From = new MailAddress("forampdalsaniya@gmail.com");
                    //mail.To.Add()
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}