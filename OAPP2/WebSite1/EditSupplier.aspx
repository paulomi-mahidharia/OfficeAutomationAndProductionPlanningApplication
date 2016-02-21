<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="EditSupplier.aspx.cs" Inherits="EditSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="assets/css/bootstrap.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="assets/css/zabuto_calendar.css">
    <link rel="stylesheet" type="text/css" href="assets/js/gritter/css/jquery.gritter.css" />
    <link rel="stylesheet" type="text/css" href="assets/lineicons/style.css">    
    
    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet">
    <link href="assets/css/style-responsive.css" rel="stylesheet">

    <script src="assets/js/chart-master/Chart.js"></script>
    
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- BASIC FORM ELELEMNTS -->
          	<div class="row mt">
          		
                      <div class="form-horizontal style-form">
                          
                        
                      </div>
                    	
          	</div><!-- /row -->
          	
          
          	
          	<!-- INPUT MESSAGES -->
          	<div class="row mt">
          		<div class="col-lg-12">
          			<div class="form-panel">
                  	  <h4 class="mb"><i class="fa fa-angle-right"></i> Supplier</h4>
                          <div class="form-horizontal tasi-form" method="get">
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Name:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="SupVal" ControlToValidate="TextBox1" runat="server" ErrorMessage="Name is Required" ForeColor="Red">*Name is Reqired</asp:RequiredFieldValidator> 
                                  </div>
                              </div>
                              
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Email:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox> 
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="SupVal"
                                          ControlToValidate="TextBox2" runat="server" ErrorMessage="Address is Required" 
                                          BorderStyle="None" ForeColor="Red">*Email is Reqired</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator BorderStyle="None" ForeColor="Red" ValidationGroup="SupVal" ID="RegularExpressionValidator1"  ControlToValidate="TextBox2" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" >*Email address is not looking well</asp:RegularExpressionValidator>
                                  </div>
                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Contact Person:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox class="form-control" ID="TextBox3" runat="server"></asp:TextBox>   
                                  </div>
                              </div>
                               <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Phone No:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox class="form-control" placeholder="Must be of 10 digit" ID="TextBox8" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="SupVal"
                                          ControlToValidate="TextBox8" runat="server" ErrorMessage="Phone No is Required" 
                                          BorderStyle="None" ForeColor="Red">*Phone No is Required</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                          ControlToValidate="TextBox8" ValidationExpression="[0-9]{10}" ValidationGroup="SupVal"
                                          ErrorMessage="Must be of 10 digit" ForeColor="Red">*Must be of 10 digit</asp:RegularExpressionValidator>  
                                  </div>
                              </div>
                              <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-success" 
                                  onclick="Button1_Click" ValidationGroup="SupVal" />

           			   </div><!-- /form-panel -->
                    </div>
          		</div><!-- /col-lg-12 -->
          	</div><!-- /row -->
          	
          	
          		
          
          		
          	</div><!-- /row -->
</asp:Content>

