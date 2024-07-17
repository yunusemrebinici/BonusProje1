using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusProje1
{
    public partial class FrmOgrenciler : Form
    {
        public FrmOgrenciler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=EMRE\SQLEXPRESS01;Initial Catalog=BonusOkul;Integrated Security=True;");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmOgretmen fr=new FrmOgretmen();
            fr.Show();
        }

        private void FrmOgrenciler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLKULUPLER",baglanti);
            SqlDataAdapter da =new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KULUPAD";
            comboBox1.ValueMember= "KULUPID";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }
        string c = "";
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            
            
            ds.OgrenciEkle(TxtAdı.Text,TxtSoyAd.Text,byte.Parse(comboBox1.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci Ekleme Yapıldı ");
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TxtID.Text = comboBox1.SelectedValue.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(TxtID.Text));
            MessageBox.Show("Silme İşlemi yapıldı");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAdı.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyAd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            c = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (c=="ERKEK"|| c=="Erkek")
            {
                radioButton2.Checked = true;
            }
            if (c=="KIZ"|| c=="Kız")
            {
                radioButton1.Checked = true;
            }
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtAdı.Text,TxtSoyAd.Text,byte.Parse(comboBox1.SelectedValue.ToString()),c,int.Parse(TxtID.Text));
            MessageBox.Show("Güncelleme Yapıldı");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.OgrenciGetir(TxtAra.Text);

        }
    }
}
