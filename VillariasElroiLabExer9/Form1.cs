using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace VillariasElroiLabExer9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string input = textBox1.Text;

            Boolean check = checkInput(input);

            if (check)
            {
                string[] values = input.Select(c => c.ToString()).ToArray();

                performNRZL(values);
                performNRZI(values);
                performBipolarAMI(values);
                performPseudoternary(values);
                performManchester(values);
                performDifferentialManchester(values);
            }
        
        }

        private Boolean checkInput(String input)
        {

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Input is empty or contains only whitespace");
                return false;
            }

            if (input.Length < 6)
            {
                MessageBox.Show("Input must be at least 6 characters.");
                return false;
            }

            if (!input.All(c => c == '0' || c == '1'))
            {
                MessageBox.Show("Invalid input. Please enter only 0 or 1.");
                return false;
            }

            return true;
        }

        private void performNRZL(string[] values)
        {
            PictureBox[] pictureBoxes = new PictureBox[] { pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            string prev = "0";
            int num = -1;

            foreach (string value in values)
            {
                if (num == -1)
                {
                    if (value == "0") { pictureBox1.Image = Image.FromFile(getImageValue("mid-bot")); }
                    else { pictureBox1.Image = Image.FromFile(getImageValue("mid-top")); }
                    prev = value;
                    num++;
                }
                else
                {
                    if (value == "0")
                    {
                        if(prev == "0") { pictureBoxes[num].Image = Image.FromFile(getImageValue("bot")); }
                        else { pictureBoxes[num].Image = Image.FromFile(getImageValue("top-bot")); }
                    }
                    else
                    {
                        if (prev == "0") { pictureBoxes[num].Image = Image.FromFile(getImageValue("bot-top")); }
                        else { pictureBoxes[num].Image = Image.FromFile(getImageValue("top")); }
                    }
                    prev = value;
                    num++;
                }
            }
        }

        private void performNRZI(string[] values)
        {
            PictureBox[] pictureBoxes = new PictureBox[] { pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12 };
            string state = "off";
            int num = -1;

            foreach (string value in values)
            {
                if (num == -1)
                {
                    if (value == "0") { pictureBox7.Image = Image.FromFile(getImageValue("mid-bot")); }
                    else { pictureBox7.Image = Image.FromFile(getImageValue("mid-top")); state = "on"; }
                    num++;
                }
                else
                {
                    if (value == "0")
                    {
                        if (state == "off") { pictureBoxes[num].Image = Image.FromFile(getImageValue("bot")); }
                        else { pictureBoxes[num].Image = Image.FromFile(getImageValue("top")); }
                    }
                    else
                    {
                        if (state == "off") { pictureBoxes[num].Image = Image.FromFile(getImageValue("bot-top")); state = "on"; }
                        else { pictureBoxes[num].Image = Image.FromFile(getImageValue("top-bot")); state = "off"; }
                    }
                    num++;
                }
            }
        }

        private void performBipolarAMI(string[] values) 
        {
            PictureBox[] pictureBoxes = new PictureBox[] { pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18 };
            string state = "off";
            string prev = "0";
            int num = -1;

            foreach (string value in values)
            {
                if (num == -1)
                {
                    if (value == "0") { pictureBox13.Image = Image.FromFile(getImageValue("mid")); }
                    else { pictureBox13.Image = Image.FromFile(getImageValue("mid-top")); state = "on"; }
                    prev = value;
                    num++;
                }
                else
                {
                    if (value == "0")
                    {
                        if (prev == "1" && state == "off") { pictureBoxes[num].Image = Image.FromFile(getImageValue("bot-mid")); }
                        else if (prev == "1" && state == "on") { pictureBoxes[num].Image = Image.FromFile(getImageValue("top-mid")); }
                        else { pictureBoxes[num].Image = Image.FromFile(getImageValue("mid")); }
                    }
                    else
                    {
                        if (prev == "0" && state == "off") { pictureBoxes[num].Image = Image.FromFile(getImageValue("mid-top")); state = "on"; }
                        else if (prev == "0" && state == "on") { pictureBoxes[num].Image = Image.FromFile(getImageValue("mid-bot")); state = "off"; }
                        else if (prev == "1" && state == "off") { pictureBoxes[num].Image = Image.FromFile(getImageValue("bot-top")); state = "on"; }
                        else if (prev == "1" && state == "on") { pictureBoxes[num].Image = Image.FromFile(getImageValue("top-bot")); state = "off"; }
                    }
                    prev = value;
                    num++;
                }
            }
        }

        private void performPseudoternary(string[] values)
        {
            PictureBox[] pictureBoxes = new PictureBox[] { pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24 };
            string state = "off";
            string prev = "0";
            int num = -1;

            foreach (string value in values)
            {
                if (num == -1)
                {
                    if (value == "0") { pictureBox19.Image = Image.FromFile(getImageValue("mid-top")); state = "on"; }
                    else { pictureBox19.Image = Image.FromFile(getImageValue("mid")); }
                    prev = value; 
                    num++;
                }
                else
                {
                    if (value == "0")
                    {
                        if (prev == "0" && state == "off") { pictureBoxes[num].Image = Image.FromFile(getImageValue("bot-top")); state = "on"; }
                        else if (prev == "0" && state == "on") { pictureBoxes[num].Image = Image.FromFile(getImageValue("top-bot")); state = "off"; }
                        else if (prev == "1" && state == "off") { pictureBoxes[num].Image = Image.FromFile(getImageValue("mid-top")); state = "on"; }
                        else if (prev == "1" && state == "on") { pictureBoxes[num].Image = Image.FromFile(getImageValue("mid-bot")); state = "off"; }
                    }
                    else
                    {
                        if (prev == "0" && state == "off") { pictureBoxes[num].Image = Image.FromFile(getImageValue("bot-mid")); }
                        else if (prev == "0" && state == "on") { pictureBoxes[num].Image = Image.FromFile(getImageValue("top-mid")); }
                        else { pictureBoxes[num].Image = Image.FromFile(getImageValue("mid")); }
                    }
                    prev = value;
                    num++;
                }
            }
        }

        private void performManchester(string[] values) 
        {
            PictureBox[] pictureBoxes = new PictureBox[] { pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30 };
            string prev = "0";
            int num = -1;

            foreach (string value in values)
            {
                if (num == -1)
                {
                    if (value == "0") { pictureBox25.Image = Image.FromFile(getImageValue("m-bot-top-bot")); }
                    else { pictureBox25.Image = Image.FromFile(getImageValue("m-top-bot-top")); }
                    prev = value;
                    num++;
                }
                else
                {
                    if (value == "0")
                    {
                        if (prev == "0") { pictureBoxes[num].Image = Image.FromFile(getImageValue("m-bot-top-bot")); }
                        else { pictureBoxes[num].Image = Image.FromFile(getImageValue("m-top-bot")); }
                    }
                    else
                    {
                        if (prev == "0") { pictureBoxes[num].Image = Image.FromFile(getImageValue("m-bot-top")); }
                        else { pictureBoxes[num].Image = Image.FromFile(getImageValue("m-top-bot-top")); }
                    }
                    prev = value;
                    num++;
                }
            }
        }

        private void performDifferentialManchester(string[] values) 
        {
            PictureBox[] pictureBoxes = new PictureBox[] { pictureBox32, pictureBox33, pictureBox34, pictureBox35, pictureBox36 };
            string prev = "0";
            int num = -1;

            foreach (string value in values)
            {
                if (num == -1)
                {
                    if (value == "0") { pictureBox31.Image = Image.FromFile(getImageValue("m-top-bot-top")); prev = "1"; }
                    else { pictureBox31.Image = Image.FromFile(getImageValue("m-bot-top")); prev = "1"; }
                    num++;

                }
                else
                {
                    if (value == "0")
                    {
                        if (prev == "0") { pictureBoxes[num].Image = Image.FromFile(getImageValue("m-bot-top-bot")); prev = "0";}
                        else { pictureBoxes[num].Image = Image.FromFile(getImageValue("m-top-bot-top")); prev = "1"; }
                    }
                    else
                    {
                        if (prev == "0") { pictureBoxes[num].Image = Image.FromFile(getImageValue("m-bot-top")); prev = "1"; }
                        else { pictureBoxes[num].Image = Image.FromFile(getImageValue("m-top-bot")); prev = "0"; } 
                    }
                    num++;
                }
            }
        }

        private String getImageValue(string value)
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = "null";

            switch (value)
            {
                //top transition

                case "top":
                    imagePath = Path.Combine(projectDirectory, "signals", "top", "top.png");
                    break;
                case "top-mid":
                    imagePath = Path.Combine(projectDirectory, "signals", "top", "top-mid.png");
                    break;
                case "top-bot":
                    imagePath = Path.Combine(projectDirectory, "signals", "top", "top-bot.png");
                    break;

                //middle transition

                case "mid":
                    imagePath = Path.Combine(projectDirectory, "signals", "middle", "mid.png");
                    break;
                case "mid-top":
                    imagePath = Path.Combine(projectDirectory, "signals", "middle", "mid-top.png");
                    break;
                case "mid-bot":
                    imagePath = Path.Combine(projectDirectory, "signals", "middle", "mid-bot.png");
                    break;

                //bottom transition

                case "bot":
                    imagePath = Path.Combine(projectDirectory, "signals", "bottom", "bot.png");
                    break;
                case "bot-mid":
                    imagePath = Path.Combine(projectDirectory, "signals", "bottom", "bot-mid.png");
                    break;
                case "bot-top":
                    imagePath = Path.Combine(projectDirectory, "signals", "bottom", "bot-top.png");
                    break;

                //manchester transition

                case "m-top-bot":
                    imagePath = Path.Combine(projectDirectory, "signals", ".manchester", "m-top-bot.png");
                    break;
                case "m-bot-top":
                    imagePath = Path.Combine(projectDirectory, "signals", ".manchester", "m-bot-top.png");
                    break;
                case "m-bot-top-bot":
                    imagePath = Path.Combine(projectDirectory, "signals", ".manchester", "m-bot-top-bot.png");
                    break;
                case "m-top-bot-top":
                    imagePath = Path.Combine(projectDirectory, "signals", ".manchester", "m-top-bot-top.png");
                    break;

            }

            return imagePath;

        }
        
    }
}
