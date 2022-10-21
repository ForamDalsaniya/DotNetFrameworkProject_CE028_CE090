using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MusicApplication
{
    public partial class AdminUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {
            if(imageUpload.HasFile && songUpload.HasFile)
            {
                string imageExtention = System.IO.Path.GetExtension(imageUpload.FileName);
                string songExtention = System.IO.Path.GetExtension(songUpload.FileName);

                if(songExtention.ToLower() != ".mp3")
                {
                    lblMessage.Text = "Only files with .mp3 extention is allowed in song";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (imageExtention.ToLower() != ".jpg")
                    {
                        //if (imageExtention.ToLower() != ".jpeg")
                        //{
                        //    lblMessage.Text = "Only images with .jpg or .jpeg extention is allowed";
                        //    lblMessage.ForeColor = System.Drawing.Color.Red;
                        //}
                        //else
                        //{
                            lblMessage.Text = "Only images with .jpg extention is allowed";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        //}
                    }
                    else
                    {
                        imageUpload.SaveAs(Server.MapPath("~/Static/Images/" + imageUpload.FileName));
                        songUpload.SaveAs(Server.MapPath("~/Static/Songs/" + songUpload.FileName));

                        string imagePath = Server.MapPath("~/Static/Images/" + imageUpload.FileName);

                        byte[] imageByte = System.IO.File.ReadAllBytes(imagePath);

                        using (SqlConnection connection = new SqlConnection())
                        {
                            connection.ConnectionString = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ToString();
                            connection.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = connection;

                            string commandText = "Insert into Songs values(@songName,@catagory,@img)";
                            cmd.CommandText = commandText;
                            cmd.Parameters.AddWithValue("@songName", songName.Text);
                            cmd.Parameters.AddWithValue("@catagory", catageory.SelectedValue.ToString());
                            cmd.Parameters.Add("@img", SqlDbType.VarBinary);

                            cmd.Parameters["@img"].Value = imageByte;
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            connection.Close();
                        }
                        Response.Redirect("AdminHome.aspx");
                    }
                }

            }
        }

        protected void adminHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }
    }
}