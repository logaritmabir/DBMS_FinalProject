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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7R1GKNS\\FORMAT;Initial Catalog=UBS;Integrated Security=True");
        public static string form_variable;
        private void buttonGiris_Click(object sender, EventArgs e)
        {
            form_variable = textBox2.Text;

            if (baglanti.State.ToString() == "Closed")
            {
                baglanti.Open();
            }
            try
            {
                if (int.Parse(textBox2.Text.ToString()) > 19060299 && int.Parse(textBox2.Text.ToString()) < 29060300)
                {
                    

                    string query = "Select * from OgrenciTable where OgrenciTC = @TC and OgrenciNo = @No";

                    SqlParameter prm1 = new SqlParameter("TC", textBox1.Text.Trim());
                    SqlParameter prm2 = new SqlParameter("No", textBox2.Text.Trim());

                    SqlCommand cmd = new SqlCommand(query, baglanti);

                    cmd.Parameters.Add(prm1);
                    cmd.Parameters.Add(prm2);

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        MessageBox.Show("Öğrenci Girişi");
                        Form f = new Form2();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı bulunamadı");
                    }
                }

                else if (int.Parse(textBox2.Text.ToString()) > 29060299 && int.Parse(textBox2.Text.ToString()) < 39060300)
                {

                    string query = "Select * from OgretmenTable where OgretmenTC = @TC and OgretmenID = @ID";
                    SqlParameter prm1 = new SqlParameter("TC", textBox1.Text.Trim());
                    SqlParameter prm2 = new SqlParameter("ID", textBox2.Text.Trim());
                    SqlCommand cmd = new SqlCommand(query, baglanti);
                    cmd.Parameters.Add(prm1);
                    cmd.Parameters.Add(prm2);
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        MessageBox.Show("Öğretmen Girişi");
                        Form f = new Form4();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı bulunamadı");
                    }
                }

                else if (int.Parse(textBox2.Text.ToString()) > 39060299)
                {
                    string query = "Select * from MemurTable where MemurTC = @TC and MemurID = @ID";

                    SqlParameter prm1 = new SqlParameter("TC", textBox1.Text.Trim());
                    SqlParameter prm2 = new SqlParameter("ID", textBox2.Text.Trim());

                    SqlCommand cmd = new SqlCommand(query, baglanti);

                    cmd.Parameters.Add(prm1);
                    cmd.Parameters.Add(prm2);

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        MessageBox.Show("Memur Girişi");
                        Form f = new Form5();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı bulunamadı");
                    }
                }

                else
                {
                    if(textBox1.Text.Length != 11 || textBox2.Text.Length != 8)
                    {
                        MessageBox.Show("Geçersiz Kullanıcı Adı veya Şifre");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
