using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicApplication
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void adminLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeScreen.aspx");
        }

        protected void adminUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpload.aspx");
        }

        protected void userList_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserList.aspx");
        }
    }
}