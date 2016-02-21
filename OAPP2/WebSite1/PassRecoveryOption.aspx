<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="PassRecoveryOption.aspx.cs" Inherits="PassRecoveryOption" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html lang="en">
  <head>
   

    <title>ADMIN - BULLION FLEXIPACK</title>

    <!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet">
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
  </head>

  <body>

      <!-- **********************************************************************************************************************************************************
      MAIN CONTENT
      *********************************************************************************************************************************************************** -->

	  <div id="login-page" >
	  	<div class="container" style="opacity:0.9">
	  	
		      <form id="form1" class="form-login" runat="server"> 
               <h2 class="form-login-heading">
                   <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h2><br />
                   
       
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox1" class="form-control" runat="server" Width="120%"></asp:TextBox> 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox1" runat="server" ErrorMessage="Value is inevitable" ForeColor="red">*Value is inevitable</asp:RequiredFieldValidator>
                                  </div>
                              
                                   <asp:Button ID="Button1" runat="server" Text="Continue" class="btn btn-theme btn-block" 
                                  onclick="Button1_Click" />
		
		      </form>	  	
	  	
	  	</div>
	  </div>

    <!-- js placed at the end of the document so the pages load faster -->
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

    <!--BACKSTRETCH-->
    <!-- You can use an image of whatever size. This script will stretch to fit in any screen size.-->
    <script type="text/javascript" src="assets/js/jquery.backstretch.min.js"></script>
    <script>
        $.backstretch("assets/img/login-bg.jpg", { speed: 500 });
    </script>


  </body>
</html>