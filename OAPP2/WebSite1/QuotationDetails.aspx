<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="QuotationDetails.aspx.cs" Inherits="QuotationDetails" %>

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
                  	  <h4 class="mb"><i class="fa fa-angle-right"></i> Quotation </h4>
                          <div class="form-horizontal tasi-form">
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess"> Product:</label>
                                  <div class="col-lg-10">
                                      <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" AutoPostBack="false" >
                                      </asp:DropDownList>
                                  </div>
                              </div>
                              
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess"> Minimum Quantity:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox> 
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="QuoVal"
                                          ControlToValidate="TextBox1" runat="server" ErrorMessage="Minimum quantity is required" 
                                          BorderStyle="None" ForeColor="Red">*Minimum quantity is reqired</asp:RequiredFieldValidator>
                                  </div>
                              </div>

                               <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess"> Rate:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox2" class="form-control" runat="server" placeholder="Per Quantity"></asp:TextBox> 
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="QuoVal"
                                          ControlToValidate="TextBox2" runat="server" ErrorMessage="Rate per piece is required" 
                                          BorderStyle="None" ForeColor="Red">*Rate per piece is reqired</asp:RequiredFieldValidator>
                                  </div>
                              </div>

                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess"> Create Date:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="dd/MM/yyyy"></asp:TextBox>  
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="QuoVal"
                                          ControlToValidate="TextBox3" runat="server" ErrorMessage="Date is required" 
                                          BorderStyle="None" ForeColor="Red">*Date is Required</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ControlToValidate="TextBox3" ValidationGroup="QuoVal" ID="RegularExpressionValidator4" ForeColor="Red" runat="server" ValidationExpression="(((0|1)[1-9]|2[1-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$">*Date format is not correct </asp:RegularExpressionValidator>  
                                  </div>
                              </div>

                               <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess"> Status:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox4" class="form-control" runat="server"></asp:TextBox> 
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="QuoVal"
                                          ControlToValidate="TextBox4" runat="server" ErrorMessage="Status is required or write -> No Status" 
                                          BorderStyle="None" ForeColor="Red">*Status is required or write -> No Status"</asp:RequiredFieldValidator>
                                  </div>
                              </div>

                               <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Remarks:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox class="form-control" ID="TextBox5" runat="server"></asp:TextBox>   
                                  </div>
                              </div>

                               <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess"> Terms and conditions:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox6" class="form-control" runat="server"></asp:TextBox> 
                                      
                                  </div>
                              </div>

                              <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-success" 
                                  onclick="Button1_Click" ValidationGroup="QuoVal" />

           			   </div><!-- /form-panel -->
                    </div>
          		</div><!-- /col-lg-12 -->
          	</div><!-- /row -->
          	
          	
          		
          
          		
          	</div><!-- /row -->
</asp:Content>



