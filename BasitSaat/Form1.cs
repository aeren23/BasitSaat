using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasitSaat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int saat, dakika, saniye;
        DateTime zaman, kalınanzaman;

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label1.Text=textBox1.Text;
        }

        Boolean duraklama =false;


        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = ((Convert.ToString(saat) + ":") + (Convert.ToString(dakika) + ":") + Convert.ToString(saniye));
            if ((saniye == 0) && (dakika > 0))
            {
                dakika = dakika - 1;
                saniye = 59;
            }
            else if((saniye==0) && (dakika == 0) && (saat > 0))
            {
                saniye = 59;
                dakika = 59;
                saat--;
            }
            if((dakika==0) && (saat > 0))
            {
                dakika=59;
                saat--;
            }
            if((saat==0) && (dakika == 0) && (saniye == 0))
            {
                timer1.Enabled = true;
                MessageBox.Show("Süre Bitti");
            }
            saniye--;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Başla")
            {
                button1.Text = "Dur";
                if (duraklama == false)
                {
                    zaman = Convert.ToDateTime(textBox1.Text);
                    saat = zaman.Hour;
                    dakika= zaman.Minute;
                    saniye = zaman.Second;
                }
                else
                {
                    zaman = kalınanzaman;
                    saat= zaman.Hour;
                    dakika= zaman.Minute;
                    saniye = zaman.Second;
                }
                timer1.Start();
            }
            else
            {
                zaman=Convert.ToDateTime(label1.Text);
                button1.Text = "Başla";
                timer1.Stop();
                duraklama = true;
                kalınanzaman = Convert.ToDateTime(label1.Text);
            }
        }

    }
}
