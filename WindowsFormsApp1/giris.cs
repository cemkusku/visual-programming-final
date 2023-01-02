using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace WindowsFormsApp1
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        public static string User;
        private void button2_Click(object sender, EventArgs e)
        {
            string Query = "select count(*) from kullanıcı where kullanici_adi='" + UnameTb.Text + "' and sifre='" + PasswordTb.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query,DB.baglanti());
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                User = UnameTb.Text;
                görünenrezervasyon Obj = new görünenrezervasyon();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Adı veya Parola Girdiniz!");
                UnameTb.Text = "";
                PasswordTb.Text = "";
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            admin Obj = new admin();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            görünenkullanıcılar Obj = new görünenkullanıcılar();
            Obj.Show();
            this.Hide();
        }

        private void giris_Load(object sender, EventArgs e)
        {
            PasswordTb.PasswordChar = '*';
        }
    }
}
