using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektMuzyka.Muzyka.Zalogowany
{
    public partial class MojeOceny : System.Web.UI.Page
    {
        Funkcje Funkcje = new Funkcje();
        TableRow PorownanieOceny = new TableRow();
        int[] IdPlyta;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            DanePlyt();
        }

        public void DanePlyt()
        {
            int ID = (int)Session["ID"];

            string GetDanePlyty =
                "Select Plyta.Nazwa, Zespol.Nazwa, Gatunek.Nazwa, Plyta.Rok_wydania, Plyta.Ilosc_sciezek, Ocena.Ocena, Ocena.ID_plyta " +
                "from Ocena " +
                "inner join Plyta on Plyta.ID_plyta = Ocena.ID_plyta " +
                "inner join Zespol on Zespol.ID_zespol = Plyta.ID_zespol " +
                "inner join Gatunek on Gatunek.ID_gatunek = Plyta.ID_gatunek " +
                "where Ocena.ID_user = " + ID;
            SqlDataReader Data = Funkcje.Connect(Funkcje.TypeOfAction.Select, GetDanePlyty);

            int NumerOcena = 0;
            IdPlyta = new int[Data.FieldCount];
            while (Data.Read())
            {
                TableRow TR = new TableRow();
                TableCell Plyta = new TableCell(), Zespol = new TableCell(), Gatunek = new TableCell(), Rok = new TableCell(), Sciezki = new TableCell(), Ocena = new TableCell(), OcenaV = new TableCell();
                int ID_Plyta;
                Plyta.Text = Data.GetString(0);
                Zespol.Text = Data.GetString(1);
                Gatunek.Text = Data.GetString(2);
                Rok.Text = Data.GetInt32(3).ToString();
                Sciezki.Text = Data.GetInt32(4).ToString();
                TextBox OcenaE = new TextBox();
                OcenaE.ID = "OcenaE" + NumerOcena;
                OcenaE.Text = Data.GetInt32(5).ToString(); ; OcenaE.Width = 30;
                OcenaV.Text = OcenaE.Text;
                Ocena.Controls.Add(OcenaE);
                PorownanieOceny.Cells.Add(OcenaV);
                ID_Plyta = Data.GetInt32(6);
                IdPlyta[NumerOcena] = ID_Plyta;

                TR.Cells.AddRange(new[] { Plyta, Zespol, Gatunek, Rok, Sciezki, Ocena });

                MojePlyty.Rows.Add(TR);
                NumerOcena = NumerOcena + 1;
            }
            Data.Close();
        }

        protected void ZapiszOceny_Click(object sender, EventArgs e)
        {
            int NrRek = 1;
            string OcenaPlyty;
            while (NrRek < MojePlyty.Rows.Count)
            {
                OcenaPlyty = ((TextBox)MojePlyty.Rows[NrRek].Cells[5].FindControl("OcenaE" + (NrRek - 1))).Text;
                if (OcenaPlyty == PorownanieOceny.Cells[NrRek - 1].Text)
                {
                }
                else
                {
                    string UpdateOcena =
                    "update Ocena " +
                     "set Ocena = " + OcenaPlyty +
                    "where Ocena.ID_plyta = " + IdPlyta[NrRek-1] + " and Ocena.ID_user = " + Session["ID"];
                    SqlDataReader Data = Funkcje.Connect(Funkcje.TypeOfAction.Update, UpdateOcena);
                    //Zmiana.Text = Zmiana.Text + "Zaaktualizowano wiersz numer: " + NrRek + " z wartości: " + PorownanieOceny.Cells[NrRek - 1].Text + " na wartość: " + OcenaPlyty + "\n";
                }
                NrRek = NrRek + 1;
            }
            MojeOcenyInfo.Visible = true;
        }
    }
}