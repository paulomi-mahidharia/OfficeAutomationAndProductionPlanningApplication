<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-9 main-chart">
        <%--<div class="row mtbox">
           
            
          <center><h1>Welcome to BULLION</h1></center>
            
            
        </div>--%>
        <!-- /row mt -->
        <div class="row mt">
            <!-- SERVER STATUS PANELS -->
            <div class="col-md-4 col-sm-4 mb" id="divAtt" runat="server">
            <a href="AttendanceReport.aspx#">
                <div class="white-panel pn donut-chart">
                    <div class="white-header">
                        <h5>
                            TODAY'S ATTANDANCE</h5>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-xs-6 goleft">
                            <p>
                                <i class="fa fa-database"></i>
                                <asp:Label ID="lblPResentPerc" CssClass="lblPResentPerc" runat="server" />%</p>
                        </div>
                    </div>
                    <canvas id="serverstatus01" height="120" width="120"></canvas>
                </div></a>
                <! --/grey-panel -->
            </div>
            <!-- /col-md-4-->
            <div class="col-md-4 col-sm-4 mb">
            <a href="TopProductReport.aspx#">
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
                </div></a>
            </div>
            <!-- /col-md-4 -->
            <div class="col-md-4 mb">
            <a href="BestOrderReport.aspx#">
                <!-- WHITE PANEL - TOP USER -->
                <div class="white-panel pn">
                    <div class="white-header">
                        <h5>BEST ORDER</h5>
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
                </div></a>
            </div>
            <!-- /col-md-4 -->
        </div>
        <!-- /row -->
        <div class="row">
            <!-- TWITTER PANEL -->
            <div class="col-md-4 mb">
            <a href="Report1.aspx#">
                <div class="darkblue-panel pn">
                    <div class="darkblue-header">
                        <h5>
                            Customer Product Report</h5>
                    </div>
                   
                   <div class="form-horizontal tasi-form">
                    <table title="Attendance Percentages" id="Table2" summary="pieDescription"
                        data-attc-createchart="true" data-attc-coldescription="Th1" data-attc-colvalues="Th2"
                        data-attc-location="Div4" data-attc-hidetable="true" data-attc-type="pie"
                        data-attc-googleoptions='{"is3D":true}' data-attc-controls='{}'>
                        <thead>
                            <tr>
                                <th id="Th3">Customer</th>
                                <th id="Th4">Products</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater3" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Name") %></td>
                                        <td><%# Eval("ProductsCount")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div id="Div4">
                    </div>
                </div>

                </div>
                <! -- /darkblue panel --></a>
            </div>
            <!-- /col-md-4 -->
            <div class="col-md-4 col-sm-4 mb">
            <a href="Stock.aspx#">
                <!-- REVENUE PANEL -->
                <div class="darkblue-panel pn">
                    <div class="darkblue-header">
                        <h5>
                           TODAY'S STOCK</h5>
                           
                    </div>
								
								
							
                            <div class="form-horizontal tasi-form">
                    <div id="Div2" class="form-horizontal tasi-form" runat="Server">
                    <table title="Attendance Percentages" id="Table1" summary="pieDescription"
                        data-attc-createchart="true" data-attc-coldescription="pieDescription" data-attc-colvalues="pieValues"
                        data-attc-location="Div3" data-attc-hidetable="true" data-attc-type="line"
                        data-attc-googleoptions='{"is3D":true}' data-attc-controls='{}' >
                        <thead>
                            <tr>
                                <th id="Th1">Raw Material</th>
                                <th id="Th2">Stock</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("RawMaterialName") %></td>
                                        <td><%# Eval("Stock")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div id="Div3">
                    </div>
                </div>
                  </div>

                


                  </div></a>


                  </div>
           
            <!-- /col-md-4 -->
            <div class="col-md-4 col-sm-4 mb">
            <a href="RevenueReport.aspx#">
                <!-- REVENUE PANEL -->
                <div class="darkblue-panel pn">
                    <div class="darkblue-header">
                        <h5>
                            REVENUE</h5>
                    </div>
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
                </div></a>
            </div>
            <!-- /col-md-4 -->
        </div>
        <!-- /row -->
        <div style="width:100%">
        <a href="TotalSaleReport.aspx#">

            <!--CUSTOM CHART START -->
            <div >
                <h3>
                    TOTAL SALE</h3>
            </div>
            <div >
                



                  <div class="form-horizontal tasi-form">
                    <div id="Div1" class="form-horizontal tasi-form" runat="Server">
                    <table title="Attendance Percentages" id="AttendancePercentages" summary="pieDescription"
                        data-attc-createchart="true" data-attc-coldescription="pieDescription" data-attc-colvalues="pieValues"
                        data-attc-location="AttendancePercentagesbar" data-attc-hidetable="true" data-attc-type="area"
                        data-attc-googleoptions='{"is3D":true}' data-attc-controls='{}' >
                        <thead>
                            <tr>
                                <th id="pieDescription">Month</th>
                                <th id="pieValues">Sale  (Rupees)</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("MonthName") %></td>
                                        <td><%# Eval("TotalValue")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div id="AttendancePercentagesbar">
                    </div>
                </div>
                  </div>








            </div></a>
            <!--custom chart end-->
            
        </div>
        <div style="width:100%">
        <a href="ProductStatusReport.aspx#">
            <!--CUSTOM CHART START -->
            <div >
                <h3>
                    PRODUCT's STATUS</h3>
            </div>


            <div id="Div5" class="form-horizontal tasi-form" runat="Server">
                    <table title="Attendance Percentages" id="Table3" summary="pieDescription"
                        data-attc-createchart="true" data-attc-coldescription="pieDescription" data-attc-colvalues="pieValues"
                        data-attc-location="Divpro" data-attc-hidetable="true" data-attc-type="pie"
                        data-attc-googleoptions='{"is3D":true}' data-attc-controls='{}' >
                        <thead>
                            <tr>
                                <th id="Th5">Status</th>
                                <th id="Th6">Product</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater9" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Status") %></td>
                                        <td><%# Eval("Total")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div id="Divpro">
                    </div>
                </div></a>

            </div>

             <div style="width:100%">
             <a href="OrderStatusReport.aspx#">
            <!--CUSTOM CHART START -->
            <div >
                <h3>
                    ORDER's STATUS</h3>
            </div>
            <div class="form-horizontal tasi-form">
                    <div id="Div6" class="form-horizontal tasi-form" runat="Server">
                    <table title="Attendance Percentages" id="Table4" summary="pieDescription"
                        data-attc-createchart="true" data-attc-coldescription="pieDescription" data-attc-colvalues="pieValues"
                        data-attc-location="AttendancePercentagesPie2" data-attc-hidetable="true" data-attc-type="column"
                        data-attc-googleoptions='{"is3D":true}' data-attc-controls='{}' >
                        <thead>
                            <tr>
                                <th id="Th7">Status</th>
                                <th id="Th8">Order</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater4" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Status") %></td>
                                        <td><%# Eval("Total")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div id="AttendancePercentagesPie2">
                    </div>
                    <center><h4>Status</h4></center>
                </div>
                  </div></a>

            </div>
        
        <!-- /row -->
    </div>
    <!-- /col-lg-9 END SECTION MIDDLE -->
    <div class="col-lg-3 ds AjaxNotification">
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            var unique_id = $.gritter.add({
                // (string | mandatory) the heading of the notification
                title: 'Welcome!',
                // (string | mandatory) the text inside the notification
                text: 'Hover me to enable the Close Button. You can hide the left sidebar clicking on the button next to the logo. .',
                // (string | optional) the image to display on the left
                image: 'assets/img/ui-sam.jpg',
                // (bool | optional) if you want it to fade out on its own or just sit there
                sticky: true,
                // (int | optional) the time you want it to be alive for before fading out
                time: '',
                // (string | optional) the class name you want to apply to that specific message
                class_name: 'my-sticky-class'
            });

            return false;
        });
    </script>
</asp:Content>
