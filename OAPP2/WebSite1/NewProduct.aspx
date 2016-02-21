<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="NewProduct.aspx.cs" Inherits="NewProduct" %>

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

    <style>
        .hidediv
        {
            display: none;
        }
    </style>
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
                             <asp:Label ID="Label1" runat="server" Text="Label">  Product</asp:Label></h4>
                          <div class="form-horizontal tasi-form" >
                             
                              
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Product Name:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox> 
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ProVal"
                                          ControlToValidate="TextBox1" runat="server" ErrorMessage="Name is Required" 
                                          BorderStyle="None" ForeColor="Red">*Product Name is Reqired</asp:RequiredFieldValidator>
                                  </div>
                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Intake Date:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox class="form-control" ID="TextBox2" runat="server"></asp:TextBox>dd/MM/yyyy  
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="ProVal"
                                          ControlToValidate="TextBox2" runat="server" ErrorMessage="Date is Required" 
                                          BorderStyle="None" ForeColor="Red">*Date is Required</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ControlToValidate="TextBox2" ValidationGroup="ProVal" ID="RegularExpressionValidator4" ForeColor="Red" runat="server" ValidationExpression="(((0|1)[1-9]|2[1-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$">*Date format is not correct </asp:RegularExpressionValidator> 
                                  </div>
                              </div>

                              <div class="form-group has-success">
                                <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Design Files:</label>
                                <div class="col-lg-10">
                                        
                                        
                                     <div><asp:HyperLink ID="lnkImage1" runat="server" NavigateUrl="" Text="View" /> 
                                         <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger btn-xs" 
                                             onclick="LinkButton1_Click"><i class="fa fa-trash-o "></i></asp:LinkButton></div>
                                        
                                     <div><asp:HyperLink ID="lnkImage2" runat="server" NavigateUrl="" Text="View" Target="_blank" /> 
                                     <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-danger btn-xs" 
                                             onclick="LinkButton2_Click"><i class="fa fa-trash-o "></i></asp:LinkButton></div>
                                     <div><asp:HyperLink ID="lnkImage3" runat="server" NavigateUrl="" Text="View" Target="_blank"/> 
                                     <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-danger btn-xs" 
                                             onclick="LinkButton3_Click"><i class="fa fa-trash-o "></i></asp:LinkButton></div>
                                     <div><asp:HyperLink ID="lnkImage4" runat="server" NavigateUrl="" Text="View" Target="_blank"/>
                                     <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-danger btn-xs" 
                                             onclick="LinkButton4_Click"><i class="fa fa-trash-o "></i></asp:LinkButton></div>
                                     <div><asp:HyperLink ID="lnkImage5" runat="server" NavigateUrl="" Text="View" Target="_blank"/> 
                                     <asp:LinkButton ID="LinkButton5" runat="server" class="btn btn-danger btn-xs" 
                                             onclick="LinkButton5_Click"><i class="fa fa-trash-o "></i></asp:LinkButton></div>
                                    
                                    <div>
                                   
                                    <asp:FileUpload ID="FileUpload1" runat="server" /><br /><input type="button" value="More Attachments"  class="btn btn-success moreat"/>
                                    </div>
                                    
                                    <div class="hidediv">
                                    
                                    <asp:FileUpload ID="FileUpload2" runat="server" /><br /><input type="button" value="More Attachments"  class="btn btn-success  moreat"/>
                                    </div>
                                    
                                    <div class="hidediv">
                                    
                                    <asp:FileUpload ID="FileUpload3" runat="server" /><br /><input type="button" value="More Attachments"  class="btn btn-success  moreat"/>
                                    </div>
                                    
                                    <div class="hidediv">
                                    <asp:FileUpload ID="FileUpload4" runat="server" /><br /><input type="button" value="More Attachments"  class="btn btn-success  moreat"/>
                                    </div>
                                    
                                    <div class="hidediv">
                                    <asp:FileUpload ID="FileUpload5" runat="server" /><br /><br />
                                    </div>
                                </div>    
                                
                              </div>
                              <div class="form-group has-success">
                              
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Status:</label>
                                  <div class="col-lg-10">
                                      <asp:DropDownList ID="DropDownList3" runat="server"  class="form-control">
                                        <asp:ListItem Text="Product Created" Value="1" />
                                        <asp:ListItem Text="Product Designed" Value="2" />
                                        <asp:ListItem Text="Product Sent for client design approval" Value="3" />
                                         <asp:ListItem Text="Design approved by client" Value="4" />
                                        <asp:ListItem Text="Trial product prepared" Value="5" />
                                        <asp:ListItem Text="Trial product sent for client approval" Value="6" />
                                        <asp:ListItem Text="Trial product approved by client" Value="1" />
                                        <asp:ListItem Text="product approved" Value="1" />
                                       
                                      </asp:DropDownList>
                                   </div>
                               </div>   
                                <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Description:</label>
                                  <div class="col-lg-10">
                                      
                                      <asp:TextBox ID="TextArea1" TextMode="multiline" Columns="50" Rows="5" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ValidationGroup="ProVal"
                                          ControlToValidate="TextArea1" runat="server" ErrorMessage="Description is required or write -> No Despcription" 
                                          BorderStyle="None" ForeColor="Red">*Description is required or write -> No Despcription</asp:RequiredFieldValidator>
                                  </div>
                              </div>

                         
                               <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Size:</label>
                                  <div class="col-lg-10">
                                  <asp:TextBox ID="TextBox4" runat="server" class="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                          ControlToValidate="TextBox4" runat="server" ErrorMessage="Size is required or write -> 0"  ValidationGroup="ProVal"
                                          BorderStyle="None" ForeColor="Red">*Size is required or write -> 0</asp:RequiredFieldValidator>
                                  </div>
                                </div>

                                <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Colors:</label>
                                  <div class="col-lg-10">
                                  <asp:TextBox ID="TextBox5" runat="server" class="form-control"></asp:TextBox>

                                  </div>
                                </div>
                          
                          <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Product Type:</label>
                                  <div class="col-lg-10">
                          <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" >
                          <asp:ListItem Text="select one" Value="Select one" Selected=True></asp:ListItem>
                          <asp:ListItem Text="Sleeves" Value="Sleeves"></asp:ListItem>
                          <asp:ListItem Text="Bags" Value="Bags"></asp:ListItem>
                          </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  ValidationGroup="ProVal"
                                          ControlToValidate="DropDownList1" runat="server" ErrorMessage="Select product type" InitialValue="Select one"
                                          BorderStyle="None" ForeColor="Red">*Select product type</asp:RequiredFieldValidator>
                          </div></div>
                           <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Customer:</label>
                                  <div class="col-lg-10">
                                      <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                                      </asp:DropDownList>
                                  </div>
                            </div>
                              
                              <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-theme" 
                                  onclick="Button1_Click"  ValidationGroup="ProVal"/>

           			   </div><!-- /form-panel -->
                    </div>
          		</div><!-- /col-lg-12 -->
          	</div><!-- /row -->
          	
          	
          		
          
          		
          	</div><!-- /row -->
</asp:Content>

