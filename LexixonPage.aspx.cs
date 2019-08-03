using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using BusinessAccesLayer;

namespace EmailSending
{
    public partial class LexixonPage : System.Web.UI.Page
    {
        BL objBL = new BL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {            
            if (Page.IsValid)
            {
               
                if (FileUpload1.HasFile)
                {
                    string sigUrl = "~/SignatureUpload/" + System.Guid.NewGuid()+ FileUpload1.FileName;
                    string fileName = FileUpload1.FileName;
                    Attachment attachment = new Attachment(FileUpload1.PostedFile.InputStream, fileName);

                    objBL.procedureName = "spInsertTblGti";
                    objBL.isMessage = true;

                    objBL.paramList.Add("@name", TextBox1.Text);
                    objBL.paramList.Add("@fthrName", TextBox2.Text);
                    objBL.paramList.Add("@mthrName", TextBox3.Text);
                    objBL.paramList.Add("@datofBirth", TextBox4.Text);
                    objBL.paramList.Add("@plBirth", TextBox5.Text);
                    objBL.paramList.Add("@maritalSts", TextBox6.Text);
                    objBL.paramList.Add("@hsbndName", TextBox7.Text);
                    objBL.paramList.Add("@spkHindi", RadioButtonList1.SelectedItem.Text);
                    objBL.paramList.Add("@motherToungh", TextBox9.Text);
                    objBL.paramList.Add("@sex", RadioButtonList2.SelectedItem.Text);
                    objBL.paramList.Add("@categeory", TextBox11.Text);
                    objBL.paramList.Add("@nation", TextBox12.Text);
                    objBL.paramList.Add("@phchl", RadioButtonList3.SelectedItem.Text);
                    objBL.paramList.Add("@phn", TextBox14.Text);
                    objBL.paramList.Add("@email", TextBox15.Text);
                    objBL.paramList.Add("@adrCorr", TextBox10.Text);
                    objBL.paramList.Add("@adrPrnmnt", TextBox13.Text);
                    objBL.paramList.Add("@clstenth", RadioButtonList4.SelectedItem.Text);
                    objBL.paramList.Add("@clstwlve", RadioButtonList5.SelectedItem.Text);
                    objBL.paramList.Add("@graduation", RadioButtonList6.SelectedItem.Text);
                    objBL.paramList.Add("@extraQual", RadioButtonList7.SelectedItem.Text);
                    objBL.paramList.Add("@sigUrl", sigUrl);

                    FileUpload1.SaveAs(Server.MapPath(sigUrl));

                    bool r = objBL.InsertUpdateDelete();

                    string msg = objBL.msg1.Value.ToString();

                    if (msg== "Data has been inserted!")
                    {
                        objBL.sendMail(TextBox15.Text, TextBox1.Text, attachment);

                        objBL.sendMailToAdmin(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, RadioButtonList1.SelectedItem.Text, TextBox9.Text, RadioButtonList2.SelectedItem.Text, TextBox11.Text, TextBox12.Text, RadioButtonList3.SelectedItem.Text, TextBox14.Text, TextBox15.Text, TextBox10.Text, TextBox13.Text, RadioButtonList4.SelectedItem.Text, RadioButtonList4.SelectedItem.Text, RadioButtonList6.SelectedItem.Text, RadioButtonList7.SelectedItem.Text, attachment);

                        Label2.ForeColor = System.Drawing.Color.Green;
                        Label2.Text = objBL.msg1.Value.ToString();
                        
                        //Response.Write("<script>alert('You have Successfully Registered!\n Confirmation email has been sent to your Email-Id!');window.location = '~/LexixonPage.aspx';</script>");                        
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('You have Successfully Registered!\n Confirmation email has been sent to your Email-Id!'); window.location='LexixonPage.aspx';", true);

                    }
                    else
                    {
                        Response.Write("<script>alert('" + msg + "')</script>");
                    }                    
                }
                else
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Please upload a signature";
                }
            }


        }
    }
}