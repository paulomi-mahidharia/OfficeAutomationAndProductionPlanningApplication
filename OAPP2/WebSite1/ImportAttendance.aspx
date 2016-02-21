<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="ImportAttendance.aspx.cs" Inherits="ImportAttendance" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- BASIC FORM ELELEMNTS -->
          	<div class="row mt">
          		
                      <div class="form-horizontal style-form">
                          
                        
                      </div>
                    	
          	</div><!-- /row -->
          	<!-- INPUT MESSAGES -->
          	<div class="row mt">
          		<div class="col-lg-12">
          			<div class="form-panel">
                  	  <h4 class="mb"><i class="fa fa-angle-right"></i> Attendance </h4>
                          <div class="form-horizontal tasi-form">
                              
                              <div style="float:left">
                               <asp:FileUpload ID="FileUpload1" runat="server" /><br />
                               </div>
                               <div style="float:left">
                               <asp:Button ID="Button2" runat="server" Text="Import" class="btn btn-theme" onclick="Button2_Click"/>
                           </div>
                              
                           <br />
                           <br />
                           <asp:Label ID="Label1" runat="server" Text="Select an excel sheet to import!" Visible="false" ForeColor="red"></asp:Label>
                           <div>
                           <br />
                               <table class="table table-striped table-advance table-hover">
                           <tr>
                           <th>Employee</th>
                           <th>Date</th>
                           <th>Attendance</th>
                           </tr>
                          <asp:Repeater ID="Repeater1" runat="server">
                        
                              <ItemTemplate>
                                  <tr>
                                      <td><%# Eval("EmployeeName") %></td>
                                      <td><%# Eval("ADate") %></td>
                                      <td><%#Eval("Mark") %></td>
                                      
                
                                  </tr>
                              </ItemTemplate>
                </asp:Repeater></table>
                          
                           </div>
                          
                          </div>
                   </div>
               </div>
           </div>
</asp:Content>

