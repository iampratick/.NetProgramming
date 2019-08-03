<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LexixonPage.aspx.cs" Inherits="EmailSending.LexixonPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet"" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="style.css" rel="stylesheet" />

    <%--<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.0/css/all.css" integrity="sha384-lZN37f5QGtY3VHgisS14W3ExzMWZxybE1SJSEsQp9S+oqd12jhcu+A56Ebc1zFSJ" crossorigin="anonymous">--%>

    <script type="text/javascript">
        function Copy() {
            if (checkIf.checked) {
                document.getElementById('TextBox13').value = document.getElementById('TextBox10').value;
            }
            else {
                document.getElementById('TextBox13').value = '';
            }
        }

        $(document).ready(function () {
            $('#TextBox15').keyup(function () {
                var email = $(this).val();

                if (email.length >= 5) {
                    $.ajax({
                        url: 'CheckExistEmail.asmx/EmailExist',
                        method: 'post',
                        data: { email: email },
                        dataType: 'json',
                        success: function (data)
                        {
                            var lblElement = $('#LabelEmail');

                            if (data.emailInUSe)
                            {
                                lblElement.text(email + ' is already exist');
                                lblElement.css('color', 'red');
                            }
                            else
                            {
                                lblElement.text('You can use this Email-Id');
                                lblElement.css('color', 'green');
                            }
                        },
                        error: function (err)
                        {
                            alert(err);
                        }
                        
                    });
                }
            });

            $('#TextBox15').keyup(function (){
                var email = $(this).val();
                var lblElement = $('#LabelEmail');

                if (email.length ==0) {
                    lblElement.text(' ');
                }
            })
        });
    </script>
</head>
<body>
   <form id="form1" runat="server">
       <div style="width:100%;background-image: url('pexels-photo-268883.jpeg');">
        <div class="container register">
            <div class="row">
                <div class="col-md-3 register-left">
                    <img src="https://image.ibb.co/n7oTvU/logo_white.png" alt="" />
                    <h3>Welcome</h3>
                    <p>You are 30 seconds away from earning your own money!</p>

                    <%--<input type="submit" name="" value="Login" />--%><br />
                    <img src="XLarge-logo-gti1.jpg" alt="Logo_GTI" runat="server" style="width: 140px; height: 130px; box-shadow: 5px 5px 5px 5px navy;" />
                </div>
                <div class="col-md-9 register-right">                   
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-4 offset-1">
                                <img src="XLarge-logo-gti1.jpg" alt="Logo_GTI" runat="server" style="width: 140px; height: 130px; box-shadow: 5px 5px 5px 5px rgba(214, 216, 205, 0.99)" />
                            </div>
                            <div class="col-md-7" style="box-shadow:2px 2px 2px rgba(214, 216, 205, 0.99)">
                                <h2 class="h2" id="gtiPvt" style="color:navy; font-size:50px;">G.T.I. PVT. LTD.</h2>
                                <h4 class="h5" id="subGti">LexIcon More, Darjeeling<br />
                                    Near Science City<br />
                                    734010</h4>
                            </div>
                        </div>
                    </div>
                    <div class="tab-content" id="myTabContent">
                        <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                            <h3 class="register-heading" style="color:blue;font-weight:bold;font-size:32px;padding:2px; ">&mdash; Register Here &mdash; </h3>
                            <div class="row register-form">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <%--<span class="input-group-addon"><i class="btn fa fa-user"></i></span>--%>
                                            <asp:TextBox ID="TextBox1" placeholder="Name" required="" CssClass="form-control" runat="server"></asp:TextBox>
                                            
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-user-check"></i></span>
                                            <asp:TextBox ID="TextBox2" placeholder="Father's Name" required="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" placeholder="Mother's Name" required=""></asp:TextBox>                                            
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="Date of Birth" required="" TextMode="Date" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="TextBox5" CssClass="form-control" placeholder="Place of Birth" required="" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="TextBox6" CssClass="form-control" placeholder="Marital Status" required="" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="TextBox7" CssClass="form-control" placeholder="Husband Name (if any)" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <b>Do you have ability read, write and speak in Hindi</b>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSpeakHindi" ForeColor="Red" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="Select Yes or No!"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="TextBox9" CssClass="form-control" placeholder="Mother Tongue" required="" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <b>Sex : </b>&nbsp;&nbsp; 
                                            <asp:RadioButtonList ID="RadioButtonList2" required="" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Male</asp:ListItem>
                                                <asp:ListItem>Female</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSex" ForeColor="Red" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="Select your gender!"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="TextBox11" CssClass="form-control" placeholder="Category" required="" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="TextBox12" CssClass="form-control" placeholder="Nationality" required="" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="col-md-6">
                                    <b>Physically challenged :</b>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorphy" ForeColor="Red" runat="server" ControlToValidate="RadioButtonList3" ErrorMessage="Select Yes or No!"></asp:RequiredFieldValidator>
                                    </div>
                                    
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="TextBox14" CssClass="form-control" placeholder="Phone Number" required="" runat="server"></asp:TextBox>                                            
                                        </div>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" runat="server" ErrorMessage="Phone number is invalid" ForeColor="Red" ControlToValidate="TextBox14" ValidationExpression="^([\+]?[0-9]{1,3}?[\s.-]?[0-9]{1,15})([\s.-]?[0-9]{1,4}?)$"></asp:RegularExpressionValidator>
                                    </div>
                                    
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="TextBox15" required="" CssClass="form-control" placeholder="Email ID" runat="server"></asp:TextBox><br />                                                                                        
                                        </div>
                                        <asp:Label ID="LabelEmail" runat="server" Text=""></asp:Label>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Email id is invalid" ForeColor="Red" ControlToValidate="TextBox15" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </div>
                                    
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="TextBox10" CssClass="form-control" TextMode="MultiLine" placeholder="Address for correspondence" required="" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <i><b>Permanent Address :</b> (Whether the Permanent Address is same with correspondence address yes/no)<br /><b>Click check box</b></i>
                                    <input type="checkbox" name="SameAsAbove" id="checkIf" onclick="Copy()" style="width:17px; height:17px;" /><br />
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                            <asp:TextBox ID="TextBox13" placeholder="Permanent Address" CssClass="form-control" TextMode="MultiLine" runat="server" required=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <h6 class="h6">ACADEMIC QUALIFICATION :</h6>
                                    <b>Class 10th or equivalent :</b><br />
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10th" ForeColor="Red" runat="server" ControlToValidate="RadioButtonList4" ErrorMessage="Select Yes or No!"></asp:RequiredFieldValidator>
                                    </div>
                                    <b>Class 12th or equivalent :</b><br />
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12th" ForeColor="Red" runat="server" ControlToValidate="RadioButtonList5" ErrorMessage="Select Yes or No!"></asp:RequiredFieldValidator>
                                    </div>
                                    <b>Graduation (bachelor degree) :</b><br />
                                    <div class="form-group">
                                        <div class="input-group">
                                             <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGrad" ForeColor="Red" runat="server" ControlToValidate="RadioButtonList6" ErrorMessage="Select Yes or No!"></asp:RequiredFieldValidator>
                                    </div>
                                    <b>Extra Qualification : </b>
                                    <div class="form-group">
                                        <div class="input-group">
                                             <asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorExtra" ForeColor="Red" runat="server" ControlToValidate="RadioButtonList7" ErrorMessage="Select Yes or No!"></asp:RequiredFieldValidator>
                                    </div>
                                    <b>Signature of the Applicant : </b>
                                    <div class="form-group row">

                                        <div class="col-sm-5">
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                        </div>
                                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                    </div>

                                </div>
                                <p class="justify-content-around">
                                    I solemnly declare that
                                        1. I am eligible to apply for that particular post.
                                        2. All statement made in this application are true, complete and
                                        correct
                                        3. Original documents will be produced on demand
                                        4. I agree to take this post on the condition that the commission
                                        may cancel my candidature if at any stage I am found ineligible.
                                </p>
                                <div class="form-group row">                                    
                                    <asp:Label ID="Label2" CssClass="col-md-6" runat="server" Text=""></asp:Label>
                                    <div class="col-md-5">
                                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click1"   Text="Submit" CssClass="btn btn-primary" />
                                        <%--<asp:Button ID="" CssClass="btn btn-primary" runat="server" Text="Submit"  OnClick="btnSubmit_Click" />--%>
                                    </div>                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
           </div>
    </form>
</body>
</html>
