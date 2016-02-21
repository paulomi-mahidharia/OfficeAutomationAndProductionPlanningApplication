<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="EmpAttendance.aspx.cs" Inherits="EmpAttendance" %>

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


<div class="row mt">
                  <div class="col-md-12">
                      <div class="content-panel">
                          
                          
                          
                      
                           <h4><i class="fa fa-angle-right"></i>  
                               <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h4>
                          
                           <br />
                           <div id="repdiv" runat="server">
                           <table class="table table-striped table-advance table-hover">
                               <tr>
                                   <th>Employee Name</th>
                                   <th>Genrate Report for Employee</th>
                                   
                               </tr>
                          <asp:Repeater ID="Repeater1" runat="server">
                        
                          <ItemTemplate>
                          <tr>
                          <td><%# Eval("Name") %></td>
                          <td>
                              <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="LinkButton1_Command" CommandArgument='<%# Eval("EmployeeID") %>'>Get Attendance Report</asp:LinkButton> </td> 
                          
                
                          </tr>
                          </ItemTemplate>
                </asp:Repeater></table>
                          </div>
                          <div id="empreport" runat="server">
                    <div id="Div1" class="form-horizontal tasi-form" runat="Server">
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
                         
                  </div><!-- /col-md-12 -->
              </div><!-- /row -->
</asp:Content>

