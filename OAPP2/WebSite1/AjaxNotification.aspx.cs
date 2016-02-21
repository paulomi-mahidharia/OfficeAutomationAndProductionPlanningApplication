using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class AjaxNotification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        QuotationLogic QL = new QuotationLogic();
        Repeater1.DataSource = QL.SelectNotification();
        Repeater1.DataBind();
    }
    
}