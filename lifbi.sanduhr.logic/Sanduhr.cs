using System;
using System.Text;

namespace lifbi.sanduhr.logic
{
    public class Sanduhr
    {
        private const string OUTPUT_SYMBOL = "*";
        private const string OUTPUT_SPACER = " ";

        public string Print(int width){
            if(width < 3)
            {
                throw new ArgumentOutOfRangeException("width", width, "Parameter must be 3 or larger.");
            }

            StringBuilder builder = new StringBuilder();

            int outputLineCount = width % 2 > 0 ? width : width - 1;
            int bonusSymbolsPerLine = width % 2 > 0 ? 0 : 1;
            
            int symbolsPerLineCount = 0;
            int spacersPerLineCount = 0;

            for(int lineIndex = 0; lineIndex < outputLineCount; lineIndex++)
            {
                if(lineIndex > 0)
                {    
                    // start new line
                    builder.Append(Environment.NewLine);
                }

                // upper half of hourglass shape, including middle
                if(lineIndex <= outputLineCount / 2)
                {
                    symbolsPerLineCount = width - 2 * lineIndex;
                    spacersPerLineCount = lineIndex;
                }
                // lower half of hourglass shape, excluding middle
                else
                {
                    symbolsPerLineCount = 
                        (1 + bonusSymbolsPerLine)                       // number of symbols in the middle
                        + 2 * (lineIndex - outputLineCount / 2);        // + 2 additional symbols per line

                    spacersPerLineCount = outputLineCount - lineIndex - 1;
                }

                // write spacers
                for(int spacerIndex = 0; spacerIndex < spacersPerLineCount; spacerIndex++)
                {
                    builder.Append(OUTPUT_SPACER);
                }

                // write symbols
                for(int symbolIndex = 0; symbolIndex < symbolsPerLineCount; symbolIndex++)
                {
                    builder.Append(OUTPUT_SYMBOL);
                }
            }

            return builder.ToString(); 
        }
    }
}
