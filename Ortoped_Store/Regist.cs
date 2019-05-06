using System;
using System.Drawing;
using System.Windows.Forms;


namespace Ortoped_Store
{
    public partial class Regist : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();

        public Regist()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseProcedure procedure = new DataBaseProcedure();
            procedure.spProfile_New_User(textBox1.Text, textBox2.Text, 15, ofd.FileName);
            procedure.spKlient_Insert(textBox1.Text, textBox4.Text, textBox5.Text, textBox6.Text, dateTimePicker1.Text);
            Autoriz autoriz = new Autoriz();
            autoriz.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            if (ofd.ShowDialog(this) == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
        }

        private void Regist_FormClosing(object sender, FormClosingEventArgs e)
        {
            Autoriz autoriz = new Autoriz();
            autoriz.Show();
            Hide();
        }

        private void Regist_Load(object sender, EventArgs e)
        {

        }
    }
}
