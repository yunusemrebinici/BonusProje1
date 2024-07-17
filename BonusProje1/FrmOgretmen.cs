using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup fr = new FrmKulup();
            fr.Show();
            this.Hide();
        }

        private void BtnDers_Click(object sender, EventArgs e)
        {
            FrmDersler fr=new FrmDersler();
            fr.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fr=new Form1();
            fr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenciler fr=new FrmOgrenciler();
            this.Hide();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSınavNotlar fr=new FrmSınavNotlar();
            this.Hide();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
