using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace CellBio_Task
{
    static class Program
    {
        public static Dictionary<string, List<string>> proteinTable = new Dictionary<string, List<string>>();
    
        public static void LoadMap()
        {
            StreamReader file = new StreamReader("Map.txt");
            while(!file.EndOfStream)
            {
                string Line = file.ReadLine();
                string[] parts = Line.Split(' ');
                List<string> codons = new List<string>();
                for (int i = 1; i < parts.Length; i++)
                    codons.Add(parts[i]);
                proteinTable[parts[0]] = codons;
            }
            /*proteinTable.Add('A', new List<string>() { "GCU", "GCC", "GCA", "GCG" });
            proteinTable.Add('R', new List<string>() { "CGU", "CGC", "CGA", "CGG", "AGA", "AGG" });
            proteinTable.Add('N', new List<string>() { "AAU", "AAC" });
            proteinTable.Add('D', new List<string>() { "GAU", "GAC" });
            proteinTable.Add('C', new List<string>() { "UGU", "UGC" });
            proteinTable.Add('Q', new List<string>() { "CAA", "CAG" });
            proteinTable.Add('E', new List<string>() { "GAA", "GAG" });
            proteinTable.Add('G', new List<string>() { "GUU", "GGC", "GGA", "GGG" });
            proteinTable.Add('H', new List<string>() { "CAU", "CAC" });
            proteinTable.Add('I', new List<string>() { "AUU", "AUC", "AUA" });
            proteinTable.Add('L', new List<string>() { "UUA", "UUG", "CUU", "CUC", "CUG" });
            proteinTable.Add('K', new List<string>() { "AAA", "AAG" });
            proteinTable.Add('M', new List<string>() { "AUG" });
            proteinTable.Add('F', new List<string>() { "UUU", "UUC" });
            proteinTable.Add('P', new List<string>() { "CCU", "CCC", "CCA", "CCG" });
            proteinTable.Add('S', new List<string>() { "UCU", "UCC", "UCA", "UCG", "AGU", "AGC" });
            proteinTable.Add('T', new List<string>() { "ACU", "ACC", "ACA", "ACG" });
            proteinTable.Add('W', new List<string>() { "UGG" });
            proteinTable.Add('Y', new List<string>() { "UAU", "UAC" });
            proteinTable.Add('V', new List<string>() { "GUU", "GUC", "GUA", "GUG" });
     */
     
    }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainPage());
        }
    }
}
