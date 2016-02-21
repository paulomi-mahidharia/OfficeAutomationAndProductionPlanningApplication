<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="OrderList" %>

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




<div class="row mt">
                  <div class="col-md-12">
                      <div class="content-panel">
                          
                          
                          
                      
                           <h4><i class="fa fa-angle-right"></i>  Orders</h4>
                          
                           <div class="form-inline">
                                <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                               </asp:DropDownList>
                               <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                               </asp:DropDownList>
                               <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="From Date"></asp:TextBox>
                               <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="To Date"></asp:TextBox>
                               
                                <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-theme" onclick="Button1_Click" 
                                  />
                           </div>
                          <br />
                          <asp:Label ID="Label1" runat="server" Text="No Data Found" Visible="false"></asp:Label>
                          <div runat="server" id="Table1">
                           <table class="table table-striped table-advance table-hover" >
                               <tr>
                                   <th>Customer</th>
                                   <th>Product</th>
                                   <th>Order Date</th>
                                   <th>PO Number</th>
                                   <th>Status</th>
                                   <th></th>
                                   <th>Operations</th>
                                   <th>Advance Operations</th>
                               </tr>
                          <asp:Repeater ID="Repeater1" runat="server" onitemcommand="Repeater1_ItemCommand">
                        
                          <ItemTemplate>
                          <tr>
                          <td><%# Eval("CustomerName") %></a></td>
                          <td><%# Eval("ProductName") %></a></td>
                          <td><%# Eval("CreateDate", "{0:dd/MM/yyyy}")%></td> 
                          <td><%# Eval("PONumber") %></td>
                          <td><%# Eval("Status") %></td>
                          <td>
                                <asp:TextBox ID="TextBox3" runat="server" placeholder="Enter Status Remarks"></asp:TextBox>
                                <asp:Button ID="ImageButton1" runat="server" CommandArgument='<%# Eval("OrderID")%>' Text = "Performa invoice generated" CommandName = "Performa invoice generated"  Visible='<%# Eval("Status").ToString() == "Order Created" %>'/>
                                <asp:Button ID="ImageButton2" runat="server" CommandArgument='<%# Eval("OrderID")%>' Text = "Performa invoice approved" CommandName = "Performa invoice approved" Visible='<%# Eval("Status").ToString() == "Performa invoice generated" %>'/>
                                <asp:Button ID="ImageButton3" runat="server" CommandArgument='<%# Eval("OrderID")%>' Text = "Cylinder requested" CommandName = "Cylinder requested" Visible='<%# Eval("Status").ToString() == "Performa invoice approved" %>'/>
                                <asp:Button ID="ImageButton4" runat="server" CommandArgument='<%# Eval("OrderID")%>' Text = "Cylinder received" CommandName = "Cylinder received" Visible='<%# Eval("Status").ToString() == "Cylinder requested" %>'/>
                                <asp:Button ID="ImageButton5" runat="server" CommandArgument='<%# Eval("OrderID")%>' Text = "Print pending" CommandName = "Print pending" Visible='<%# Eval("Status").ToString() == "Cylinder received" %>'/>
                                <asp:Button ID="ImageButton6" runat="server" CommandArgument='<%# Eval("OrderID")%>' Text = "Converting" CommandName = "Converting" Visible='<%# Eval("Status").ToString() == "Print pending" %>'/>
                                <asp:Button ID="ImageButton7" runat="server" CommandArgument='<%# Eval("OrderID")%>' Text = "Ready" CommandName = "Ready" Visible='<%# Eval("Status").ToString() == "Converting" %>'/>
                                <asp:Button ID="ImageButton8" runat="server" CommandArgument='<%# Eval("OrderID")%>' Text = "Dispached" CommandName = "Dispached" Visible='<%# Eval("Status").ToString() == "Ready" %>'/>
                                <asp:Button ID="ImageButton9" runat="server" CommandArgument='<%# Eval("OrderID")%>' Text = "Closed" CommandName = "Closed" Visible='<%# Eval("Status").ToString() == "Dispached" %>'/>
                                    </td> 
                          <td> 
                               <a href='<%# "ProfileOrd.aspx?id="+Eval("OrderID") %>' class="btn btn-success btn-xs"><i class="fa fa-check"></i></button></a> 
                               <a href='<%# "NewOrder.aspx?id="+Eval("OrderID") %>' class="btn btn-primary btn-xs"><i class="fa fa-pencil"></i></button></a>
                                      
                              <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger btn-xs" OnCommand="LinkButton1_Command" CommandArgument='<%# Eval("OrderID") %>'><i class="fa fa-trash-o "></i></asp:LinkButton>
                          </td>
                          <td>
                              <asp:Button ID="Button2" runat="server" Text="Invoice" CommandArgument='<%# Eval("OrderID")%>' OnCommand="Button2_OnCommand" />
                              <asp:Button ID="Button3" runat="server" Text="Job Card" CommandArgument='<%# Eval("OrderID")%>' OnCommand="Button3_OnCommand" Visible='<%# (Eval("JobPath").ToString() == "") %>' />
                              <a href='<%# Eval("JobPath") %>'> <%# (Eval("JobPath").ToString() == "") ? "" : "View Job Card"%></a> </td>
                           
                           </td>
                          </tr>
                          </ItemTemplate>
                </asp:Repeater></table>
                          </div>
                         
                  </div><!-- /col-md-12 -->
              </div><!-- /row -->
</asp:Content>

