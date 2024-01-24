using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

namespace Man_prod
{
    public partial class View_order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<order> orders = new List<order>();
            string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand comm = new SqlCommand(constr, conn);
            comm.Connection = conn;
            comm.CommandText = "select * from [dbo].[order]";
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read()) 
            {
                order order=new order();
                order.Id =(int) reader["id"];
                order.Name =(string) reader["cust_name"];
                order.email =(string) reader["cust_em"];
                order.address =(string) reader["cust_addr"];
                order.card_type =(string) reader["card_type"];
                order.data =(string) reader["j_data"];
                order.dateTime =(DateTime) reader["o_date"];
                order.amount =(float)(double) reader["amount"];
                orders.Add(order);
            }
            GridView1.DataSource = orders;
            GridView1.DataBind();
            Session["ord"] = orders;
        }
        protected void show_order(object sender,GridViewCommandEventArgs e) 
        {
            List<order> orders = Session["ord"] as List<order>;
            string id = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            order order=orders.Where(ord=>ord.Id==Convert.ToInt16(id)).FirstOrDefault();            
            var j_cart = new JavaScriptSerializer().Deserialize<Item[]>(order.data);
            List<Item> items = new List<Item>();
            for(int i = 0; i < j_cart.Length; i++) 
            {
                Item item = new Item();
                item.Id = j_cart[i].Id;
                item.Name = j_cart[i].Name;
                item.price = j_cart[i].price;
                item.quantity = j_cart[i].quantity;
                items.Add(item);
            }
            Table1.Rows[0].Cells[0].Text = order.Id.ToString();
            Table1.Rows[0].Cells[1].Text = order.Name;
            Table1.Rows[0].Cells[2].Text = order.email;
            XmlSerializer xml_s = new XmlSerializer(items.GetType());
            XmlDocument x_cart = new XmlDocument();
            MemoryStream ms = new MemoryStream();
            xml_s.Serialize(ms, items);
            ms.Position = 0;
            x_cart.Load(ms);
            ms.Close();
            Xml1.DocumentContent = x_cart.InnerXml;
        }
    }
}