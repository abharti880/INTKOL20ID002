using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TruYum.Models
{
    public class CartOperation
    {
        SqlConnection con;
        public CartOperation()
        {
            con= new SqlConnection(@"Data Source=DESKTOP-R18O42L\SQLEXPRESS;Initial Catalog=TruYum;Integrated Security=true");
        }
        public string AddToCart(Cart cart)
        {
            con.Open();
            string cmd = "INSERT INTO cart VALUES("+cart.Id+","+cart.ItemId+")";
            SqlCommand insert = new SqlCommand(cmd,con);
            insert.ExecuteNonQuery();
            con.Close();
            return "Cart Created";
        }
        public List<MenuItem> GetCartItems(User user)
        {
            con.Open();
            string cmd = "SELECT m.Id,m.Name,m.Price,m.FreeDelivery,m.DateOfLaunch,m.Active FROM users u,cart c,menuitem m WHERE u.Id="+user.Id+" AND u.CartId=c.Id AND c.ItemId=m.Id";
            SqlCommand select = new SqlCommand(cmd, con);
            SqlDataAdapter da = new SqlDataAdapter(select);
            DataTable dt = new DataTable();
            da.Fill(dt);
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
        public string DeleteFromCart(int ItemId)
        {
            con.Open();
            string cmd = "DELETE FROM Cart WHERE Id=1 AND ItemId="+ItemId+";";
            SqlCommand delete = new SqlCommand(cmd, con);
            delete.ExecuteNonQuery();
            con.Close();
            return "Deleted from Cart = "+ItemId;
        }
    }
}
