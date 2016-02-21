<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="SupplierHistory.aspx.cs" Inherits="SupplierHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row mt">
                  <div class="col-md-12">
                      <div class="content-panel">
                         

                           <h4><i class="fa fa-angle-right"></i> Supplier : <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> </h4>
                           
                            <div class="form-inline">
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="RawMaterial Name"></asp:TextBox>
                               <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="From Date"></asp:TextBox>
                               <asp:TextBox ID="TextBox3" runat="server" class="form-control" placeholder="To Date"></asp:TextBox>
                               
                                <asp:Button ID="Button2" runat="server" Text="Search" class="btn btn-theme" onclick="Button2_Click" 
                                  />
                           </div>
                          <br />
                          <asp:Label ID="Label2" runat="server" Text="No Data Found" Visible="false"></asp:Label>
                          <div runat="server" id="Table1">
                           <table class="table table-striped table-advance table-hover">
                               <tr>
                                   <th>Rawmaterial Name</th>
                                   <th>RawMaterial Code</th>
                                   <th>Quantity</th>                      
                                   <th>Transaction Date</th>
                                   <th>Category</th>
                                   <th>Type</th>     
                               </tr>
                              <asp:Repeater ID="Repeater1" runat="server">
                        
                                  <ItemTemplate>
                                      <tr>
                                          <td><%# Eval("RawMaterialName") %></td>
                                          <td><%# Eval("Code") %></td>
                                          <td><%# Eval("Quantity") %></td>
                                          <td><%# Eval("TrDate","{0:dd/MM/yyyy}") %></td>
                                          <td><%# Eval("Category") %></td>
                                          <td><%# Eval("Type") %></td>
                                      </tr>
                                  </ItemTemplate>
                </asp:Repeater></table>
                          </div>
                          
                  </div><!-- /content-panel -->
                  </div><!-- /col-md-12 -->
              </div><!-- /row -->


</asp:Content>

