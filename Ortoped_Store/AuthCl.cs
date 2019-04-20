using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ortoped_Store
{
    class AuthCl
    {
        SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
        public string ava, Login, FIO_Kl, FIO_St, Dol;

        public void FunAuth(string login, string password)
        {
            try
            {
                command.CommandText = "Select Count(*) from Profile where Login_Profile = '" + login + "' and Password_Profile = '" + password + "'";
                Registry_Class.sqlConnection.Open();
                Program.acc = (int)command.ExecuteScalar();
                command.CommandText = "SELECT System_access FROM dbo.Profile where Login_Profile = '" + login + "'";
                Program.System_Access = (int)command.ExecuteScalar();
                command.CommandText = "SELECT dbo.Access_rights.Profili FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID where Login_Profile = '" + login + "' and Password_Profile = '" + password + "'";
                Program.Prof = (int)command.ExecuteScalar();
                command.CommandText = "SELECT dbo.Access_rights.Client FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID where Login_Profile = '" + login + "' and Password_Profile = '" + password + "'";
                Program.Cli = (int)command.ExecuteScalar();
                command.CommandText = "SELECT dbo.Access_rights.Sotrudniki FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID where Login_Profile = '" + login + "' and Password_Profile = '" + password + "'";
                Program.Sot = (int)command.ExecuteScalar();
                command.CommandText = "SELECT dbo.Access_rights.Vidi FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID where Login_Profile = '" + login + "' and Password_Profile = '" + password + "'";
                Program.Vid = (int)command.ExecuteScalar();
                command.CommandText = "SELECT dbo.Access_rights.Firmi FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID where Login_Profile = '" + login + "' and Password_Profile = '" + password + "'";
                Program.Fir = (int)command.ExecuteScalar();
                command.CommandText = "SELECT dbo.Access_rights.Colors FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID where Login_Profile = '" + login + "' and Password_Profile = '" + password + "'";
                Program.Col = (int)command.ExecuteScalar();
                command.CommandText = "SELECT dbo.Access_rights.Pol_Tova FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID where Login_Profile = '" + login + "' and Password_Profile = '" + password + "'";
                Program.Pol = (int)command.ExecuteScalar();
                command.CommandText = "SELECT dbo.Access_rights.Tovari FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID where Login_Profile = '" + login + "' and Password_Profile = '" + password + "'";
                Program.Tov = (int)command.ExecuteScalar();
                command.CommandText = "SELECT dbo.Access_rights.Skladi FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID where Login_Profile = '" + login + "' and Password_Profile = '" + password + "'";
                Program.Skl = (int)command.ExecuteScalar();
                command.CommandText = "SELECT dbo.Access_rights.Prihodi FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID where Login_Profile = '" + login + "' and Password_Profile = '" + password + "'";
                Program.Pri = (int)command.ExecuteScalar();
                command.CommandText = "SELECT dbo.Access_rights.Cheki FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID where Login_Profile = '" + login + "' and Password_Profile = '" + password + "'";
                Program.Che = (int)command.ExecuteScalar();

                Registry_Class.sqlConnection.Close();
            }
            catch
            { }
            
        }

        public void FunProf(Object senderFIO, Object senderDolj, Object Ava)
        {
                Registry_Class.sqlConnection.Open();
                try
                {
                    command.CommandText = "SELECT dbo.Sotr.Surname_Sotr + ' ' + SUBSTRING(dbo.Sotr.Name_Sotr,1,1) + '.' + SUBSTRING(dbo.Sotr.Middle_name_Sotr, 1,1) + '.' FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID INNER JOIN dbo.Sotr ON dbo.Profile.Login_Profile = dbo.Sotr.Login_Sotr where Login_Profile = '" + Program.Log + "'";
                    FIO_St = command.ExecuteScalar().ToString();
                }
                catch
                {
                    FIO_St = "";
                }
                try
                {
                    command.CommandText = "SELECT Surname_Klient + ' ' + SUBSTRING(Name_Klient, 1, 1) + '.' + SUBSTRING(Middle_name_Klient, 1, 1) + '.' FROM  dbo.Klient where Login_Klient = '" + Program.Log + "'";
                    FIO_Kl = command.ExecuteScalar().ToString();
                }
                catch
                {
                    FIO_Kl = "";
                }
                try
                {
                    command.CommandText = "SELECT dbo.Access_rights.Dolj FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID WHERE (dbo.Profile.Login_Profile = '" + Program.Log + "')";
                    Dol = command.ExecuteScalar().ToString();
                }
                catch
                {
                    Dol = "Что-то пошло не так";
                }
                try
                {
                    command.CommandText = "SELECT Profile_Image FROM dbo.Profile WHERE (dbo.Profile.Login_Profile = '" + Program.Log + "')";
                    ava = command.ExecuteScalar().ToString();
                }
                catch
                {
                    ava = "";
                }
                Registry_Class.sqlConnection.Close();
                (senderDolj as Label).Text = Dol;
                System.IO.FileInfo FI = new System.IO.FileInfo(ava);
                (Ava as PictureBox).Image = Image.FromFile(FI.FullName);
                if (FIO_St != "")
                    (senderFIO as Label).Text = "Ваше ФИО: " + FIO_St;
                else
                    (senderFIO as Label).Text = "Ваше ФИО: " + FIO_Kl;
        }
    }
}
