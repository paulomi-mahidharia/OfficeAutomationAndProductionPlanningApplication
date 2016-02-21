<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="GenInvoice.aspx.cs" Inherits="GenInvoice" %>

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
        .marAddLeftSmall
        {
            padding-left:310px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <div>
        Removal of Excisable Goods from factory : Rule 11 of Central Excise Rules 2002.<br />
        (Monthly payment of duty under Rule 8)<br /></div>
        
        <div>
        <table  style="width:97%">
        <tr style="text-align:right"><td style="padding-left:100px">
        
        <img src="assets/img/logo.jpg" style="width:200px;margin-bottom:70px;"></td>
        <td style="padding-right:25px"><h4>
                          <b>BULLION FLEXIPACK PVT. LTD.</b></h4>
                        <br />
                        328/15,JAROD RASULABAD ROAD,<br />
                        NEAR REFERRAL HOSPITAL,<br />
                        OFF BARODA-HALOL EXPRESS HIGHWAY,<br />
                        JAROD,VADODARA-391 510.<br />
                        Fax. :-<br />
                        Tel. :+91-2668-274940/50<br />
                        </td>
        </tr>
        </table>
    </div>
    <br />
    <div><h4><center><b>INVOICE</b></center></h4></div>
<div style="border:1px solid black;width:1000px">
<table style="width:1000px">
<tr>
<td style="padding-left:10px;border:1px solid black">
<b style="font-size:20px">Details of Manufacturer</b>
<br/>
C. Ex Read. No : 
    <asp:TextBox ID="TextBox1" runat="server" value="AABCB5401CEM002"></asp:TextBox>
<br/>
C.Excise Range : II<br/>
Add :624,Near Shily Engineering,GIDC Estate,
<br/>Halol-273459
<br/>Division : Waghodia
<br/>Commisionerate : Vadodara-II
<br/>C.S.T.No. 24691602026 DT.01.10.2005
<br/>G.S.T No. 24191602026 DT.01.10.2005
<br/>C.I.N No :-U25202Gj2001PTC039141
</td>
<td style="padding-bottom:170px;padding-left:40px;border:1px solid black">
<b style="font-size:20px;padding-left:0px">Self Authentication</b>
</td>
<td style="text-align:center;border:1px solid black">
<br />
<table id="innertab">
<tr >
<td style="text-align:left;padding-left:5px">Invoice No :</td>
<td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br /></td>
</tr>
<tr>
<td style="text-align:left;padding-left:5px">Invoice Date :</td>
<td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br /></td>
</tr>
<tr>
<td style="text-align:left;padding-left:5px">Order Form No :</td>
<td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br /></td>
</tr>
<tr>
<td style="text-align:left;padding-left:5px">Order Date :</td>
<td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br /></td>
</tr>
<tr>
<td style="text-align:left;padding-left:5px">Date Of Removal :</td>
<td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><br /></td>
</tr>
<tr>
<td style="text-align:left;padding-left:5px">Date of Preparation :</td>
<td><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox><br /></td>
</tr>
</table>
<br />

<div style="border-top:1px solid black">
<br />
Rule 42 of the Gujarat Value Added Tax Rule 2006
</div>
</td>
<%--<td  style="text-align:center;border:1px solid black;border-right:0px" >

<br />
Invoice No : <br />
<br />

Invoice Date :<br /><br />
  Order Form No :<br /><br /><br />

   Order Date :<br /><br />
    Date Of Removal :<br /><br />
      Date of Preparation :<br /><br />
 
      </td>
      <td style="text-align:left;border:1px solid black;border-left:0px">
      <br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br /><br />

    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br /><br />
  
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br /><br />
   
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br /><br />
   
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><br /><br />
  
    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox><br /><br />

</td>
--%>
</tr>
</table>

<div style="width:1000px">
<div style="float:left;border-right:1px solid black;border-left:1px solid black;width:330px;height:280px;padding-left:10px"><br/>
<b style="">Buyer's Name And Address :</b><br/><br/>
    <b style=""><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></b><br/>
    <textarea id="TextArea1" runat="server" cols="30" rows="4"></textarea><br/><br/>
    VAT L.S.T. 
    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox><br/>
    VAT C.S.T.
    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox><br/>
    </div>
<div style="float:left;border-right:1px solid black;margin-left:50px;width:280px;height:280px;padding-left:10px"><br/>
<b>Consignee Address :</b><br/><br/>
    <b><asp:Label ID="Label2" runat="server" Text="Label" ></asp:Label></b><br/>
    <textarea id="txt" runat="server" cols="30" rows="4"></textarea><br/><br/>
    VAT L.S.T. 
    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox><br/>
    VAT C.S.T.
    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox><br/>
</div>
<div style="float:left;margin-left:10px;height:280px;width:282px;margin-right:10px"><br/>
<b>Details of Consignee :</b><br/><br />
<table>
<tr >
<td style="text-align:left;padding-left:5px">C. Ex Regd. No. :</td>
<td><asp:TextBox ID="TextBox14" runat="server"></asp:TextBox><br /></td>
</tr>
<tr>
<td style="text-align:left;padding-left:5px">C. Excise Range :</td>
<td><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox><br /></td>
</tr>
<tr>
<td style="text-align:left;padding-left:5px">Division :</td>
<td><asp:TextBox ID="TextBox13" runat="server"></asp:TextBox><br /></td>
</tr>
<tr>
<td style="text-align:left;padding-left:5px">Collectorate :</td>
<td><asp:TextBox ID="TextBox15" runat="server"></asp:TextBox><br /><br /></td>
</tr>
<tr>
<td style="text-align:left;padding-left:5px">VAT L.S.Ts :</td>
<td><asp:TextBox ID="TextBox16" runat="server"></asp:TextBox><br /></td>
</tr>
<tr>
<td style="text-align:left;padding-left:5px">VAT C.S.T. :</td>
<td><asp:TextBox ID="TextBox17" runat="server"></asp:TextBox><br /></td>
</tr>
</table>

</div>

<div style="border-top:1px solid black;padding-top:10px;width:1000px ;padding-bottom:10px">
<br />
<table style="border:1px solid black;padding-top:10px;margin-left: 10px;text-align:center;width:95%;padding-bottom:10px">
<tr>
<td>Name of Excisable Goods :
</td>
<td>
    <asp:TextBox ID="TextBox19" runat="server" Width="100%"></asp:TextBox> </td>
    <td>Document sent through :</td>
    <td>
    <asp:TextBox ID="TextBox29" runat="server" Width="100%"></asp:TextBox> </td>
</tr>

<tr>
<td>Tariff Heading/ Sub-Heading :</td>
<td>
    <asp:TextBox ID="TextBox30" runat="server" Width="100%"></asp:TextBox> </td>
    <td>Payment Terms :</td>
    <td>
    <asp:TextBox ID="TextBox31" runat="server" Width="100%"></asp:TextBox> </td>
</tr>
</table>
<div>
</div>
<div>
</div>



    <div style="border:1px solid black;padding-top: 10px;width:1000px ;padding-bottom: 10px;clear:both">
            <table border="1px"  class="marTable tblcalculation" style="margin-left: 10px;text-align:center;width:95%;">
                <tr style="font-weight:bold;padding-left:20px;font-size:15  px">
                    <th class="marTableHeader">
                    sr<br/>
                        No.
                    </th>
                    <th class="marTableHeader">
                       Description and Specification of Goods
                    </th>
                    
                    <th class="marTableHeader">
                        No. and Desp.<br/>
                        of packing
                    </th>
                    <th class="marTableHeader">
                       Total Qty in <br/>
                       Nos./Kgs.
                    </th>
                    <th class="marTableHeader">
                       Rate Per <br/>
                       Nos. in Rs
                    </th>
                    <th class="marTableHeader">
                        Amount <br/>
                        in Rs.
                    </th>
                    
                </tr>
               
                        <tr class="itemrow" style="padding-top:10px">
                            <td>
                              1
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox18" width="100%" runat="server"></asp:TextBox>
                            </td>
                            
                            <td>
                                <asp:TextBox ID="TextBox32" runat="server" width="100%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox33" runat="server" width="100%"></asp:TextBox>
                            </td>
                            <td>
                               
                               <asp:TextBox ID="TextBox20" runat="server" width="100%"></asp:TextBox></td>
                            
                            <td>
                                <asp:TextBox ID="txtAmount" CssClass="txtAmount calculateall" runat="server" width="100%"></asp:TextBox>
                            </td>
                           
                        </tr>
                   
            </table>
        </div>
                    <div style="border: 1px solid black" >
                    <br />
            <table>
                
                <tr>
                    <td class="marLeft">
                        <b>Goods Despatch From </b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                    </td>
                    <td class="marAddLeftSmall">
                        <b>Discount  %</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDiscount" CssClass="txtDiscount calculateall" runat="server" Text="0" Columns="4"></asp:TextBox>%
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtDiscountTotal" CssClass="txtDiscountTotal" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="marLeft">
                        <b>Mode of Transport </b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" class="marAddLeftSmall">
                        <b>Total :</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtDiscountSubTotal" CssClass="txtDiscountSubTotal" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="marLeft">
                        <b> L.R.No & Date</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
                    </td>
                    <td class="marAddLeftSmall">
                        <b>Packing & Forwarding</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPack" runat="server" CssClass="txtPack calculateall" Text="0" Columns="4"></asp:TextBox>%
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtPackDis" CssClass="txtPackDis" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                     <td class="marLeft">
                        <b> P.R.No & Date</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox25" runat="server"></asp:TextBox>
                    </td>
                   
                   
                    <td class="marAddLeftSmall">
                        <b>Total Assembly Value</b>
                    </td>
                    <td>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtTotalAss" CssClass="txtTotalAss" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                  <td class="marLeft">
                        <b> Notificatio No.</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox24" runat="server"></asp:TextBox>
                    </td>
                    
                    <td class="marAddLeftSmall">
                        <b>c.Excise Duty@</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtExcise" runat="server" CssClass="txtExcise calculateall" Text="0" Columns="4"></asp:TextBox>%
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtExciseDis" CssClass="txtExciseDis" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                     <td class="marLeft">
                        <b>Sales Against Form</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox27" runat="server"></asp:TextBox>
                    </td>
                    <td  class="marAddLeftSmall">
                        <b>Edu. cess</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEduCess" runat="server" CssClass="txtEduCess calculateall" Text="0" Columns="4"></asp:TextBox>%
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtEduCessDis" CssClass="txtEduCessDis" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                     <td >
                        <b>Exice Duty Rs.</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="TextBox28" runat="server"></asp:TextBox>
                    </td>
                    <td class="marAddLeftSmall">
                        <b>S & H Edu. Cess @</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSHECess" runat="server" CssClass="txtSHECess calculateall" Text="0" Columns="4"></asp:TextBox>%
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtSHECessDis" CssClass="txtSHECessDis" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td colspan="2" class="marAddLeftSmall">
                        <b>Additional Duty</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtAddDuty" CssClass="txtAddDuty calculateall" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td colspan="2" class="marAddLeftSmall">
                        <b>Total</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtTot2" CssClass="txtTot2 calculateall" runat="server" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td class="marAddLeftSmall">
                        <b>C.S.T/G.S.T @</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCSTGST" runat="server" CssClass="txtCSTGST calculateall" Text="0" Columns="4"></asp:TextBox>%
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtCSTGSTDis" CssClass="txtCSTGSTDis calculateall" runat="server" disabled="disabled"></asp:TextBox>
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
                        <asp:TextBox ID="txtFreight" CssClass="txtFreight calculateall" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td colspan="2" class="marAddLeftSmall">
                        <b>Grand Total</b>
                    </td>
                    <td>
                        :
                        <asp:TextBox ID="txtGTotal" CssClass="txtGTotal calculateall" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
            </table>
            <br />
        </div>
        <div>
        <div style="width:1000px;border-left:1px solid black">
        <div style="margin-left:10px;border-bottom:0px;width:600px">
        Ceritified that the particulars given above are true and correct and the amount <br/>
        indicated represents the price actually charged and that there is no flow aditional<br/>
        consideration directly or indirectly from the buyer. OR certified that the particulars<br/>
        given above are true and correct and the amount indicated is provisional as<br/>
        additional consideration will be received from the buyer on account of.<br/></div>
        <div style="border-left:0px solid black"><p style="margin-left:700px;margin-top:26px;font-weight:bold"> For BULLION FLEXIPACK PVT.LTD.</p></div></div>
      <div style="float:left">
         <div style="float:left;border:0px solid black;width:250px"> <p style="margin-left:10px;margin-top:50px;font-weight:bold"> Subject to VADODARA Jurisdiction</p></div>
         <div style="float:left;width:200px;border:0px solid black;margin-left:120px"> <p style="width:200px;border-bottom:1px solid black;margin-left:0px;margin-top:80px"></p>
       <p style="margin-left:70px;margin-top:20px"> Checked By</p></div>
         </div>
        
        <div style="float:right;border-right:2px solid black">
       
       <p style="width:200px;border-bottom:1px solid black;margin-left:140px;margin-top:80px"></p>
       <p style="margin-left:170px;margin-top:20px"> Authorised Signature</p>
        </div>
      </div>
      <div style="width:1000px;border-left:1px solid black">
      
      </div>
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

