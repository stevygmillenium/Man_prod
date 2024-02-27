using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Man_prod
{
    public partial class Add_prod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Name = Request.Form["p_nam"];
            item.price =(float)Convert.ToDouble(Request.Form["price"]);
            item.quantity = Convert.ToInt16(Request.Form["quan"]);
            HttpPostedFile postedFile = Request.Files[0];
            Stream stream = postedFile.InputStream;
            MemoryStream memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            item.img = memoryStream.ToArray();
            WebService webService = new WebService();
            webService.write_db(item);
            Label1.Text = item.Name + " " + item.price + " " + item.quantity + " ";
        }
    }
}