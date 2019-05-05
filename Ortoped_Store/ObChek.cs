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
    public partial class ObChek : Form
    {
        public string imya;
        private DataBaseProcedure procedure = new DataBaseProcedure();
        SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
        private int num;
        long inn;
        decimal Itog;

        public ObChek()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }

        public void ObChek_Load(object sender, EventArgs e)
        {
            Thread threadChek = new Thread(ChekLoad);
            threadChek.Start();
            Thread threadTovar = new Thread(TovarLoad);
            threadTovar.Start();
            Thread threadSotr = new Thread(SotrLoad);
            threadSotr.Start();
        }
        


        public void Potok()
        {
            
        }



        public void ChekLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtChek.Clear();
                        dataComb.dtChekFill();
                        dataComb.dependency.OnChange += Chekonchange;
                        dataGridView1.DataSource = dataComb.dtChek;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[4].Visible = false;
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView1.Columns[8].Visible = false;
                        dataGridView1.Columns[9].Visible = false;
                        dataGridView1.Columns[1].HeaderText = "№ Чека";
                        dataGridView1.Columns[2].HeaderText = "ИНН";
                        dataGridView1.Columns[3].HeaderText = "Дата и время продажи";
                        dataGridView1.Columns[6].HeaderText = "Наименование товара";
                        dataGridView1.Columns[7].HeaderText = "Кол-во";
                        dataGridView1.Columns[10].HeaderText = "ФИО сотрудника";

                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Chekonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                ChekLoad();
        }

        public void TovarLoad()
        {
            Action action = () =>
            {
                try
                {
                    DataBaseTables dataComb = new DataBaseTables();
                    dataComb.dtTovar.Clear();
                    dataComb.dtTovarFill();
                    dataComb.dependency.OnChange += Tovaronchange;
                    comboBox1.DataSource = dataComb.dtTovar;
                    comboBox1.ValueMember = "ID_Tovar";
                    comboBox1.DisplayMember = "Товар";
                }
                catch
                {

                }

            };
            Invoke(action);
        }

        public void SotrLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtSotr.Clear();
                        dataComb.dtSotrFill();
                        //Test function
                        dataComb.dependency.OnChange += Sotronchange;
                        comboBox2.DataSource = dataComb.dtSotr;
                        comboBox2.ValueMember = "Login_Sotr";
                        comboBox2.DisplayMember = "ФИО";
                        imya = comboBox2.Text;
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Sotronchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                SotrLoad();
        }

        private void Tovaronchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                TovarLoad();
        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void button3_Click(object sender, EventArgs e)
        {
            procedure.spAdd_Chek(num, inn.ToString(), (int)comboBox1.SelectedValue,(int)numericUpDown1.Value, comboBox2.SelectedValue.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            procedure.spUpd_Chek((int)dataGridView1.CurrentRow.Cells[0].Value, num, inn.ToString(), "12.04.2019 14:20", (int)comboBox1.SelectedValue, (int)numericUpDown1.Value, comboBox2.SelectedValue.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            procedure.spChek_Logical_Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBox2.SelectedValue = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                numericUpDown1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                label4.Text = "Номер чека: " + dataGridView1.CurrentRow.Cells[1].Value.ToString();
                label5.Text = "ИНН: " + dataGridView1.CurrentRow.Cells[2].Value.ToString();
                num = (int)dataGridView1.CurrentRow.Cells[1].Value;
                inn = Convert.ToInt64(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch { }
        }

        private void ObChek_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlavMenu glav = new GlavMenu();
            glav.Show();
            Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Thread(() => {
                //работы где-то на 2 минуты
                this.Invoke(new Action(() =>
                {
                    button1.Enabled = false;
                }));
                otZaDen();
                this.Invoke(new Action(() =>
                {
                    button1.Enabled = true;
                    MessageBox.Show("Отчет сохранен");
                }));
            }).Start();
        }

        public void otZaDen()
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
                    data.qrChek = "SELECT dbo.Chek.INN, dbo.Sotr.Surname_Sotr + ' ' + dbo.Sotr.Name_Sotr + ' ' + dbo.Sotr.Middle_name_Sotr, 'Фирма: ' + dbo.Firma.NaimFir + ', Вид: ' + dbo.Vidi_Tov.Naim + ', Пол: ' + dbo.Pol.Pol + ', Цвет: ' + dbo.Cvet_Tov.Cvet + ', Наименование товара: ' + dbo.Tovar.Naim AS 'Наименование товара', dbo.Chek.Kol_Vo* dbo.Tovar.Cena FROM   dbo.Chek INNER JOIN dbo.Sotr ON dbo.Chek.Login_Sotr = dbo.Sotr.Login_Sotr INNER JOIN dbo.Tovar ON dbo.Chek.ID_Tovar = dbo.Tovar.ID_Tovar INNER JOIN dbo.Firma ON dbo.Tovar.Firm_ID = dbo.Firma.ID_Firm INNER JOIN dbo.Pol ON dbo.Tovar.ID_Pol = dbo.Pol.ID_Pol INNER JOIN dbo.Cvet_Tov ON dbo.Tovar.ID_Cvet = dbo.Cvet_Tov.ID_Cvet INNER JOIN dbo.Vidi_Tov ON dbo.Tovar.ID_Vid = dbo.Vidi_Tov.ID_Vid where Data_Pech like '%'+CONVERT(VARCHAR(10),GETDATE(),104)+'%' or Data_Pech like '%'+CONVERT(VARCHAR(10),GETDATE(),4)+'%'";
                    data.dtChekFill();
                    WordDocument document = new WordDocument();
                    command.CommandText = "SELECT  Sum(dbo.Chek.Kol_Vo* dbo.Tovar.Cena) FROM   dbo.Chek INNER JOIN dbo.Sotr ON dbo.Chek.Login_Sotr = dbo.Sotr.Login_Sotr INNER JOIN dbo.Tovar ON dbo.Chek.ID_Tovar = dbo.Tovar.ID_Tovar INNER JOIN dbo.Firma ON dbo.Tovar.Firm_ID = dbo.Firma.ID_Firm INNER JOIN dbo.Pol ON dbo.Tovar.ID_Pol = dbo.Pol.ID_Pol INNER JOIN dbo.Cvet_Tov ON dbo.Tovar.ID_Cvet = dbo.Cvet_Tov.ID_Cvet INNER JOIN dbo.Vidi_Tov ON dbo.Tovar.ID_Vid = dbo.Vidi_Tov.ID_Vid where Data_Pech like '%'+CONVERT(VARCHAR(10),GETDATE(),104)+'%' or Data_Pech like '%'+CONVERT(VARCHAR(10),GETDATE(),4)+'%'";
                    Registry_Class.sqlConnection.Open();
                    Itog = (decimal)command.ExecuteScalar();
                    Registry_Class.sqlConnection.Close();
                    document.table = data.dtChek;
                    document.table2 = Itog.ToString();
                    document.CheckOtch();
                    break;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new Thread(() => {
                //работы где-то на 2 минуты
                this.Invoke(new Action(() =>
                {
                    button2.Enabled = false;
                }));
                otZaMes();
                this.Invoke(new Action(() =>
                {
                    button2.Enabled = true;
                    MessageBox.Show("Отчет сохранен");
                }));
            }).Start();

           
        }

        public void otZaMes()
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
                    data.qrChek = "SELECT  dbo.Chek.INN, dbo.Sotr.Surname_Sotr + ' ' + dbo.Sotr.Name_Sotr + ' ' + dbo.Sotr.Middle_name_Sotr, 'Фирма: ' + dbo.Firma.NaimFir + ', Вид: ' + dbo.Vidi_Tov.Naim + ', Пол: ' + dbo.Pol.Pol + ', Цвет: ' + dbo.Cvet_Tov.Cvet + ', Наименование товара: ' + dbo.Tovar.Naim AS 'Наименование товара', dbo.Chek.Kol_Vo* dbo.Tovar.Cena FROM   dbo.Chek INNER JOIN dbo.Sotr ON dbo.Chek.Login_Sotr = dbo.Sotr.Login_Sotr INNER JOIN dbo.Tovar ON dbo.Chek.ID_Tovar = dbo.Tovar.ID_Tovar INNER JOIN dbo.Firma ON dbo.Tovar.Firm_ID = dbo.Firma.ID_Firm INNER JOIN dbo.Pol ON dbo.Tovar.ID_Pol = dbo.Pol.ID_Pol INNER JOIN dbo.Cvet_Tov ON dbo.Tovar.ID_Cvet = dbo.Cvet_Tov.ID_Cvet INNER JOIN dbo.Vidi_Tov ON dbo.Tovar.ID_Vid = dbo.Vidi_Tov.ID_Vid where SUBSTRING(Data_Pech,4,2) = MONTH(GETDATE())";
                    data.dtChekFill();
                    WordDocument document = new WordDocument();
                    command.CommandText = "SELECT  Sum(dbo.Chek.Kol_Vo* dbo.Tovar.Cena) FROM   dbo.Chek INNER JOIN dbo.Sotr ON dbo.Chek.Login_Sotr = dbo.Sotr.Login_Sotr INNER JOIN dbo.Tovar ON dbo.Chek.ID_Tovar = dbo.Tovar.ID_Tovar INNER JOIN dbo.Firma ON dbo.Tovar.Firm_ID = dbo.Firma.ID_Firm INNER JOIN dbo.Pol ON dbo.Tovar.ID_Pol = dbo.Pol.ID_Pol INNER JOIN dbo.Cvet_Tov ON dbo.Tovar.ID_Cvet = dbo.Cvet_Tov.ID_Cvet INNER JOIN dbo.Vidi_Tov ON dbo.Tovar.ID_Vid = dbo.Vidi_Tov.ID_Vid where SUBSTRING(Data_Pech,4,2) = MONTH(GETDATE())";
                    Registry_Class.sqlConnection.Open();
                    Itog = (decimal)command.ExecuteScalar();
                    Registry_Class.sqlConnection.Close();
                    document.table = data.dtChek;
                    document.table2 = Itog.ToString();
                    document.CheckOtch2();
                    break;
            }
        }
    }
}
