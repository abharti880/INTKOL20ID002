using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TruYum.Models
{
    public class MenuItemOperation
    {
        SqlConnection con;
        public MenuItemOperation()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-R18O42L\SQLEXPRESS;Initial Catalog=TruYum;Integrated Security=true");
        }
        public void InsertMenuItem(MenuItem item)
        {
            con.Open();
            int Id = item.Id;
            string Name = item.Name;
            int fd = Convert.ToInt32(item.FreeDelivery);
            double Price = item.Price;
            DateTime date = item.DateofLaunch;
            int active = Convert.ToInt32(item.Active);
            string cmd = "INSERT INTO menuitem VALUES("+Id+",'"+Name+"',"+fd+","+Price+",'"+date+"',"+active+")";
            SqlCommand insert = new SqlCommand(cmd,con);
            insert.ExecuteNonQuery();
            con.Close();
        }
        public List<MenuItem> SelectMenuItems()
        {
            con.Open();
            SqlCommand select = new SqlCommand("SELECT * FROM menuitem", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(select);
            da.Fill(dt);
            if (dt.Rows.Count>0)
            {
                List<MenuItem> items = new List<MenuItem>();
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    MenuItem mi = new MenuItem();
                    mi.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    mi.Name = dt.Rows[i]["Name"].ToString();
                    mi.FreeDelivery = Convert.ToBoolean(dt.Rows[i]["FreeDelivery"]);
                    mi.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                    mi.DateofLaunch = Convert.ToDateTime(dt.Rows[i]["DateOfLaunch"]);
                    mi.Active = Convert.ToBoolean(dt.Rows[i]["Active"]);
                    items.Add(mi);
                }
                return items;
            }
            return null;
        }
        public void UpdateMenuItem(int id,MenuItem item)
        {
            con.Open();
            string Name = item.Name;
            int fd = Convert.ToInt32(item.FreeDelivery);
            double Price = item.Price;
            DateTime date = item.DateofLaunch;
            int active = Convert.ToInt32(item.Active);
            string cmd = "UPDATE menuitem SET Name='"+Name+"',FreeDelivery="+fd+",Price="+Price+",DateOfLaunch='"+date+"',Active="+active+" WHERE Id="+id;
            SqlCommand update = new SqlCommand(cmd,con);
            update.ExecuteNonQuery();
            con.Close();
        }
    }
}
