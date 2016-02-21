<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="ProdList.aspx.cs" Inherits="ProdList" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="assets/css/zabuto_calendar.css" />
    <link rel="stylesheet" type="text/css" href="assets/js/gritter/css/jquery.gritter.css" />
    <link rel="stylesheet" type="text/css" href="assets/lineicons/style.css" />
    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" />
    <script src="assets/js/chart-master/Chart.js"></script>
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row mt">
        <div class="col-md-12">
            <div class="content-panel">
                <h4>
                    <i class="fa fa-angle-right"></i>Product</h4>
                <div class="form-inline">
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                        <asp:ListItem Text="All Types" Selected="True" />
                        <asp:ListItem Text="Sleeves" />
                        <asp:ListItem Text="Bags" />
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList2" class="form-control" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" class="btn btn-theme" />
                </div>
                <br />
                
                          <asp:Label ID="Label1" runat="server" Text="No Data Found" Visible="false"></asp:Label>
                          <div runat="server" id="Table1">
                <table class="table table-striped table-advance table-hover">
                    <tr>
                        <th>
                            Name
                        </th>
                        <th>
                            Status
                        </th>
                        <th>Change Status
                        </th>
                        <th>
                            Type
                        </th>
                        <th>
                            Customer
                        </th>
                        <th>
                            Operations
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" 
                        onitemcommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <a href='<%# "ProfileProd.aspx?id="+Eval("ProductID") %>'>
                                        <%# Eval("Name") %></a>
                                </td>
                                <td>
                                    <%# Eval("Status") %>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server" placeholder = "Enter Status Remarks"></asp:TextBox>
                                    <asp:Button ID="ImageButton1" runat="server" Text = "Product Designed" CommandName = "Product Designed"
                                         CommandArgument='<%# Eval("ProductID")%>' Visible='<%# Eval("Status").ToString() == "Product Created" %>' />
                                    <asp:Button ID="ImageButton2" runat="server" Text = "Product Sent for client design approval" CommandName = "Product Sent for client design approval"
                                         CommandArgument='<%# Eval("ProductID")%>' Visible='<%# Eval("Status").ToString() == "Product Designed" %>' />
                                    <asp:Button ID="ImageButton3" runat="server" Text = "Design approved by client" CommandName = "Design approved by client"
                                         CommandArgument='<%# Eval("ProductID")%>' Visible='<%# Eval("Status").ToString() == "Product Sent for client design approval" %>' />
                                    <asp:Button ID="ImageButton4" runat="server" Text = "Trial product prepared" CommandName = "Trial product prepared"
                                        CommandArgument='<%# Eval("ProductID")%>' Visible='<%# Eval("Status").ToString() == "Design approved by client" %>' />
                                    <asp:Button ID="ImageButton5" runat="server" Text = "Trial product sent for client approval" CommandName = "Trial product sent for client approval"
                                         CommandArgument='<%# Eval("ProductID")%>' Visible='<%# Eval("Status").ToString() == "Trial product prepared" %>' />
                                    <asp:Button ID="ImageButton6" runat="server" Text = "Trial product approved by client" CommandName = "Trial product approved by client"
                                        CommandArgument='<%# Eval("ProductID")%>' Visible='<%# Eval("Status").ToString() == "Trial product sent for client approval" %>' />
                                    <asp:Button ID="ImageButton7" runat="server" Text = "product approved" CommandName = "product approved"
                                        CommandArgument='<%# Eval("ProductID")%>' Visible='<%# Eval("Status").ToString() == "Trial product approved by client" %>' />
                                    
                                </td>
                                <td>
                                    <%# Eval("Type") %>
                                </td>
                                <td>
                                    <%# Eval("CustomerName") %>
                                </td>
                                <td>
                                    <a href='<%# "ProfileProd.aspx?id="+Eval("ProductID") %>' class="btn btn-success btn-xs">
                                        <i class="fa fa-check"></i></button></a> <a href='<%# "NewProduct.aspx?id="+Eval("ProductID") %>'
                                            class="btn btn-primary btn-xs"><i class="fa fa-pencil"></i></button></a>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="hii" class="btn btn-danger btn-xs"
                                        OnCommand="LinkButton1_Command" CommandArgument='<%# Eval("ProductID") %>'><i class="fa fa-trash-o "></i></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                </div>
            </div>
            <!-- /col-md-12 -->
        </div>
        <!-- /row -->
        </div>
</asp:Content>
