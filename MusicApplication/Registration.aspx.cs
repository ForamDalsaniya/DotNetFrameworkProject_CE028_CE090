using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace MusicApplication
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signUp_Click(object sender, EventArgs e)
        {
            try
            {
                string pass = password.Text;
                if (pass.Length < 6 && pass.Length > 13)
                {
                    error.InnerHtml = "<span style='color:red'>password must be atleast 6 character long</span>";
                }
                else
                {
                    Guid newGUID = Guid.NewGuid();
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                    conn.Open();
                    string checkUser = "Select count(*) from UserData Where UserName= '" + userName.Text + "'";
                    SqlCommand com = new SqlCommand(checkUser, conn);
                    int temp = Convert.ToInt32(com.ExecuteScalar().ToString());

                    if (temp == 1)
                    {
                        error.InnerHtml = "<span style='color:red'>Username already taken</span>";
                    }
                    else if (temp == 0)
                    {
                        string insertQuery = "Insert into UserData (Id,FirstName,LastName,UserName, Email, Password) values (@ID, @firstname, @lastname, @uname, @emailID, @Password)";

                        SqlCommand cmd = new SqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@ID", newGUID.ToString());
                        cmd.Parameters.AddWithValue("@firstname", firstName.Text);
                        cmd.Parameters.AddWithValue("@lastname", lastName.Text);
                        cmd.Parameters.AddWithValue("@uname", userName.Text);
                        cmd.Parameters.AddWithValue("@emailID", email.Text);
                        cmd.Parameters.AddWithValue("@Password", password.Text);
                        cmd.ExecuteNonQuery();
                        /*Response.Write("<span style='color:red'>Username already taken</span>");*/

                        /* Response.Write("Registration Successful");*/
                        Response.Redirect("Login.aspx");

                        conn.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
        }
    }
}