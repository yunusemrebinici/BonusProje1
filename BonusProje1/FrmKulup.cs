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

namespace BonusProje1
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLKULUPLER ", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=EMRE\SQLEXPRESS01;Initial Catalog=BonusOkul;Integrated Security=True;");

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("INSERT INTO TBLKULUPLER (KULUPAD) VALUES (@p1)", baglanti);
            ekle.Parameters.AddWithValue("@p1",TxtKulupAdı.Text);
            ekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            liste();

            
                
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmOgretmen fr= new FrmOgretmen();
            fr.Show();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor=Color.Gray;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAdı.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() ;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete From TBLKULUPLER WHERE KULUPID=@p1",baglanti);
            sil.Parameters.AddWithValue("@p1",TxtKulupID.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi gerçekleşti");
            liste();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand gun = new SqlCommand("Update TBLKULUPLER SET KULUPAD=@p1 WHERE KULUPID=@p2", baglanti);
            gun.Parameters.AddWithValue("@p1",TxtKulupAdı.Text);
            gun.Parameters.AddWithValue("@p2",TxtKulupID.Text);
            gun.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi gerçekleşti");
            liste();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TxtKulupID_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtKulupAdı_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
