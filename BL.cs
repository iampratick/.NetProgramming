using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DALClass;
using System.Net.Mail;
using System.Net;

namespace BusinessAccesLayer
{
    public class BL
    {
        DAL objDAL = new DAL();

        private SqlParameter _paraSet;
        public SqlParameter paraSet
        {
            get { return _paraSet; }
            set { _paraSet = value; }
        }

        public SqlParameter param;

        public List<SqlParameter> li_param;
        public SqlParameter msg1;
        public Dictionary<String, object> paramList = new Dictionary<string, object>();

        private string _procedureName;
        public string procedureName
        {
            get { return _procedureName; }
            set { _procedureName=value;}
        }

        public bool isMessage;

        public bool InsertUpdateDelete()
        {
            li_param = new List<SqlParameter>();
            objDAL.cmdstr = procedureName;
            
            foreach (KeyValuePair<string, object> para in paramList)
            {
                param = new SqlParameter(para.Key, para.Value);
                paraSet = param;
                li_param.Add(paraSet);
            }

            if (isMessage)
            {
                param = new SqlParameter("@msg", SqlDbType.VarChar,100);
                param.Direction = ParameterDirection.Output;
                paraSet = param;
                li_param.Add(paraSet);
            }

            objDAL.lparam = li_param;

            bool r = objDAL.manipulateBySpInDAL();

            if (r)
                return true;
            else
                return false;
        }

        public bool ManiipulateByObjectDataSource(string pname, string parameterName1, object value1, string parameterName2, object value2, string parameterName3, object value3, string parameterName4, object value4, string parameterName5, object value5, string parameterName6, object value6, string parameterName7, object value7)
        {
            li_param = new List<SqlParameter>();

            objDAL.cmdstr = pname;

            if (parameterName1 != null && value1 != null)
            {
                SqlParameter param = new SqlParameter(parameterName1, value1);
                paraSet = param;
                li_param.Add(paraSet);
            }

            if (parameterName2 != null && value2 != null)
            {
                SqlParameter param = new SqlParameter(parameterName2, value2);
                paraSet = param;
                li_param.Add(paraSet);
            }

            if (parameterName3 != null && value3 != null)
            {
                SqlParameter param = new SqlParameter(parameterName3, value3);
                paraSet = param;
                li_param.Add(paraSet);
            }

            if (parameterName4 != null && value4 != null)
            {
                SqlParameter param = new SqlParameter(parameterName4, value4);
                paraSet = param;
                li_param.Add(paraSet);
            }

            if (parameterName5 != null && value5 != null)
            {
                SqlParameter param = new SqlParameter(parameterName5, value5);
                paraSet = param;
                li_param.Add(paraSet);
            }

            if (parameterName6 != null && value6 != null)
            {
                SqlParameter param = new SqlParameter(parameterName6, value6);
                paraSet = param;
                li_param.Add(paraSet);
            }

            if (parameterName7 != null && value7 != null)
            {
                SqlParameter param = new SqlParameter(parameterName7, value7);
                paraSet = param;
                li_param.Add(paraSet);
            }

            objDAL.lparam = li_param;

            bool r = objDAL.manipulateBySpInDAL();

            if (r)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public DataSet fetch(string pname)
        {
            li_param = new List<SqlParameter>();

            objDAL.cmdstr = pname;

            //if (param1 != null)
            //{
            //    foreach (SqlParameter para in param1)
            //    {
            //        paraSet = para;
            //        li_param.Add(paraSet);
            //    }
            //}

            if (paramList != null)
            {
                foreach (KeyValuePair<string, object> para in paramList)
                {
                    SqlParameter param = new SqlParameter(para.Key, para.Value);
                    paraSet = param;
                    li_param.Add(paraSet);
                }

                objDAL.lparam = li_param;
            }
            DataSet ds = objDAL.fetchBySpInDAL();

            return ds;
        }

        public DataSet fetchByObjectDataSource(string pname, string parameterName1, object value1, string parameterName2, object value2, string parameterName3, object value3)
        {
            li_param = new List<SqlParameter>();

            objDAL.cmdstr = pname;

            if (parameterName1 != null && value1 != null)
            {
                SqlParameter para = new SqlParameter(parameterName1, value1);
                paraSet = para;
                li_param.Add(paraSet);
            }

            if (parameterName2 != null && value2 != null)
            {
                SqlParameter para = new SqlParameter(parameterName2, value2);
                paraSet = para;
                li_param.Add(paraSet);
            }

            if (parameterName3 != null && value3 != null)
            {
                SqlParameter para = new SqlParameter(parameterName3, value3);
                paraSet = para;
                li_param.Add(paraSet);
            }

            objDAL.lparam = li_param;

            DataSet ds = objDAL.fetchBySpInDAL();
            return ds;
        }

        public bool sendMail(string toEmail,string name, Attachment attachment)
        {
            try
            {
                MailMessage mailMessage = new MailMessage("iampratick.02@gmail.com", toEmail);
                mailMessage.Subject = "Registration Confirmation";
                mailMessage.Body = "Hey Mr/Miss. " + name+",\n"+"You have successfully registered!";
                if (attachment != null)
                {
                    mailMessage.Attachments.Add(attachment);
                }

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential()
                {
                    UserName = "iampratick.02@gmail.com",
                    Password = "****"
                };
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool sendMailToAdmin(string name,string fthrName,string mthrName,string dob,string plceBirth,string maritalSts,string hsbdName,string spkHindin,string mothrToung,string sex,string categeory,string nation,string phChlng,string phnNumber,string email,string addrCorrs,string addrPrnamnt,string tenth,string twlve,string grad,string extra, Attachment attachment)
        {
            try
            {
                string Messagebody= "Hey Pratick, a new user is registered" + "\nName: " + name + "\nFather's Name: " + fthrName + "\nMother's Name: " + mthrName + "\nDate of Birth: " + dob + "\nPlace of Birth: " + plceBirth + "\nMarital Status: " + maritalSts + "\nHusband Name: " + hsbdName + "\nSpeak in Hindi: " + spkHindin + "\nSex: " + sex + "\nCategeory: " + categeory + "\nNationality: " + nation + "\nPhysical Challenged? " + phChlng + "\nPhone Number: " + phnNumber + "\nEmail: " + email + "\nCorresponding Address: " + addrCorrs + "\nPermanent Address: " + addrPrnamnt + "\n10th pass or Equivalent: " + tenth + "\n12th pass or Equivalent: " + twlve + "\nGraduation: " + grad + "\nExtra Qualification: " + extra;
                MailMessage mailMessage = new MailMessage("iampratick.02@gmail.com", "iampratick.02@gmail.com");
                mailMessage.Subject = "New User Registered";
                mailMessage.Body = Messagebody;
                if (attachment != null)
                {
                    mailMessage.Attachments.Add(attachment);
                }

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential()
                {
                    UserName = "iampratick.02@gmail.com",
                    Password = "****"
                };
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

    public class BL1
    {
        Dal1 dal = new Dal1();
        SqlParameter param;        
        List<SqlParameter> li_param;
        private string _procedureName;
        public string procedureName
        {
            get { return _procedureName; }
            set { _procedureName = value; }
        }
        
        bool isMessage=false;

        Dictionary<string, object> listParam = new Dictionary<string, object>();

        public bool InsertUpdateDelete()
        {
            try
            {
                li_param = new List<SqlParameter>();
                dal.cmdStr = procedureName;
                foreach (KeyValuePair<string, object> para in listParam)
                {
                    param = new SqlParameter(para.Key, para.Value);
                    li_param.Add(param);
                }

                if (isMessage)
                {
                    param = new SqlParameter("message", SqlDbType.VarChar, 100);
                    param.Direction = ParameterDirection.Output;
                    li_param.Add(param);
                }

                dal.paramList = li_param;
                dal.manipulateInDal();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public DataSet fetch()
        {
            SqlParameter param;
            li_param = new List<SqlParameter>();
            dal.cmdStr = procedureName;

            if (listParam != null)
            {
                foreach (KeyValuePair<string, object> para in listParam)
                {
                    param = new SqlParameter(para.Key,para.Value);
                    li_param.Add(param);
                }
                dal.paramList = li_param;
            }
           

            DataSet ds= dal.fetchInDal();
            return ds;

        }
    }

}
