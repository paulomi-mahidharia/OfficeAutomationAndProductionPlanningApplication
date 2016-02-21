<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="RevenueReport.aspx.cs" Inherits="RevenueReport" %>

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
            <a href="AllReports.aspx"> <span ID="hideButton"  class="btn btn-round btn-danger" style="width:100px">Back</span></a>
            <br />
            <br />
<div class="darkblue-panel pn">
                        <h5>
                            REVENUE</h5>
                    
                    <div class="chart mt">
                        <div id="individualInvoiceAmount" runat="server" class="sparkline" data-type="line"
                            data-resize="true" data-height="75" data-width="90%" data-line-width="1" data-line-color="#fff"
                            data-spot-color="#fff" data-fill-color="" data-highlight-line-color="#fff" data-spot-radius="4"
                            data-data="[200,135,667,333,526,996,564,123,890,464,655]">
                        </div>
                    </div>
                    <p class="mt">
                        <b>
                            <asp:Label ID="txtTotIncome" runat="server" Text="Label"></asp:Label></b><br />
                        Monthly Income Generated</p>
               </div>
                <br /><br />
            <br /><br />
            <br /><br />
            

            
            
            </div>
            </div>
            </div>
</asp:Content>

