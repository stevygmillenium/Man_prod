using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Man_prod
{
    /// <summary>
    /// Summary description for Get_image
    /// </summary>
    public class Get_image : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            /*context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");*/
            string id = context.Request.QueryString["id"];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand comm = new SqlCommand(constr, conn);
            comm.Connection = conn;
            comm.CommandText = "select image from [dbo].[table] where id=" + id;
            SqlDataReader reader = comm.ExecuteReader();
            reader.Read();
            byte[] img = (byte[])reader["image"];
            context.Response.BinaryWrite(img);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}