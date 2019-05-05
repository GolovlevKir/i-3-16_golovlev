using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ortoped_Store
{
    public partial class Prihod : Form
    {
        DataBaseProcedure procedure = new DataBaseProcedure();
        public Prihod()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
        }

        public void Prihod_Load(object sender, EventArgs e)
        {
            Thread threadPrih = new Thread(PrihLoad);
            threadPrih.Start();
            Thread threadTov = new Thread(TovarLoad);
            threadTov.Start();
        }

        private void PrihLoad()
        {
            Action action = () =>
            {
                try
                {
                    DataBaseTables dataComb = new DataBaseTables();
                    dataComb.dtPrihod.Clear();
                    dataComb.dtPrihodFill();
                    dataComb.dependency.OnChange += Prihonchange;
                    dataGridView1.DataSource = dataComb.dtPrihod;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].HeaderText = "Товар";
                    dataGridView1.Columns[2].Width = 300;
                    dataGridView1.Columns[3].HeaderText = "Количество";
                }
                catch
                {

                }

            };
            Invoke(action);
        }

        private void Prihonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                PrihLoad();
        }

        private void TovarLoad()
        {
            Action action = () =>
            {
                try
                {
                    DataBaseTables dataComb = new DataBaseTables();
                    dataComb.dtTovar.Clear();
                    dataComb.dtTovarFill();
                    dataComb.dependency.OnChange += Tovaronchange;
                    comboBox4.DataSource = dataComb.dtTovar;
                    comboBox4.ValueMember = "ID_Tovar";
                    comboBox4.DisplayMember = "Товар";
                }
                catch
                {

                }

            };
            Invoke(action);
        }

        private void Tovaronchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                TovarLoad();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            procedure.spAdd_Prihod(Convert.ToInt32(comboBox4.SelectedValue.ToString()), (int)numericUpDown1.Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            procedure.spPrih_Logical_Delete((int)dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            procedure.spUPD_Prihod(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), Convert.ToInt32(comboBox4.SelectedValue.ToString()), (int)numericUpDown1.Value);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            numericUpDown1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox4.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void Prihod_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlavMenu glav = new GlavMenu();
            glav.Show();
            Hide();
        }

        private void otch()
        {
            Documentacia configurationForm = new Documentacia();
            configurationForm.Documentacia_Load(null, null);
            switch (Registry_Class.DirPath == "Empry" || Registry_Class.OrganizationName == "Empty"
                || Registry_Class.DocBM == 0.0 || Registry_Class.DocTM == 0.0 ||
                Registry_Class.DocRM == 0.0 || Registry_Class.DocLM == 0.0)
            {
                case (true):

                    configurationForm.ShowDialog();
                    break;
                case (false):
                    DataBaseTables data = new DataBaseTables();
                    data.qrPrihod = "SELECT 'Фирма: ' + dbo.Firma.NaimFir + ' Вид: ' + dbo.Vidi_Tov.Naim + ' Пол: ' + dbo.Pol.Pol + ' Цвет: ' + dbo.Cvet_Tov.Cvet + ' Наимнование товара: ' + dbo.Tovar.Naim AS 'Наименование товара', dbo.Prihod.Kol_vo_Tov FROM   dbo.Cvet_Tov INNER JOIN dbo.Tovar ON dbo.Cvet_Tov.ID_Cvet = dbo.Tovar.ID_Cvet INNER JOIN dbo.Firma ON dbo.Tovar.Firm_ID = dbo.Firma.ID_Firm INNER JOIN dbo.Pol ON dbo.Tovar.ID_Pol = dbo.Pol.ID_Pol INNER JOIN dbo.Prihod ON dbo.Tovar.ID_Tovar = dbo.Prihod.ID_Tovar INNER JOIN dbo.Vidi_Tov ON dbo.Tovar.ID_Vid = dbo.Vidi_Tov.ID_Vid ";
                    data.dtPrihodFill();
                    ExcelDocument document = new ExcelDocument();
                    document.dtDannieSklada = data.dtPrihod;
                    document.SpisokOnPrih();
                    break;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Thread(() => {
                //работы где-то на 2 минуты
                this.Invoke(new Action(() =>
                {
                    button1.Enabled = false;
                }));
                otch();
                this.Invoke(new Action(() =>
                {
                    button1.Enabled = true;
                    MessageBox.Show("Отчет сохранен");
                }));
            }).Start();

            
        }
    }
}
