using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DALClass
{
    public class DAL
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=192.168.0.58;Initial Catalog=pratickOffice;User ID=sa;Password=password@123");
                
        public string cmdstr;
        public List<SqlParameter> lparam;

        public bool manipulateBySpInDAL()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdstr, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter para in lparam)
                {
                    cmd.Parameters.Add(para);
                }
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
            finally
            {
                con.Close();
            }
        }

        public DataSet fetchBySpInDAL()
        {
            SqlDataAdapter da = new SqlDataAdapter(cmdstr, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (lparam != null)
            {
                foreach (SqlParameter para in lparam)
                {
                    da.SelectCommand.Parameters.Add(para);
                }
            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }

    public class Dal1
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=192.168.0.58;Initial Catalog=pratickOffice;User ID=sa;Password=password@123");

        public List<SqlParameter> paramList;
        public string cmdStr;

        public bool manipulateInDal()
        {
            try
            {
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter para in paramList)
                {
                    cmd.Parameters.Add(para);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet fetchInDal()
        {
            SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (paramList != null)
            {
                foreach (SqlParameter para in paramList)
                {
                    da.SelectCommand.Parameters.Add(para);
                }
            }

            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
    }
}
