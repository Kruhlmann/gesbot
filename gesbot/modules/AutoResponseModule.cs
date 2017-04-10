using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gesbot.modules
{
    class AutoResponseModule : Module
    {
        private CheckedListBox moduleList;
        private TextBox commandBox;

        public AutoResponseModule(MainForm mainForm)
        {
            this.moduleList = mainForm.GetModulesList();
            this.commandBox = mainForm.GetCommandBox();
            this.commandBox.Text = "";
            ReadCommandsIntoBox();
        }

        public string ProcessMessage(string speaker, string command, string[] arguments)
        {
            Dictionary<string, string> commandsList = CompileCommandsDictionary();
            foreach (KeyValuePair<string, string> item in commandsList)
            {
                if (item.Key == command)
                {
                    if (!isEnabled()) return $"Sorry {speaker} this command is currently disabled.";
                    return StringToTwitchFormat(item.Value, speaker);
                }
            }
            return null;
        }

        public override string ToString()
        {
            return "Auto Response Module";
        }

        public Dictionary<string, string> CompileCommandsDictionary()
        {
            Dictionary<string, string> dict =  new Dictionary<string, string>();
            foreach (string line in commandBox.Lines)
            {
                var splitLine = line.Split(new string[] { "==" }, StringSplitOptions.None);
                if (splitLine.Length != 2) continue;
                dict.Add(splitLine[0], splitLine[1]);
            }
            return dict;
        }
        
        public string OnTick() { return null; }

        public bool isEnabled()
        {
            foreach (object o in moduleList.CheckedItems) if (o.ToString() == this.ToString()) return true;
            return false;
        }

        private void ReadCommandsIntoBox()
        {
            var commands = File.ReadAllLines("auto_reponses.txt");
            foreach (string command in commands) this.commandBox.Text += command + Environment.NewLine;
        }

        private string StringToTwitchFormat(string message, string speaker)
        {
            return message.Replace("$speaker", speaker);
        }

    }
}
