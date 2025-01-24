using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Man_prod
{
    public partial class View_prod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Text = "add to cart";
            Button2.Text = "check out";
            Button3.Text = "place order";
            string[] card_type = { "card_one", "card_two" };
            for(int i = 0; i < card_type.Length; i++) 
            {
                ListItem listItem = new ListItem();
                listItem.Text = card_type[i];
                DropDownList1.Items.Add(listItem);
            }            
            /*DropDownList1.DataSource = card_type;
            DropDownList1.DataBind();*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Item> list = new List<Item>();
            foreach (int i in ListBox1.GetSelectedIndices())
            {
                Item item = new Item();
                int id_num = int.Parse(ListBox1.Items[i].Value);
                string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand comm = new SqlCommand(constr, conn);
                comm.Connection = conn;
                comm.CommandText = "select * from [dbo].[table] where id=" + id_num;
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                item.Id = (int)reader["id"];
                item.Name = (string)reader["product_name"];
                item.price = (float)Convert.ToDouble(reader["price"]);
                item.img = (byte[])reader["image"];
                string img_s = "data:image/jpg;base64," + Convert.ToBase64String(item.img, 0, item.img.Length);                
                item.image = img_s;
                list.Add(item);
            }            
            GridView1.DataSource = list;
            GridView1.DataBind();
            /*Item[] cart = list.ToArray();
            for (int i = 0; i < cart.Length; i++)
            {
                cart[i].img = null;
                cart[i].image = null;
            }  */          
            Session["cart"] = list;            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<string> quant = new List<string>();
            float g_tot = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                float price = float.Parse(row.Cells[2].Text);
                TextBox amt = row.FindControl("amt") as TextBox;
                int amount = int.Parse(amt.Text);
                quant.Add(amount.ToString());
                float sub_t = price * amount;
                Label st = row.FindControl("sub_t") as Label;
                st.Text = Convert.ToString(sub_t);
                g_tot += sub_t;
            }            
            Label1.Text = g_tot.ToString();
            Label2.Text = Convert.ToString(1.15 * float.Parse(Label1.Text));
            List<Item> items= Session["cart"] as List<Item>;
            Item[] cart = items.ToArray();            
            for (int i = 0; i < cart.Length; i++) 
            {                
                cart[i].quantity =Convert.ToInt16(quant[i]);
            }
            /*var j_cart = new JavaScriptSerializer().Serialize(cart);            
            Session["j_cart"] = j_cart;*/            
            Session["g_tot"] = Label2.Text;
        }

        protected void del_row(object sender,GridViewDeleteEventArgs e) 
        {            
            int i =e.RowIndex;
            List<Item> items = Session["cart"] as List<Item>;
            items.RemoveAt(i);
            GridView1.DataSource = items;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            List<Item> items = Session["cart"] as List<Item>;
            Item[] cart = items.ToArray();
            for (int i = 0; i < cart.Length; i++)
            {
                cart[i].img = null;
                cart[i].image = null;
            }
            order order = new order();
            order.Name = TextBox2.Text;
            order.email = TextBox3.Text;
            order.address= TextBox4.Text;
            order.card_type = DropDownList1.Text;
            var j_cart = new JavaScriptSerializer().Serialize(cart);
            //order.data = Session["j_cart"] as string;            
            order.data=j_cart;
            order.dateTime = DateTime.Now;
            order.amount =(float)Convert.ToDouble(Session["g_tot"]);
            WebService webService = new WebService();
            webService.write_db(order);
        }
    }
}