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

namespace Oyun
{
    public partial class Form1 : Form
    {
        Form2 frm = new Form2();
        SqlConnection baglanti = new SqlConnection("Data Source=.; Initial Catalog=oyun; Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        public static string gon;
        private void button1_Click(object sender, EventArgs e)
        {
            string ıd, pass;
            ıd = textBox1.Text;
            pass = textBox2.Text;
            gon = textBox1.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select id,pass from giriş",baglanti);//seçtiklerimizi çalışşsın diye nesneye atadık 
            SqlDataReader oku;//oku nesne .
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (ıd == oku[0].ToString() && pass == oku[1].ToString())
                {
                    frm.Show();
                    this.Hide();
                }
            }
            baglanti.Close();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox2.PasswordChar = '\0';
            else
                textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
