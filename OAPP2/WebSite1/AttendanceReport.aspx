<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="AttendanceReport.aspx.cs" Inherits="AttendanceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row mt">
        <div class="col-lg-12">
            <div class="form-panel">
            <a href="AllReports.aspx"> <span ID="hideButton"  class="btn btn-round btn-danger" style="width:100px" >Back</span></a>
             
                <h4 class="mb">
                    <i class="fa fa-angle-right"></i>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h4>
                <div class="form-horizontal tasi-form">
                    <div class="form-horizontal tasi-form" runat="Server">
                    <table title="Attendance Percentages" id="AttendancePercentages" summary="pieDescription"
                        data-attc-createchart="true" data-attc-coldescription="pieDescription" data-attc-colvalues="pieValues"
                        data-attc-location="AttendancePercentagesPie" data-attc-hidetable="true" data-attc-type="pie"
                        data-attc-googleoptions='{"is3D":true}' data-attc-controls='{}' >
                        <thead>
                            <tr>
                                <th id="pieDescription">Present</th>
                                <th id="pieValues">Absent</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Name") %></td>
                                        <td><%# Eval("Count")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div id="AttendancePercentagesPie">
                    </div>
                </div>
                  </div>
        </div>
    </div>
    </div>


</asp:Content>

