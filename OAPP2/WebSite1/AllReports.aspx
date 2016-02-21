<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="AllReports.aspx.cs" Inherits="AllReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet/">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
        
    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet"/>
    <link href="assets/css/style-responsive.css" rel="stylesheet"/>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style>
     @media screen and (max-width: 700px) 
        {
            #hiddenTop
            {
                display:none;
            }
            }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="row mt">
                  <div class="col-md-12">
                      <div class="content-panel">
                          
                          
                          
                      
                           <h4><i class="fa fa-angle-right"></i>  All Reports </h4>
                           
                          <br />

                           <table class="table table-striped table-advance table-hover">
                           <tr>
                           <th>Reports</th>
                           
                           </tr>
                          
                          <tr><td>
                          <a href="Report1.aspx">Customer-Product Report</a></td></tr>
                           <tr><td>
                          <a href="AttendanceReport.aspx">Today's Attendance</a></td></tr>
                          <tr><td>
                          <a href="ProductPlanning.aspx">Production Planning</a></td></tr>
                           <tr><td>
                          <a href="ProPlanning.aspx">Product Report</a></td></tr>
                          <tr><td>
                          <a href="OrderStatusReport.aspx">Orders' Status Report</a></td></tr>
                          <tr><td>
                          <a href="ProductStatusReport.aspx">Products' Status Report</a></td></tr>
                          <tr><td>
                          <a href="TotalSaleReport.aspx">Total Sales Report</a></td></tr>
                          <tr><td>
                          <a href="Stock.aspx">Today's Stock</a></td></tr>
                          <tr><td>
                          <a href="TopProductReport.aspx">Top Product</a></td></tr>
                          <tr><td>
                          <a href="BestOrderReport.aspx">Best Order</a></td></tr>
                          <tr><td>
                          <a href="RevenueReport.aspx">Revenue Report</a></td></tr>
                         
                          <tr><td>
                          <a href="TrackOrderStatus.aspx">Track order status Report</a></td></tr>
                         
                          <tr><td>
                          <a href="TrackProductStatus.aspx">Track Product Status Report</a></td></tr>
                          <tr>
                          
                          </table>
                          
                         
                  </div><!-- /col-md-12 -->
              </div><!-- /row -->

</asp:Content>

