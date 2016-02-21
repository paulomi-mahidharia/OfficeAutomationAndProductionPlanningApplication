<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="NewOrder.aspx.cs" Inherits="NewOrder" %>

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

    <script src="assets/js/chart-master/Chart.js"></script>
    
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- BASIC FORM ELELEMNTS -->
          	<div class="row mt">
          		
                      <div class="form-horizontal style-form">
                          
                        
                      </div>
                    	
          	</div><!-- /row -->
          	
          
          	
          	<!-- INPUT MESSAGES -->
          	<div class="row mt">
          		<div class="col-lg-12">
          			<div class="form-panel">
                  	  <h4 class="mb"><i class="fa fa-angle-right"></i> 
                             <asp:Label ID="Label1" runat="server" Text="Label">  Order</asp:Label></h4>
                          <div class="form-horizontal tasi-form" >
                             
                              
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Product:</label>
                                  <div class="col-lg-10">
                                         <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" OnSelectedIndexChanged="DropDownList1_OnSelectedIndexChanged" AutoPostBack = "True"></asp:DropDownList>
                                     
                                  </div>
                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Quotation ID:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox class="form-control" ID="TextBox1" runat="server" style="cursor:not-allowed"></asp:TextBox>   
                                  <asp:Label ID="Label2" runat="server" Text="No quotation created!" Visible="false" ForeColor="Red"></asp:Label>
                                  </div>
                              </div>
                               <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Quantity:</label>
                                  <div class="col-lg-10">
                                      
                                     <asp:TextBox class="form-control" ID="TextBox2" runat="server"></asp:TextBox> 
                                      
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="OrdVal"
                                          ControlToValidate="TextBox2" runat="server"  
                                          BorderStyle="None" ForeColor="Red">*Order Quantity is required</asp:RequiredFieldValidator>
                                  </div>
                              </div>

                              <div class="form-group has-success">
                              
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Rate:</label>
                                  <div class="col-lg-10">
                                   <asp:TextBox ID="TextBox3" runat="server" class="form-control" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="OrdVal"
                                          ControlToValidate="TextBox3" runat="server"  
                                          BorderStyle="None" ForeColor="Red">*Rate is required</asp:RequiredFieldValidator>
                                   </div>
                               </div>   
                                <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Purchase Order Number:</label>
                                  <div class="col-lg-10"> 
                                  <asp:TextBox ID="TextBox5" class="form-control" runat="server"></asp:TextBox> 
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="OrdVal"
                                          ControlToValidate="TextBox5" runat="server"  
                                          BorderStyle="None" ForeColor="Red">*Purchase order number is required</asp:RequiredFieldValidator>
                                         
                         </div></div>
                         
                               <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Purchase Order Date:</label>
                                  <div class="col-lg-10">
                                  <asp:TextBox ID="TextBox4" runat="server" placeholder="dd/MM/yyyy"  class="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="OrdVal"
                                          ControlToValidate="TextBox4" runat="server"  
                                          BorderStyle="None" ForeColor="Red">*Purchase order Date is Required</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ControlToValidate="TextBox4" ValidationGroup="OrdVal" ID="RegularExpressionValidator4" ForeColor="Red" runat="server" ValidationExpression="(((0|1)[1-9]|2[1-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$">*Date format is not correct </asp:RegularExpressionValidator>
                                  </div>
                          
                          </div>
                           
                         <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Order Creation Date:</label>
                                  <div class="col-lg-10"> 
                                  <asp:TextBox ID="TextBox6" class="form-control" placeholder="dd/MM/yyyy" runat="server"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="OrdVal"
                                          ControlToValidate="TextBox6" runat="server" ErrorMessage="Phone No is Required" 
                                          BorderStyle="None" ForeColor="Red">*Order creation date is Required</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ControlToValidate="TextBox6" ValidationGroup="OrdVal" ID="RegularExpressiona5lidator1" ForeColor="Red" runat="server" ValidationExpression="(((0|1)[1-9]|2[1-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$">*Date format is not correct </asp:RegularExpressionValidator>   
                         </div></div>
                         <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Status:</label>
                                  <div class="col-lg-10"> 
                                      <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                                        <asp:ListItem Text="Order Created" Value="1" />
                                        <asp:ListItem Text="Performa invoice generated" Value="2" />
                                        <asp:ListItem Text="Performa invoice approved" Value="3" />
                                        <asp:ListItem Text="Cylinder requested" Value="4" />
                                        <asp:ListItem Text="Cylinder received" Value="5" />
                                        <asp:ListItem Text="Print pending" Value="6" />
                                        <asp:ListItem Text="Converting" Value="7" />
                                        <asp:ListItem Text="Ready" Value="8" />
                                        <asp:ListItem Text="Dispached" Value="9" />
                                        <asp:ListItem Text="Closed" Value="10" />
                                      </asp:DropDownList>
                                      
                         </div></div>
                         <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Remarks:</label>
                                  <div class="col-lg-10"> 
                                  <asp:TextBox ID="TextBox8" class="form-control" runat="server"></asp:TextBox> 
                                      
                         </div></div>
                        
                         
                         <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Delivery Address:</label>
                                  <div class="col-lg-10"> 
                                   <asp:TextBox ID="TextArea2" TextMode="multiline" Columns="50" Rows="5" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="OrdVal"
                                          ControlToValidate="TextArea2" runat="server"  
                                          BorderStyle="None" ForeColor="Red">*DeliveryAddress is Required</asp:RequiredFieldValidator>  
                         </div></div>
                          <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Delivery Date:</label>
                                  <div class="col-lg-10"> 
                                  <asp:TextBox ID="TextBox9" class="form-control" placeholder="dd/MM/yyyy" runat="server"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="OrdVal"
                                          ControlToValidate="TextBox9" runat="server"  
                                          BorderStyle="None" ForeColor="Red">*Delivery Date is Required</asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ControlToValidate="TextBox9" ValidationGroup="OrdVal" ID="RegularExpressionValidator1" ForeColor="Red" runat="server" ValidationExpression="(((0|1)[1-9]|2[1-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$">*Date format is not correct </asp:RegularExpressionValidator>   
                                      
                         </div></div>
                         
                          <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Attach Purchase Order:</label>
                                  <div class="col-lg-10"> 

                                        <div><asp:HyperLink ID="lnkImage1" runat="server" NavigateUrl="" Text="View" Target="_blank"/> 
                                     <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger btn-xs" 
                                             onclick="LinkButton1_Click"><i class="fa fa-trash-o "></i></asp:LinkButton></div>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                         
                                      
                         </div></div>
                        
                         <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-theme" ValidationGroup="OrdVal"
                                  onclick="Button1_Click" />

           			   </div><!-- /form-panel -->
                    </div>
          		</div><!-- /col-lg-12 -->
          	</div><!-- /row -->
        
</asp:Content>

