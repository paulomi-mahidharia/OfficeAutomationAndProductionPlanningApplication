<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="BestOrderReport.aspx.cs" Inherits="BestOrderReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
 
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
             <a href="AllReports.aspx"> <span ID="hideButton"  class="btn btn-round btn-danger" style="width:100px" >Back</span></a>
            
            <br />
            <br />
<div class="col-md-4 mb">
                <!-- WHITE PANEL - TOP USER -->
                <div class="white-panel pn">
                    <div class="white-header">
                        <h5>
                            BEST ORDER</h5>
                    </div>
                    <p>
                        <img id="proimg" runat="server" src="" class="img-circle" width="80" height="100"
                            alt="No image available" /></p>
                    <p>
                        <b>
                            <asp:Label ID="bestOrd" CssClass="bstOrd" runat="server" Text="Label"></asp:Label></b></p>
                    <div class="row">
                        <div class="col-md-6">
                            <p class="small mt">
                                FROM</p>
                            <p>
                                <asp:Label ID="txtCustomer" CssClass="totalAmt" runat="server" Text="Label"></asp:Label></p>
                        </div>
                        <div class="col-md-6">
                            <p class="small mt">
                                TOTAL ORDER</p>
                            <p>
                                <asp:Label ID="totalAmt" CssClass="totalAmt" runat="server" Text="Label"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <br /><br />
            <br /><br />
            <br /><br />
            <br /><br />
            <br /><br />
            <br /><br />
            <br /><br />
            <br /><br />
            
            </div>
            </div>
            </div>
</asp:Content>

