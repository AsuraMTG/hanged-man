using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hanged_man
{
    public partial class Form1 : Form
    {
        public static string[] szavak =
        {
            "forrásvíz",
            "határidő",
            "kengurú",
            "cirkáló",
            "ismert",
            "törött",
            "őrködik",
            "kopogtat",
            "bájos",
            "sarokház"
        };

        public static Random rnd = new Random();

        public static string feladvany = szavak[rnd.Next(0, szavak.Length)];

        public static string[] megtalalt = new string[feladvany.Length];

        public static string[] helytelen = new string[10];

        public static int hibaSzam = 0;

        public static void betuTest(char lekertBetű)
        {
            int hiba = 0;
            for (int i = 0; i < feladvany.Length; i++)
            {
                if (lekertBetű == feladvany[i])
                    megtalalt[i] = lekertBetű.ToString();
                else
                    hiba++;
            }
            if (hiba == feladvany.Length)
            {
                if (!helytelen.Contains(lekertBetű.ToString()))
                {     
                    helytelen[hibaSzam] = lekertBetű.ToString(); 
                    hibaSzam++;
                } 
            }
        }

        public void kezdet()
        {
            button1.Text = "küld";
            button2.Text = "új játék";
            label1.Text = " ";
            label2.Text = $"A feladvány hossza: {feladvany.Length}-betű";
            label3.Text = "";
            label4.Text = "";

            for (int i = 0; i < feladvany.Length; i++)
            {
                label1.Text += "? ";
                megtalalt[i] = "?";
            }

            for (int i = 0; i < helytelen.Length; i++)
                helytelen[i] = "";
        }

        public void reset()
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";

            for (int i = 0; i < feladvany.Length; i++)
            {
                label1.Text += "? ";
                megtalalt[i] = "?";
            }

            for (int i = 0; i < helytelen.Length; i++)
                helytelen[i] = "";

            feladvany = szavak[rnd.Next(0, szavak.Length)];

            label2.Text = $"A feladvány hossza: {feladvany.Length}-betű";

            hibaSzam = 0;
        }

        public void csinal() 
        {
            if (textBox1.Text != "")
            {
                if (hibaSzam != 10)
                {
                    label4.Text = "";
                    label1.Text = " ";
                    betuTest(Convert.ToChar(textBox1.Text));
                    for (int i = 0; i < feladvany.Length; i++)
                    {
                        if (megtalalt[i] != "?")
                            label1.Text += $"{megtalalt[i]} ";
                        else
                            label1.Text += "? ";
                    }
                    label3.Text = $"Hibázások száma: {hibaSzam}";
                    for (int i = 0; i < helytelen.Length; i++)
                        if (helytelen[i] != "")
                            label4.Text += $"{helytelen[i]}, ";
                }
                else
                {
                    label5.Text = $"Vesztettél";
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kezdet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            csinal();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            csinal();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
