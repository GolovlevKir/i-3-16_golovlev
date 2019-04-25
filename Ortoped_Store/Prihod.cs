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
    }
}
