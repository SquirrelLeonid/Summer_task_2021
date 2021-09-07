using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using SummerTask_RadkevichMarsell.UI;
using SummerTask_RadkevichMarsell.blockScheme;
using SummerTask_RadkevichMarsell.tokenization;
using SummerTask_RadkevichMarsell.fileProcessing;

namespace SummerTask_RadkevichMarsell
{
    public partial class MainForm : Form
    {
        private LineParser Parser;
        private Tokenizer Tokenizer;
        private BlockBuilder BlockBuilder;
        private PictureBox currentCanvas;
        private Dictionary<Button, SchemeArea> tabsAndSchemes;

        public MainForm(LineParser parser, Tokenizer tokenizer, BlockBuilder builder)
        {
            InitializeComponent();
            Parser = parser;
            Tokenizer = tokenizer;
            BlockBuilder = builder;
            tabsAndSchemes = new Dictionary<Button, SchemeArea>();
        }

        private void ToolStripMenuItem_BlockScheme_Click(object sender, EventArgs e)
        {
            var files = GetFileNames();
            var listings = ReadSelectedFiles(files);
            var methods = Parser.ParseListings(listings);
            var tokenizedMethods = Tokenizer.Tokenize(methods);

            foreach (var methodEntry in tokenizedMethods)
            {
                var methodName = methodEntry.Key;
                var methodTokens = methodEntry.Value;

                var tab = CreateTab(methodName);
                var schemeArea = CreateSchemeArea();                
                                           
                tabsAndSchemes.Add(tab, schemeArea);

                var methodBlocks = BlockBuilder.Build(methodTokens);
                schemeArea.DrawBlocks(methodBlocks);
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

            foreach (var fileName in selectedFiles)
            {
                var content = new List<string>();

                using (var reader = new StreamReader(fileName, Encoding.UTF8))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        content.Add(line);
                        line = reader.ReadLine();
                    }

                    listings.Add(new Listing(fileName, content));
                }
            }

            return listings;
        }
       
        private MethodTab CreateTab(string methodName)
        {
            var tab = new MethodTab(methodName);
            tab.Click += Tab_Click;

            SplitContainer_MainArea.Panel1.Controls.Add(tab);

            return tab;
        }

        private SchemeArea CreateSchemeArea()
        {
            var canvas = CreateCanvas();
            var schemeArea = new SchemeArea(canvas);                                        
            
            return schemeArea;
        }

        private PictureBox CreateCanvas()
        {
            var canvas = new PictureBox();
            var width = SplitContainer_MainArea.Panel2.Width;
            var height = SplitContainer_MainArea.Panel2.Height;

            canvas.Size = new Size(width, height);
            canvas.Dock = DockStyle.Fill;
            canvas.BackColor = Color.White;
            canvas.Hide();

            SplitContainer_MainArea.Panel2.Controls.Add(canvas);

            return canvas;
        }

        public void Tab_Click(object sender, EventArgs e)
        {
            var tab = (Button)sender;

            if (currentCanvas != null)
                currentCanvas.Hide();

            currentCanvas = tabsAndSchemes[tab].Canvas;
            currentCanvas.Show();
        }

        private void Button_ResetCanvasLocation_Click(object sender, EventArgs e)
        {
            currentCanvas.Location = new Point(0, 0);
        }
    }
}
