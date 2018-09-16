using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Oyun
{
    public partial class Form2 : Form
    {
        
        Form3 frm = new Form3();
        SqlConnection baglanti = new SqlConnection("Data Source=.; Initial Catalog=oyun; Integrated Security=True");
       public int sayac1,sayac2, sayac3 ,deger = 12;
        public Form2()
        {
            InitializeComponent();
        }
        public static int i;
        public static int t=0, y=0; int say;
        private void Form2_Load(object sender, EventArgs e)
        {
            t = 0; y = 0;
            string ıd;
            ıd = Form1.gon;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select id,bakiye from giriş where id='"+ıd+"'", baglanti);//seçtiklerimizi çalışşsın diye nesneye atadık 
            SqlDataReader oku;//oku nesne .
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                label6.Text = oku[0].ToString();
                label2.Text = oku[1].ToString();
            }
            baglanti.Close(); sayac1 = 0; sayac3 = 0; sayac2 = 0;
            Random rastgele = new Random();
            int sayi = rastgele.Next(0, 10);
            i = sayi; timer2.Enabled = true;
            if (sayi % 2 == 0)
            {
                label4.Text = "Y"; baglanti.Open();
                SqlCommand oho = new SqlCommand("insert into iht (ihtimal) values ('Y')", baglanti);
                oho.ExecuteNonQuery();
                baglanti.Close();
            }
            else
            {
                label4.Text = "T";
                baglanti.Open();
                SqlCommand koko = new SqlCommand("insert into iht (ihtimal) values ('T')", baglanti);
                koko.ExecuteNonQuery();
                baglanti.Close();
                
            }
            



        }

        private void button5_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            label7.Text = "-200";
            say = 5;
            timer1.Interval = 100;
            timer1.Enabled = true;
            sayac2++;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            label7.Text = "-300";
            say = 5;
            timer1.Interval = 100;
            timer1.Enabled = true;
            sayac3++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            say--;
            if (say == 0)
                label7.Visible = false;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (deger >= 0)
            {
                deger--;
                label3.Text = Convert.ToString(deger);
            }
           if(deger==0)
            { Form2 fff = new Form2();
                fff.Show();this.Hide();
               
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                int top, a; string ıd; ıd = Form1.gon;
                a = Convert.ToInt32(textBox1.Text);
                top = sayac1 * 100 + sayac2 * 200 + sayac3 * 300 + a;
                if (i % 2 == 0)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("UPDATE giriş SET bakiye='" + (Convert.ToInt32(label2.Text) + top) + "' where id='" + ıd + "'", baglanti);
                    komut.ExecuteNonQuery();
                    SqlCommand pip = new SqlCommand("Select bakiye from giriş where id='" + ıd + "'", baglanti);
                    SqlDataReader oku;
                    oku = pip.ExecuteReader();
                    while (oku.Read())
                    {
                        label2.Text = oku[0].ToString();
                    }
                    baglanti.Close();
                }
                else
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("UPDATE giriş SET bakiye='" + (Convert.ToInt32(label2.Text) - top) + "' where id='" + ıd + "'", baglanti);
                    komut.ExecuteNonQuery();
                    SqlCommand pip = new SqlCommand("Select bakiye from giriş where id='" + ıd + "'", baglanti);
                    SqlDataReader oku;
                    oku = pip.ExecuteReader();
                    while (oku.Read())
                    {
                        label2.Text = oku[0].ToString();
                    }
                    baglanti.Close();
                }
                sayac1 = 0; sayac2 = 0; sayac3 = 0;
                textBox1.Text = "0";
              
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            label7.Text = "-100";
            say = 5;
            timer1.Interval = 100;
            timer1.Enabled = true;
            sayac1++;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                int top, a; string ıd; ıd = Form1.gon;
                t++;
                a = Convert.ToInt32(textBox1.Text);
                top = sayac1 * 100 + sayac2 * 200 + sayac3 * 300 + a;
                if (i % 2 == 0)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("UPDATE giriş SET bakiye='" + (Convert.ToInt32(label2.Text) - top) + "' where id='" + ıd + "'", baglanti);
                    komut.ExecuteNonQuery();
                    SqlCommand pip = new SqlCommand("Select bakiye from giriş where id='" + ıd + "'", baglanti);
                    SqlDataReader oku;
                    oku = pip.ExecuteReader();
                    while (oku.Read())
                    {
                        label2.Text = oku[0].ToString();
                    }
                    baglanti.Close();
                }
                else
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("UPDATE giriş SET bakiye='" + (Convert.ToInt32(label2.Text) + top) + "' where id='" + ıd + "'", baglanti);
                    komut.ExecuteNonQuery();
                    SqlCommand pip = new SqlCommand("Select bakiye from giriş where id='" + ıd + "'", baglanti);
                    SqlDataReader oku;
                    oku = pip.ExecuteReader();
                    while (oku.Read())
                    {
                        label2.Text = oku[0].ToString();
                    }
                    baglanti.Close();
                }
                sayac1 = 0; sayac2 = 0; sayac3 = 0;
                textBox1.Text = "0";
               
            
        }
    }
}