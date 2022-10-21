using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MusicApplication
{
    public partial class ChangeImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);
                if(fileExtention.ToLower() != ".jpg")
                {
                    lblMsg.Text = "Image does not have .jpg extention";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    int imagefilelenth = FileUpload1.PostedFile.ContentLength;
                    byte[] imgarray = new byte[imagefilelenth];
                    HttpPostedFile image = FileUpload1.PostedFile;
                    image.InputStream.Read(imgarray, 0, imagefilelenth);
                    using (SqlConnection connection = new SqlConnection()) {
                        connection.ConnectionString = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ToString();
                        connection.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connection;

                        string query = "Update UserData SET img = @Image WHERE UserName='"+Session["UserName"] +"'";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@Image", SqlDbType.Image).Value = imgarray;
                        cmd.ExecuteNonQuery();
                        //Label1.Visible = true;
                        lblMsg.Text = "Image Is Uploaded successfully";
                        //connection.Close();
                        ///
                        //string query = "Update Songs SET img = @Image WHERE Id = 1";
                        //cmd.CommandText = query;
                        //cmd.Parameters.AddWithValue("@Image", SqlDbType.Image).Value = imgarray;
                        //cmd.ExecuteNonQuery();


                    }
                }
            }
            else
            {
                lblMsg.Text = "Please select Image";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeScreen.aspx");
        }
    }
}