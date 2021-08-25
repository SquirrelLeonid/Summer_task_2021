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
        private LineParser parser;
        private Tokenizer tokenizer;

        private Dictionary<Button, PictureBox> tabsAndSchemes;

        public Form1()
        {
            InitializeComponent();
            parser = new LineParser();
            tokenizer = new Tokenizer();

            tabsAndSchemes = new Dictionary<Button, PictureBox>();
        }

        private void ToolStripMenuItem_BlockScheme_Click(object sender, EventArgs e)
        {
            var files = GetFileNames();
            var listings = ReadSelectedFiles(files);
            var methods = parser.ParseListings(listings);
            var tokenizedMethods = tokenizer.Tokenize(methods);

            foreach (var method in methods)
            {
                var tab = CreateMethodTab(method.Name);
                var schemeWorkspace = CreateMethodSchemeWorkspace(method.Name);
                SplitContainer_Workspace.Panel1.Controls.Add(tab);
                tabsAndSchemes.Add(tab, schemeWorkspace);
            }

        }

        private string[] GetFileNames()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "Текстовые файлы (*.txt, *.cs)|*.txt;*.cs";

            if (fileDialog.ShowDialog() == DialogResult.OK)
                return fileDialog.FileNames;

            return new string[0];
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

        private Button CreateMethodTab(string methodName)
        {
            var offsetX = 3;
            var offsetY = 3;
            var tabLength = 187;
            var tabWidth = 40;
            var textFontSize = 10;

            var tab = new Button();
            tab.Name = "Button_tab_" + methodName;
            tab.Text = methodName;
            tab.Font = new Font(FontFamily.GenericMonospace, textFontSize);
            tab.BackColor = Color.White;
            tab.Size = new Size(tabLength, tabWidth);
            tab.Location = new Point(offsetX, offsetY + tabWidth * (SplitContainer_Workspace.Panel1.Controls.Count - 1));

            tab.MouseClick += Tab_Click;

            return tab;
        }

        private PictureBox CreateMethodSchemeWorkspace(string methodName)
        {
            var workspace = new PictureBox();

            workspace.Dock = DockStyle.Fill;
            workspace.BackColor = Color.Black;

            return workspace;
        }

        private void Tab_Click(object sender, EventArgs e)
        {
            var tab = (Button)sender;
            SplitContainer_Workspace.Panel2.Controls.Clear();
            SplitContainer_Workspace.Panel2.Controls.Add(tabsAndSchemes[tab]);
        }
    }
}
