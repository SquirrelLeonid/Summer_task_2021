using System;
using System.Windows.Forms;

using SummerTask_RadkevichMarsell.fileProcessing;
using SummerTask_RadkevichMarsell.tokenization;

namespace SummerTask_RadkevichMarsell
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var fileParser = new LineParser();
            var tokenizer = new Tokenizer();
            Application.Run(new MainForm(fileParser, tokenizer));
        }
    }
}
