<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="SupplierList.aspx.cs" Inherits="SupplirList" %>

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
                         

                           <h4><i class="fa fa-angle-right"></i> Supplier </h4>

                          <div class="form-inline">
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Supplier Name"></asp:TextBox>
                                <asp:Button ID="Button2" runat="server" Text="Search" class="btn btn-theme" onclick="Button2_Click" 
                                  />
                           </div>
                          <br />
                          <asp:Label ID="Label1" runat="server" Text="No Data Found" Visible="false"></asp:Label>
                          <div runat="server" id="Table1">
                            <table class="table table-striped table-advance table-hover">
                           <tr>
                           <th>Name</th>
                           <th>Contact Person</th>
                           
                           <th>Email</th>
                           
                           <th>Operations</th>
                           <th>Additional features</th>
                           
                           </tr>
                          <asp:Repeater ID="Repeater1" runat="server">
                        
                          <ItemTemplate>
                          <tr>
                          <td> <a href='<%# "Profilesup.aspx?id="+Eval("SupplierID") %>'><%# Eval("Name") %></a></td>
                          <td><%# Eval("ContactPerson") %></td>
                          <td> <span class="label label-info label-mini"> <%# Eval("Email") %> </span></td>
                          <td>  
                                       <a href='<%# "Profilesup.aspx?id="+Eval("SupplierID") %>' class="btn btn-success btn-xs"><i class="fa fa-check"></i></button></a>
                                       <a href='<%# "EditSupplier.aspx?id="+Eval("SupplierID") %>' class="btn btn-primary btn-xs"><i class="fa fa-pencil"></i></button></a>
                              <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger btn-xs" OnCommand="LinkButton1_Command" CommandArgument='<%# Eval("SupplierID") %>'><i class="fa fa-trash-o "></i></asp:LinkButton>
                          </td>
                          <td>
                              <asp:LinkButton ID="LinkButton2" runat="server" Text="Show History" class="btn btn-theme" OnCommand="LinkButton2_Command" CommandArgument='<%#Eval("SupplierID")%>'></asp:LinkButton>
                              
                          </td>
                          </tr>
                          </ItemTemplate>
                </asp:Repeater></table>
                          </div>
                          
                  </div><!-- /content-panel -->
                  </div><!-- /col-md-12 -->
              </div><!-- /row -->
</asp:Content>

