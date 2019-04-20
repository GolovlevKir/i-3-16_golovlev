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
    public partial class Rights : Form
    {

        DataBaseProcedure procedure = new DataBaseProcedure();

        public Rights()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
        }

        private void Rights_Load(object sender, EventArgs e)
        {
            Thread threadSotr = new Thread(RightLo);
            threadSotr.Start();
        }

        private void RightLo()
        {
            Action action = () =>
            {
                try
                {
                    DataBaseTables dataComb = new DataBaseTables();
                    dataComb.dtAccess_rights.Clear();
                    dataComb.dtAccess_rightsFill();
                    dataComb.dependency.OnChange += Righonchange;
                    dataGridView1.DataSource = dataComb.dtAccess_rights;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[13].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Должность";
                    dataGridView1.Columns[2].HeaderText = "Профили";
                    dataGridView1.Columns[3].HeaderText = "Клиенты";
                    dataGridView1.Columns[4].HeaderText = "Сотрудники";
                    dataGridView1.Columns[5].HeaderText = "Виды";
                    dataGridView1.Columns[6].HeaderText = "Фирмы";
                    dataGridView1.Columns[7].HeaderText = "Цвета";
                    dataGridView1.Columns[8].HeaderText = "Пол";
                    dataGridView1.Columns[9].HeaderText = "Товары";
                    dataGridView1.Columns[10].HeaderText = "Склад";
                    dataGridView1.Columns[11].HeaderText = "Приходы";
                    dataGridView1.Columns[12].HeaderText = "Чек";
                }
                catch
                {

                }

            };
            Invoke(action);
        }

        private void Righonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                RightLo();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            procedure.spAccess_rights_Insert(textBox1.Text, Convert.ToInt32(checkBox1.Checked), Convert.ToInt32(checkBox2.Checked), Convert.ToInt32(checkBox3.Checked), Convert.ToInt32(checkBox4.Checked), Convert.ToInt32(checkBox5.Checked), Convert.ToInt32(checkBox6.Checked), 0, Convert.ToInt32(checkBox7.Checked), Convert.ToInt32(checkBox8.Checked), Convert.ToInt32(checkBox9.Checked), Convert.ToInt32(checkBox10.Checked));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            procedure.spAccess_rights_Update((int)dataGridView1.CurrentRow.Cells[0].Value, textBox1.Text, Convert.ToInt32(checkBox1.Checked), Convert.ToInt32(checkBox2.Checked), Convert.ToInt32(checkBox3.Checked), Convert.ToInt32(checkBox4.Checked), Convert.ToInt32(checkBox5.Checked), Convert.ToInt32(checkBox6.Checked), 0, Convert.ToInt32(checkBox7.Checked), Convert.ToInt32(checkBox8.Checked), Convert.ToInt32(checkBox9.Checked), Convert.ToInt32(checkBox10.Checked));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            procedure.spAccess_rights_Logical_Delete((int)dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                checkBox1.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[2].Value);
                checkBox2.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[3].Value);
                checkBox3.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value);
                checkBox4.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[5].Value);
                checkBox5.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[6].Value);
                checkBox6.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[7].Value);
                checkBox7.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[9].Value);
                checkBox8.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[10].Value);
                checkBox9.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[11].Value);
                checkBox10.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[12].Value);
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //textBox1.Text = Convert.ToInt32(checkBox1.Checked).ToString();
            }
            catch
            {

            }
        }

        private void Rights_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlavMenu glav = new GlavMenu();
            glav.Show();
            Hide();
        }
    }
}
