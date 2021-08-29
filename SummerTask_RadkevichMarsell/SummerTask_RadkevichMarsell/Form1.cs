﻿using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SummerTask_RadkevichMarsell.fileReading;

namespace SummerTask_RadkevichMarsell
{
    public partial class Form1 : Form
    {
        private LineParser parser;
        private Tokenizer tokenizer;
        private PictureBox currentCanvas;
        private Dictionary<Button, SchemeArea> tabsAndSchemes;

        public Form1()
        {
            InitializeComponent();
            parser = new LineParser();
            tokenizer = new Tokenizer();
            tabsAndSchemes = new Dictionary<Button, SchemeArea>();
        }

        private void ToolStripMenuItem_BlockScheme_Click(object sender, EventArgs e)
        {
            var files = GetFileNames();
            var listings = ReadSelectedFiles(files);
            var methods = parser.ParseListings(listings);
            var tokenizedMethods = tokenizer.Tokenize(methods);

            foreach (var methodEntry in tokenizedMethods)
            {
                var methodName = methodEntry.Key;
                var methodTokens = methodEntry.Value;

                var tab = CreateTab(methodName);
                var schemeArea = CreateSchemeArea();                
                                           
                tabsAndSchemes.Add(tab, schemeArea);
              
                schemeArea.DrawBlocks(methodTokens);
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

            canvas.Dock = DockStyle.Fill;
            canvas.Image = new Bitmap(width, height);
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
    }
}
