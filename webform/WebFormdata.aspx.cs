using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webform
{
    public partial class WebFormdata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ConStr = "";
            //getting the path of the file     
            string path = Server.MapPath("EmpData.xlsx");
            //connection string for that file which extantion is .xlsx    
            ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;ReadOnly=False;HDR=Yes;\"";
            //making query    
            string query = "INSERT INTO [Sheet1$] ([Name], [Email], [MobileNo]) VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')";
            //Providing connection    
            OleDbConnection conn = new OleDbConnection(ConStr);
            //checking that connection state is closed or not if closed the     
            //open the connection    
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            //create command object    
            OleDbCommand cmd = new OleDbCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Response.Write("<script>alert('Sucessfully Data Inserted Into Excel')</script>");
            }
            else
            {
                Response.Write("<script>alert('Sorry!\n Insertion Failed')</script>");
            }
            conn.Close();
        }
    }
    }
