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
    public partial class görünenrezervasyon : Form
    {
        public görünenrezervasyon()
        {
            InitializeComponent();
            GetMüsteri();
            ShowRezervasyonlar();
            GetCars();
            UNameLbl.Text = giris.User;
        }
        private void GetMüsteri()
        {
            MySqlCommand cmd = new MySqlCommand("select * from musteri", DB.baglanti());
            MySqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("musteri_adi", typeof(string));
            dt.Load(rdr);
            CustCb.ValueMember = "musteri_adi";
            CustCb.DataSource = dt;
        }
        private void GetSurucu()
        {
            string Query = "select * from araclar where arac_plaka='" + VehicleCb.SelectedValue.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(Query, DB.baglanti());
            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DriverTb.Text = dr["surucu"].ToString();
            }
        }
        private void GetCars()
        {
            string IsBooked = "Hayır";
            MySqlCommand cmd = new MySqlCommand("select * from araclar where rezerve='" + IsBooked + "'", DB.baglanti());
            MySqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("arac_plaka", typeof(string));
            dt.Load(rdr);
            VehicleCb.ValueMember = "arac_plaka";
            VehicleCb.DataSource = dt;
        }
        private void Clear()
        {
            CustCb.SelectedIndex = -1;
            VehicleCb.SelectedIndex = -1;
            DriverTb.Text = "";
            AmountTb.Text = "";
        }
        private void ShowRezervasyonlar()
        {
            string Query = "select * from rezervasyon";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            MySqlCommandBuilder Builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookingsDGV.DataSource = ds.Tables[0];
        }
        private void UpdateVehicle()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update araclar set rezerve=@VB where arac_plaka=@VP", DB.baglanti());
                cmd.Parameters.AddWithValue("@VP", VehicleCb.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@VB", "Evet");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Aracınız Başarıyla Düzenlendi");
                Clear();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustCb.SelectedIndex == -1 || VehicleCb.SelectedIndex == -1 || DriverTb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("insert into rezervasyon(musteri_adi,arac,surucu,gidis_tarihi,donus_tarihi,ucret,rezervasyon_kullanici) values(@CN,@Veh,@Dri,@PDate,@DDate,@Am,@UN)", DB.baglanti());
                    cmd.Parameters.AddWithValue("@CN", CustCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Veh", VehicleCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Dri", DriverTb.Text);
                    cmd.Parameters.AddWithValue("@PDate", PickUpDate.Value.Date);
                    cmd.Parameters.AddWithValue("@DDate", RetDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Am", AmountTb.Text);
                    cmd.Parameters.AddWithValue("@UN", UNameLbl.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rezervasyonunuz Başarıyla Kaydedildi");
                    ShowRezervasyonlar();
                    UpdateVehicle();
                    Clear();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            giris Obj = new giris();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            görünenmüsteriler Obj = new görünenmüsteriler();
            Obj.Show();
            this.Hide();
        }

        private void AmountTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
