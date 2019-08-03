using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace EmailSending
{
    /// <summary>
    /// Summary description for CheckExistEmail
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CheckExistEmail : System.Web.Services.WebService
    {

        [WebMethod]
        public void EmailExist(string email)
        {
            string conStr = @"Data Source=192.168.0.58;Initial Catalog=pratickOffice;User ID=sa;Password=password@123";
            bool emailInUse = false;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("spCheckEmailOnEmailExist",con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@email", email);
                cmd.Parameters.Add(param);
                emailInUse = Convert.ToBoolean(cmd.ExecuteScalar());
            }

            TblGtiEmailExist tblGtiEmailExist = new TblGtiEmailExist();
            tblGtiEmailExist.email = email;
            tblGtiEmailExist.emailInUSe = emailInUse;

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(tblGtiEmailExist));
        }
    }
}
