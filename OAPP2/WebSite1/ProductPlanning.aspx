<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="ProductPlanning.aspx.cs" Inherits="ProductPlanning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
 @media print
        {
         
            .dontprint
            {
                display:none;
            }
            input,textarea
            {
                border:0px solid gray;
            }
            
            
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
                          
                             <a href="AllReports.aspx"> <span ID="hideButton"  class="btn btn-round btn-danger" style="width:100px" >Back</span></a>                                     
                          
                      
                           <h4><i class="fa fa-angle-right"></i>  Production Planning Report (Product) </h4>
                           
                          <br />

                           <table class="table table-striped table-advance table-hover">
                           <tr>
                           <th>Sr No</th>
                           <th>Date of Product</th>
                           <th>Customer Name</th>
                           <th>Product Name</th>
                           <th>Type</th>
                           <th>Status</th>
                          
                           </tr>
                          <asp:Repeater ID="Repeater1" runat="server">
                        
                          <ItemTemplate>
                          <tr>
                          <td> <%# (Container.ItemIndex + 1).ToString() %></td>
                          <td> <%# Eval("CreateDate", "{0:dd/MM/yyyy}") %></td>
                          <td> <%# Eval("CustomerName") %></td>
                          <td> <%# Eval("Name") %> </span></td>
                          <td> <%# Eval("Type") %> </span></td>
                          <td> <%# Eval("Status") %> </span></td>
                          
                          </tr>
                          </ItemTemplate>
                </asp:Repeater></table>
                        <br />  
                        <div style="border: 1px solid black" class="marButton dontprint">
                       <center>
                <input type="button" value="Print/Save" class="btn btn-theme dontprint" onclick="print()" />
            </center>   
            </div>
                  </div><!-- /col-md-12 -->
              </div><!-- /row -->

</asp:Content>

