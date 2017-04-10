using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gesbot
{
    interface Module
    {
        string ProcessMessage(string speaker, string command, string[] arguments);
        string ToString();
        string OnTick();
        bool isEnabled();
    }
}
