using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Man_prod
{
    public partial class Mult_prod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> list = new List<Item>();
            HttpPostedFile postedFile = Request.Files[0];
            Stream stream = postedFile.InputStream;
            TextReader text = new StreamReader(stream);
            string line;
            while ((line = text.ReadLine())!=null) 
            {                
                string[] parts = line.Split(',');
                Item item = new Item { Name = parts[0], price = float.Parse(parts[1]), quantity = int.Parse(parts[2]) };
                list.Add(item);
            }
            GridView1.DataSource=list;
            GridView1.DataBind();
            Label1.Text=list.Count.ToString();
            WebService webService = new WebService();
            webService.write_db(list);
        }
    }
}