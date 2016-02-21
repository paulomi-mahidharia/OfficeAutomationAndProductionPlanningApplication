<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="EditEmp.aspx.cs" Inherits="EditEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="assets/css/bootstrap.css" rel="stylesheet"/>
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="assets/css/zabuto_calendar.css"/>
    <link rel="stylesheet" type="text/css" href="assets/js/gritter/css/jquery.gritter.css" />
    <link rel="stylesheet" type="text/css" href="assets/lineicons/style.css"/>    
    
    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet"/>
    <link href="assets/css/style-responsive.css" rel="stylesheet"/>

    <script type="text/javascript" src="assets/js/chart-master/Chart.js"></script>
    
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--main content start-->
      
          	<!-- BASIC FORM ELELEMNTS -->
          	<div class="row mt">
          		
                      <div class="form-horizontal style-form">
                          
                        
                      </div>
                    	
          	</div><!-- /row -->
          	
          
          	
          	<!-- INPUT MESSAGES -->
          	<div class="row mt">
          		<div class="col-lg-12">
          			<div class="form-panel" >
                  	  <h4 class="mb"><i class="fa fa-angle-right"></i>Employee</h4>
                          <div class="form-horizontal tasi-form">
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Name:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox1"  class="form-control" runat="server"></asp:TextBox> 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="EmpVal"
                                          ControlToValidate="TextBox1" runat="server" ErrorMessage="Name is Required" 
                                          BorderStyle="None" ForeColor="Red">*Name is Reqired</asp:RequiredFieldValidator>
                                  </div>
                              </div>
                              
                              <div class="form-group has-success" style="margin-top:20px;">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Address:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextArea1" TextMode="multiline" Columns="50" Rows="5" runat="server" class="form-control"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="EmpVal"
                                          ControlToValidate="TextArea1" runat="server" ErrorMessage="Address is Required" 
                                          BorderStyle="None" ForeColor="Red">*Address is Reqired</asp:RequiredFieldValidator>
                                      
                                  </div>
                              </div>
                              
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Email:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox> 
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="EmpVal"
                                          ControlToValidate="TextBox2" runat="server" ErrorMessage="Address is Required" 
                                          BorderStyle="None" ForeColor="Red">*Email is Reqired</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator BorderStyle="None" ForeColor="Red" ID="RegularExpressionValidator1"  ControlToValidate="TextBox2" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" >*Email address is not looking well</asp:RegularExpressionValidator>
                                  </div>
                              </div>
                              
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Phone No:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox class="form-control" ID="TextBox3" runat="server"></asp:TextBox> 
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="EmpVal"
                                          ControlToValidate="TextBox3" runat="server" ErrorMessage="Phone No is Required" 
                                          BorderStyle="None" ForeColor="Red">*Phone No is Required</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                          ControlToValidate="TextBox3" ValidationExpression="[0-9]{10}" ValidationGroup="EmpVal"
                                          ErrorMessage="Must be of 10 digit" ForeColor="Red">*Must be of 10 digit</asp:RegularExpressionValidator>  
                                  </div>
                              </div>
                              
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Date of Birth</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox5" class="form-control" placeholder="dd/MM/yyyy" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                                          ControlToValidate="TextBox5" runat="server" ErrorMessage="Phone No is Required" ValidationGroup="EmpVal"
                                          BorderStyle="None" ForeColor="Red">*Date of birth is Required</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ControlToValidate="TextBox5" ID="RegularExpressionValidator4" ForeColor="Red" ValidationGroup="EmpVal" runat="server" ValidationExpression="(((0|1)[1-9]|2[1-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$">*Date format is not correct </asp:RegularExpressionValidator>
                                      

                                  </div>
                              </div>
                              
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Date of Join</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox6" class="form-control"  placeholder="dd-MM-yyyy" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                                          ControlToValidate="TextBox6" runat="server" ErrorMessage="Phone No is Required" ValidationGroup="EmpVal"
                                          BorderStyle="None" ForeColor="Red">*Date of join is Required</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ControlToValidate="TextBox6" ID="RegularExpressionValidator3" ForeColor="Red" runat="server" ValidationGroup="EmpVal" ValidationExpression="(((0|1)[1-9]|2[1-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$">*Date format is not correct </asp:RegularExpressionValidator>
                                  </div>

                              </div>
                              
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Gender</label>
                                  <div class="col-lg-10" class="radio">
                                      <asp:RadioButton ID="RadioButton1" name="optionsRadios" GroupName="gender" checked="true"  runat="server" />Male
                                      <asp:RadioButton ID="RadioButton2" name="optionsRadios" GroupName="gender" runat="server" />Female
                                  </div>
                              </div>
                              <br />
                   
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Designation</label>
                                  <div class="col-lg-10">
                                      <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                                        <asp:ListItem Text="MANAGING DIRECTOR" />
                                        <asp:ListItem Text="MARKETING MANAGER" />
                                        <asp:ListItem Text="MARKETING EMPLOYEE" />
                                        <asp:ListItem Text="DESIGNER" />
                                        <asp:ListItem Text="COMERCIAL MANAGER" />
                                        <asp:ListItem Text="COMERCIAL EMPLOYEE" />
                                        <asp:ListItem Text="STOCK MANAGER" />
                                        <asp:ListItem Text="STOCK EMPLOYEE" />
                                        <asp:ListItem Text="PRODUCTION MANAGER" />
                                        <asp:ListItem Text="PRODUCTION EMPLOYEE" />
                                        <asp:ListItem Text="HR MANAGER" />
                                        <asp:ListItem Text="HR EMPLOYEE" />
                                        <asp:ListItem Text="EMPLOYEE" />
                                        <asp:ListItem Text="CHAIRMAN" />
                                        <asp:ListItem Text="ACCOUNTATANT" />
                                        <asp:ListItem Text="WORKER" />
                                      </asp:DropDownList>
                                  </div>
                              </div>
                              <br />
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">photo</label>
                                  <div class="col-lg-10">
                                      <asp:Image ID="Image1" runat="server" style="max-width:100px; max-height:100px" ImageUrl="Images/default.png"/>
                                    <asp:FileUpload ID="FileUpload1" runat="server"   />
                                  
                                  </div>

                              </div>
                                <br />
                            
                               <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-success" 
                                  onclick="Button1_Click" ValidationGroup="EmpVal" />

                               <br />
                          </div>
          			</div><!-- /form-panel -->
          		</div><!-- /col-lg-12 -->
          	</div><!-- /row -->
          	
          	
          		
          
          		
          	
          	
          	
	
</asp:Content>

