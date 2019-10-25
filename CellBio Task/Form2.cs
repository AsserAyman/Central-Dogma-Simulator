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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        int counter = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //Preventing the overloading of the map
            counter++;
            if(counter==1)
            Program.LoadMap();


          
            string Complementary_DNA = "";
            string DNA_STRAND = textBox1.Text;
            string mRNA = "";
            string proteinstring = "";
            int mRNALength = DNA_STRAND.Length;
            bool isCorrect = true;
            bool isAUGFound = false;
            bool isStopFound = false;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
                

            for (int i = 0; i < DNA_STRAND.Length; i++)
            {
                if (DNA_STRAND[i] == 'A' || DNA_STRAND[i] == 'a')
                { Complementary_DNA += 'T'; mRNA += 'U'; }
                else if (DNA_STRAND[i] == 'T' || DNA_STRAND[i] == 't')
                { Complementary_DNA += 'A'; mRNA += 'A'; }
                else if (DNA_STRAND[i] == 'C' || DNA_STRAND[i] == 'c')
                { Complementary_DNA += 'G'; mRNA += 'G'; }
                else if (DNA_STRAND[i] == 'G' || DNA_STRAND[i] == 'g')
                { Complementary_DNA += 'C'; mRNA += 'C'; }
                else if (DNA_STRAND[i] == ' ' || DNA_STRAND[i] == '\n')
                { mRNALength--; continue; }
                else
                    isCorrect = false;
                    
            }

            if (DNA_STRAND.Length == 0)
                MessageBox.Show("There is no input found", "Error");
            else
         if (isCorrect == true)
            {

                //Handling DNA Starnd with length not divisible by 3
                if (mRNA.Length % 3 != 0)
                {
                    mRNALength -= mRNALength % 3;
                    MessageBox.Show("Take care your input is not correct the extra nucleotides will be ignored", "Warning");
                }

                //Displaying Codons
                string temp;
                //textBox5.Text += "";
                for (int i = 0; i < mRNALength; i += 3)
                {
                    temp = "";
                    temp += mRNA[i];
                    temp += mRNA[i + 1];
                    temp += mRNA[i + 2];
                    textBox5.Text += temp;
                    textBox5.Text += " ";

                }
               
       

                for (int i = 0; i < mRNALength; i += 3)
                {
                   

                    temp = "";

                    temp += mRNA[i];
                    temp += mRNA[i + 1];
                    temp += mRNA[i + 2];
                    //textBox5.Text += temp;
                   // textBox5.Text += " ";

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
                if (!isAUGFound)
                    MessageBox.Show("There is no Start Codon found", "Error");
                if (!isStopFound) MessageBox.Show("There is no protein as there is no end Codon found", "Error");
                textBox2.Text = Complementary_DNA.ToString();
                textBox3.Text = mRNA.ToString();
                textBox4.Text = proteinstring;
            }
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog Path = new OpenFileDialog();
            Path.ShowDialog();
            // MessageBox.Show(Path.FileName);
            
            if (!(Path.FileName.ToString() == ""))
            {
                string DNA = File.ReadAllText(Path.FileName);
                textBox1.Text = DNA;
            }
        }
    }
}
