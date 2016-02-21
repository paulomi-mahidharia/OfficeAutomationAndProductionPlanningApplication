<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AjaxNotification.aspx.cs"
    Inherits="AjaxNotification" %>
    <h3>NOTIFICATIONS</h3>
    <asp:Repeater ID="Repeater1" runat="server" >
        <ItemTemplate>
            <div class="desc">
                <div class="thumb">
                    <span class="badge bg-theme"><i class="fa fa-clock-o"></i></span>
                </div>
                <div class="details">
                    <p>
                        <div id="Div6" runat="server" visible=' <%#Convert.ToInt32(Math.Round((DateTime.Now - Convert.ToDateTime(Eval("Date"))).TotalMinutes))==0 %>'>
                            <muted>Recently</muted>
                        </div>
                        <div runat="server" visible=' <%#((Convert.ToInt32(Math.Round((DateTime.Now - Convert.ToDateTime(Eval("Date"))).TotalMinutes))<60) && (Convert.ToInt32(Math.Round((DateTime.Now - Convert.ToDateTime(Eval("Date"))).TotalMinutes))!=0))%>'>
                            <muted><%# Math.Round((DateTime.Now - Convert.ToDateTime(Eval("Date"))).TotalMinutes).ToString() + " Minutes Ago" %>
                            </muted>
                        </div>
                        <div id="Div7" runat="server" visible=' <%#((Convert.ToInt32(Math.Round((DateTime.Now - Convert.ToDateTime(Eval("Date"))).TotalMinutes))>60) && (Convert.ToInt32(Math.Round((DateTime.Now - Convert.ToDateTime(Eval("Date"))).TotalHours))<24))%>'>
                            <muted><%# Math.Round((DateTime.Now - Convert.ToDateTime(Eval("Date"))).TotalHours).ToString() + " hours Ago" %>
                            </muted>
                        </div>
                        <div id="Div8" runat="server" visible=' <%#Convert.ToInt32(Math.Round((DateTime.Now - Convert.ToDateTime(Eval("Date"))).TotalHours))>=24 %>'>
                            <muted><%# Math.Round((DateTime.Now - Convert.ToDateTime(Eval("Date"))).TotalDays).ToString() + " days Ago" %>
                            </muted>
                        </div>
                         
                        
                        
                        <br />


                        <div runat="server" >
                             <%# Eval("Data").ToString() %><br />
                        </div>
                    <!--    <div id="Div1" runat="server" visible=' <%# (Eval("Type").ToString() == "Order") %>'>
                             <%# "An order has been placed by "+Eval("Data").ToString()+ "." %><br />
                        </div>
                        <div id="Div2" runat="server" visible=' <%# (Eval("Type").ToString() == "Quotation") %>'>
                             <%# "Quotation Generated for "+Eval("Data").ToString()+ "." %><br />
                        </div>
                        <div id="Div3" runat="server" visible=' <%# (Eval("Type").ToString() == "Inventory") %>'>
                             <%# Eval("Data").ToString()+ " placed in Inventory." %><br />
                        </div>
                        <div id="Div4" runat="server" visible=' <%# (Eval("Type").ToString() == "Transition-Product") %>'>
                             <%# Eval("Data").ToString()+ "." %><br />
                        </div>
                        <div id="Div5" runat="server" visible=' <%# (Eval("Type").ToString() == "Transition-Order") %>'>
                             <%# Eval("Data").ToString()+ "." %><br />
                        </div>
                       -->
                    </p>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
