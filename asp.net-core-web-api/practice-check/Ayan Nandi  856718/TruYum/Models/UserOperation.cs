using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TruYum.Models
{
    public class UserOperation
    {
        SqlConnection con;
        public UserOperation()
        {
            con = new SqlConnection(@"Data Source=LAPTOP-MRUNEKJ1\SQLEXPRESS;Initial Catalog=PCheck;Integrated Security=true");
        }
        public bool Login(int id,string password)
        {
            con.Open();
            SqlCommand select = new SqlCommand("SELECT * FROM Users WHERE Id=" + id + " AND Password='" + password + "'",con);
            SqlDataAdapter da = new SqlDataAdapter(select);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        public string CreateUser(User user)
        {
            con.Open();
            int id = user.Id;
            string uname = user.Username;
            string pass = user.Password;
            int cart = user.CartId;
            string cmd = "INSERT INTO Users VALUES("+id+",'"+uname+"','"+pass+"',"+cart+")";
            SqlCommand insert = new SqlCommand(cmd,con);
            insert.ExecuteNonQuery();
            con.Close();
            return "User Created";
        }
    }
}
