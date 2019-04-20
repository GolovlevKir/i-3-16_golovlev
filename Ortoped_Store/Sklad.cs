using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ortoped_Store
{
    public partial class Sklad : Form
    {
        public Sklad()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
        }

        DataBaseProcedure procedure = new DataBaseProcedure();
        DataBaseTables dataComb = new DataBaseTables();

        private void SkladLoad()
        {
            Action action = () =>
            {
                try
                {
                    dataComb.dtSklad.Clear();
                    dataComb.dtSkladFill();
                    dataComb.dependency.OnChange += Skladonchange;
                    dataGridView1.DataSource = dataComb.dtSklad;
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

        private void Skladonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                SkladLoad();
        }

        private void TovarLoad()
        {
            Action action = () =>
            {
                try
                {
                    
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


        private void Sklad_Load(object sender, EventArgs e)
        {
            Thread threadSklad = new Thread(SkladLoad);
            threadSklad.Start();
            Thread threadTovar = new Thread(TovarLoad);
            threadTovar.Start();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            procedure.spAdd_Sklad((int)comboBox4.SelectedValue, (int)numericUpDown1.Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            procedure.spSclad_Logical_Delete((int)dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            procedure.spUPD_Sklad((int)dataGridView1.CurrentRow.Cells[0].Value, (int)comboBox4.SelectedValue, (int)numericUpDown1.Value);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox4.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                numericUpDown1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch { }
        }

        private void Sklad_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlavMenu glav = new GlavMenu();
            glav.Show();
            Hide();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            DataBaseTables data = new DataBaseTables();
            data.qrSklad += "and dbo.Firma.NaimFir like '%" + textBox8.Text + "%'" +
                " or dbo.Vidi_Tov.Naim like '%"+textBox8.Text+ "%' or dbo.Tovar.Naim like '%" + textBox8.Text + "%' or dbo.Pol.Pol like '%" + textBox8.Text + "%' or dbo.Cvet_Tov.Cvet like '%" + textBox8.Text + "%' or " +
                " dbo.Sklad.Kol_vo_Tov like '%" + textBox8.Text + "%'";
            data.dtSkladFill();
            dataGridView1.DataSource = data.dtSklad;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Товар";
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Columns[3].HeaderText = "Количество";
        }
    }
}
