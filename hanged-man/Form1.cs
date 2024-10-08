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

        public void texture()
        {
            string labelBackColor = "#6A9AB0";
            string labelTextColor = "#EAD8B1";
            string picture1BoxColor = "#3A6D8C";
            string picture2BoxColor = "#001F3F";

            Color myLabelBackColor = System.Drawing.ColorTranslator.FromHtml(labelBackColor);
            Color myLabelTextColor = System.Drawing.ColorTranslator.FromHtml(labelTextColor);
            Color myPicture1BoxColor = System.Drawing.ColorTranslator.FromHtml(picture1BoxColor);
            Color myPicture2BoxColor = System.Drawing.ColorTranslator.FromHtml(picture2BoxColor);

            label1.ForeColor = myLabelTextColor;
            label2.ForeColor = myLabelTextColor;
            label3.ForeColor = myLabelTextColor;
            label4.ForeColor = myLabelTextColor;
            label5.ForeColor = myLabelTextColor;

            label1.BackColor = myLabelBackColor;
            label2.BackColor = myLabelBackColor;
            label3.BackColor = myLabelBackColor;
            label4.BackColor = myLabelBackColor;
            label5.BackColor = myLabelBackColor;

            pictureBox2.BackColor = myPicture1BoxColor;
            pictureBox1.BackColor = myPicture2BoxColor;
        }
        public void kezdet()
        {
            button1.Text = "küld";
            button2.Text = "új játék";
            label1.Text = " ";
            label2.Text = $"A feladvány hossza: {feladvany.Length}-betű";
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
                    int nyertE = feladvany.Length;
                    label4.Text = "";
                    label1.Text = " ";
                    betuTest(Convert.ToChar(textBox1.Text));
                    for (int i = 0; i < feladvany.Length; i++)
                    {
                        if (megtalalt[i] != "?")
                        { label1.Text += $"{megtalalt[i]} "; nyertE--; }
                        else
                            label1.Text += "? ";
                    }
                    if (nyertE == 0)
                        label5.Text = $"nyertél";
                    label3.Text = $"Hibázások száma: {hibaSzam}";
                    for (int i = 0; i < helytelen.Length; i++)
                        if (helytelen[i] != "")
                            label4.Text += $"{helytelen[i]}, ";
                }
                else
                {
                    label5.Text = "vesztettél";
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kezdet(); //texture();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
