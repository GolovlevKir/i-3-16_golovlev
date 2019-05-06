using System;
using System.Data;
using System.Data.SqlClient;
using LibraryForSQLCon;

namespace Ortoped_Store
{
    class DataBaseTables
    {
        Registry_Class registry = new Registry_Class();
        public SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
        public event Action<DataTable> dtFillFull;
        public DataTable dtAccess_rights = new DataTable("Access_rights");
        public DataTable dtChek = new DataTable("Chek");
        public DataTable dtCvet_Tov = new DataTable("Cvet_Tov");
        public DataTable dtFirma = new DataTable("Firma");
        public DataTable dtKlient = new DataTable("Klient");
        public DataTable dtPol = new DataTable("Pol");
        public DataTable dtPrihod = new DataTable("Prihod");
        public DataTable dtProfile1 = new DataTable("Profile");
        public DataTable dtProfile2 = new DataTable("Profile");
        public DataTable dtProfile3 = new DataTable("Profile");
        public DataTable dtSklad = new DataTable("Sklad");
        public DataTable dtSotr = new DataTable("Sotr");
        public DataTable dtTovar = new DataTable("Tovar");
        public DataTable dtVidi_Tov = new DataTable("Vidi_Tov");
        public SqlDependency dependency = new SqlDependency();

        public string qrAccess_rights = "SELECT ID_Access_rights, Dolj, Profili, Client, Sotrudniki, Vidi, Firmi, Colors, Pol_Tova," +
            " Tovari, Skladi, Prihodi, Cheki, Access_rights_Logical_Delete FROM dbo.Access_rights where [Access_rights_Logical_Delete] = 0",
            qrChek = "SELECT dbo.Chek.ID_Chek, dbo.Chek.Nom_Cheka, dbo.Chek.INN, dbo.Chek.Data_Pech, dbo.Chek.ID_Tovar, dbo.Tovar.ID_Tovar AS 'Тов'," +
            " dbo.Firma.NaimFir + ' ' + dbo.Vidi_Tov.Naim + ' ' + dbo.Tovar.Naim + ' (Пол: ' + dbo.Pol.Pol + ', Цвет: ' + dbo.Cvet_Tov.Cvet + ')'" +
            " AS 'Товар', dbo.Chek.Kol_Vo, dbo.Chek.Login_Sotr, dbo.Sotr.Login_Sotr AS Expr3, dbo.Sotr.Surname_Sotr + ' ' +" +
            " SUBSTRING(dbo.Sotr.Name_Sotr, 1, 1) + '.' + SUBSTRING(dbo.Sotr.Middle_name_Sotr, 1, 1) + '. (Должность: ' + dbo.Access_rights.Dolj + ')'" +
            " AS 'Продавец' FROM   dbo.Access_rights JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID" +
            " JOIN dbo.Sotr ON dbo.Profile.Login_Profile = dbo.Sotr.Login_Sotr JOIN dbo.Chek ON dbo.Sotr.Login_Sotr = dbo.Chek.Login_Sotr" +
            " JOIN dbo.Tovar ON dbo.Chek.ID_Tovar = dbo.Tovar.ID_Tovar JOIN dbo.Pol ON dbo.Tovar.ID_Pol = dbo.Pol.ID_Pol JOIN dbo.Firma" +
            " ON dbo.Tovar.Firm_ID = dbo.Firma.ID_Firm JOIN dbo.Cvet_Tov ON dbo.Tovar.ID_Cvet = dbo.Cvet_Tov.ID_Cvet JOIN dbo.Vidi_Tov" +
            " ON dbo.Tovar.ID_Vid = dbo.Vidi_Tov.ID_Vid where Check_Logical_Delete = 0",
            qrCvet_Tov = "SELECT ID_Cvet, Cvet FROM dbo.Cvet_Tov where Cvet_Logical_Delete = 0",
            qrFirma = "SELECT ID_Firm, NaimFir FROM dbo.Firma where Firm_Logical_Delete = 0",
            qrKlient = "SELECT Login_Klient, Surname_Klient, Name_Klient, Middle_name_Klient, Surname_Klient+' '+Name_Klient+' '+ Middle_name_Klient," +
            " The_date_of_the_Rojd FROM dbo.Klient where Klient_Logical_Delete = 0",
            qrPol = "SELECT ID_Pol, Pol FROM dbo.Pol where Pol_Logical_Delete = 0",
            qrPrihod = "SELECT dbo.Prihod.ID_Prihod, dbo.Tovar.ID_Tovar, dbo.Firma.NaimFir + ' ' + dbo.Vidi_Tov.Naim + ' ' " +
            "+ dbo.Tovar.Naim + ' (Пол: ' + dbo.Pol.Pol + ', Цвет: ' + dbo.Cvet_Tov.Cvet + ')' AS 'Товар', dbo.Prihod.Kol_vo_Tov FROM dbo.Cvet_Tov " +
            "JOIN dbo.Tovar ON dbo.Cvet_Tov.ID_Cvet = dbo.Tovar.ID_Cvet JOIN dbo.Firma ON dbo.Tovar.Firm_ID = dbo.Firma.ID_Firm " +
            "JOIN dbo.Pol ON dbo.Tovar.ID_Pol = dbo.Pol.ID_Pol JOIN dbo.Prihod ON dbo.Tovar.ID_Tovar = dbo.Prihod.ID_Tovar " +
            "JOIN dbo.Vidi_Tov ON dbo.Tovar.ID_Vid = dbo.Vidi_Tov.ID_Vid where Prihod.Prih_Logical_Delete = 0",
            qrProfileSotr = "SELECT dbo.Profile.Login_Profile, dbo.Profile.Password_Profile, dbo.Access_rights.ID_Access_rights, dbo.Access_rights.Dolj," +
            " dbo.Profile.System_access, dbo.Profile.Access_rights_ID, dbo.Profile.Profile_Image, dbo.Profile.Profile_Logical_Delete, " +
            "dbo.Sotr.Login_Sotr, dbo.Sotr.Surname_Sotr, dbo.Sotr.Name_Sotr, dbo.Sotr.Middle_name_Sotr, dbo.Sotr.The_date_of_the_Rojd, " +
            "dbo.Sotr.Adres_Proj, dbo.Sotr.Sotr_Logical_Delete FROM   dbo.Access_rights INNER JOIN dbo.Profile ON " +
            "dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID INNER JOIN dbo.Sotr ON dbo.Profile.Login_Profile = dbo.Sotr.Login_Sotr " +
            "WHERE (dbo.Access_rights.Dolj <> 'Клиент') and (dbo.Profile.Profile_Logical_Delete = 0)",
            qrProfileKlients = "SELECT dbo.Profile.Login_Profile, dbo.Profile.Password_Profile, dbo.Access_rights.ID_Access_rights, " +
            "dbo.Access_rights.Dolj, dbo.Profile.System_access, dbo.Profile.Access_rights_ID, dbo.Profile.Profile_Image, " +
            "dbo.Profile.Profile_Logical_Delete, dbo.Klient.Login_Klient, dbo.Klient.Surname_Klient, dbo.Klient.Name_Klient, dbo.Klient.Middle_name_Klient, " +
            "dbo.Klient.The_date_of_the_Rojd, dbo.Klient.Klient_Logical_Delete FROM   dbo.Access_rights INNER JOIN dbo.Profile " +
            "ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID INNER JOIN dbo.Klient ON dbo.Profile.Login_Profile = dbo.Klient.Login_Klient " +
            "WHERE (dbo.Access_rights.Dolj = 'Клиент') and (dbo.Profile.Profile_Logical_Delete = 0)",
            qrSklad = "SELECT dbo.Sklad.ID_Sklad, dbo.Tovar.ID_Tovar, dbo.Firma.NaimFir + ' ' + dbo.Vidi_Tov.Naim + ' ' + dbo.Tovar.Naim + " +
            "' (Пол: ' + dbo.Pol.Pol + ', Цвет: ' + dbo.Cvet_Tov.Cvet + ')' AS 'Товар', dbo.Sklad.Kol_vo_Tov FROM   dbo.Cvet_Tov INNER " +
            "JOIN dbo.Tovar ON dbo.Cvet_Tov.ID_Cvet = dbo.Tovar.ID_Cvet INNER JOIN dbo.Firma ON dbo.Tovar.Firm_ID = dbo.Firma.ID_Firm INNER " +
            "JOIN dbo.Pol ON dbo.Tovar.ID_Pol = dbo.Pol.ID_Pol INNER JOIN dbo.Sklad ON dbo.Tovar.ID_Tovar = dbo.Sklad.ID_Tovar INNER " +
            "JOIN dbo.Vidi_Tov ON dbo.Tovar.ID_Vid = dbo.Vidi_Tov.ID_Vid where Sklad.Sclad_Logical_Delete = 0",
            qrSotr = "SELECT Login_Sotr,Surname_Sotr, Name_Sotr, Middle_name_Sotr,Surname_Sotr +' '+substring(Name_Sotr,1,1)+'.'+ " +
            "substring(Middle_name_Sotr,1,1)+'.' as 'ФИО', The_date_of_the_Rojd, Adres_Proj FROM dbo.Sotr where Sotr_Logical_Delete = 0",
            qrTovar = "SELECT Tovar.ID_Tovar,Tovar.Naim, dbo.Tovar.Firm_ID, dbo.Firma.ID_Firm, dbo.Firma.NaimFir, dbo.Tovar.Cena, " +
            "dbo.Tovar.ID_Pol, dbo.Pol.ID_Pol, dbo.Pol.Pol, dbo.Tovar.ID_Cvet, dbo.Cvet_Tov.ID_Cvet, dbo.Cvet_Tov.Cvet, dbo.Tovar.ID_Vid, " +
            "dbo.Vidi_Tov.ID_Vid, dbo.Vidi_Tov.Naim, dbo.Firma.NaimFir + ' ' + dbo.Vidi_Tov.Naim +' '+ dbo.Tovar.Naim + ' (Пол: ' + dbo.Pol.Pol + " +
            "', Цвет: ' + dbo.Cvet_Tov.Cvet + ')' AS 'Товар' FROM dbo.Tovar JOIN dbo.Cvet_Tov ON dbo.Tovar.ID_Cvet = dbo.Cvet_Tov.ID_Cvet " +
            "JOIN dbo.Firma ON dbo.Tovar.Firm_ID = dbo.Firma.ID_Firm JOIN dbo.Pol ON dbo.Tovar.ID_Pol = dbo.Pol.ID_Pol JOIN dbo.Vidi_Tov " +
            "ON dbo.Tovar.ID_Vid = dbo.Vidi_Tov.ID_Vid where Tovar.Tovar_Logical_Delete = 0",
            qrVidi_Tov = "SELECT ID_Vid, Naim FROM dbo.Vidi_Tov where Vid_Logical_Delete = 0";

        private void dtFill(DataTable table, string query)
        {
            try
            {
                command.Notification = null;
                command.CommandText = query;
                dependency.AddCommandDependency(command);
                SqlDependency.Start(Registry_Class.sqlConnection.ConnectionString);
                Registry_Class.sqlConnection.Open();
                table.Load(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                Registry_Class.error_message += "\n"
                    + DateTime.Now.ToLongDateString() + ex.Message;
            }
            finally
            {
                Registry_Class.sqlConnection.Close();
            }
        }

        public void dtAccess_rightsFill()
        {
            dtFill(dtAccess_rights, qrAccess_rights);
        }

        public void dtChekFill()
        {
            dtFill(dtChek,qrChek);
        }
        public void dtCvet_TovFill()
        {
            dtFill(dtCvet_Tov,qrCvet_Tov);
        }
        public void dtFirmaFill()
        {
            dtFill(dtFirma,qrFirma);
        }
        public void dtKlientFill()
        {
            dtFill(dtKlient,qrKlient);
        }
        public void dtPolFill()
        {
            dtFill(dtPol,qrPol);
        }
        public void dtPrihodFill()
        {
            dtFill(dtPrihod,qrPrihod);
        }
        public void dtProfileSotrFill()
        {
            dtFill(dtProfile1,qrProfileSotr);
        }
        public void dtProfileKlientsFill()
        {
            dtFill(dtProfile2, qrProfileKlients);
        }
        public void dtSkladFill()
        {
            dtFill(dtSklad,qrSklad);
        }
        public void dtSotrFill()
        {
            dtFill(dtSotr,qrSotr);
        }
        public void dtTovarFill()
        {
            dtFill(dtTovar,qrTovar);
        }
        public void dtVidi_TovFill()
        {
            dtFill(dtVidi_Tov,qrVidi_Tov);
        }
    }
}
