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
    public partial class Autoriz : Form
    {
        DataBase_Configuration data = new DataBase_Configuration();
        AuthCl auth = new AuthCl();
        public Autoriz()
        {
            InitializeComponent();
        }

        public void button2_Click(object sender, EventArgs e)
        {
           // Perem perem = new Perem();
            Program.Log = textBox1.Text;
            auth.FunAuth(textBox1.Text, textBox2.Text);
            if (Program.acc == 1 && Program.System_Access == 1)
            {
                GlavMenu glav = new GlavMenu();
                glav.Show();
                glav.tsslCon.Text = Registry_Class.DS + " - " + Registry_Class.IC;
            }
            else
            {
                if (Program.acc == 1 && Program.System_Access == 0)
                {
                    MessageBox.Show("Ваш профиль заблокирован!!!");
                }
            }
            Visible = false;
        }

        private void Autoriz_Load(object sender, EventArgs e)
        {
            tsslCon.Visible = true;
            tsslCon.Text = "Опрделение серверера...";
            data.conState += constate;
            Thread thread = new Thread(data.Connection_check);
            thread.Start();
            Thread.Sleep(100);
            
        }

        private void constate(bool value)
        {
            GlavMenu glav = new GlavMenu();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Regist regist = new Regist();
            regist.Show();
            Hide();
        }
    }
}
