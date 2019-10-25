using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CellBio_Task
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        int counter = 0;

        private void button1_Click(object sender, EventArgs e)
        {   
            //Preventing the overloading of the map
            counter++;
            if(counter==1)
            Program.LoadMap();

            //Decleration of variables and emptying textboxes
            string DNA_STRAND = textBox1.Text;
            string mRNA ="";
            string proteinstring = "";
            int mRNALength = DNA_STRAND.Length;
            bool isCorrect = true;
            bool isAUGFound=false;
            bool isStopFound = false;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            //Transcription
            for (int i = 0; i < DNA_STRAND.Length; i++)
            {
                if (DNA_STRAND[i] == 'A' || DNA_STRAND[i] == 'a')
                    mRNA += 'A';
                else if (DNA_STRAND[i] == 'T' || DNA_STRAND[i] == 't')
                    mRNA += 'U';
                else if (DNA_STRAND[i] == 'C' || DNA_STRAND[i] == 'c')
                    mRNA += 'C';
                else if (DNA_STRAND[i] == 'G' || DNA_STRAND[i] == 'g')
                    mRNA += 'G';
                else if (DNA_STRAND[i] == ' '||DNA_STRAND[i]=='\n')
                { mRNALength--; continue; }
                else
                    isCorrect = false;

            }

            if (DNA_STRAND.Length == 0)
                MessageBox.Show("There is no input found", "Error");
            else
            if (isCorrect) {


                //Handling DNA Starnd with length not divisible by 3
                if (mRNA.Length % 3 != 0)
                {
                    mRNALength -= mRNALength % 3;
                    MessageBox.Show("Take care your input is not correct the extra nucleotides will be ignored", "Warning");
                }


                //Displaying Codons
                string temp;                
                for (int i = 0; i < mRNALength; i += 3)
                {
                    temp = "";
                    temp += mRNA[i];
                    temp += mRNA[i + 1];
                    temp += mRNA[i + 2];
                    textBox4.Text += temp;
                    textBox4.Text += " ";

                }

                //Translation
                for (int i = 0; i < mRNALength; i += 3)
            {


                temp = "";
                temp += mRNA[i];
                temp += mRNA[i + 1];
                temp += mRNA[i + 2];

                

                     if (temp == "AUG")
                        isAUGFound = true;

                if (isAUGFound)
                {
                    if (temp == "UAG" || temp == "UGA" || temp == "UAA")
                    { proteinstring += '*'; isStopFound = true; break; }
                    foreach (var value in Program.proteinTable)
                    {
                        if (value.Value.Contains(temp))
                        { proteinstring += value.Key; break; }
                    }
                }
                

            }

                if (!isAUGFound) MessageBox.Show("There is no Start Codon found", "Error");
                if(!isStopFound) MessageBox.Show("This is not a protein as there is no End Codon found", "Error");
                textBox2.Text = mRNA.ToString(); textBox3.Text = proteinstring; }
            else
                MessageBox.Show("Please re-check your input", "Error");
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainPage f1 = new MainPage();
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog Path = new OpenFileDialog();
            Path.ShowDialog();
            // MessageBox.Show(Path.FileName);
            
           
            if (!(Path.FileName.ToString() == ""))
            {
                //StreamReader file = new StreamReader(Path.FileName);
                string DNA = File.ReadAllText(Path.FileName);
                textBox1.Text = DNA;
            }
        }
    }
}
