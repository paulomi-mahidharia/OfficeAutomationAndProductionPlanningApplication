<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="SCode.aspx.cs" Inherits="SCode" %>
<html>
<head><!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
        
    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet">
    <link href="assets/css/style-responsive.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]--></head>
<body bgcolor="aqua">
          	<div class="row mt">
          		
                      <div class="form-horizontal style-form">
                          
                        
                      </div>
                    	
          	</div><!-- /row  bgbackground-color="#00FFFF" -->
          	
          
          	
          	<!-- INPUT MESSAGES -->
          	<div class="row mt">
          		<div class="col-lg-12">
          			<form id="Form1" class="form-panel" runat="server">
                  	  <h4 class="mb"><i class="fa fa-angle-right"></i> Enter Code (via SMS)</h4>
                          <div id="Div1" class="form-horizontal tasi-form" method="get" runat="server" >
                             
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Code:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox> 
                                      
                                  </div>
                              </div>
                              
                              
                              <asp:Button ID="Button1" runat="server" Text="Continue" class="btn btn-success" 
                                  onclick="Button1_Click" />
                              <asp:Label ID="Label1" runat="server" Text="Invalid Code!" Visible="false" ForeColor="red"></asp:Label>
                        </div>
           			   </form><!-- /form-panel -->
                    </div>
                   
          		</div><!-- /col-lg-12 -->
                
          	
          	
          		
          
          		
          	
</body>
</html>

