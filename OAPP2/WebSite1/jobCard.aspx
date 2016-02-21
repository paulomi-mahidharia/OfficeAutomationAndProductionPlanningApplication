<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="jobCard.aspx.cs" Inherits="jobCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
       .tdLabel
    {
        padding-left:30px;
        font-weight:bold;
        
    }
            .doprint
            {
                display: none;
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
            .doprint
            {
                display: block;
            }
        
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="border:1px solid black;">
<div style="border:0px solid black;text-align:center">
    <table border="1"  style="width:100%;">
<tr>
<td><h4><b>Bullion Flexipack Pvt.Ltd</b></h4></td>
</tr>
<tr>
<td><b>328/15, Jarod Rasulabad Road, Jarod, Vadodara</b></td>
</tr>
<tr>
<td><h4><b>Job card</b></h4></td>
</tr>
</table>
</div>
        <div style="border-bottom:1px solid black">
        <table style="text-align:left;width:100%;">
<tr>
<td class="tdLabel">
    <asp:Label ID="Label1" runat="server" Text="Job No:"></asp:Label>
</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</td>
<td class="tdLabel">
     <asp:Label ID="Label2" runat="server" Text="Date:"></asp:Label>
</td>

<td>
    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
</td>
</tr>

<tr>
<td class="tdLabel">
    <asp:Label ID="Label3" runat="server" Text="Customer Name:"></asp:Label>
</td>
<td>
    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
</td>
<td class="tdLabel">
     <asp:Label ID="Label4" runat="server" Text="PO No:"></asp:Label>
</td>

<td>
    <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
</td>
</tr>

<tr>
<td class="tdLabel">
    <asp:Label ID="Label5" runat="server" Text="Job Name:"></asp:Label>
</td>
<td>
    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
</td>
<td class="tdLabel">
     <asp:Label ID="Label6" runat="server" Text="PO Date:"></asp:Label>
</td>

<td>
    <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
</td>
</tr>

<tr>
<td class="tdLabel">
    <asp:Label ID="Label7" runat="server" Text="Material:"></asp:Label>
</td>
<td>
    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
</td>
<td class="tdLabel">
     <asp:Label ID="Label8" runat="server" Text="Del Date:"></asp:Label>
</td>

<td>
    <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
</td>
</tr>

<tr>
<td class="tdLabel">
    <asp:Label ID="Label9" runat="server" Text="Specification Code:"></asp:Label>
</td>
<td>
    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
</td>
<td class="tdLabel">
     <asp:Label ID="Label10" runat="server" Text="Order Qty:"></asp:Label>
</td>

<td>
    <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
</td>
</tr>

</table>
</div>
<div style="border:0px solid black;clear:both">
<br/>
<br/>
<h4><span style="font-weight:bold">Material Specification:</span></h4>
<table style="width:100%;margin-top:30px" border="1" >
<tr style="text-align:center;font-weight:bold" >
<td >
<span">Material<span>
</td>
<td>
Film Size
</td>
<td>
Qty(kg)
</td>
<td>
Job Length
</td>
<td>
Glue / Matt
</td>
</tr>
<tr>

</tr>
<tr style="text-align:center" >
<td >
    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
</td>
</tr>

</table>
</div>
<div style="border:1px solid black;">
<br/>
<br/>
<h4><span style="font-weight:bold">Printing:</span></h4>
<table style="width:100%;margin-top:30px" border="1" >
<tr style="text-align:center;font-weight:bold" >
<td >
No Colors
</td>
<td>
Cylinder Width
</td>
<td>
Cyl Circume
</td>
<td>
Cylinder Mfr
</td>
<td>
No of Ups
</td>
</tr>
<tr>

</tr>
<tr style="text-align:center">
<td >
    <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
</td>
</tr>
                <tr style="text-align: center">
                    <td>
                        <asp:DropDownList ID="DropDownList1" class="dontprint" runat="server" OnSelectedIndexChanged="DropDownList1_OnSelectedIndexChanged"
                            AutoPostBack="true" Style="width: 100%">
                            <asp:ListItem Text="Input(Kg)"></asp:ListItem>
                            <asp:ListItem Text="Input(gram)"></asp:ListItem>
                            <asp:ListItem Text="Input(tones)"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label18" class="doprint" runat="server" Text="Input(Kg)"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" class="dontprint" runat="server" OnSelectedIndexChanged="DropDownList2_OnSelectedIndexChanged"
                            AutoPostBack="true" Style="width: 100%">
                            <asp:ListItem Text="Input(Mts)"></asp:ListItem>
                            <asp:ListItem Text="Input(cm)"></asp:ListItem>
                            <asp:ListItem Text="Input(mm)"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label19" class="doprint" runat="server" Text="Input(Mts)"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList3" class="dontprint" OnSelectedIndexChanged="DropDownList3_OnSelectedIndexChanged"
                            AutoPostBack="true" runat="server" Style="width: 100%">
                            <asp:ListItem Text="Output(Kg)"></asp:ListItem>
                            <asp:ListItem Text="Output(gram)"></asp:ListItem>
                            <asp:ListItem Text="Output(tones)"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label20" class="doprint" runat="server" Text="Output(Kg)"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" placeholder="sign(Ptg Op)" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" placeholder="sign(stores)" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox24" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox25" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div style="border: 1px solid black;">
            <br />
            <br />
            <h4><span style="font-weight:bold">Slitting:</span></h4>
            <table style="width: 100%; margin-top: 30px" border="1">
                <tr style="text-align: center; font-weight: bold">
                    <td>
                        Coil</br> Width
                    </td>
                    <td>
                        Joint Tape
                    </td>
                    <td>
                        Coil OD
                    </td>
                    <td>
                        Core Type &</br>Size
                    </td>
                    <td>
                        Opening Direction
                    </td>
                </tr>
                <tr>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:TextBox ID="TextBox26" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox27" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox28" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox29" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox30" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        Height::
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox34" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        No of Ups
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox36" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:DropDownList ID="DropDownList4" class="dontprint" runat="server" OnSelectedIndexChanged="DropDownList1_OnSelectedIndexChanged"
                            AutoPostBack="true" Style="width: 100%">
                            <asp:ListItem Text="Input(Kg)"></asp:ListItem>
                            <asp:ListItem Text="Input(gram)"></asp:ListItem>
                            <asp:ListItem Text="Input(tones)"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label21" class="doprint" runat="server" Text="Input(Kg)"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList5" class="dontprint" runat="server" OnSelectedIndexChanged="DropDownList2_OnSelectedIndexChanged"
                            AutoPostBack="true" Style="width: 100%">
                            <asp:ListItem Text="Output(Mts)"></asp:ListItem>
                            <asp:ListItem Text="Output(cm)"></asp:ListItem>
                            <asp:ListItem Text="Output(mm)"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label22" class="doprint" runat="server" Text="Input(Mts)"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList6" class="dontprint" OnSelectedIndexChanged="DropDownList3_OnSelectedIndexChanged"
                            AutoPostBack="true" runat="server" Style="width: 100%">
                            <asp:ListItem Text="Output(Kg)"></asp:ListItem>
                            <asp:ListItem Text="Output(gram)"></asp:ListItem>
                            <asp:ListItem Text="Output(tones)"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label23" class="doprint" runat="server" Text="Output(Kg)"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox4" placeholder="sign(Ptg Op)" runat="server"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox82" runat="server"></asp:TextBox>
                    </td>
                  
                </tr>
            </table>
        </div>
        <div style="border: 1px solid black;">
            <br />
            <br />
            <h4><span style=" font-weight: bold">Sleeving/Cutting:</span></h4>
            <table style="width: 100%; margin-top: 30px" border="1">
                <tr style="text-align: center;font-weight: bold">
                    <td>
                        Sleeve</br> Width(mm)
                    </td>
                    <td>
                        height
                    </td>
                    <td>
                        Over lap
                    </td>
                    <td>
                        Hot melt
                    </td>
                    <td>
                        Perforation
                    </td>
                </tr>
                <tr>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:TextBox ID="TextBox41" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox42" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox43" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox44" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox45" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
              
                 <tr style="text-align: center">
                    <td  colspan="2">
                        <asp:DropDownList ID="DropDownList7" class="dontprint" runat="server" OnSelectedIndexChanged="DropDownList1_OnSelectedIndexChanged"
                            AutoPostBack="true" Style="width: 50%;text-align:left;">
                            <asp:ListItem Text="Input(Kg)"></asp:ListItem>
                            <asp:ListItem Text="Input(gram)"></asp:ListItem>
                            <asp:ListItem Text="Input(tones)"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label24" class="doprint" runat="server" Text="Input(Kg)"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList8" class="dontprint" runat="server" OnSelectedIndexChanged="DropDownList2_OnSelectedIndexChanged"
                            AutoPostBack="true" Style="width: 100%">
                            <asp:ListItem Text="Output(Mts)"></asp:ListItem>
                            <asp:ListItem Text="Output(cm)"></asp:ListItem>
                            <asp:ListItem Text="Output(mm)"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label25" class="doprint" runat="server" Text="Input(Mts)"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="TextBox5" placeholder="sign(Ptg Op)" runat="server"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr style="text-align: center">
                    <td colspan="2" style="text-align:center" >
                        <asp:TextBox ID="TextBox83" runat="server"></asp:TextBox>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="TextBox85" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox86" runat="server"></asp:TextBox>
                    </td>
                  
                </tr>
            </table>
        </div>
        <div style="border:1px solid black;">
<br/>
<br/>
<h4><span style="font-weight:bold">Packing:</span></h4>
<table style="width:100%;margin-top:30px" border="1" >
<tr style="text-align:center;font-weight:bold" >
<td >
Box Type
</td>
<td>
Box Size
</td>
<td>
Sleeve Packing CB strip
</td>
<td>
Special Remark
</td>

</tr>
<tr>

</tr>
<tr style="text-align:center" >
<td >
    <asp:TextBox ID="TextBox35" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox37" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox38" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox39" runat="server"></asp:TextBox>
</td>

</tr>

</table>
<table style="width:100%" border="1" >
<tr style="text-align:center;font-weight:bold" >
<td >
Sorting Wastage<br/>(Kg)
</td>
<td>
Total Pack Qty<br/>(Nos)
</td>
<td>
Sign(Dispatch)
</td>


</tr>

<tr style="text-align:center" >
<td >
    <asp:TextBox ID="TextBox40" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox46" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox47" runat="server"></asp:TextBox>
</td>


</tr>

</table>

</div>
<div style="border:1px solid black;">
<br/>
<br/>
<h4><span style="font-weight:bold">Dispatch Details:</span></h4>
<table style="width:100%;margin-top:30px;" border="1" >
<tr style="text-align:center;font-weight:bold">
<td>Sr.No.</td>
<td>Date</td>
<td>Invoice No</td>
<td>No of Sleeves</td>
<td>No of <br/>Box</td>
<td>Net Wt.</td>
</tr>
<tr style="text-align:center">
<td>
    <asp:TextBox ID="TextBox48" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox49" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox50" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox51" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox52" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox53" runat="server"></asp:TextBox></td>
</tr>
<tr style="text-align:center">
<td>
    <asp:TextBox ID="TextBox54" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox55" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox56" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox57" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox58" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox59" runat="server"></asp:TextBox></td>
</tr>
<tr style="text-align:center">
<td>
    <asp:TextBox ID="TextBox60" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox61" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox62" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox63" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox64" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox65" runat="server"></asp:TextBox></td>
</tr>
<tr style="text-align:center">
<td>
    <asp:TextBox ID="TextBox66" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox67" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox68" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox69" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox70" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox71" runat="server"></asp:TextBox></td>
</tr>
<tr style="text-align:center">
<td>
    <asp:TextBox ID="TextBox72" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox73" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox74" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox75" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox76" runat="server"></asp:TextBox></td>
<td>
    <asp:TextBox ID="TextBox77" runat="server"></asp:TextBox></td>
</tr>


</table>
</div>
<div style="border:0px solid black;">

<table><tr>
<td>
<h4><span style="font-weight:bold;text-align:center">
Special Remark:
</span></h4></td>
<td><textarea id="TextArea1" cols="30" rows="5" style="margin-top:10px"></textarea></td>
</tr>
</table>
</div>
<div style="border:0px solid black;">
<table style="width:100%;margin-top:30px" border="1" >
<tr style="text-align:center;font-weight:bold" >
<td >
Prepared By
</td>
<td>
Approved By
</td>
<td>
Checked / Cleared By
</td>
<td>
Closed By/Date
</td>

</tr>
<tr>

</tr>
<tr style="text-align:center" >
<td >
    <asp:TextBox ID="TextBox78" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox79" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox80" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox81" runat="server"></asp:TextBox>
</td>

</tr>

</table>
</div>
    </div>
    <div style="border: 1px solid black" class="marButton dontprint">
        <center>
            <input type="button" value="Print/Save" class="btn btn-theme dontprint showdialog1" onclick="print1()" />
        </center>
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
