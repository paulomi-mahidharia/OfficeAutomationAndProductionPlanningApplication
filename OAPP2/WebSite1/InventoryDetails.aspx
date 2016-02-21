<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="InventoryDetails.aspx.cs" Inherits="InventoryDetails" %>


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
                  	  <h4 class="mb"><i class="fa fa-angle-right"></i> Inventory </h4>
                          <div class="form-horizontal tasi-form">
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">RawMaterial:</label>
                                  <div class="col-lg-10">
                                      <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" >
                                      </asp:DropDownList>
                                  </div>
                              </div>
                              
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Quantity:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox> 
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  ValidationGroup="InvVal"
                                          ControlToValidate="TextBox1" runat="server" ErrorMessage="Minimum quantity is required" 
                                          BorderStyle="None" ForeColor="Red">*Minimum quatity is required</asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationGroup="InvVal" runat="server" 
                                          ControlToValidate="TextBox1" ValidationExpression="[0-9]*" 
                                          ErrorMessage="Must be a digit" ForeColor="Red">*Must be a digit</asp:RegularExpressionValidator> 
                                      
                                  </div>
                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Transaction Date:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="dd/MM/yyyy"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="InvVal"
                                          ControlToValidate="TextBox2" runat="server" ErrorMessage="Date of birth is Required" 
                                          BorderStyle="None" ForeColor="Red">*Date of birth is Required</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ControlToValidate="TextBox2" ValidationGroup="InvVal" ID="RegularExpressionValidator4" ForeColor="Red" runat="server" ValidationExpression="(((0|1)[1-9]|2[1-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$">*Date format is not correct </asp:RegularExpressionValidator>  
                                  </div>
                              </div>
                               <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Remarks:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox class="form-control" ID="TextBox3" runat="server"></asp:TextBox>   
                                  </div>
                              </div>
                              <asp:Button ID="Button1" runat="server" ValidationGroup="InvVal" Text="Save" class="btn btn-success" 
                                  onclick="Button1_Click" />

           			   </div><!-- /form-panel -->
                    </div>
          		</div><!-- /col-lg-12 -->
          	</div><!-- /row -->
          	
          	
          		
          
          		
          	</div><!-- /row -->
</asp:Content>

