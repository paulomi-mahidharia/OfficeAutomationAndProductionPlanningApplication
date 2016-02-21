<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="ViewAttendance.aspx.cs" Inherits="ViewAttendance" %>

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
                              
                              <div class="form-inline">
                               <asp:TextBox ID="TextBox1" runat="server" class="form-control" style="" placeholder="Date"></asp:TextBox>
                               <asp:Button ID="Button2" runat="server" Text="Search" class="btn btn-theme" onclick="Button2_Click"/>
                           
                              <asp:Button ID="Button1" runat="server" 
                                  Text="See Attendance Report" class="btn btn-theme02" 
                                   onclick="Button1_Click"/></div>
                              <asp:Label ID="Label1" runat="server" Text="Enter date to generate specific report!" Visible="false" ForeColor="red"></asp:Label>
                               <asp:Label ID="Label2" runat="server" Text="Enter date for a specific search!" Visible="false" ForeColor="red"></asp:Label>
                           <div>
                           <br/>
                           <asp:Label ID="Label3" runat="server" Text="No Data Found" Visible="false"></asp:Label>
                          <div runat="server" id="Table1">
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
                                      <td><%# Eval("ADate", "{0:dd/MM/yyyy}") %></td>
                                      <td><%#Convert.ToBoolean(Eval("Mark"))?"P":"A" %></td>
                                  </tr>
                              </ItemTemplate>
                </asp:Repeater></table>
                          </div>
                           </div>
                          <br />
                          </div>
                   </div>
               </div>
           </div>
</asp:Content>

