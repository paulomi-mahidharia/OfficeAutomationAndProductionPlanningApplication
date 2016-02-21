<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="OrderStatusReport.aspx.cs" Inherits="OrderStatusReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="assets/css/bootstrap.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="assets/css/zabuto_calendar.css">
    <link rel="stylesheet" type="text/css" href="assets/js/gritter/css/jquery.gritter.css" />
    <link rel="stylesheet" type="text/css" href="assets/lineicons/style.css">    
    
    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet">
    <link href="assets/css/style-responsive.css" rel="stylesheet">

    <script src="assets/js/chart-master/Chart.js"></script>
    
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
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
            
                <h4 class="mb">
                    <i class="fa fa-angle-right"></i>
                    <asp:Label ID="Label3" runat="server" Text="Label">Order Status Report</asp:Label></h4>
                <div class="form-horizontal tasi-form">
                    <div id="Div1" class="form-horizontal tasi-form" runat="Server">
                    <table title="Attendance Percentages" id="AttendancePercentages" summary="pieDescription"
                        data-attc-createchart="true" data-attc-coldescription="pieDescription" data-attc-colvalues="pieValues"
                        data-attc-location="AttendancePercentagesPie" data-attc-hidetable="true" data-attc-type="column"
                        data-attc-googleoptions='{"is3D":true}' data-attc-controls='{}' >
                        <thead>
                            <tr>
                                <th id="pieDescription">Status</th>
                                <th id="pieValues">Order</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater9" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Status") %></td>
                                        <td><%# Eval("Total")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div id="AttendancePercentagesPie">
                    </div>
                    <center><h4>Status</h4></center>
                </div>
                  </div>
        </div>
    </div>
    </div>
</asp:Content>

