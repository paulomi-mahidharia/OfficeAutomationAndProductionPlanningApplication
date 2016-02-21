<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="AddRawMat.aspx.cs" Inherits="AddRawMat" %>

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
                             <asp:Label ID="Label1" runat="server" Text="Label">  Add Raw Material</asp:Label></h4>
                          <div class="form-horizontal tasi-form" >
                             
                              
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Name:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox> 
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="RawVal"
                                          ControlToValidate="TextBox2" runat="server" ErrorMessage="Raw material name is required" 
                                          BorderStyle="None" ForeColor="Red">*Raw material name is reqired</asp:RequiredFieldValidator>
                                  </div>
                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Code:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox class="form-control" ID="TextBox3" runat="server"></asp:TextBox>  
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="RawVal"
                                          ControlToValidate="TextBox3" runat="server" ErrorMessage="Raw material code is required" 
                                          BorderStyle="None" ForeColor="Red">*Raw material code is required</asp:RequiredFieldValidator> 
                                  </div>
                              </div>
                               <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Description:</label>
                                  <div class="col-lg-10">
                                      
                                      <asp:TextBox ID="TextArea1" TextMode="multiline" Columns="50" Rows="5" runat="server" class="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="RawVal"
                                          ControlToValidate="TextArea1" runat="server" ErrorMessage="Description is required" 
                                          BorderStyle="None" ForeColor="Red">*Description is required</asp:RequiredFieldValidator> 
                                  </div>
                              </div>

                              <div class="form-group has-success">
                              
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Unit:</label>
                                  <div class="col-lg-10">
                                   <asp:TextBox ID="TextBox4" runat="server" class="form-control" ></asp:TextBox>
                                   </div>
                               </div>   
                         
                               <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Minimum Quantity:</label>
                                  <div class="col-lg-10">
                                  <asp:TextBox ID="TextBox5" runat="server" class="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="RawVal"
                                          ControlToValidate="TextBox5" runat="server" ErrorMessage="Minimum quantity is required" 
                                          BorderStyle="None" ForeColor="Red">*Minimum quatity is required</asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationGroup="RawVal"
                                          ControlToValidate="TextBox5" ValidationExpression="[0-9]*" 
                                          ErrorMessage="Must be a digit" ForeColor="Red">*Must be a digit</asp:RegularExpressionValidator> 
                                  </div>
                          
                          </div>
                            <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Supplier Name:</label>
                                  <div class="col-lg-10">
                          <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" ></asp:DropDownList></div></div>
                          
                          <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Category:</label>
                                  <div class="col-lg-10">
                          <asp:DropDownList ID="DropDownList2" runat="server" class="form-control" >
                          <asp:ListItem Text="Select one" Value="Select one" Selected=True></asp:ListItem>
                          <asp:ListItem Text="Sleeves" Value="Sleeves"></asp:ListItem>
                          <asp:ListItem Text="Bags" Value="Bags"></asp:ListItem>
                          </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="RawVal"
                                          ControlToValidate="DropDownList2" runat="server" ErrorMessage="Select a category" InitialValue="Select one"
                                          BorderStyle="None" ForeColor="Red">*Select a category</asp:RequiredFieldValidator>
                          </div></div>

                         <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Type:</label>
                                  <div class="col-lg-10">
                          <asp:DropDownList ID="DropDownList3" runat="server" class="form-control" >
                          <asp:ListItem Text="Select one" Value="Select one" Selected=True></asp:ListItem>
                          <asp:ListItem Text="PVC ROlls"></asp:ListItem>
                          <asp:ListItem Text="Ink and Solvents"></asp:ListItem>
                          <asp:ListItem Text="Cylinder"></asp:ListItem>
                          <asp:ListItem Text="Ink and Solvents"></asp:ListItem>
                          
                          </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="RawVal"
                                          ControlToValidate="DropDownList3" runat="server" ErrorMessage="Select raw material type" InitialValue="Select one"
                                          BorderStyle="None" ForeColor="Red">*Select raw material type</asp:RequiredFieldValidator>
                          </div></div>
                              
                              <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-theme" 
                                  onclick="Button1_Click" ValidationGroup="RawVal" />

           			   </div><!-- /form-panel -->
                    </div>
          		</div><!-- /col-lg-12 -->
          	</div><!-- /row -->
          	
          	
          		
          
          		
          	</div><!-- /row -->
</asp:Content>

