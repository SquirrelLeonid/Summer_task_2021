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
using SummerTask_RadkevichMarsell.fileReading;

namespace SummerTask_RadkevichMarsell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_ChooseFiles_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "Текстовые файлы (*.txt, *.cs)|*.txt;*.cs";

            if (fileDialog.ShowDialog() == DialogResult.OK)
                TB_ChoosedFiles.Lines = fileDialog.FileNames;      
        }

        private void Btn_CreateScheme_Click(object sender, EventArgs e)
        {
            var listings = ReadSelectedFiles(TB_ChoosedFiles.Lines);
            LineParser parser = new LineParser();
            var methods = parser.ParseListings(listings);

            foreach (MethodRecord record in methods)
            {
                TB_Methods.Text += record.Name;
                TB_Methods.Text += "\r\n";
            }

            var tagPlacementor = new TagPlacementor();
            methods = tagPlacementor.PlacementTags(methods);
        }

        private List<Listing> ReadSelectedFiles(string[] selectedFiles)
        {
            var listings = new List<Listing>();
            foreach (string file in selectedFiles)
            {
                var content = new List<string>();
                using (StreamReader reader = new StreamReader(file, Encoding.UTF8))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        content.Add(line);
                        line = reader.ReadLine();
                    }
                    listings.Add(new Listing(file, content));
                }
            }

            return listings;
        }

        
    }
}
