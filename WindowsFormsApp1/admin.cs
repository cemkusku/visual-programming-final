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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            giris Obj = new giris();
            this.Hide();
            Obj.Show();
        }
        public static string password;
        

        private void button2_Click(object sender, EventArgs e)
        {
            string Query = "select count(*) from admin where admin_sifre ='" + PasswordTb.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                password = PasswordTb.Text;
                panel Obj = new panel();
                this.Hide();
                Obj.Show();
            }
            else
            {
                MessageBox.Show("Yanlış Admin Şifresi");
            }
        }

        private void admin_Load(object sender, EventArgs e)
        {
            PasswordTb.PasswordChar = '*';
        }
    }
}
