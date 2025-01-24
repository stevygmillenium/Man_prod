using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Man_prod
{
    public partial class Stock_con : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> list = new List<Item>();
            string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand comm = new SqlCommand(constr, conn);
            comm.Connection = conn;
            comm.CommandText = "select * from [dbo].[Table]";
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Item item = new Item();
                item.Id = (int)reader["id"];
                item.Name = (string)reader["product_name"];
                item.price = (float)Convert.ToDouble(reader["price"]);
                item.quantity = (int)reader["quantity"];
                list.Add(item);
            }
            Session["items"] = list;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Item> list = Session["items"] as List<Item>;            
            ListBox1.Items.Clear();
            foreach(Item item in list) 
            {
                ListBox1.Items.Add(new ListItem { Text = item.Name });
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Item> list = Session["items"] as List<Item>;            
            List<Item> items = list.Where(itm => itm.quantity > int.Parse(TextBox1.Text)).ToList();
            ListBox1.Items.Clear();
            foreach (Item item in items) 
            {
                ListBox1.Items.Add(new ListItem { Text = item.Name });
            }
        }
    }
}