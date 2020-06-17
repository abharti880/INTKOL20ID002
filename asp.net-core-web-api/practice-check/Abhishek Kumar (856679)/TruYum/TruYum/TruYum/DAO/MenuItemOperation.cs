using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TruYum.Models;

namespace TruYum.DAO
{
    public class MenuItemOperation
    {
        SqlConnection con;
        public MenuItemOperation()
        {
            con = new SqlConnection(@"Data Source=SUJOYS-NOTEBOOK;Initial Catalog=PracticeDatabase;Integrated Security=True");
        }        

        public void addItem(MenuItem menu)
        {
            con.Open();

            var category = "";

            SqlCommand cmd1 = new SqlCommand("Select * from Category where Id="+menu.categoryId+"",con);
            SqlDataReader read = cmd1.ExecuteReader();
            while(read.Read())
            {
                category = read["Name"].ToString();
            }            
            
            read.Close();

            SqlCommand cmd = new SqlCommand("INSERT INTO MenuItem(Id,Name,freeDelivery,Price,Active,DateOfLaunch,categoryId) VALUES" +
                "("+menu.Id+",'"+menu.Name+"',"+Convert.ToInt32(menu.freeDelivery)+","+menu.Price+","+Convert.ToInt32(menu.Active)+"," +
                "'"+menu.DateOfLaunch+"',"+menu.categoryId+")",con);
            
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
