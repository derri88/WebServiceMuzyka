using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektMuzyka.Muzyka
{
    /// <summary>
    /// Summary description for Funkcje
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Funkcje : System.Web.Services.WebService
    {
        public static int ID_zalogowanego;
        public static int InsertOrUpdate = 0;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //[WebMethod]
        public enum TypeOfAction
        {
            Select,
            Update,
            Count
        };

        [WebMethod]
        public SqlDataReader Connect(TypeOfAction TOA, string Query) // Funcka otwierajaca polaczenie i w zależności od pożadanej akcji wykonuje różny kod.
        {
            string ConnectionString = "Server=ProjektGrupowy.mssql.somee.com; Database=ProjektGrupowy; User ID=derri_SQLLogin_1; Password=pe2fjz4yh9;";
            SqlConnection Conn = new SqlConnection(ConnectionString);
            
            Conn.Open();

            SqlDataReader Data;

            if (TOA == TypeOfAction.Update)// Przy update nie zamykać SqlDataReadera!(w uzywanej funkcji) bo jego wartosc == null!!!
            {
                SqlCommand DataCmd = new SqlCommand(Query, Conn);
                DataCmd.ExecuteNonQuery();
                Conn.Close();
            }

            if (TOA == TypeOfAction.Select)
            {
                SqlCommand DataCmd = new SqlCommand(Query, Conn);
                Data = DataCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return Data;
            }
            return null;
        }

        [WebMethod]
        public int DaneLogowania(string LoginName, string LoginPassword)
        {
            int ID, IleRek = 1;
            string IleRekordow = "SELECT COUNT (*) " +
                                "FROM Users INNER JOIN User_password ON Users.ID_user = User_password.ID_user " +
                                "WHERE Users.Nick = '" + LoginName + "'" +
                                "AND User_password.Password = '" + LoginPassword + "'";

            string CheckUser = "SELECT Users.ID_user " +
                                "FROM Users INNER JOIN User_password ON Users.ID_user = User_password.ID_user " +
                                "WHERE Users.Nick = '" + LoginName + "'" +
                                "AND User_password.Password = '" + LoginPassword + "'";

            SqlDataReader DataUser = Connect(TypeOfAction.Select, CheckUser);
            SqlDataReader DataIleRek = Connect(TypeOfAction.Select, IleRekordow);

            DataIleRek.Read();
            IleRek = DataIleRek.GetInt32(0);
            DataIleRek.Close();

            if (IleRek == 1 && DataUser.Read())
            {
                ID = DataUser.GetInt32(0);
                DataUser.Close();
                return ID;
            }
            else
            {
                DataUser.Close();
                return 0;
            }
        }

        [WebMethod]
        public void DropDownItemsGatunek(DropDownList DDL) // Pobiera gatunki jako itemy do ComboBoxow
        {
            string GetGatunki = "SELECT Nazwa FROM Gatunek";
            SqlDataReader Data = Connect(TypeOfAction.Select, GetGatunki);
            DDL.Items.Add("");
            while (Data.Read())
            {
                DDL.Items.Add(Data.GetString(0));
            }
            Data.Close();
        }

        [WebMethod]
        public void DropDownItemsRok(DropDownList DDL) // Rok jako item do ComboBoxow
        {
            DDL.Items.Add("");
            for (int i = 1900; i <= DateTime.Now.Year; i++)
            {
                DDL.Items.Add(i.ToString());
            }
        }

        [WebMethod]
        public int CzySzukacTB(TextBox TB)
        {
            string S = TB.Text;
            if (S != "")
                return 1;
            else
                return 0;
        }

        [WebMethod]
        public int CzySzukacDDL(DropDownList DDL)
        {
            string S = DDL.Text;
            if (S != "")
                return 1;
            else
                return 0;
        }
    }
}
