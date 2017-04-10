using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gesbot.modules
{
    class PeriodicMessageModule : Module
    {
        private CheckedListBox moduleList;
        public int timeout = 0;
        public long lastMessageTime = 0;
        public List<string> messages;
        private int currentListIndex = 0;

        public PeriodicMessageModule(MainForm mainForm)
        {
            this.moduleList = mainForm.GetModulesList();
            this.messages = new List<string>();
            if (!File.Exists("periodic_responses.txt")) return;
            var periodicMessageLines = File.ReadAllLines("periodic_responses.txt");
            if(periodicMessageLines.Length < 1)
            {
                timeout = 300;
                mainForm.SetPeriodicMessageTimeOut(300);
            }else if(periodicMessageLines.Length == 1)
            {
                if (!int.TryParse(periodicMessageLines[0], out timeout)) mainForm.SetPeriodicMessageTimeOut(timeout);
                else
                {
                    timeout = 300;
                    mainForm.SetPeriodicMessageTimeOut(300);
                }
                mainForm.SetPeriodicMessageTimeOut(300);
            }
            else
            {
                for(int i = 0; i < periodicMessageLines.Length; i++)
                {
                    if (i == 0)
                    {
                        if (int.TryParse(periodicMessageLines[0], out timeout)) mainForm.SetPeriodicMessageTimeOut(timeout);
                        else
                        {
                            timeout = 300;
                            mainForm.SetPeriodicMessageTimeOut(300);
                        }
                    }
                    else
                    {
                        mainForm.AddPeriodicMessage(periodicMessageLines[i]);
                        messages.Add(periodicMessageLines[i]);
                    }
                }
            }
        }

        public string OnTick() {
            if (!isEnabled()) return null;
            long epochTicks = new DateTime(1970, 1, 1).Ticks;
            long unixTime = ((DateTime.UtcNow.Ticks - epochTicks) / TimeSpan.TicksPerSecond);
            if (unixTime - lastMessageTime > timeout)
            {
                Console.WriteLine($"Picking next msg otu of {messages.Count}");
                if (messages.Count <= 0) return null;
                lastMessageTime = unixTime;
                string message = messages[currentListIndex == -1 ? 0 : currentListIndex % messages.Count]; ;
                Console.WriteLine("Picked " + message);
                currentListIndex ++;
                return message;
            }
            return null;
        }

        public string ProcessMessage(string speaker, string command, string[] arguments) { return null; }

        public override string ToString()
        {
            return "Periodic Message Module";
        }

        public bool isEnabled()
        {
            foreach (object o in moduleList.CheckedItems) if (o.ToString() == this.ToString()) return true;
            return false;
        }
    }
}
