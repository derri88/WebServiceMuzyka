using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektMuzyka.Muzyka
{
    public partial class Main : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LogOffInfoStatus"] == null) { Session["LogOffInfoStatus"] = false; }
            Logowanie.Visible = false;
            Rejestracja.Visible = false;
            if ((bool)Session["LogOffInfoStatus"] == true)
            {
                Logowanie.Visible = true;
                LogOffInfo.Visible = true;
            }
            else { LogOffInfo.Visible = false; }
        }

        protected void Zaloguj_Click(object sender, EventArgs e)
        {
            Rejestracja.Visible = false;
            Logowanie.Visible = true;
            LoginBox.Focus();
        }

        protected void Rejestruj_Click(object sender, EventArgs e)
        {
            Logowanie.Visible = false;
            Rejestracja.Visible = true;
        }

        protected void ZamknijLogowanie_Click(object sender, EventArgs e)
        {
            Logowanie.Visible = false;
            Session["LogOffInfoStatus"] = false;
        }

        protected void ZamknijRejestracje_Click(object sender, EventArgs e)
        {
            Rejestracja.Visible = false;
        }

        protected void LoginBox_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Funkcje Funkcje = new Funkcje();
            Funkcje.ID_zalogowanego = Funkcje.DaneLogowania(LoginBox.UserName, LoginBox.Password);
            if (Funkcje.ID_zalogowanego != 0)
            {
                string UserName = LoginBox.UserName;
                e.Authenticated = true;
                Session["ID"] = Funkcje.ID_zalogowanego;
                Session["User"] = UserName;
                Response.Redirect("~/Muzyka/Zalogowany/MainZalogowany.aspx");
            }
            else
            {
               // Info.Text = "Blad!";
                Logowanie.Visible = true;
                e.Authenticated = false;
            }
        }

        //protected void LoginBox_LoginError(object sender, EventArgs e)
        //{
        //    Logowanie.Visible = true;
        //    Info.Text = "Blad!";
        //}


    }
}