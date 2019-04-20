using System;
using System.Data.SqlClient;

namespace Ortoped_Store
{
    class DataBaseProcedure
    {
        private SqlCommand cmd = new SqlCommand("Empty", Registry_Class.sqlConnection);

        private void message(object sender, SqlInfoMessageEventArgs e)
        {
            Registry_Class.error_message += "\n" + DateTime.Now.ToLongDateString() + " " + e.Message;
        }

        private void spConfiguration(string spName)
        {
            cmd.CommandText = spName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public void spAdd_Chek(int Nom_Cheka, string INN, int ID_Tovar, int Kol_vo, string Login_Sotr)
        {
            spConfiguration("Add_Chek");
                cmd.Parameters.AddWithValue("@Nom_Cheka", Nom_Cheka);
                cmd.Parameters.AddWithValue("@INN", INN);
                cmd.Parameters.AddWithValue("@ID_Tovar", ID_Tovar);
                cmd.Parameters.AddWithValue("@Kol_vo", Kol_vo);
                cmd.Parameters.AddWithValue("@Login_Sotr", Login_Sotr);
                Registry_Class.sqlConnection.Open();
                Registry_Class.sqlConnection.InfoMessage += message;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spUpd_Chek(int ID_Chek,int Nom_Cheka, string INN, string Data_Pech, int ID_Tovar, int Kol_vo, string Login_Sotr)
        {
            spConfiguration("Upd_Chek");
            cmd.Parameters.AddWithValue("@ID_Chek", ID_Chek);
            cmd.Parameters.AddWithValue("@Nom_Cheka", Nom_Cheka);
            cmd.Parameters.AddWithValue("@INN", INN);
            cmd.Parameters.AddWithValue("@Data_Pech", Data_Pech);
            cmd.Parameters.AddWithValue("@ID_Tovar", ID_Tovar);
            cmd.Parameters.AddWithValue("@Kol_vo", Kol_vo);
            cmd.Parameters.AddWithValue("@Login_Sotr", Login_Sotr);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spAdd_Firm(string NaimFir)
        {
            spConfiguration("Add_Firm");
            cmd.Parameters.AddWithValue("@NaimFir", NaimFir);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spUpd_Firm(int ID_Firm,string NaimFir)
        {
            spConfiguration("Upd_Firm");
            cmd.Parameters.AddWithValue("@ID_Firm", ID_Firm);
            cmd.Parameters.AddWithValue("@NaimFir", NaimFir);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spAdd_Cvet_Tov(string Cvet)
        {
            spConfiguration("Add_Cvet_Tov");
            cmd.Parameters.AddWithValue("@Cvet", Cvet);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spUPD_Cvet_Tov(int ID_Cvet, string Cvet)
        {
            spConfiguration("UPD_Cvet_Tov");
            cmd.Parameters.AddWithValue("@ID_Cvet", ID_Cvet);
            cmd.Parameters.AddWithValue("@Cvet", Cvet);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spDell_Chek(int ID_Chek)
        {
            spConfiguration("Dell_Chek");
            cmd.Parameters.AddWithValue("@ID_Chek", ID_Chek);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spChek_Logical_Delete(int ID_Chek)
        {
            spConfiguration("Chek_Logical_Delete");
            cmd.Parameters.AddWithValue("@ID_Chek", ID_Chek);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spAdd_Prihod(int ID_Tovar, int Kol_vo_Tov)
        {
            spConfiguration("Add_Prihod");
            cmd.Parameters.AddWithValue("@ID_Tovar", ID_Tovar);
            cmd.Parameters.AddWithValue("@Kol_vo_Tov", Kol_vo_Tov);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spUPD_Prihod(int ID_Prihod, int ID_Tovar, int Kol_vo_Yach)
        {
            spConfiguration("UPD_Prihod");
            cmd.Parameters.AddWithValue("@ID_Prihod", ID_Prihod);
            cmd.Parameters.AddWithValue("@ID_Tovar", ID_Tovar);
            cmd.Parameters.AddWithValue("@Kol_vo_Yach", Kol_vo_Yach);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spDell_Prihod(int ID_Prihod)
        {
            spConfiguration("Dell_Prihod");
            cmd.Parameters.AddWithValue("@ID_Prihod", ID_Prihod);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spPrih_Logical_Delete(int ID_Prihod)
        {
            spConfiguration("Prih_Logical_Delete");
            cmd.Parameters.AddWithValue("@ID_Prihod", ID_Prihod);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spAdd_Sklad(int ID_Tovar, int Kol_vo_Tov)
        {
            spConfiguration("Add_Sklad");
            cmd.Parameters.AddWithValue("@ID_Tovar", ID_Tovar);
            cmd.Parameters.AddWithValue("@Kol_vo_Tov", Kol_vo_Tov);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spUPD_Sklad(int ID_Sklad,int ID_Tovar, int Kol_vo_Yach)
        {
            spConfiguration("UPD_Sklad");
            cmd.Parameters.AddWithValue("@ID_Sklad", ID_Sklad);
            cmd.Parameters.AddWithValue("@ID_Tovar", ID_Tovar);
            cmd.Parameters.AddWithValue("@Kol_vo_Yach", Kol_vo_Yach);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spAdd_Tovar(string Naim, int Firm_ID, float Cena, int ID_Pol, int ID_Cvet, int ID_Vid)
        {
            spConfiguration("Add_Tovar");
            cmd.Parameters.AddWithValue("@Naim", Naim);
            cmd.Parameters.AddWithValue("@Firm_ID", Firm_ID);
            cmd.Parameters.AddWithValue("@Cena", Cena);
            cmd.Parameters.AddWithValue("@ID_Pol", ID_Pol);
            cmd.Parameters.AddWithValue("@ID_Cvet", ID_Cvet);
            cmd.Parameters.AddWithValue("@ID_Vid", ID_Vid);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spUPD_Tovar(int ID_Tovar, string Naim, int ID_Firm, float Cena, int ID_Pol, int ID_Cvet, int ID_Vid)
        {
            spConfiguration("UPD_Tovar");
            cmd.Parameters.AddWithValue("@ID_Tovar", ID_Tovar);
            cmd.Parameters.AddWithValue("@Naim", Naim);
            cmd.Parameters.AddWithValue("@ID_Firm", ID_Firm);
            cmd.Parameters.AddWithValue("@Cena", Cena);
            cmd.Parameters.AddWithValue("@ID_Pol", ID_Pol);
            cmd.Parameters.AddWithValue("@ID_Cvet", ID_Cvet);
            cmd.Parameters.AddWithValue("@ID_Vid", ID_Vid);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spAdd_Vidi_Tov(string Naim)
        {
            spConfiguration("Add_Vidi_Tov");
            cmd.Parameters.AddWithValue("@Naim", Naim);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spUpd_Vidi_Tov(int ID_Vid,string Naim)
        {
            spConfiguration("Upd_Vidi_Tov");
            cmd.Parameters.AddWithValue("@ID_Vid", ID_Vid);
            cmd.Parameters.AddWithValue("@Naim", Naim);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spDell_Cvet_Tov(int ID_Cvet)
        {
            spConfiguration("Dell_Cvet_Tov");
            cmd.Parameters.AddWithValue("@ID_Cvet", ID_Cvet);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spCvet_Logical_Delete(int ID_Cvet)
        {
            spConfiguration("Cvet_Logical_Delete");
            cmd.Parameters.AddWithValue("@ID_Cvet", ID_Cvet);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spDell_Firm(int ID_Firm)
        {
            spConfiguration("Dell_Firm");
            cmd.Parameters.AddWithValue("@ID_Firm", ID_Firm);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spFirm_Logical_Delete(int ID_Firm)
        {
            spConfiguration("Firm_Logical_Delete");
            cmd.Parameters.AddWithValue("@ID_Firm", ID_Firm);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spDell_Sklad(int ID_Sklad)
        {
            spConfiguration("Dell_Sklad");
            cmd.Parameters.AddWithValue("@ID_Sklad", ID_Sklad);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spSclad_Logical_Delete(int ID_Sklad)
        {
            spConfiguration("Sclad_Logical_Delete");
            cmd.Parameters.AddWithValue("@ID_Sklad", ID_Sklad);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spDell_Tovar(int ID_Tovar)
        {
            spConfiguration("Dell_Tovar");
            cmd.Parameters.AddWithValue("@ID_Tovar", ID_Tovar);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spTovar_Logical_Delete(int ID_Tovar)
        {
            spConfiguration("Tovar_Logical_Delete");
            cmd.Parameters.AddWithValue("@ID_Tovar", ID_Tovar);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spDell_Vidi_Tov(int ID_Vid)
        {
            spConfiguration("Dell_Vidi_Tov");
            cmd.Parameters.AddWithValue("@ID_Vid", ID_Vid);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spVid_Logical_Delete(int ID_Vid)
        {
            spConfiguration("Vid_Logical_Delete");
            cmd.Parameters.AddWithValue("@ID_Vid", ID_Vid);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spKlient_Delete(string Login_Klient)
        {
            spConfiguration("Klient_Delete");
            cmd.Parameters.AddWithValue("@Login_Klient", Login_Klient);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spKlient_Logical_Delete(string Login_Klient)
        {
            spConfiguration("Klient_Logical_Delete");
            cmd.Parameters.AddWithValue("@Login_Klient", Login_Klient);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spKlient_Insert(string Login_Klient, string Surname_Klient, string Name_Klient, string Middle_name_Klient, string The_date_of_the_Rojd)
        {
            spConfiguration("Klient_Insert");
            cmd.Parameters.AddWithValue("@Login_Klient", Login_Klient);
            cmd.Parameters.AddWithValue("@Surname_Klient", Surname_Klient);
            cmd.Parameters.AddWithValue("@Name_Klient", Name_Klient);
            cmd.Parameters.AddWithValue("@Middle_name_Klient", Middle_name_Klient);
            cmd.Parameters.AddWithValue("@The_date_of_the_Rojd", The_date_of_the_Rojd);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spKlient_Update(string Login_Klient, string Surname_Klient, string Name_Klient, string Middle_name_Klient, string The_date_of_the_Rojd)
        {
            spConfiguration("Klient_Update");
            cmd.Parameters.AddWithValue("@Login_Klient", Login_Klient);
            cmd.Parameters.AddWithValue("@Surname_Klient", Surname_Klient);
            cmd.Parameters.AddWithValue("@Name_Klient", Name_Klient);
            cmd.Parameters.AddWithValue("@Middle_name_Klient", Middle_name_Klient);
            cmd.Parameters.AddWithValue("@The_date_of_the_Rojd", The_date_of_the_Rojd);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spSotr_Delete(string Login_Sotr)
        {
            spConfiguration("Sotr_Delete");
            cmd.Parameters.AddWithValue("@Login_Sotr", Login_Sotr);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spSotr_Logical_Delete(string Login_Sotr)
        {
            spConfiguration("Sotr_Logical_Delete");
            cmd.Parameters.AddWithValue("@Login_Sotr", Login_Sotr);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spSotr_Insert(string Login_Sotr, string Surname_Sotr, string Name_Sotr, string Middle_name_Sotr, string The_date_of_the_spending, string Adres_Proj)
        {
            spConfiguration("Sotr_Insert");
            cmd.Parameters.AddWithValue("@Login_Sotr", Login_Sotr);
            cmd.Parameters.AddWithValue("@Surname_Sotr", Surname_Sotr);
            cmd.Parameters.AddWithValue("@Name_Sotr", Name_Sotr);
            cmd.Parameters.AddWithValue("@Middle_name_Sotr", Middle_name_Sotr);
            cmd.Parameters.AddWithValue("@The_date_of_the_spending", The_date_of_the_spending);
            cmd.Parameters.AddWithValue("@Adres_Proj", Adres_Proj);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spSotr_Update(string Login_Sotr, string Surname_Sotr, string Name_Sotr, string Middle_name_Sotr, string The_date_of_the_spending, string Adres_Proj)
        {
            spConfiguration("Sotr_Update");
            cmd.Parameters.AddWithValue("@Login_Sotr", Login_Sotr);
            cmd.Parameters.AddWithValue("@Surname_Sotr", Surname_Sotr);
            cmd.Parameters.AddWithValue("@Name_Sotr", Name_Sotr);
            cmd.Parameters.AddWithValue("@Middle_name_Sotr", Middle_name_Sotr);
            cmd.Parameters.AddWithValue("@The_date_of_the_spending", The_date_of_the_spending);
            cmd.Parameters.AddWithValue("@Adres_Proj", Adres_Proj);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spAccess_rights_Insert(string Dolj, int Profili, int Client, int Sotrudniki, int vidi, int Firmi, int Colors, int Pol_Tova, int Tovari, int Skladi, int Prihodi, int Cheki)
        {
            spConfiguration("Access_rights_Insert");
            cmd.Parameters.AddWithValue("@Dolj", Dolj);
            cmd.Parameters.AddWithValue("@Profili", Profili);
            cmd.Parameters.AddWithValue("@Client", Client);
            cmd.Parameters.AddWithValue("@Sotrudniki", Sotrudniki);
            cmd.Parameters.AddWithValue("@vidi", vidi);
            cmd.Parameters.AddWithValue("@Firmi", Firmi);
            cmd.Parameters.AddWithValue("@Colors", Colors);
            cmd.Parameters.AddWithValue("@Pol_Tova", Pol_Tova);
            cmd.Parameters.AddWithValue("@Tovari", Tovari);
            cmd.Parameters.AddWithValue("@Skladi", Skladi);
            cmd.Parameters.AddWithValue("@Prihodi", Prihodi);
            cmd.Parameters.AddWithValue("@Cheki", Cheki);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spAccess_rights_Update(int ID_Access_rights, string Dolj, int Profili, int Client, int Sotrudniki, int vidi, int Firmi, int Colors, int Pol_Tova, int Tovari, int Skladi, int Prihodi, int Cheki)
        {
            spConfiguration("Access_rights_Update");
            cmd.Parameters.AddWithValue("@ID_Access_rights", ID_Access_rights);
            cmd.Parameters.AddWithValue("@Dolj", Dolj);
            cmd.Parameters.AddWithValue("@Profili", Profili);
            cmd.Parameters.AddWithValue("@Client", Client);
            cmd.Parameters.AddWithValue("@Sotrudniki", Sotrudniki);
            cmd.Parameters.AddWithValue("@vidi", vidi);
            cmd.Parameters.AddWithValue("@Firmi", Firmi);
            cmd.Parameters.AddWithValue("@Colors", Colors);
            cmd.Parameters.AddWithValue("@Pol_Tova", Pol_Tova);
            cmd.Parameters.AddWithValue("@Tovari", Tovari);
            cmd.Parameters.AddWithValue("@Skladi", Skladi);
            cmd.Parameters.AddWithValue("@Prihodi", Prihodi);
            cmd.Parameters.AddWithValue("@Cheki", Cheki);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spAccess_rights_Delete(int ID_Access_rights)
        {
            spConfiguration("Access_rights_Delete");
            cmd.Parameters.AddWithValue("@ID_Access_rights", ID_Access_rights);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spAccess_rights_Logical_Delete(int ID_Access_rights)
        {
            spConfiguration("Access_rights_Logical_Delete");
            cmd.Parameters.AddWithValue("@ID_Access_rights", ID_Access_rights);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spProfile_Delete_User(string Login_Profile)
        {
            spConfiguration("Profile_Delete_User");
            cmd.Parameters.AddWithValue("@Login_Profile", Login_Profile);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spProfile_Logical_Delete(string Login_Profile)
        {
            spConfiguration("Profile_Logical_Delete");
            cmd.Parameters.AddWithValue("@Login_Profile", Login_Profile);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }

        public void spProfile_New_User(string Login_Profile, string Password_Profile, int Access_rights_ID, string Profile_Image)
        {
            spConfiguration("Profile_New_User");
            cmd.Parameters.AddWithValue("@Login_Profile", Login_Profile);
            cmd.Parameters.AddWithValue("@Password_Profile", Password_Profile);
            cmd.Parameters.AddWithValue("@Access_rights_ID", Access_rights_ID);
            cmd.Parameters.AddWithValue("@Profile_Image", Profile_Image);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }
        
        public void spProfile_Update_User(string Login_Profile, string Password_Profile, int Access_rights_ID,int System_access, string Profile_Image)
        {
            spConfiguration("Profile_Update_User");
            cmd.Parameters.AddWithValue("@Login_Profile", Login_Profile);
            cmd.Parameters.AddWithValue("@Password_Profile", Password_Profile);
            cmd.Parameters.AddWithValue("@Access_rights_ID", Access_rights_ID);
            cmd.Parameters.AddWithValue("@System_access", System_access);
            cmd.Parameters.AddWithValue("@Profile_Image", Profile_Image);
            Registry_Class.sqlConnection.Open();
            Registry_Class.sqlConnection.InfoMessage += message;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Registry_Class.sqlConnection.Close();
        }
    }
}
