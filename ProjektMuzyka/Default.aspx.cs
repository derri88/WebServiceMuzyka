using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektMuzyka
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Enabled = true;
            Panel1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel1.Enabled = false;
            Panel1.Visible = false;
        }
        protected void PanelDisable(object sender, EventArgs e)
        {
            Panel1.Enabled = false;
            Panel1.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Panel1.Enabled = false;
            Panel1.Visible = false;
        }
    }
}