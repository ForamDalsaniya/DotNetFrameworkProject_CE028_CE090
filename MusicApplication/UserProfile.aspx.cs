using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicApplication
{
    public partial class UserProfile : System.Web.UI.Page
    {
        static bool isError = false;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //if(Session["UserName"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            if (!IsPostBack)
            {
                if (isError)
                {
                    error.Text = "UserName already taken";
                    error.ForeColor = System.Drawing.Color.Red;
                    isError = false;
                }
                if (Session["UserName"] != null)
                {

                    suser.InnerHtml = $"{Session["UserName"]}";
                    using (SqlConnection connection = new SqlConnection())
                    {
                        connection.ConnectionString = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ToString();
                        connection.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connection;
                        
                        string query = "Select img from UserData where UserName='" + Session["UserName"] + "'";
                        cmd.CommandText = query;

                        //SqlCommand oCmd = new SqlCommand(oString, conn);
                        //using (SqlDataReader oReader = oCmd.ExecuteReader())
                        //{
                        //byte[] bytes = (byte[])oReader["img"];
                        byte[] bytes = null;
                        try
                        {
                            bytes = (Byte[])cmd.ExecuteScalar();
                            string strBase64 = Convert.ToBase64String(bytes);
                            Image1.ImageUrl = "data:Image/jpg;base64," + strBase64;
                        }
                        catch(Exception ex)
                        {

                        }
                        
                        

                        string temp = "Select FirstName,LastName from UserData WHERE UserName='" + Session["UserName"] + "'";
                        cmd.CommandText = temp;
                        string fname = "", lname = "";
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                fname = dr["FirstName"].ToString();
                                lname = dr["LastName"].ToString();
                            }
                        }
                        cFirstName.Text = fname;
                        cLastName.Text = lname;
                        cUserName.Text = Session["UserName"].ToString();
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void userPicture_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeImage.aspx");
        }

        protected void changeProfile_Click(object sender, EventArgs e)
        {
            error.Text = "";
            //if (Session["UserName"] != null)
            //{

            //    suser.InnerHtml = $"{Session["UserName"]}";
            //    using (SqlConnection connection = new SqlConnection())
            //    {
            //        connection.ConnectionString = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ToString();
            //        connection.Open();
            //        SqlCommand cmd = new SqlCommand();
            //        cmd.Connection = connection;

            //        string query = "Select img from UserData where UserName='" + Session["UserName"] + "'";
            //        cmd.CommandText = query;

            //        //SqlCommand oCmd = new SqlCommand(oString, conn);
            //        //using (SqlDataReader oReader = oCmd.ExecuteReader())
            //        //{
            //        //byte[] bytes = (byte[])oReader["img"];
            //        byte[] bytes = (Byte[])cmd.ExecuteScalar();
            //        string strBase64 = Convert.ToBase64String(bytes);
            //        Image1.ImageUrl = "data:Image/jpg;base64," + strBase64;
            //        //}

            //        string temp = "Select FirstName,LastName from UserData WHERE UserName='" + Session["UserName"] + "'";
            //        cmd.CommandText = temp;
            //        string fname = "", lname = "";
            //        SqlDataReader dr = cmd.ExecuteReader();
            //        if (dr.HasRows)
            //        {
            //            while (dr.Read())
            //            {
            //                fname = dr["FirstName"].ToString();
            //                lname = dr["LastName"].ToString();
            //            }
            //        }
            //        cFirstName.Text = fname;
            //        cLastName.Text = lname;
            //        cUserName.Text = Session["UserName"].ToString();
            //    }
            //}
            //else
            //{
            //    Response.Redirect("Login.aspx");
            //}
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ToString();
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                if(Session["UserName"].ToString() == cUserName.Text)
                {
                    string query = "Update UserData SET FirstName = @fname, LastName = @lname WHERE UserName='" + Session["UserName"] + "'";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@fname", cFirstName.Text);
                    cmd.Parameters.AddWithValue("@lname", cLastName.Text);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string checkUser = "Select count(*) from UserData Where UserName= '" + cUserName.Text + "'";
                    SqlCommand com = new SqlCommand(checkUser, connection);
                    int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                    if(temp == 0)
                    {
                        string query = "Update UserData SET UserName = @uname, FirstName = @fname, LastName = @lname WHERE UserName='" + Session["UserName"] + "'";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@fname", cFirstName.Text);
                        cmd.Parameters.AddWithValue("@lname", cLastName.Text);
                        cmd.Parameters.AddWithValue("@uname", cUserName.Text);
                        Session["UserName"] = cUserName.Text;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        isError = true;
                        //error.Text = "UserName already taken";
                        //error.ForeColor = System.Drawing.Color.Red;
                    }

                }
                Response.Redirect("UserProfile.aspx");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeScreen.aspx");
        }
    }
}