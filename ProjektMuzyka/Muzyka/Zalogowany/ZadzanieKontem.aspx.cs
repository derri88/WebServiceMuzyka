using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektMuzyka.Muzyka.Zalogowany
{
    public partial class ZarzadzanieKontem : System.Web.UI.Page
    {
        public string NickData, ImieData, NazwiskoData, KrajData, MiastoData, MailData, StatusData;
        public DateTime Data_ur;
        public int PlecData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                DaneUzytkownika();
        }




        public void DaneUzytkownika()
        {
            Funkcje Funkcje = new Funkcje();
            int ID = (int)Session["ID"];
            string GetDane_user =
                "SELECT Users.Nick, Users.Imie, Users.Nazwisko, Users.Kraj, Users.Miasto, Users.Mail, Status.Nazwa, Users.Data_urodzenia, Users.Id_plec " +
                "FROM Users INNER JOIN Status on Status.ID_status = Users.ID_status " +
                "WHERE Users.ID_user = " + ID;

            SqlDataReader Data = Funkcje.Connect(Funkcje.TypeOfAction.Select, GetDane_user);

            Data.Read();
            NickData = Data.GetString(0);
            ImieData = Data.GetString(1);
            if (Data.IsDBNull(2))
            {
                Nazwisko = null;
            }
            else { NazwiskoData = Data.GetString(2); ; }
            if (Data.IsDBNull(3))
            {
                Kraj = null;
            }
            else { KrajData = Data.GetString(3); }
            if (Data.IsDBNull(4))
            {
                Miasto = null;
            }
            else { MiastoData = Data.GetString(4); }
            MailData = Data.GetString(5);
            StatusData = Data.GetString(6);

            if (Data.IsDBNull(7))
            {
                DataUrodzenia.Text = "";
            }
            else
            {
                Data_ur = Data.GetDateTime(7);
                DataUrodzenia.Text = Data_ur.ToShortDateString();
            }
            PlecData = Data.GetInt32(8);

            Nick.Text = NickData;
            Imie.Text = ImieData;
            Nazwisko.Text = NazwiskoData;
            Kraj.Text = KrajData;
            Miasto.Text = MiastoData;
            Mail.Text = MailData;
            Status.Text = StatusData;
            Plec.SelectedIndex = PlecData - 1;

            Data.Close();
        }

        protected void ZapiszZmiany_Click(object sender, EventArgs e)
        {
            Funkcje Funkcje = new Funkcje();
            int ID = (int)Session["ID"];
            //if (ImieBox.Text == ImieData &&
            //    NazwiskoBox.Text == NazwiskoData &&
            //    DataBox.Value == Data_ur &&
            //    PlecBox.SelectedIndex == (PlecData - 1) &&
            //    MailBox.Text == MailData &&
            //    KrajBox.Text == KrajData &&
            //    MiastoBox.Text == MiastoData)
            //{
            //    MessageBox.Show("Nie wprowadzono żadnych zmian, nic nie zaaktualizowano.");
            //}
            //else
            //{
                string UpdateUser = "update Users " +
                                        "set " +
                                        "Imie = '" + Imie.Text +
                                        "', Nazwisko = '" + Nazwisko.Text +
                                        "', Data_urodzenia = '" + DataUrodzenia.Text +
                                        "', ID_plec = '" + (Plec.SelectedIndex + 1) +
                                        "', Mail = '" + Mail.Text +
                                        "', Kraj = '" + Kraj.Text +
                                        "', Miasto = '" + Miasto.Text + "' " +
                                        "where Users.ID_user = " + ID;
                SqlDataReader Data = Funkcje.Connect(Funkcje.TypeOfAction.Update, UpdateUser);
                TwojeDaneInfo.Visible = true;
            //}
        }

    }
}