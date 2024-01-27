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
    public partial class Upd_prod : System.Web.UI.Page
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
                item.quantity =(int) reader["quantity"];                
                list.Add(item);
            }
            GridView1.DataSource= list;
            GridView1.DataBind();
            Session["itm"] = list;
            Button1.Text = "update";
            Button2.Text = "delete";
        }
        protected void item_data(object sender, GridViewCommandEventArgs e) 
        {
            List<Item> items = Session["itm"]as List<Item>;
            string id = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            Item item = items.Where(itm => itm.Id == Convert.ToInt16(id)).FirstOrDefault();
            Label1.Text = item.Id.ToString();
            TextBox1.Text = item.Name;
            TextBox2.Text= item.price.ToString();
            TextBox3.Text= item.quantity.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Label1.Text);
            string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand comm = new SqlCommand(constr, conn);
            comm.Connection = conn;
            comm.CommandText = "update [dbo].[Table] set product_name=@product_name,price=@price,quantity=@quantity,image=@image where id="+id;
            comm.Parameters.AddWithValue("@product_name", TextBox1.Text);
            comm.Parameters.AddWithValue("@price", float.Parse(TextBox2.Text));
            comm.Parameters.AddWithValue("@quantity", int.Parse(TextBox3.Text));
            comm.Parameters.AddWithValue("@image", FileUpload1.PostedFile.InputStream);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Label1.Text);
            string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand comm = new SqlCommand(constr, conn);
            comm.Connection = conn;
            comm.CommandText = "delete from [dbo].[Table] where";
        }
    }
}