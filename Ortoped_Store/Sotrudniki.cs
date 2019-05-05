using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ortoped_Store
{
    public partial class Sotrudniki : Form
    {

        DataBaseProcedure procedure = new DataBaseProcedure();
        OpenFileDialog ofd = new OpenFileDialog();

        public Sotrudniki()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            dateTimePicker3.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            
        }

        private void Sotrudniki_Load(object sender, EventArgs e)
        {
            Thread threadSotr = new Thread(SotrLoad);
            threadSotr.Start();
            Thread threadSotrAcc = new Thread(AccSotrLoad);
            threadSotrAcc.Start();
            Thread threadKlAcc = new Thread(AccKlientLoad);
            threadKlAcc.Start();
            Thread threadAccR = new Thread(AccRLoad);
            threadAccR.Start();
            
        }

        private void SotrLoad()
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
                        dataComb.dependency.OnChange += Sotronchange;
                        dataGridView1.DataSource = dataComb.dtSotr;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        dataGridView1.Columns[5].HeaderText = "Дата рождения";
                        dataGridView1.Columns[6].HeaderText = "Адрес проживания";
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

        private void AccSotrLoad()
        {
            try
            { 
            Action action = () =>
            {
                try
                {
                    DataBaseTables dataComb = new DataBaseTables();
                    dataComb.dtProfile1.Clear();
                    dataComb.dtProfileSotrFill();
                    dataComb.dependency.OnChange += AccSotrLoadonchange;
                    dataGridView2.DataSource = dataComb.dtProfile1;

                    Thread prov = new Thread(ProverkaS);
                    prov.Start();
                    dataGridView2.Columns[2].Visible = false;
                    dataGridView2.Columns[4].Visible = false;
                    dataGridView2.Columns[5].Visible = false;
                    dataGridView2.Columns[6].Visible = false;
                    dataGridView2.Columns[7].Visible = false;
                    dataGridView2.Columns[8].Visible = false;
                    dataGridView2.Columns[14].Visible = false;
                    dataGridView2.Columns[0].HeaderText = "Логин";
                    dataGridView2.Columns[1].HeaderText = "Пароль";
                    dataGridView2.Columns[3].HeaderText = "Должность";
                    dataGridView2.Columns[9].HeaderText = "Фамилия";
                    dataGridView2.Columns[10].HeaderText = "Имя";
                    dataGridView2.Columns[11].HeaderText = "Отчество";
                    dataGridView2.Columns[12].HeaderText = "Дата рождения";
                    dataGridView2.Columns[13].HeaderText = "Адрес";
                }
                catch
                {

                }

            };
            Invoke(action);
        }
            catch { }
        }

        public void ProverkaS()
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
                if (dataGridView2[4, i].FormattedValue.ToString().
                    Contains("0"))
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
                }
        }
        public void ProverkaK()
        {
            for (int i = 0; i < dataGridView3.RowCount; i++)
                if (dataGridView3[4, i].FormattedValue.ToString().
                    Contains("0"))
                {
                    dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
                }
        }

        private void AccSotrLoadonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
            {
                AccSotrLoad();
            }
        }

        private void AccRLoad()
        {
            Action action = () =>
            {
                try
                {
                    DataBaseTables dataComb = new DataBaseTables();
                    dataComb.dtAccess_rights.Clear();
                    dataComb.dtAccess_rightsFill();
                    dataComb.dependency.OnChange += AccRoadonchange;
                    comboBox1.DataSource = dataComb.dtAccess_rights;
                    comboBox2.DataSource = dataComb.dtAccess_rights;
                    comboBox1.ValueMember = "ID_Access_rights";
                    comboBox1.DisplayMember = "Dolj";
                    comboBox2.ValueMember = "ID_Access_rights";
                    comboBox2.DisplayMember = "Dolj";
                }
                catch
                {

                }

            };
            Invoke(action);
        }

        private void AccRoadonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                AccRLoad();
        }

        private void AccKlientLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtProfile2.Clear();
                        dataComb.dtProfileKlientsFill();
                        dataComb.dependency.OnChange += AccKlientLoadonchange;
                        dataGridView3.DataSource = dataComb.dtProfile2;
                        Thread prov = new Thread(ProverkaK);
                        prov.Start();
                        dataGridView3.Columns[2].Visible = false;
                        dataGridView3.Columns[4].Visible = false;
                        dataGridView3.Columns[5].Visible = false;
                        dataGridView3.Columns[6].Visible = false;
                        dataGridView3.Columns[7].Visible = false;
                        dataGridView3.Columns[8].Visible = false;
                        dataGridView3.Columns[13].Visible = false;
                        dataGridView3.Columns[0].HeaderText = "Логин";
                        dataGridView3.Columns[1].HeaderText = "Пароль";
                        dataGridView3.Columns[3].HeaderText = "Должность";
                        dataGridView3.Columns[9].HeaderText = "Фамилия";
                        dataGridView3.Columns[10].HeaderText = "Имя";
                        dataGridView3.Columns[11].HeaderText = "Отчество";
                        dataGridView3.Columns[12].HeaderText = "Дата рождения";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void AccKlientLoadonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                AccKlientLoad();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["TabPage2"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            procedure.spSotr_Update(dataGridView1.CurrentRow.Cells[0].Value.ToString(), textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Text, textBox7.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            procedure.spSotr_Logical_Delete(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            if (ofd.ShowDialog(this) == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            button10_Click(sender, e);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            if (ofd.ShowDialog(this) == DialogResult.OK)
                pictureBox2.Image = Image.FromFile(ofd.FileName);
            button17_Click(sender, e);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch
            {

            }
            
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox11.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                textBox12.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox6.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
                textBox10.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
                textBox9.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells[13].Value.ToString();
                dateTimePicker2.Text = dataGridView2.CurrentRow.Cells[12].Value.ToString();
                comboBox1.SelectedValue = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                System.IO.FileInfo FI = new System.IO.FileInfo(@dataGridView2.CurrentRow.Cells[6].Value.ToString());
                pictureBox1.Image = Image.FromFile(FI.FullName);
                checkBox1.Checked = Convert.ToBoolean((int)dataGridView2.CurrentRow.Cells[4].Value);
                ofd.FileName = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            }
            catch
            {
                pictureBox1.Image = Ortoped_Store.Properties.Resources.NoPhoto;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            procedure.spProfile_New_User(textBox11.Text, textBox12.Text, (int)comboBox1.SelectedValue, ofd.FileName.ToString());
            procedure.spSotr_Insert(textBox11.Text, textBox6.Text, textBox10.Text, textBox9.Text, dateTimePicker2.Text, textBox2.Text);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            ProverkaS();
            ProverkaK();
        }

        private void dataGridView2_BindingContextChanged(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            procedure.spProfile_Update_User(textBox11.Text, textBox12.Text, (int)comboBox1.SelectedValue, Convert.ToInt32(checkBox1.Checked), ofd.FileName.ToString());
            procedure.spSotr_Update(textBox11.Text, textBox6.Text, textBox10.Text, textBox9.Text, dateTimePicker2.Text, textBox2.Text);
        }

        private void dataGridView2_Sorted(object sender, EventArgs e)
        {
            ProverkaS();
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox24.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                textBox23.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                textBox16.Text = dataGridView3.CurrentRow.Cells[9].Value.ToString();
                textBox15.Text = dataGridView3.CurrentRow.Cells[10].Value.ToString();
                textBox14.Text = dataGridView3.CurrentRow.Cells[11].Value.ToString();
                dateTimePicker3.Text = dataGridView3.CurrentRow.Cells[12].Value.ToString();
                comboBox1.SelectedValue = dataGridView3.CurrentRow.Cells[5].Value.ToString();
                System.IO.FileInfo FI = new System.IO.FileInfo(@dataGridView3.CurrentRow.Cells[6].Value.ToString());
                pictureBox2.Image = Image.FromFile(FI.FullName);
                checkBox2.Checked = Convert.ToBoolean((int)dataGridView3.CurrentRow.Cells[4].Value);
                ofd.FileName = dataGridView3.CurrentRow.Cells[6].Value.ToString();
            }
            catch
            {
                pictureBox2.Image = Ortoped_Store.Properties.Resources.NoPhoto;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            procedure.spProfile_New_User(textBox24.Text, textBox23.Text, (int)comboBox2.SelectedValue, ofd.FileName);
            procedure.spKlient_Insert(textBox24.Text, textBox16.Text, textBox15.Text, textBox14.Text, dateTimePicker3.Text);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            procedure.spProfile_Update_User(textBox24.Text, textBox23.Text, (int)comboBox2.SelectedValue,Convert.ToInt32(checkBox2.Checked) , ofd.FileName);
            procedure.spKlient_Update(textBox24.Text, textBox16.Text, textBox15.Text, textBox14.Text, dateTimePicker3.Text);
        }

        private void dataGridView3_Sorted(object sender, EventArgs e)
        {
            ProverkaK();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ofd.FileName = "";
            pictureBox2.Image = Ortoped_Store.Properties.Resources.NoPhoto;
            button17_Click(sender, e);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ofd.FileName = "";
            pictureBox1.Image = Ortoped_Store.Properties.Resources.NoPhoto;
            button10_Click(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            procedure.spProfile_Logical_Delete(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            procedure.spSotr_Logical_Delete(dataGridView2.CurrentRow.Cells[0].Value.ToString());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            procedure.spProfile_Logical_Delete(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            procedure.spKlient_Logical_Delete(dataGridView3.CurrentRow.Cells[0].Value.ToString());
        }

        private void Sotrudniki_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlavMenu glav = new GlavMenu();
            glav.Show();
            Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Thread(() => {
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

        public void otch()
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
                    data.qrSotr = "SELECT dbo.Sotr.Surname_Sotr + ' ' + dbo.Sotr.Name_Sotr + ' ' + dbo.Sotr.Middle_name_Sotr, dbo.Sotr.The_date_of_the_Rojd, dbo.Access_rights.Dolj FROM   dbo.Access_rights INNER JOIN dbo.Profile ON dbo.Access_rights.ID_Access_rights = dbo.Profile.Access_rights_ID INNER JOIN dbo.Sotr ON dbo.Profile.Login_Profile = dbo.Sotr.Login_Sotr ORDER BY dbo.Access_rights.Dolj ASC";
                    data.dtSotrFill();
                    ExcelDocument document = new ExcelDocument();
                    document.dtDannieSklada = data.dtSotr;
                    document.SpisokSotr();
                    break;
            }
        }
    }
}
