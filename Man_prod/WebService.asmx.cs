using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Man_prod
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public void write_db(object obj) 
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand comm = new SqlCommand(constr, conn);
            comm.Connection = conn;
            if (obj.GetType() == typeof(Item)) 
            {
                Item item=(Item)obj;
                comm.CommandText = "insert into [dbo].[Table] (product_name,price,quantity,image) values (@product_name,@price,@quantity,@image)";
                comm.Parameters.AddWithValue("@product_name", item.Name);
                comm.Parameters.AddWithValue("@price", item.price);
                comm.Parameters.AddWithValue("@quantity", item.quantity);
                comm.Parameters.AddWithValue("@image", item.img);
                comm.ExecuteNonQuery();
            }
            else if(obj.GetType() == typeof(order)) 
            {
                order order=(order)obj;
                comm.CommandText = "insert into [dbo].[order] (cust_name,cust_em,cust_addr,card_type,j_data,o_date,amount) values (@cust_name,@cust_em,@cust_addr,@card_type,@j_data,@o_date,@amount)";
                comm.Parameters.AddWithValue("@cust_name", order.Name);
                comm.Parameters.AddWithValue("@cust_em", order.email);
                comm.Parameters.AddWithValue("@cust_addr", order.address);
                comm.Parameters.AddWithValue("@card_type", order.card_type);
                comm.Parameters.AddWithValue("@j_data", order.data);                
                comm.Parameters.AddWithValue("@o_date", order.dateTime);
                comm.Parameters.AddWithValue("@amount", order.amount);
                comm.ExecuteNonQuery();
            }
            else if (obj.GetType() == typeof(List<Item>)) 
            {
                List<Item> items= (List<Item>)obj;
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add(nameof(Item.Name), typeof(string));
                dataTable.Columns.Add(nameof(Item.price), typeof(float));
                dataTable.Columns.Add(nameof(Item.quantity), typeof(int));
                foreach(Item item in items) 
                {
                    dataTable.Rows.Add(item.Name, item.price,item.quantity);
                }
                SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(conn);
                sqlBulkCopy.DestinationTableName = "[Table]";
                sqlBulkCopy.ColumnMappings.Add("Name", "product_name");
                sqlBulkCopy.ColumnMappings.Add("price", "price");
                sqlBulkCopy.ColumnMappings.Add("quantity", "quantity");
                //conn.Open();
                sqlBulkCopy.WriteToServer(dataTable);
                conn.Close();
            }
            else { }
            //comm.ExecuteNonQuery();
        }
    }
}
