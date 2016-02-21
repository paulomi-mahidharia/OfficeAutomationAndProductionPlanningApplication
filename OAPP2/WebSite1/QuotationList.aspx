<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="QuotationList.aspx.cs" Inherits="QuotationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row mt">
        <div class="col-md-12">
            <div class="content-panel">
                <h4><i class="fa fa-angle-right"></i>  Quotation</h4>

                    <div class="form-inline">
                                <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                               </asp:DropDownList>
                               <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                               </asp:DropDownList>
                               <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="From Date"></asp:TextBox>
                               <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="To Date"></asp:TextBox>
                               
                                <asp:Button ID="Button2" runat="server" Text="Search" class="btn btn-theme" onclick="Button2_Click" 
                                  />
                           </div>
                          <br />
                           <asp:Label ID="Label1" runat="server" Text="No Data Found" Visible="false"></asp:Label>
                          <div runat="server" id="Table1">

                   <table class="table table-striped table-advance table-hover">
                      <tr>
                           <th></th>
                           <th>Product</th>
                           <th>Customer</th>
                           <th>Create Date</th>     
                           <th>MOQ</th>   
                           <th>Status</th>
                           <th>Document</th>
                           <th>Operations</th>
                      </tr>
                      <asp:Repeater ID="Repeater1" runat="server">  
                          <ItemTemplate>
                            <tr>
                                <td><asp:CheckBox ID="CheckBox1" runat="server" /><asp:Label ID="Label1" runat="server" Text='<%# Eval("QuotationID") %>' style="display:none"></asp:Label></td>
                                <td> <a href='<%# "PrintQuotation.aspx?id="+Eval("QuotationID") %>'><%# Eval("ProductName") %></a></td>
                                <td><%# Eval("CustomerName") %></td>
                                <td><%# Eval("CreateDate", "{0:dd/MM/yyyy}")%></td>
                                <td><%# Eval("MOQ") %></td>
                                <td><%# Eval("Status") %></td>
                                <td><a href='<%# Eval("QuotationPath") %>'> <%# (Eval("QuotationPath") == "") ? "" : "View Quotation"%></a> </td>
                                <td>
                                    
                                    <a href='<%# "QuotationDetails.aspx?id="+Eval("QuotationID") %>' class="btn btn-primary btn-xs"><i class="fa fa-pencil"></i></button></a>
                                    <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger btn-xs" OnCommand="LinkButton1_Command" CommandArgument='<%# Eval("QuotationID") %>'><i class="fa fa-trash-o "></i></asp:LinkButton>
                                </td>
                              </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                   </table>  
                <asp:Button ID="Button1" runat="server" Text="Generate Quotation" 
                    onclick="Button1_Click" class="btn btn-success" />   
              
                <asp:Label ID="Label2" runat="server" style="color:Red;" Text="Same quotation can not be generated for multiples customer." Visible="false"></asp:Label>
           </div>
            </div><!-- /col-md-12 -->
        </div><!-- /row -->
    </div>       
</asp:Content>

