<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="PrintQuotation.aspx.cs" Inherits="PrintQuotation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .margin
        {
            margin: 35px;
        }
        .firsttd
        {
            font-weight: bold;
            padding-right: 100px;
        }
        .marTableHeader
        {
            padding: 10px 65px 10px 65px;
        }
        
        @media print
        {
        
            .dontprint
            {
                display: none;
            }
            input, textarea
            {
                border: 0px solid gray;
            }
        
        
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="PrintDiv" runat="server">
        <div>
            <center>
                <h2>
                    QUOTATION</h2>
            </center>
        </div>
        <div>
            <table class="margin" width="2200px" style="caption-side: top">
                <tr>
                    <td style="caption-side: top">
                        To,<br />
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label><br />
                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label><br />
                        Phone No:<asp:Label ID="Label7" runat="server" Text="Label"></asp:Label><br />
                        Email:<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label><br />
                        Date:<asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="caption-side: top">
                        From,<br />
                        BULLION FLEXIPACK PVT. LTD.
                        <br />
                        328/15,JAROD RASULABAD ROAD,<br />
                        NEAR REFERRAL HOSPITAL,<br />
                        OFF BARODA-HALOL EXPRESS HIGHWAY,<br />
                        JAROD,VADODARA-391 510.<br />
                        Fax. :-<br />
                        Tel. :+91-2668-274940/50<br />
                        bullionindia@gmail.com www.bullionflexipack.com
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="margin" border="1px">
                <tr>
                    <td class="marTableHeader">
                        S.N.
                    </td>
                    <td class="marTableHeader">
                        Description
                    </td>
                    <td class="marTableHeader">
                        Size(W x H)
                    </td>
                    <td class="marTableHeader">
                        Colors
                    </td>
                    <td class="marTableHeader">
                        MOQ
                    </td>
                    <td class="marTableHeader">
                        Rate per pc.
                    </td>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# (Container.ItemIndex + 1).ToString() %>
                            </td>
                            <td>
                                <%# Eval("ProductName") %>
                            </td>
                            <td>
                                <%# Eval("Size") %>
                            </td>
                            <td>
                                <%# Eval("Colors") %>
                            </td>
                            <td>
                                <%# Eval("MOQ") %>
                            </td>
                            <td>
                                <%# Eval("Rate") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="margin">
            <div>
                <h5 style="text-decoration: underline">
                    Terms & Conditions</h5>
            </div>
            <div>
                <table>
                    <tr>
                        <td class="firsttd">
                            1. Transport
                        </td>
                        <td>
                            :Freight and Octroi Shall be borne by you at actual.
                        </td>
                    </tr>
                    <tr>
                        <td class="firsttd">
                            2. Taxes
                        </td>
                        <td>
                            :CST 2% against form "C",else 5% (VAT 5% shall be charged for biling within Gujarat.)
                        </td>
                    </tr>
                    <tr>
                        <td class="firsttd">
                            3. C. Excise
                        </td>
                        <td>
                            :12.36% shall be charged extra.
                        </td>
                    </tr>
                    <tr>
                        <td class="firsttd">
                            4. Dev. Cost
                        </td>
                        <td>
                            :Rs. 9000 per cyllinder per colour per varient + levis , shall be charged extra
                            for the 1st time only in advance.
                        </td>
                    </tr>
                    <tr>
                        <td class="firsttd">
                            5. Payment
                        </td>
                        <td>
                            :Against Deliery
                        </td>
                    </tr>
                    <tr>
                        <td class="firsttd">
                            6. Delivery
                        </td>
                        <td>
                            :1st time 3 weeks, repeat 15 days.
                        </td>
                    </tr>
                    <tr>
                        <td class="firsttd">
                            7. Validity
                        </td>
                        <td>
                            30 days.
                        </td>
                    </tr>
                    <tr>
                        <td class="firsttd">
                            8. Quantity
                        </td>
                        <td>
                            10% to 15% +- shall be permissible
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div>
            <!-- <asp:Button ID="Button1" runat="server" Text="Print" OnClientClick="javascript:MyPrint();" />-->
            <div style="border: 1px solid black" class="marButton dontprint">
            <center>
                <input type="button" value="Print/Save" class="btn btn-theme dontprint showdialog1"
                    runat="server" onclick="print1()" />
            </center>
            </div>
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
