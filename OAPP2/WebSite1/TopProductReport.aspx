<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="TopProductReport.aspx.cs" Inherits="TopProductReport" %>

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
           
<div class="col-md-4 col-sm-4 mb">
                <div class="white-panel pn">
                    <div class="white-header">
                        <h5>
                            TOP PRODUCT</h5>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-xs-6 goleft">
                            <p>
                                <i class="fa fa-heart"></i>
                                <asp:Label ID="OrderNumber" CssClass="OrderNumber" runat="server" Text="Label"></asp:Label></p>
                        </div>
                        <div class="col-sm-6 col-xs-6">
                        </div>
                    </div>
                    <div class="centered">
                        <img id="topProimg" src="" runat="server" width="120" height="120" alt="No image available" />
                    </div>
                    <div>
                        <p>
                            <b>
                                <asp:Label ID="ProName" CssClass="ProName" runat="server" Text="Label"></asp:Label></b></p>
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

