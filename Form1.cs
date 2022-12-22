using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace saatli_kapatma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int saniye = 60;
        int dk = 2;
       


        public string ipcek()
        {
            string bilgisayarAdi = Dns.GetHostName();
            string ipAdresi = Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString();
            return ipAdresi;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            label6.Text = ipcek();
            label7.Text = Environment.UserName;
            label3.Text = "59";
            label4.Text = "2";
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye--;
            label3.Text = saniye.ToString();
            label4.Text = dk.ToString();
            if (saniye==0) 
            {
                dk--;
                saniye = 60;
            }
            if (dk == -1)
            {
                timer1.Stop();
                System.Diagnostics.Process.Start("shutdown", "-s -f -t 0");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saniye = 0;
            System.Diagnostics.Process.Start("shutdown", "-a");
            Application.Exit();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.TabStop = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.BackgroundImage = saatli_kapatma.Properties.Resources.siyah_buton;
            
        }

        

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.TabStop = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.BackgroundImage = saatli_kapatma.Properties.Resources.beyaz_buton;
            

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            System.Diagnostics.Process.Start("shutdown", "-s -f -t 0");

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderSize = 0;
            button2.BackgroundImage = saatli_kapatma.Properties.Resources.kapatbtn2;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderSize = 0;
            button2.BackgroundImage = saatli_kapatma.Properties.Resources.kapatbtn;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saniye != 0 )
            {
                e.Cancel = true;
                base.OnClosing(e);
            }

        }
    }
}
