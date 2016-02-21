<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="TotalSaleReport.aspx.cs" Inherits="TotalSaleReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
 
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
<div style="width:100%">
            <!--CUSTOM CHART START -->
            <div >
                <h3>
                    TOTAL SALE</h3>
            </div>
            <div >
                



                  <div class="form-horizontal tasi-form">
                    <div id="Div1" class="form-horizontal tasi-form" runat="Server">
                    <table title="Attendance Percentages" id="AttendancePercentages" summary="pieDescription"
                        data-attc-createchart="true" data-attc-coldescription="pieDescription" data-attc-colvalues="pieValues"
                        data-attc-location="AttendancePercentagesbar" data-attc-hidetable="true" data-attc-type="area"
                        data-attc-googleoptions='{"is3D":true}' data-attc-controls='{}' >
                        <thead>
                            <tr>
                                <th id="pieDescription">Month</th>
                                <th id="pieValues">Sale  (Rupees)</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("MonthName") %></td>
                                        <td><%# Eval("TotalValue")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div id="AttendancePercentagesbar">
                    </div>
                </div>
                  </div>








            </div>
            <!--custom chart end-->
            
        </div>
        </div></div></div>
</asp:Content>

