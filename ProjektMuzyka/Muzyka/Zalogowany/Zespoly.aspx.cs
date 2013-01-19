using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektMuzyka.Muzyka.Zalogowany
{
    public partial class Zespoly : System.Web.UI.Page
    {
        Funkcje Funkcje = new Funkcje();
        public string Istnieja = "Istnieją";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Funkcje.DropDownItemsGatunek(GatunekZespolu);
                Funkcje.DropDownItemsRok(RokZalozeniaZespoluOd);
                Funkcje.DropDownItemsRok(RokZalozeniaZespoluDo);
                Funkcje.DropDownItemsRok(RokKoncowyZespoluOd);
                Funkcje.DropDownItemsRok(RokKoncowyZespoluDo);
            }

        }

        protected void Szukaj_Click(object sender, EventArgs e)
        {
            int ID = (int)Session["ID"];
            int ZespolID;

            string Nazwa = NazwaZespolu.Text;
            string Gatunek = GatunekZespolu.Text;
            string RokStartOd = RokZalozeniaZespoluOd.Text;
            string RokStartDo = RokZalozeniaZespoluDo.Text;
            string RokEndOd = RokKoncowyZespoluOd.Text;
            string RokEndDo = RokKoncowyZespoluDo.Text;
            string warunek = "";
            int Warunki_sum = 0;

            int[] Warunki = new int[6];
            Warunki[0] = Funkcje.CzySzukacTB(NazwaZespolu);
            Warunki[1] = Funkcje.CzySzukacDDL(GatunekZespolu);
            Warunki[2] = Funkcje.CzySzukacDDL(RokZalozeniaZespoluOd);
            Warunki[3] = Funkcje.CzySzukacDDL(RokZalozeniaZespoluDo);
            Warunki[4] = Funkcje.CzySzukacDDL(RokKoncowyZespoluOd);
            Warunki[5] = Funkcje.CzySzukacDDL(RokKoncowyZespoluDo);
            Warunki_sum = Warunki[0] + Warunki[1] + Warunki[2] + Warunki[3];

            string[] Warunki_String = new string[6];
            Warunki_String[0] = "Zespol.Nazwa like '%" + Nazwa + "%' ";
            Warunki_String[1] = "Gatunek.Nazwa = '" + Gatunek + "' ";
            Warunki_String[2] = "Zespol.Rok_Start >= " + RokStartOd + " ";
            Warunki_String[3] = "Zespol.Rok_Start <= " + RokStartDo + " ";
            Warunki_String[4] = "Zespol.Rok_End >= " + RokEndOd + " ";
            Warunki_String[5] = "Zespol.Rok_End <= " + RokEndDo + " ";

            bool Warunki_ok = false;
            if ((Warunki_sum) > 0)
            {
                Warunki_ok = true;
            }

            if (Warunki_ok)
            {

                for (int i = 0; i < 6; i++)
                {
                    if (Warunki[i] == 1)
                    {
                        warunek = warunek + Warunki_String[i];
                        Warunki_sum += -1;
                    }
                    if (Warunki_sum != 0 & Warunki[i] == 1)
                    {
                        warunek = warunek + "and ";
                    }
                }

                string GetZespoly = "select Zespol.ID_zespol, Zespol.Nazwa, Gatunek.Nazwa, Zespol.Rok_start, Zespol.Rok_end " +
                                    "from dbo.Zespol " +
                                    "inner join Gatunek on Gatunek.Id_gatunek = Zespol.Id_Gatunek " +
                                    "where " + warunek;

                SqlDataReader Data = Funkcje.Connect(Funkcje.TypeOfAction.Select, GetZespoly);

                while (Data.Read())
                {
                    TableCell NazwaCell = new TableCell(), GatunekCell = new TableCell(), RokZalozeniaCell = new TableCell(), RokKoncowyCell = new TableCell(), LiczbaPlytCell = new TableCell();
                    ZespolID = Data.GetInt32(0);
                    NazwaCell.Text = Data.GetString(1);
                    GatunekCell.Text = Data.GetString(2);
                    RokZalozeniaCell.Text = Data.GetInt32(3).ToString();

                    if (Data.IsDBNull(4))
                        RokKoncowyCell.Text = Istnieja;
                    else
                        RokKoncowyCell.Text = Data.GetInt32(4).ToString();

                    string GetCountPlyty = "select COUNT(*) from Plyta " +
                                       "where Plyta.ID_zespol = " + ZespolID +
                                       "group by Plyta.ID_zespol";
                    SqlDataReader Data1 = Funkcje.Connect(Funkcje.TypeOfAction.Select, GetCountPlyty);

                    Data1.Read();
                    if (Data1.HasRows)
                    {
                        LiczbaPlytCell.Text = Data1.GetInt32(0).ToString();
                    }
                    else
                    {
                        LiczbaPlytCell.Text = "0";
                    }
                    Data1.Close();

                    TableRow TR = new TableRow();
                    TR.Cells.AddRange(new[] { NazwaCell, GatunekCell, RokZalozeniaCell, RokKoncowyCell, LiczbaPlytCell });
                    ZespolyDane.Rows.Add(TR);
                }
                Data.Close();
                //if (ZespolyList.Items.Count == 0)
                //    MessageBox.Show("Nie znaleziono zespołu o podanych kryteriach");
            }
            else
            {
                StatusWyszukiwania.Text = "Nie zaznaczono żadnych warunków wyszukiwania";
            }

        }


    }
}