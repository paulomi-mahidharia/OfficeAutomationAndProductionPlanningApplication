<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="Report1.aspx.cs" Inherits="Report1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style>
     @media screen and (max-width: 1600px) 
        {
    #hideButton
            {
                display:none;
            }
            
        }
     @media screen and (max-width: 700px) 
        {
            #hiddenTop
            {
                display:none;
            }
            #hideButton
            {
                display:block;
            }
            }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row mt">
        <div class="col-lg-12">
            <div class="form-panel">
                <a href="AllReports.aspx"> <span ID="hideButton"  class="btn btn-round btn-danger" style="width:100px" >Back</span></a>
                <h4 class="mb">
                    <i class="fa fa-angle-right"></i>
                    <asp:Label ID="Label1" runat="server" Text="Label">  Customer-Product Report</asp:Label></h4>
                <div class="form-horizontal tasi-form">
                    <table title="Attendance Percentages" id="AttendancePercentages" summary="pieDescription"
                        data-attc-createchart="true" data-attc-coldescription="pieDescription" data-attc-colvalues="pieValues"
                        data-attc-location="AttendancePercentagesPie" data-attc-hidetable="true" data-attc-type="bar"
                        data-attc-googleoptions='{"is3D":true}' data-attc-controls='{}'>
                        <thead>
                            <tr>
                                <th id="pieDescription">Customer</th>
                                <th id="pieValues">Products</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Name") %></td>
                                        <td><%# Eval("ProductsCount")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div id="AttendancePercentagesPie">
                    </div>
                </div>
                <div class="form-horizontal tasi-form">
                    <table title="Attendance Percentages" id="Table1" summary="pieDescription"
                        data-attc-createchart="true" data-attc-coldescription="Th1" data-attc-colvalues="Th2"
                        data-attc-location="Div1" data-attc-hidetable="true" data-attc-type="pie"
                        data-attc-googleoptions='{"is3D":true}' data-attc-controls='{}'>
                        <thead>
                            <tr>
                                <th id="Th1">Customer</th>
                                <th id="Th2">Products</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Name") %></td>
                                        <td><%# Eval("ProductsCount")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div id="Div1">
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
