using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektMuzyka.Muzyka.Zalogowany
{
    public partial class Zalogowany : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            Powitanie.Text = "Witaj " + (string)Session["User"] + "!";
        }

        protected void WylogujB_Click(object sender, EventArgs e)
        {
            Main Main = new Main();
            Session.Clear();
            Session["LogOffInfoStatus"] = true;
            Response.Redirect("~/Muzyka/Main.aspx");
        }

        protected void ZarzadzanieKontemB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Muzyka/Zalogowany/ZadzanieKontem.aspx");
        }

    }
}