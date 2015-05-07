using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    class LinesystemCommandParser
    {
        ILinesystemUI LinesystenCLI;
        Linesystem Linesystem;

        public LinesystemCommandParser(ILinesystemUI linesystemCLI, Linesystem linesystem)
        {
            this.LinesystenCLI = linesystemCLI;
            this.Linesystem = linesystem;
        }

        public void ParseCommander(string command)
        {

        }
    }
}
