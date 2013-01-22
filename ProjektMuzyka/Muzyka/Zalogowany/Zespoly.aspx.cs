using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProjektMuzyka.Muzyka.Zalogowany
{
    public partial class Zespoly : System.Web.UI.Page
    {
        Funkcje Funkcje = new Funkcje();
        public string Istnieja = "Istnieją";
        public int NrWiersza = 1;
        public static string IdZespol;

        //protected override void OnInit(EventArgs e)
        //{
        //    //AddButton.Click += new EventHandler(Edytuj_Click);
        //    //Button button = new Button();
        //    //button.Text = "button";
        //    //button.ID = "button1";
        //    //button.Click += new EventHandler(jol_Click);
        //    //Panel1.Controls.Add(button);

        //    this.Edytuj = new Button();
        //    this.Edytuj.ID = "Edytuj" + NrWiersza;
        //    this.Edytuj.Text = "Edytuj";
        //    this.Edytuj.Click += new EventHandler(jol_Click);
        //    base.OnInit(e);
        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Funkcje.DropDownItemsGatunek(GatunekZespolu);
                Funkcje.DropDownItemsRok(RokZalozeniaZespoluOd);
                Funkcje.DropDownItemsRok(RokZalozeniaZespoluDo);
                Funkcje.DropDownItemsRok(RokKoncowyZespoluOd);
                Funkcje.DropDownItemsRok(RokKoncowyZespoluDo);
                Funkcje.DropDownItemsGatunek(EdytujGatunek);
                Funkcje.DropDownItemsRok(EdytujRokZalozenia);
                Funkcje.DropDownItemsRok(EdytujRokKoncowy);
            }
        }

        //protected void Szukaj_Click(object sender, EventArgs e)
        //{
        //    int ID = (int)Session["ID"];
        //    int ZespolID;

        //    string Nazwa = NazwaZespolu.Text;
        //    string Gatunek = GatunekZespolu.Text;
        //    string RokStartOd = RokZalozeniaZespoluOd.Text;
        //    string RokStartDo = RokZalozeniaZespoluDo.Text;
        //    string RokEndOd = RokKoncowyZespoluOd.Text;
        //    string RokEndDo = RokKoncowyZespoluDo.Text;
        //    string warunek = "";
        //    int Warunki_sum = 0;

        //    int[] Warunki = new int[6];
        //    Warunki[0] = Funkcje.CzySzukacTB(NazwaZespolu);
        //    Warunki[1] = Funkcje.CzySzukacDDL(GatunekZespolu);
        //    Warunki[2] = Funkcje.CzySzukacDDL(RokZalozeniaZespoluOd);
        //    Warunki[3] = Funkcje.CzySzukacDDL(RokZalozeniaZespoluDo);
        //    Warunki[4] = Funkcje.CzySzukacDDL(RokKoncowyZespoluOd);
        //    Warunki[5] = Funkcje.CzySzukacDDL(RokKoncowyZespoluDo);
        //    Warunki_sum = Warunki[0] + Warunki[1] + Warunki[2] + Warunki[3];

        //    string[] Warunki_String = new string[6];
        //    Warunki_String[0] = "Zespol.Nazwa like '%" + Nazwa + "%' ";
        //    Warunki_String[1] = "Gatunek.Nazwa = '" + Gatunek + "' ";
        //    Warunki_String[2] = "Zespol.Rok_Start >= " + RokStartOd + " ";
        //    Warunki_String[3] = "Zespol.Rok_Start <= " + RokStartDo + " ";
        //    Warunki_String[4] = "Zespol.Rok_End >= " + RokEndOd + " ";
        //    Warunki_String[5] = "Zespol.Rok_End <= " + RokEndDo + " ";

        //    bool Warunki_ok = false;
        //    if ((Warunki_sum) > 0)
        //    {
        //        Warunki_ok = true;
        //    }

        //    if (Warunki_ok)
        //    {

        //        for (int i = 0; i < 6; i++)
        //        {
        //            if (Warunki[i] == 1)
        //            {
        //                warunek = warunek + Warunki_String[i];
        //                Warunki_sum += -1;
        //            }
        //            if (Warunki_sum != 0 & Warunki[i] == 1)
        //            {
        //                warunek = warunek + "and ";
        //            }
        //        }

        //        string GetZespoly = "select Zespol.ID_zespol, Zespol.Nazwa, Gatunek.Nazwa, Zespol.Rok_start, Zespol.Rok_end " +
        //                            "from dbo.Zespol " +
        //                            "inner join Gatunek on Gatunek.Id_gatunek = Zespol.Id_Gatunek " +
        //                            "where " + warunek;


        //        SqlDataReader Data = Funkcje.Connect(Funkcje.TypeOfAction.Select, GetZespoly);

        //        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //        while (Data.Read())
        //        {
        //            TableCell NazwaCell = new TableCell(), GatunekCell = new TableCell(), RokZalozeniaCell = new TableCell(), RokKoncowyCell = new TableCell(), LiczbaPlytCell = new TableCell();
        //            TableCell EdycjaCell = new TableCell();


        //            OnInit(e);
        //            //this.Edytuj = new Button();
        //            //Edytuj = new Button();
        //            //Edytuj.ID = "Edytuj" + NrWiersza;
        //            //Edytuj.Text = "Edytuj";
        //            //Edytuj.Click += new EventHandler(jol_Click);


        //            ZespolID = Data.GetInt32(0);
        //            NazwaCell.Text = Data.GetString(1);
        //            GatunekCell.Text = Data.GetString(2);
        //            RokZalozeniaCell.Text = Data.GetInt32(3).ToString();

        //            if (Data.IsDBNull(4))
        //                RokKoncowyCell.Text = Istnieja;
        //            else
        //                RokKoncowyCell.Text = Data.GetInt32(4).ToString();

        //            string GetCountPlyty = "select COUNT(*) from Plyta " +
        //                               "where Plyta.ID_zespol = " + ZespolID +
        //                               "group by Plyta.ID_zespol";
        //            SqlDataReader Data1 = Funkcje.Connect(Funkcje.TypeOfAction.Select, GetCountPlyty);

        //            Data1.Read();
        //            if (Data1.HasRows)
        //            {
        //                LiczbaPlytCell.Text = Data1.GetInt32(0).ToString();
        //            }
        //            else
        //            {
        //                LiczbaPlytCell.Text = "0";
        //            }
        //            Data1.Close();
        //            EdycjaCell.Controls.Add(this.Edytuj);

        //            TableRow TR = new TableRow();
        //            TR.Cells.AddRange(new[] { NazwaCell, GatunekCell, RokZalozeniaCell, RokKoncowyCell, LiczbaPlytCell, EdycjaCell });
        //            ZespolyDane.Rows.Add(TR);

        //            NrWiersza = NrWiersza + 1;
        //        }
        //        Data.Close();
        //        //if (ZespolyList.Items.Count == 0)
        //        //    MessageBox.Show("Nie znaleziono zespołu o podanych kryteriach");
        //    }
        //    else
        //    {
        //        StatusWyszukiwania.Text = "Nie zaznaczono żadnych warunków wyszukiwania";
        //    }
        //}
        //protected void jol_Click(object sender, EventArgs e)
        //{
        //    NazwaZespolu.Text = "Edycja";
        //}



        protected void SzukajZespol_Click(object sender, EventArgs e)
        {
            //int ID = (int)Session["ID"];
            //int ZespolID;
            InfoEdycjaText.Visible = false;
            ZleDaneEdycjiText.Visible = false;
            EdycjaZespol.Visible = false;

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
                SqlDataZespoly.SelectCommand = GetZespoly;
            }
        }


        //protected void ZespolyWidok_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    TextBox1.Text = "Edycja";
        //    //ZespolyWidok.Rows[butt
        //}

        protected void ZespolyWidok_SelectedIndexChanged(object sender, EventArgs e)
        {
            EdycjaZespolNaglowek.Text = "Edytuj dane zespołu";
            Funkcje.InsertOrUpdate = 2;
            IdZespol = ZespolyWidok.SelectedRow.Cells[4].Text;
            InfoEdycjaText.Visible = false;
            ZleDaneEdycjiText.Visible = false;
            EdycjaZespol.Visible = true;
            EdytujNazwa.Text = ZespolyWidok.SelectedRow.Cells[0].Text;
            EdytujGatunek.Text = ZespolyWidok.SelectedRow.Cells[1].Text;
            if (ZespolyWidok.SelectedRow.Cells[2].Text != "&nbsp;")
            {
                EdytujRokZalozenia.Text = ZespolyWidok.SelectedRow.Cells[2].Text;
            }
            else { EdytujRokZalozenia.Text = ""; }
            if (ZespolyWidok.SelectedRow.Cells[3].Text != "&nbsp;")
            {
                EdytujRokKoncowy.Text = ZespolyWidok.SelectedRow.Cells[3].Text;
            }
            else { EdytujRokKoncowy.Text = ""; }
        }

        protected void EdycjaAnuluj_Click(object sender, EventArgs e)
        {
            InfoEdycjaText.Visible = false;
            ZleDaneEdycjiText.Visible = false;
            EdytujNazwa.Text = "";
            EdytujGatunek.Text = "";
            EdytujRokZalozenia.Text = "";
            EdytujRokKoncowy.Text = "";
            EdycjaZespol.Visible = false;
        }

        protected void EdycjaZapisz_Click(object sender, EventArgs e)
        {
            string EndRokU, EndRokI;
            bool b = true;

            if (EdytujRokKoncowy.SelectedIndex == 0)
            {
                EndRokU = ", Z.Rok_End = NULL";
                EndRokI = "NULL";
            }
            else
            {
                EndRokU = ", Z.Rok_End = " + EdytujRokKoncowy.Text;
                EndRokI = EdytujRokKoncowy.Text;
            }

            if (EdytujNazwa.Text == "")
                b = false;
            if (EdytujGatunek.Text == "")
                b = false;
            if (EdytujRokZalozenia.Text == "")
                b = false;
            //if (EdytujRokKoncowy.Text == "")
            //    b = false;
            if (EdytujRokKoncowy.SelectedIndex != 0 && EdytujRokKoncowy.SelectedIndex <= EdytujRokZalozenia.SelectedIndex)
                b = false;

            if (!b)
                ZleDaneEdycjiText.Visible = true;

            if (Funkcje.InsertOrUpdate == 2 && b)
            {
                String UpdateZespol = "UPDATE Z " +
                                        "SET " +
                                        "Z.ID_gatunek = (SELECT Gatunek.ID_gatunek FROM Gatunek WHERE Gatunek.Nazwa = '" + EdytujGatunek.Text +
                                        "'), Z.Nazwa = '" + EdytujNazwa.Text +
                                        "', Z.Rok_Start = " + EdytujRokZalozenia.Text +
                                        EndRokU +
                                        " FROM Zespol Z INNER JOIN Gatunek ON Gatunek.Id_gatunek = Z.Id_Gatunek" +
                                        " where ID_zespol = " + IdZespol;
                Funkcje.Connect(Funkcje.TypeOfAction.Update, UpdateZespol);
                InfoEdycjaText.Text = "Zaaktualizowano zespół o nazwie: " + EdytujNazwa.Text;
                SzukajZespol_Click(sender, e);

            }

            if (Funkcje.InsertOrUpdate == 1 && b)
            {
                String InsertZespol = "INSERT INTO Zespol   (ID_gatunek, Nazwa, Rok_start, Rok_end) " +
                                                  "VALUES   ((SELECT Gatunek.ID_gatunek FROM Gatunek WHERE Gatunek.Nazwa = '" + EdytujGatunek.Text +
                                                            "'), '" + EdytujNazwa.Text +
                                                            "', " + EdytujRokZalozenia.Text +
                                                            ", " + EndRokI + ")";
                Funkcje.Connect(Funkcje.TypeOfAction.Update, InsertZespol);
                InfoEdycjaText.Text = "Dodano nowy zespół o nazwie: " + EdytujNazwa.Text;
                string script1 = "<script type =\"text/javascript\" >alert(\"Dodano nowy zespół o nazwie: " + EdytujNazwa.Text + "\");</script>";
                Type csType = this.GetType();
                ClientScript.RegisterClientScriptBlock(csType, "DodajAllert", script1);


            }
            if (b)
            {
                InfoEdycjaText.Visible = true;
                EdycjaZespol.Visible = false;
                Funkcje.InsertOrUpdate = 0;
            }
        }

        protected void DodajZespol_Click(object sender, EventArgs e)
        {
            EdycjaZespolNaglowek.Text = "Dodaj nowy zespół";
            Funkcje.InsertOrUpdate = 1;
            InfoEdycjaText.Visible = false;
            ZleDaneEdycjiText.Visible = false;
            EdytujNazwa.Text = "";
            EdytujGatunek.Text = "";
            EdytujRokZalozenia.Text = "";
            EdytujRokKoncowy.Text = "";
            EdycjaZespol.Visible = true;
        }

    }
}