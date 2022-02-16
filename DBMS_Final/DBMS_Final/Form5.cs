using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBMS_Final
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7R1GKNS\\FORMAT;Initial Catalog=UBS;Integrated Security=True");

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox3.Text = Form1.form_variable;

            baglanti.Open();

            string query = "select * from MemurTable where MemurID = '" + textBox3.Text + "'"; //Memur bilgilerini çekme
            SqlCommand cmd = new SqlCommand(query, baglanti);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            textBox1.Text = reader.GetString(1); //Memur bilgilerini yazdırma textboxlara
            textBox2.Text = reader.GetString(2);

            reader.Close();

            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Öğretmen veya Öğrenci Tanımlama");
            Form f = new Form6();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Öğretmen veya Öğrenci Düzenle");
            Form f = new Form7();
            f.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
