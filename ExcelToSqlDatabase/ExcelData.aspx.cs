using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace ExcelToSqlDatabase
{
    public partial class ExcelData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            int rollno;
            String sname;
            String fname;
            String mname;
            string path = Path.GetFileName(FileUpload1.FileName);
            //path = path.Replace("","");
            FileUpload1.SaveAs(Server.MapPath("~/ExcelFile/") + path);
            String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
            OleDbConnection mycon=new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelPath +"; Extended Properties=Excel 8.0; Persist Security Info=false");
            mycon.Open();
            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    rollno = Convert.ToInt32(dr[0].ToString());
                    sname = dr[1].ToString();
                    fname = dr[2].ToString();
                    mname = dr[3].ToString();
                    savedata(rollno, sname, fname, mname);
                }
                else
                {
                    break;
                }
             
            }
            Label1.Text = "Data Has Been Saved Successfully";
            mycon.Close();
        }
        private void savedata(int rollno1,String sname1,String fname1,String mname1)
        {
            String query="insert into StudentsRecord(rollno,sname,fathername,mothername) values("+rollno1+",'"+sname1+"','"+fname1+"','"+mname1+"')";
            String mycon = "Data Source=DESKTOP-LDP0GC0\\SQLEXPRESS;Initial Catalog=StudentDetails;Integrated Security=true";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }
        //private void Updatedata(int rollno1, String sname1, String fname1, String mname1)
        //{
        //    String query = "update StudentRecord set sname='" + sname1 + "',+fathername='" + fname1 + "',mothername='" + mname1 + "' where rollno=" + rollno1;
        //    String mycon = "Data Source=DESKTOP-LDP0GC0\\SQLEXPRESS;Initial Catalog=StudentDetails;Integrated Security=true";
        //    SqlConnection con = new SqlConnection(mycon);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = query;
        //    cmd.Connection = con;
        //    cmd.ExecuteNonQuery();
        //}

      
    }
}