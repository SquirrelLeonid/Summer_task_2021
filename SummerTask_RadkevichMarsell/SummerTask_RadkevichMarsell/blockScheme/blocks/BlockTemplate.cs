using System.Collections.Generic;
using SummerTask_RadkevichMarsell.blockScheme.Links;

namespace SummerTask_RadkevichMarsell.blockScheme.blocks
{
    public class BlockTemplate
    {
        public string Content { get; set; }
        public BlockType Type { get; set; }
        public BaseLink[] Links { get; set; }

        public BlockTemplate(BlockType type, string content)
        {
            Type = type;
            Content = content;         
        }

        public void SetLinks(BaseLink[] links)
        {
            Links = links;
        }
        public override string ToString()
        {
            return Type.ToString() + " " + Content;
        }
    }
}
