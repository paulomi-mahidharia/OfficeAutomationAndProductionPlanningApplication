<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="TrackOrderStatus.aspx.cs" Inherits="TrackOrderStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="assets/css/bootstrap.css" rel="stylesheet"/>

 <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="assets/css/zabuto_calendar.css"/>
    <link rel="stylesheet" type="text/css" href="assets/js/gritter/css/jquery.gritter.css" />
    <link rel="stylesheet" type="text/css" href="assets/lineicons/style.css"/>    
    
    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet"/>
    <link href="assets/css/style-responsive.css" rel="stylesheet"/>

    <script src="assets/js/chart-master/Chart.js"></script>
    
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

    <style type="text/css">
        .hidediv
        {
            display: none;
        }
    
 
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

          		
                      <div class="form-horizontal style-form">
                          
                        
                      </div>
                    	
          	
          	<a href="AllReports.aspx"> <span ID="hideButton"  class="btn btn-round btn-danger" style="width:100px" >Back</span></a>
          
          	
          	<!-- INPUT MESSAGES -->
          	<div class="row mt">
          		<div class="col-lg-12">
          			<div style="margin-left:20px">
                  	  <h4 class="mb" style="font-weight:bold;font-size:20px" > 
                             <asp:Label ID="Label1" runat="server" Text="Order Status Report"></asp:Label></h4>
                         <div class="form-inline">
                             <asp:TextBox ID="TextBox1" placeholder="Enter Date(dd/MM/yyyy)" class="form-control" runat="server"></asp:TextBox>
           
                            <asp:Button ID="Button2" OnClick="Button2_click" class="btn btn-theme02" runat="server" Text="Status Transition Report" />

                         </div>
                         <br/>
                         
                          <div class="form-inline" style="font-weight:bold;font-size:15px" >
                            Date:<asp:Label ID="Label2" runat="server" Text=""></asp:Label> 
                            
                         </div>
                         <br />
                          
                                 <div>
                                 <div style="border=1px solid black">
                                 <div style="float:left;width:20%">
                                 <table class="table table-striped table-advance table-hover" border="1">
                    <tr>
                        <th>
                            Order Created
                        </th>
                       
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" 
                        >
                        <ItemTemplate>
                            <tr>
                                <td>
                                   
                                        <%# Eval("Name") %>
                                </td>
                               
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                </div>
                                 <div style="float:left;width:20%">
                                 <table class="table table-striped table-advance table-hover" border="1">
                    <tr>
                        <th>
                          Performa invoice generated
                        </th>
                       
                    </tr>
                    <asp:Repeater ID="Repeater2" runat="server" 
                        >
                        <ItemTemplate>
                            <tr>
                                <td>
                                   
                                        <%# Eval("Name") %>
                                </td>
                               
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                </div>
                                 <div style="float:left;width:20%">
                                 <table class="table table-striped table-advance table-hover" border="1">
                    <tr>
                        <th>
                           Performa invoice approved
                        </th>
                       
                    </tr>
                    <asp:Repeater ID="Repeater3" runat="server" 
                        >
                        <ItemTemplate>
                            <tr>
                                <td>
                                   
                                        <%# Eval("Name") %>
                                </td>
                               
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                </div>
                                 <div style="float:left;width:20%">
                                 <table class="table table-striped table-advance table-hover" border="1">
                    <tr>
                        <th>
                            Cylinder requested
                        </th>
                       
                    </tr>
                    <asp:Repeater ID="Repeater4" runat="server" 
                        >
                        <ItemTemplate>
                            <tr>
                                <td>
                                   
                                        <%# Eval("Name") %>
                                </td>
                               
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                </div>
                                 <div style="float:left;width:20%">
                                 <table class="table table-striped table-advance table-hover" border="1">
                    <tr>
                        <th>
                           Cylinder received
                        </th>
                       
                    </tr>
                    <asp:Repeater ID="Repeater5" runat="server" 
                        >
                        <ItemTemplate>
                            <tr>
                                <td>
                                   
                                        <%# Eval("Name") %>
                                </td>
                               
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                </div>
                                  </div><div style="border=1px solid black;clear:both">
                                  <div style="float:left;width:20%">
                                 <table class="table table-striped table-advance table-hover" border="1">
                    <tr>
                        <th>
                            Print pending
                        </th>
                       
                    </tr>
                    <asp:Repeater ID="Repeater6" runat="server" 
                        >
                        <ItemTemplate>
                            <tr>
                                <td>
                                   
                                        <%# Eval("Name") %>
                                </td>
                               
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                </div>
                                  <div style="float:left;width:20%">
                                 <table class="table table-striped table-advance table-hover" border="1">
                    <tr>
                        <th>
                            Converting
                        </th>
                       
                    </tr>
                    <asp:Repeater ID="Repeater7" runat="server" 
                        >
                        <ItemTemplate>
                            <tr>
                                <td>
                                   
                                        <%# Eval("Name") %>
                                </td>
                               
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                </div>
                                  <div style="float:left;width:20%">
                                 <table class="table table-striped table-advance table-hover" border="1">
                    <tr>
                        <th>
                           Ready
                        </th>
                       
                    </tr>
                    <asp:Repeater ID="Repeater8" runat="server" 
                        >
                        <ItemTemplate>
                            <tr>
                                <td>
                                   
                                        <%# Eval("Name") %>
                                </td>
                               
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                </div>
                                  <div style="float:left;width:20%">
                                 <table class="table table-striped table-advance table-hover" border="1">
                    <tr>
                        <th>
                           Dispached
                        </th>
                       
                    </tr>
                    <asp:Repeater ID="Repeater9" runat="server" 
                        >
                        <ItemTemplate>
                            <tr>
                                <td>
                                   
                                        <%# Eval("Name") %>
                                </td>
                               
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                </div>
                                  <div style="float:left;width:20%">
                                 <table class="table table-striped table-advance table-hover" border="1">
                    <tr>
                        <th>
                            Last Closed
                        </th>
                       
                    </tr>
                    <asp:Repeater ID="Repeater10" runat="server" 
                        >
                        <ItemTemplate>
                            <tr>
                                <td>
                                   
                                        <%# Eval("Name") %>
                                </td>
                               
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                </div>
                </div>
                </div>
                    </div>
                    </div>
                    </div>
                    </div>
                    </div></div>

</asp:Content>

