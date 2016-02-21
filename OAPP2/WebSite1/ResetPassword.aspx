<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><!-- Bootstrap core CSS -->
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
    <![endif]-->
    <style>
    .VeryPoorStrength
{
background: Red;
color:White;
font-weight:bold;
}
.WeakStrength
{
background: Gray;
color:White;
font-weight:bold;
}
.AverageStrength
{
background: orange;
color:black;
font-weight:bold;
}
.GoodStrength

{
background: blue;
color:White;
font-weight:bold;
}
.ExcellentStrength

{
background: Green;
color:White;
font-weight:bold;
}
.BarBorder
{
border-style: solid;
border-width: 1px;
width: 180px;
padding:22 22px;
}
</style>
    </head>
<body>
<div class="row mt">
          		
                      <div class="form-horizontal style-form">
                          
                        
                      </div>
                    	
          	</div><!-- /row  bgbackground-color="#00FFFF" -->
          	
          
          	
          	<!-- INPUT MESSAGES -->
          	<div class="row mt">
          		<div class="col-lg-12">
          			<form id="form1" class="form-panel" runat="server">

<asp:ScriptManager ID="ScriptManger1" runat="server"></asp:ScriptManager>

<table style="display:none">
<tr>
<td colspan="2">
<b>PasswordStrength TextIndicator</b>
</td>
</tr>
<tr>
<td>
Enter Password:
</td>
<td>
 <asp:TextBox runat="server" hidden ID="txtpwd1"  TextMode="Password"/>
</td>
</tr>
<tr>
<td></td>
<td>
<asp:Label ID="lblhelp1" runat="server"/>
</td>
</tr>
<tr>
<td colspan="2" height="30px"></td>
</tr>
</table>



<h4 class="mb"><i class="fa fa-angle-right"></i> Reset Password   [Must be containe 8 characters, 1 numbers, 1 symbol characters]</h4>
                          <div id="Div1" class="form-horizontal tasi-form" method="get" runat="server" >
                             
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">New Password:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="txtPassword" class="form-control" TextMode = "Password" runat="server" Width="50%"></asp:TextBox> 
                                     
                                      <asp:Label ID="lblhelp" runat="server"/> 
                                  </div>
                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Confirm New Password:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox class="form-control" ID="TextBox3" TextMode = "Password" Width="50%" runat="server"></asp:TextBox>  
                                     
                                  </div>
                              </div>
                              
                              <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-success" 
                                  onclick="Button1_Click" />
                              <asp:Label ID="Label1" runat="server" Text="Both passwords must match!" Visible="false" ForeColor="red"></asp:Label>
                        </div>
           			  
                    </div>
                   
          		</div>





<ajax:PasswordStrength ID="pwdStrength" TargetControlID="txtPassword" StrengthIndicatorType="Text" PrefixText="Strength:" HelpStatusLabelID="lblhelp" PreferredPasswordLength="8" 
MinimumNumericCharacters="1" MinimumSymbolCharacters="1" TextStrengthDescriptions="Very Poor;Weak;Average;Good;Excellent" TextStrengthDescriptionStyles="VeryPoorStrength;WeakStrength;
AverageStrength;GoodStrength;ExcellentStrength" runat="server" />
<ajax:PasswordStrength ID="PasswordStrength1" TargetControlID="txtpwd1" StrengthIndicatorType="BarIndicator" PrefixText="Strength:" HelpStatusLabelID="lblhelp1" PreferredPasswordLength="8" 
MinimumNumericCharacters="1" MinimumSymbolCharacters="1" BarBorderCssClass="BarBorder" TextStrengthDescriptionStyles="VeryPoorStrength;WeakStrength;
AverageStrength;GoodStrength;ExcellentStrength" runat="server" />

</form>
</body>
</html>

          	<%--<div class="row mt">
          		
                      <div class="form-horizontal style-form">
                          
                        
                      </div>
                    	
          	</div><!-- /row  bgbackground-color="#00FFFF" -->
          	
          
          	
          	<!-- INPUT MESSAGES -->
          	<div class="row mt">
          		<div class="col-lg-12">
          			<form class="form-panel" runat="server">
                  	  <h4 class="mb"><i class="fa fa-angle-right"></i> Reset Password</h4>
                          <div class="form-horizontal tasi-form" method="get" runat="server" >
                             
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">New Password:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox2" class="form-control" TextMode = "Password" runat="server"></asp:TextBox> 
                                      
                                  </div>
                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Confirm New Password:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox class="form-control" ID="TextBox3" TextMode = "Password" runat="server"></asp:TextBox>   
                                  </div>
                              </div>
                              
                              <asp:Button ID="Button1" runat="server" Text="Save" class="btn btn-success" 
                                  onclick="Button1_Click" />
                              <asp:Label ID="Label1" runat="server" Text="Both passwords must match!" Visible="false" ForeColor="red"></asp:Label>
                        </div>
           			   </form><!-- /form-panel -->
                    </div>
                   
          		</div><!-- /col-lg-12 -->
                --%>
          	
          	
          		
          
      