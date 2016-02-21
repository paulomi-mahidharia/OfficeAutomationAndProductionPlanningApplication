<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <p class="centered">
     <asp:Image ID="Image1" runat="server" class="img-circle" width="260" /></p>
 <p class="centered">
     <!--main content start-->
      
          	<!-- BASIC FORM ELELEMNTS -->
          	<div class="row mt">
          		
                      <div class="form-horizontal style-form">
                          
                        
                      </div>
                    	
          	</div><!-- /row -->
          	
          
          	
          	<!-- INPUT MESSAGES -->
          	<div class="row mt">
          		<div class="col-lg-12">
          			<div class="form-panel">
                  	  <h4 class="mb"><i class="fa fa-angle-right"></i> </h4>
                          <div class="form-horizontal tasi-form">
                              <div class="form-group has-success">
                               <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Name:</label>
                                  <div class="col-lg-10">
                                      <asp:Label ID="Label1"  runat="server" Text="Label"></asp:Label>
                                  </div>
                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2"  for="inputSuccess">Address:</label>
                                  <div class="col-lg-10">
                                      <asp:Label ID="Label2"  runat="server" Text="Label"></asp:Label>
                                  </div>
                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Email:</label>
                                  <div class="col-lg-10">
                                       <asp:Label ID="Label3"  runat="server" Text="Label"></asp:Label>
                                  </div>
                                  
                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Phone No:</label>
                                  <div class="col-lg-10">
                                     <asp:Label ID="Label4"   runat="server" Text="Label"></asp:Label>
                                  </div>
                                  
                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Date of Birth</label>
                                  <div class="col-lg-10">
                                      <asp:Label ID="Label5"  runat="server"  Text="Label"></asp:Label>
                                  </div>
                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Date of Join</label>
                                  <div class="col-lg-10">
                                      <asp:Label ID="Label6"  runat="server" Text="Label"></asp:Label>
                                  </div>

                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Gender</label>
                                  <div class="col-lg-10">
                                      <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                                  </div>
                              </div>
                              <div class="form-group has-success">
                                  <label class="col-sm-2 control-label col-lg-2" for="inputSuccess">Designationt:</label>
                                  <div class="col-lg-10">
                                      <asp:Label ID="Label8"  runat="server" Text="Label"></asp:Label>
                                  </div>
                              </div>
                              
                               
                          </div>
          			</div><!-- /form-panel -->
          		</div><!-- /col-lg-12 -->
          	</div><!-- /row -->
          	
          	
          		
          
          		
          	</div><!-- /row -->
          	
 </p>
</asp:Content>

