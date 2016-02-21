<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- BASIC FORM ELELEMNTS -->
          	<div class="row mt">
          		
                      <div class="form-horizontal style-form">
                          
                        
                      </div>
                    	
          	</div><!-- /row -->
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

          	
          	<!-- INPUT MESSAGES -->
          	<div class="row mt">
          		<div class="col-lg-12">
          			<div class="form-panel">
                  	  <h4 class="mb"><i class="fa fa-angle-right"></i> Change Password</h4>
                          <div class="form-horizontal tasi-form" method="get">
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Original Password:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="TextBox1" class="form-control" TextMode = "Password" Width="50%" runat="server"></asp:TextBox> 
                                      
                                  </div>
                              </div>
                              
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">New Password:</label>
                                  <div class="col-lg-10">
                                      <asp:TextBox ID="txtPassword" class="form-control" TextMode = "Password" Width="50%" runat="server"></asp:TextBox> 
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
                                  <ajax:PasswordStrength ID="pwdStrength" TargetControlID="txtPassword" StrengthIndicatorType="Text" PrefixText="Strength:" HelpStatusLabelID="lblhelp" PreferredPasswordLength="8" 
MinimumNumericCharacters="1" MinimumSymbolCharacters="1" TextStrengthDescriptions="Very Poor;Weak;Average;Good;Excellent" TextStrengthDescriptionStyles="VeryPoorStrength;WeakStrength;
AverageStrength;GoodStrength;ExcellentStrength" runat="server" />
<ajax:PasswordStrength ID="PasswordStrength1" TargetControlID="txtpwd1" StrengthIndicatorType="BarIndicator" PrefixText="Strength:" HelpStatusLabelID="lblhelp1" PreferredPasswordLength="8" 
MinimumNumericCharacters="1" MinimumSymbolCharacters="1" BarBorderCssClass="BarBorder" TextStrengthDescriptionStyles="VeryPoorStrength;WeakStrength;
AverageStrength;GoodStrength;ExcellentStrength" runat="server" />

           			   </div><!-- /form-panel -->
                    </div>
          		</div><!-- /col-lg-12 -->
          	</div><!-- /row -->
          	
          	
          		
          
          		
          	</div><!-- /row -->

</asp:Content>

