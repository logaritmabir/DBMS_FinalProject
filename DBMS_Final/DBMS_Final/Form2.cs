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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7R1GKNS\\FORMAT;Initial Catalog=UBS;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e) // Form2 ilk açıldığı zaman gerçekleşecek işlemler
        {
            textBox4.Text = Form1.form_variable; // Giriş yapan kişinin NO'sunu alıyoruz

            baglanti.Open();

            string query = "select * from OgrenciTable where OgrenciNo = '"+textBox4.Text+"'"; // Öğrencinin Tüm bilgilerini çekiyoruz
            SqlCommand cmd = new SqlCommand(query,baglanti);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            textBox1.Text = reader.GetString(1); // Öğrencinin bilgilerini textboxlara yazıyoruz
            textBox2.Text = reader.GetString(2);
            textBox3.Text = reader.GetString(4);

            reader.Close();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from DersTable", baglanti); // Dersleri datagrid view e dolduruyoruz,sistemde bulunan tüm dersleri
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            baglanti.Close();
        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e) // Data grid view de herhangi bir satırı seçtiğimizde o satırın bilgerini yukarıdaki text boxlara yerleştiriyoruz
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e) // Danışmana göndereceğimiz dersi ders kayıt ekranına ekliyoruz burada
        {
            baglanti.Open();
            try
            {
                string query = "Insert into OgrenciDersTable (OgrenciNo,DersID) values('" + textBox4.Text + "','" + textBox8.Text + "')";
                SqlCommand sqlCommand = new SqlCommand(query, baglanti);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ders Seçim Ekranı");
            Form f = new Form3();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Görüntüleme Ekranı");
            Form f = new Form8();
            f.Show();
        }
    }
}
