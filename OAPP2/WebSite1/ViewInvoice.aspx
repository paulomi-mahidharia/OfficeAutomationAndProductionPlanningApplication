<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="ViewInvoice.aspx.cs" Inherits="ViewInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row mt">
        <div class="col-md-12">
            <div class="content-panel">
                <h4>
                    <i class="fa fa-angle-right"></i>  Invoices</h4>
               
                <br />
                <asp:Label ID="Label1" runat="server" Text="No Data Found" Visible="false"></asp:Label>
                          <div runat="server" id="Table1">
                <table class="table table-striped table-advance table-hover">
                    <tr>
                        <th>
                            Order
                        </th>
                        <th>
                            Invoice No
                        </th>
                        <th>Invoice Date
                        </th>
                        <th>
                            Amount
                        </th>
                        <th>
                            Invoice Document
                        </th>
                        <th>
                            Operations
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" 
                        >
                        <ItemTemplate>
                            <tr>
                                <td>
                                    
                                        <%# Eval("ProductName") %></a>
                                </td>
                                <td>
                                    <%# Eval("InvoiceNo") %>
                                </td>
                                <td><%# Eval("InvoiceDate", "{0:dd/MM/yyyy}")%>
                                </td>
                                <td>
                                    <%# Eval("GrandTotal") %>
                                </td>
                                <td>
                                   <a href='<%# Eval("InvoicePDF") %>' target="_blank"> <%# (Eval("InvoicePDF") == DBNull.Value) ? "" : "View Invoice"%></a> </td>
                                </td>
                                <td>
                                   
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="hii" class="btn btn-danger btn-xs"
                                        OnCommand="LinkButton1_Command" CommandArgument='<%# Eval("InvoiceID") %>'><i class="fa fa-trash-o "></i></asp:LinkButton>
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

