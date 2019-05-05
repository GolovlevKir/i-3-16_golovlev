using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ortoped_Store
{
    public partial class GlavMenu : Form
    {
        DataBase_Configuration data = new DataBase_Configuration();
        Tovar Tovar = new Tovar();


        public GlavMenu()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
        }

        public void GlavMenu_Load(object sender, EventArgs e)
        {
                AuthCl auth = new AuthCl();
                auth.FunProf(label3, label4, pictureBox1);
                разграничениеПравДоступаToolStripMenuItem.Visible = Convert.ToBoolean(Program.Sot);
                настройкаОтчетностиToolStripMenuItem.Visible = Convert.ToBoolean(Program.Sot);
                списокСотрудниковToolStripMenuItem.Visible = Convert.ToBoolean(Program.Sot);
                конфигурацияПодключенияToolStripMenuItem.Visible = Convert.ToBoolean(Program.Sot);
                товарToolStripMenuItem.Visible = Convert.ToBoolean(Program.Tov);
                приходнойЛистToolStripMenuItem.Visible = Convert.ToBoolean(Program.Pri);
                складToolStripMenuItem.Visible = Convert.ToBoolean(Program.Skl);
                общийЧекToolStripMenuItem.Visible = Convert.ToBoolean(Program.Che);
                Tovar.panel3.Enabled = Convert.ToBoolean(Program.Fir);
                Tovar.panel5.Enabled = Convert.ToBoolean(Program.Tov);
                Tovar.panel4.Enabled = Convert.ToBoolean(Program.Col);
                Tovar.panel6.Enabled = Convert.ToBoolean(Program.Vid);
                tsslCon.Text = Registry_Class.DS + " - " + Registry_Class.IC;
        }

        private void constate(bool value)
        {
            Action action = () =>
            {
                switch (value)
                {
                    case (true):
                        tsslCon.Visible = true;
                        tsslCon.Text = Registry_Class.DS + " - " + Registry_Class.IC;
                        break;
                    case (false):
                        ConectionForm conection = new ConectionForm();
                        tsslCon.Visible = true;
                        tsslCon.Text = "Подключение отсутвует!";
                        conection.Show(this);
                        break;
                }
            };
            Invoke(action);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tssldateTime.Text = DateTime.Now.ToLongTimeString() + "/" + DateTime.Now.ToShortDateString();
        }

        private void разграничениеПравToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sotrudniki sotrudniki = new Sotrudniki();
            sotrudniki.Show();
            Hide();
        }

        private void товарToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tovar.Show();
            Hide();
        }

        private void приходнойЛистToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prihod prihod = new Prihod();
            prihod.Show();
            Hide();
        }

        private void складToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sklad sklad = new Sklad();
            sklad.Show();
            Hide();
        }

        private void общийЧекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObChek obChek = new ObChek();
            obChek.Show();
            Hide();
        }

        private void справочникиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void разграничениеПравДоступаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rights rights = new Rights();
            rights.Show();
            Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void выходИзПрофиляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Log = "";
            Autoriz autoriz = new Autoriz();
            autoriz.Show();
            Hide();
        }

        private void завершитьРаботуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GlavMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void конфигурацияПодключенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConectionForm conectionForm = new ConectionForm();
            conectionForm.Show();

        }

        private void НастройкаОтчетностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Documentacia documentacia = new Documentacia();
            documentacia.Show();
        }
    }
}
