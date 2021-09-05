using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SummerTask_RadkevichMarsell.tokenization;
using SummerTask_RadkevichMarsell.blockScheme.blocks;

namespace SummerTask_RadkevichMarsell.blockScheme
{
    public class SchemeArea
    {
        public PictureBox Canvas { get; private set; }
        private List<BlockBlueprint> Content;

        public SchemeArea(PictureBox canvas)
        {
            Canvas = canvas;
            Content = new List<BlockBlueprint>();
        }

        public void DrawBlocks(List<TokenRecord> methodTokens)
        {
            
            foreach (var token in methodTokens)
            {
                switch (token.Type)
                {
                    case TokenType.Operation:
                        break;
                    default:
                        break;
                }
            }
            Canvas.Refresh();
        }
    }
}
