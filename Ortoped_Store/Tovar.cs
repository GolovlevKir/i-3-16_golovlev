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
    public partial class Tovar : Form
    {
        DataBaseProcedure procedure = new DataBaseProcedure();
        DataBaseTables tableTovar = new DataBaseTables();
        DataBaseTables tableVidi = new DataBaseTables();
        DataBaseTables tableFirmi = new DataBaseTables();
        DataBaseTables tableCveta = new DataBaseTables();
        DataBaseTables tableVidicb = new DataBaseTables();
        DataBaseTables tableFirmicb = new DataBaseTables();
        DataBaseTables tableCvetacb = new DataBaseTables();
        DataBaseTables tablePolcb = new DataBaseTables();
        SqlConnection sql = new SqlConnection("Data Source = " + Registry_Class.DS +
                    "; Initial Catalog = " + Registry_Class.IC + "; Persist Security Info = true; " +
                    "User ID = " + Registry_Class.UI + "; Password = \"" + Registry_Class.PW + "\"");

       public Tovar()
       {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
       }

        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            procedure.spAdd_Tovar(textBox4.Text, (int)comboBox4.SelectedValue, (float)numericUpDown1.Value, (int)comboBox1.SelectedValue, (int)comboBox2.SelectedValue, (int)comboBox3.SelectedValue);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void Tovar_Load(object sender, EventArgs e)
        {
            Thread threadFirm = new Thread(FirmLoad);
            threadFirm.Start();
            Thread threadCvet = new Thread(CvetaLoad);
            threadCvet.Start();
            Thread threadVidi = new Thread(VidiLoad);
            threadVidi.Start();
            Thread threadPol = new Thread(CbPolLoad);
            threadPol.Start();
            Thread threadTov = new Thread(TovariLoad);
            threadTov.Start();
        }

        private void FirmLoad()
        {
            Action action = () =>
            {
                try
                {
                    DataBaseTables tables = new DataBaseTables();
                    tables.dtFirmaFill();
                    tables.dependency.OnChange += Firmonchange;
                    listBox1.DataSource = tables.dtFirma;
                    listBox1.ValueMember = "ID_Firm";
                    listBox1.DisplayMember = "NaimFir";
                    Thread threadfirm = new Thread(CbFirmLoad);
                    threadfirm.Start();
                }
                catch
                {

                }

            };
            Invoke(action);
        }

        private void Firmonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                FirmLoad();
        }

        private void CbFirmLoad()
        {
            Action action = () =>
            {
                try
                {
                    DataBaseTables tables = new DataBaseTables();
                    tables.dtFirmaFill();
                    tables.dependency.OnChange += CbFirmonchange;
                    comboBox4.DataSource = tables.dtFirma;
                    comboBox4.ValueMember = "ID_Firm";
                    comboBox4.DisplayMember = "NaimFir";
                }
                catch
                {

                }

            };
            Invoke(action);
        }

        private void CbFirmonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                FirmLoad();
        }

        private void CvetaLoad()
        {
            Action action = () =>
            {
                try
                {
                    DataBaseTables tables = new DataBaseTables();
                    tables.dtCvet_TovFill();
                    tables.dependency.OnChange += Cvetaonchange;
                    listBox2.DataSource = tables.dtCvet_Tov;
                    listBox2.ValueMember = "ID_Cvet";
                    listBox2.DisplayMember = "Cvet";
                    Thread threadCvet = new Thread(CbCvetaLoad);
                    threadCvet.Start();
                }
                catch
                {

                }

            };
            Invoke(action);
        }

        private void Cvetaonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                CvetaLoad();
        }

        private void CbCvetaLoad()
        {
            Action action = () =>
            {
                try
                {
                    DataBaseTables tables = new DataBaseTables();
                    tables.dtCvet_TovFill();
                    tables.dependency.OnChange += CbCvetaonchange;
                    comboBox2.DataSource = tables.dtCvet_Tov;
                    comboBox2.ValueMember = "ID_Cvet";
                    comboBox2.DisplayMember = "Cvet";
                }
                catch
                {

                }

            };
            Invoke(action);
        }

        private void CbCvetaonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                CbCvetaLoad();
        }

        private void VidiLoad()
        {
            Action action = () =>
            {
                try
                {
                    DataBaseTables tables = new DataBaseTables();
                    tables.dtVidi_TovFill();
                    tables.dependency.OnChange += Vidionchange;
                    listBox3.DataSource = tables.dtVidi_Tov;
                    listBox3.ValueMember = "ID_Vid";
                    listBox3.DisplayMember = "Naim";
                    Thread threadVid = new Thread(CbVidiLoad);
                    threadVid.Start();
                }
                catch
                {

                }

            };
            Invoke(action);
        }

        private void Vidionchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                VidiLoad();
        }

        private void CbVidiLoad()
        {
            Action action = () =>
            {
                try
                {
                    DataBaseTables tables = new DataBaseTables();
                    tables.dtVidi_TovFill();
                    tables.dependency.OnChange += CbVidionchange;
                    comboBox3.DataSource = tables.dtVidi_Tov;
                    comboBox3.ValueMember = "ID_Vid";
                    comboBox3.DisplayMember = "Naim";
                }
                catch
                {

                }

            };
            Invoke(action);
        }

        private void CbVidionchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                CbVidiLoad();
        }

        private void CbPolLoad()
        {
            Action action = () =>
            {
                try
                {
                    DataBaseTables tables = new DataBaseTables();
                    tables.dtPolFill();
                    tables.dependency.OnChange += CbPolonchange;
                    comboBox1.DataSource = tables.dtPol;
                    comboBox1.ValueMember = "ID_Pol";
                    comboBox1.DisplayMember = "Pol";
                }
                catch
                {

                }

            };
            Invoke(action);
        }

        private void TovariLoad()
        {
            Action action = () =>
            {
                try
                {
                    DataBaseTables dataComb = new DataBaseTables();
                    dataComb.dtTovar.Clear();
                    dataComb.dtTovarFill();
                    dataComb.dependency.OnChange += Tovonchange;
                    dataGridView1.DataSource = dataComb.dtTovar;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[9].Visible = false;
                    dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                    dataGridView1.Columns[13].Visible = false;
                    dataGridView1.Columns[15].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Наименование";
                    dataGridView1.Columns[4].HeaderText = "Фирма";
                    dataGridView1.Columns[5].HeaderText = "Цена";
                    dataGridView1.Columns[8].HeaderText = "Пол";
                    dataGridView1.Columns[11].HeaderText = "Цвет";
                    dataGridView1.Columns[14].HeaderText = "Вид";
                }
                catch
                {

                }

            };
            Invoke(action);
        }

        private void Tovonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                TovariLoad();
        }

        private void CbPolonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                CbPolLoad();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.Text;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = listBox2.Text;
        }

        private void listBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = listBox3.Text;
        }

        private void co(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            procedure.spAdd_Cvet_Tov(textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            procedure.spAdd_Firm(textBox1.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            procedure.spAdd_Vidi_Tov(textBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            procedure.spUPD_Tovar((int)dataGridView1.CurrentRow.Cells[0].Value, textBox4.Text, (int)comboBox4.SelectedValue, (float)numericUpDown1.Value, (int)comboBox1.SelectedValue, (int)comboBox2.SelectedValue, (int)comboBox3.SelectedValue);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            procedure.spCvet_Logical_Delete(Convert.ToInt32(listBox2.SelectedValue.ToString()));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            procedure.spUPD_Cvet_Tov(Convert.ToInt32(listBox2.SelectedValue.ToString()), textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            procedure.spFirm_Logical_Delete(Convert.ToInt32(listBox1.SelectedValue.ToString()));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            procedure.spVid_Logical_Delete(Convert.ToInt32(listBox3.SelectedValue.ToString()));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            procedure.spUpd_Firm(Convert.ToInt32(listBox1.SelectedValue.ToString()), textBox1.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            procedure.spUpd_Vidi_Tov(Convert.ToInt32(listBox3.SelectedValue.ToString()), textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            procedure.spTovar_Logical_Delete((int)dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox4.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            numericUpDown1.Value = (decimal)dataGridView1.CurrentRow.Cells[5].Value;
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox2.SelectedValue = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            comboBox3.SelectedValue = dataGridView1.CurrentRow.Cells[13].Value.ToString();
        }

        private void Tovar_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlavMenu glav = new GlavMenu();
            glav.Show();
            Hide();
        }
    }
}
