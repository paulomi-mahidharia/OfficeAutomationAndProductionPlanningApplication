<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="InventoryList.aspx.cs" Inherits="InventoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
        
    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet">
    <link href="assets/css/style-responsive.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
      <![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row mt">
                  <div class="col-md-12">
                      <div class="content-panel">
                         

                           <h4><i class="fa fa-angle-right"></i> Inventory </h4>

                             <div class="form-inline">
                               <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="From Date"></asp:TextBox>
                               <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="To Date"></asp:TextBox>
                               <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                               </asp:DropDownList>
                                <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-theme" 
                                   onclick="Button1_Click"/>
                           </div>
                          <br />
                          
                           <asp:Label ID="Label3" runat="server" Text="No Data Found" Visible="false"></asp:Label>
                          <div runat="server" id="Table1">
                            <table class="table table-striped table-advance table-hover">
                           <tr>
                           <th>Select for GRN</th>
                           <th>RawMatrial Name</th>
                           <th>Supplier</th>
                           <th>Quantity</th>
                           
                           <th>Transaction date</th>
                           
                           <th>GRN Document</th>
                           <th>Operations</th>
                           
                           </tr>
                          <asp:Repeater ID="Repeater1" runat="server">
                        
                          <ItemTemplate>
                          <tr>
                          <td>
                              <asp:CheckBox ID="CheckBox1" runat="server" /><asp:Label ID="Label1" runat="server"
                                  Text='<%# Eval("InventoryID") %>' style="display:none"></asp:Label> </td>
                          <td> <a href='<%# "ProfileInv.aspx?id="+Eval("InventoryID") %>'><%# Eval("RawMaterialName") %></a></td>
                           <td><%# Eval("SupplierName") %></a></td>
                          <td><%# Eval("Quantity")%></td>
                          <td> <%# Eval("TrDate", "{0:dd/MM/yyyy}")%> </td>
                          <td><a href='<%# Eval("GRNPath") %>'> <%# (Eval("GRNPath") == DBNull.Value) ? "" : "View GRN"%></a> </td>
                          <td>  
                                       <a href='<%# "ProfileInv.aspx?id="+Eval("InventoryID") %>' class="btn btn-success btn-xs"><i class="fa fa-check"></i></button></a>
                                       <a href='<%# "InventoryDetails.aspx?id="+Eval("InventoryID") %>' class="btn btn-primary btn-xs"><i class="fa fa-pencil"></i></button></a>
                              <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger btn-xs" OnCommand="LinkButton1_Command" CommandArgument='<%# Eval("InventoryID") %>'><i class="fa fa-trash-o "></i></asp:LinkButton>
                          </td>
                          </tr>
                          </ItemTemplate>
                </asp:Repeater></table>
                         
                          <asp:Button ID="Button2" runat="server" class="btn btn-success" 
                               Text="Generate GRN" onclick="Button2_Click"/>
                               <asp:Label ID="Label2" runat="server" style="color:Red;" Text="Same GRN can not be generated for multiple Suppliers." Visible="false"></asp:Label>
                  </div>
                  </div><!-- /content-panel -->
                  </div><!-- /col-md-12 -->
              </div><!-- /row -->
</asp:Content>

