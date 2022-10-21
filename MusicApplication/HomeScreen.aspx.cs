using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WMPLib;
using System.Data.SqlClient;
using System.Configuration;

namespace MusicApplication
{
    public partial class HomeScreen : System.Web.UI.Page
    {
        readonly private static WindowsMediaPlayer player = new WindowsMediaPlayer();
        static Dictionary<int, bool> rowIndex = new Dictionary<int, bool>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserName"] != null)
            {
                sessionUser.InnerHtml = "Welcome " + Session["UserName"];
                ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"];
                SqlConnection conn = new SqlConnection(connectionString.ConnectionString);
                SqlCommand query = new SqlCommand("SELECT * FROM Songs", conn);
                conn.Open();
                GridView1.DataSource = query.ExecuteReader();
                GridView1.DataBind();
                conn.Close();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Play_Click")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string songName = GridView1.Rows[index].Cells[1].Text;
                try
                {
                    rowIndex.Add(index, true);
                }
                catch (Exception ex)
                {
                    //Response.Write("error: " + ex.ToString());
                }
                //for (int i = 0; i < rowIndex.Count; i++)
                //{
                //Response.Write(songName);
                //Response.Write(index);
                //Response.Write(rowIndex[index]);
                if (rowIndex[index] == true)
                {
                    //Response.Write("Hello");
                    string extention = ".mp3";
                    songName = songName + extention;
                    songName = songName.Replace(" ", "");
                    player.URL = "C:\\Users\\Dell\\source\\repos\\MusicApplication\\MusicApplication\\Static\\Songs\\" + songName;
                    //Response.Write(player.playState);
                    //current = songName;

                    //rowIndex[i] = new KeyValuePair<int, bool>(index, false);
                    rowIndex[index] = false;
                }
                else
                {
                    //Response.Write(player.playState);
                    if (player.playState == WMPPlayState.wmppsPaused && (player.currentMedia.sourceURL.Contains(songName)))
                    {
                        player.controls.play();
                    }
                    else
                    {
                        if (rowIndex[index] == true)
                        {
                            string extention = ".mp3";
                            songName = songName + extention;
                            songName = songName.Replace(" ", "");
                            player.URL = "C:\\Users\\Dell\\source\\repos\\MusicApplication\\MusicApplication\\Static\\Songs\\" + songName;
                            //Response.Write(player.playState);
                            //current = songName;

                            //rowIndex[i] = new KeyValuePair<int, bool>(index, false);
                            rowIndex[index] = false;
                        }
                        else
                        {

                            //player.currentMedia.sourceURL = "C:\\Users\\Dell\\source\\repos\\Music_App\\Music_App\\Static\\Songs\\" + songName.Replace(" ", "") + ".mp3";
                            player.controls.play();
                        }
                    }
                    //player.controls.play();
                    //Response.Write(player.playState);
                    //}
                }
                //Response.Write(songName);
            }
            else if (e.CommandName == "Pause_Click")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string songName = GridView1.Rows[index].Cells[1].Text.Replace(" ", "");

                //string current = player.currentMedia.name.Replace(" ", "");

                //Response.Write(player.currentMedia.name);
                //if (songName.Replace(" ","") == current)
                //{
                //string songName = GridView1.Rows[index].Cells[1].Text;
                if ((player.currentMedia.sourceURL.Contains(songName)))
                {
                    player.controls.pause();
                    //Response.Write(player.playState);
                }
                //}
            }
            else if (e.CommandName == "Stop_Click")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string songName = GridView1.Rows[index].Cells[1].Text.Replace(" ", "");
                if (player.currentMedia.sourceURL.Contains(songName))
                {

                    //if (songName.Replace(" ","") == current)
                    //{
                    player.controls.stop();
                    //Response.Write(player.playState);
                    rowIndex[index] = true;
                    //}
                }
            }

        }
        protected void userProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }

        protected void logOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }
    }
}