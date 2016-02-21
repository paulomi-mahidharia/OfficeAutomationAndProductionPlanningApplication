<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="GenGRN.aspx.cs" Inherits="GenGRN" %>

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


        .marLeft
        {
            padding-left: 50px;
            padding-right: 70px;
        }
        .marAddLeft
        {
            padding-left: 200px;
        }
        .marAddLeftSmall
        {
            padding-left: 157px;
        }
        .marRight
        {
            padding-right: 0px;
        }
        .marSign
        {
            padding-left: 140px;
            padding-right: 140px;
            padding-bottom: 10px;
        }
        .marTable td, .marTable th
        {
           // padding: 10px 25px 10px 25px;
                padding:5px;
        }
        
        .marTableHeaderAmt
        {
            padding: 10px 60px 10px 60px;
        }
        .marButton
        {
            padding: 10px 120px 10px 100px;
        }
        .marEntryTable
        {
            padding-top: 10px;
            padding-bottom: 10px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div style="border: 1px solid black">
        <!-- Main block-->
        <div style="border: 1px solid black">
            <center>
                <h2>
                    Goods Received Note</h2>
            </center>
            <table>
                <tr>
                    <td class="marLeft">
                        <b>P.O. No. </b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" rowspan="4" class="marAddLeft">
                        <h4>
                            <b>BULLION FLEXIPACK PVT. LTD.</b></h4>
                        <br />
                        328/15,JAROD RASULABAD ROAD,<br />
                        NEAR REFERRAL HOSPITAL,<br />
                        OFF BARODA-HALOL EXPRESS HIGHWAY,<br />
                        JAROD,VADODARA-391 510.<br />
                        Fax. :-<br />
                        Tel. :+91-2668-274940/50<br />
                        bullionindia@gmail.com<br />
                        www.bullionflexipack.com<br />
                    </td>
                </tr>
                <tr>
                    <td class="marLeft">
                        <b>Supplier Name </b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox2" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="marLeft">
                        <b>Supplier Address </b>
                    </td>
                    <td>
                        :
                        <textarea id="TextArea1" cols="21" rows="3"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="marLeft">
                        <b>Manufacture Type </b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td class="marAddLeft" style="padding-top:15px">
                        <b>GRN No </b>
                    </td>
                    <td style="padding-top:15px">
                        :
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td class="marAddLeft">
                        <b>GRN Date </b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td class="marAddLeft">
                        <b>Excise Invoice </b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td class="marAddLeft">
                        <b>Comm. Invoice </b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td class="marAddLeft">
                        <b>Invoice Date </b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td class="marAddLeft">
                        <b>ECC No. </b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table><br />
        </div>
        <div style="border: 1px solid black; padding-top: 10px; padding-bottom: 10px" class="marLeft">
            <table border="1px" class="marTable tblcalculation">
                <tr>
                    <th class="marTableHeader">
                        No.
                    </th>
                    <th class="marTableHeader">
                        Material Code
                    </th>
                    <th class="marTableHeader">
                        Name of Goods Received
                    </th>
                    <th class="marTableHeader">
                        Tariff
                    </th>
                    <th class="marTableHeader">
                        No. Of Article
                    </th>
                    <th class="marTableHeader">
                        Qty
                    </th>
                    <th class="marTableHeader">
                        Rate Per
                    </th>
                    <th class="marTableHeaderAmt">
                        Amount
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr class="itemrow">
                            <td>
                                <%# (Container.ItemIndex + 1).ToString() %>
                            </td>
                            <td>
                                <%# Eval("RawMaterialCode") %>
                            </td>
                            <td>
                                <%# Eval("RawMaterialName") %>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox32" runat="server" Columns="8"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox33" runat="server" Columns="8"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblQuantity" CssClass="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRate" CssClass="txtRate calculateall2" runat="server" Columns="8"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAmount" CssClass="txtAmount" Enabled="false" runat="server" Columns="20"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div style="border: 1px solid black" class="marEntryTable">
            <table>
                <tr>
                    <td class="marLeft">
                    
                    </td>
                    <td>
                    </td>
                    <td class="marAddLeftSmall">
Sub Total
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtSubTotal" CssClass="txtSubTotal" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="marLeft">
                        <b>Transporter </b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                    </td>
                    <td class="marAddLeftSmall">
                        <b>Discount @</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDiscount" CssClass="txtDiscount calculateall2" runat="server" Text="0" Columns="4"></asp:TextBox>%
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtDiscountTotal" CssClass="txtDiscountTotal" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="marLeft">
                        <b>L.R.No </b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" class="marAddLeftSmall">
                        <b>Net Assessment Value</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtDiscountSubTotal" CssClass="txtDiscountSubTotal" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="marLeft">
                        <b>Truck No </b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                    </td>
                    <td class="marAddLeftSmall">
                        <b>Excise Duty @</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtExcise" runat="server" CssClass="txtExcise calculateall2" Text="0" Columns="4"></asp:TextBox>%
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtExciseDis" CssClass="txtExciseDis" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td class="marAddLeftSmall">
                        <b>Education Cess @</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEduCess" runat="server" CssClass="txtEduCess calculateall2" Text="0" Columns="4"></asp:TextBox>%
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtEduCessDis" CssClass="txtEduCessDis" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td class="marAddLeftSmall">
                        <b>S&H Edu Cess @</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSHEduCess" runat="server" CssClass="txtSHEduCess calculateall2" Text="0" Columns="4"></asp:TextBox>%
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtSHEduCessDis" CssClass="txtSHEduCessDis" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td colspan="2" class="marAddLeftSmall">
                        <b>Net Assessment Value</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtNetAss2" CssClass="txtNetAss2 calculateall2" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td class="marAddLeftSmall">
                        <b>C.S.T/G.S.T @</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCstGst" runat="server" CssClass="txtCstGst calculateall2" Text="0" Columns="4"></asp:TextBox>%
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtCstGstDis" CssClass="txtCstGstDis" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td colspan="2" class="marAddLeftSmall">
                        <b>Freight</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtFreight" CssClass="txtFreight calculateall2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td colspan="2" class="marAddLeftSmall">
                        <b>Total Value</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtTot2" CssClass="txtTot2 calculateall2" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td class="marAddLeftSmall">
                        <b>Octroi @</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOct" runat="server" CssClass="txtOct calculateall2" Text="0" Columns="4"></asp:TextBox>%
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtOctDis" CssClass="txtOctDis calculateall2" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td colspan="2" class="marAddLeftSmall">
                        <b>Loading/Off Loading</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtLoad" CssClass="txtLoad calculateall2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td colspan="2" class="marAddLeftSmall">
                        <b>Others</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtOther" CssClass="txtOther calculateall2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td colspan="2" class="marAddLeftSmall">
                        <b>TOTAL</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtGTotal" CssClass="txtGTotal calculateall2" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div style="border: 1px solid black">
            <br />
            <br />
            <br />
            <table>
                <tr>
                    <td class="marSign">
                        <b>Store Incharge</b>
                    </td>
                    <td class="marSign">
                        <b>Purchase Manager</b>
                    </td>
                    <td class="marSign">
                        <b>Director</b>
                    </td>
                </tr>
            </table>
        </div>
        <div style="border: 1px solid black" class="marButton dontprint">
            <center>
                <input type="button" value="Print/Save" class="btn btn-theme dontprint showdialog1" onclick="print1()" />
            </center>
        </div>
    </div>
    <div id="dialog" title="Basic dialog">
        <p>
            Please upload the PDF here.
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <center>
                <asp:Button ID="btnUpload" class="btn btn-theme dontprint" runat="server" Text="Upload" OnClick="btnUpload_OnClick" />
            </center>
        </p>
    </div>
</asp:Content>

