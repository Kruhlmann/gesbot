using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gesbot.modules
{
    class AutismModule : Module
    {
        private CheckedListBox moduleList;

        public AutismModule(MainForm mainForm)
        {
            this.moduleList = mainForm.GetModulesList();
        }

        public string OnTick() { return null; }

        public string ProcessMessage(string speaker, string command, string[] arguments)
        {
            if (command != "!autism") return null;
            if (!isEnabled()) return $"Sorry {speaker} this command is currently disabled.";
            int rnd = new Random().Next(1, 100);
            return (arguments.Length < 1) ? $"{speaker} you are {rnd}% autistic {GetEmoteFromNumber(rnd)}" : $"{arguments[0]} is {rnd}% autistic {GetEmoteFromNumber(rnd)}";
        }

        public override string ToString()
        {
            return "Sound Module";
        }

        public bool isEnabled()
        {
            foreach (object o in moduleList.CheckedItems) if (o.ToString() == this.ToString()) return true;
            return false;
        }

        private string GetEmoteFromNumber(int rnd)
        {
            if (rnd < 10) return "PogChamp";
            if (rnd < 30) return "FeelsGoodMan";
            if (rnd < 50) return "SeemsGood";
            if (rnd < 80) return "FeelsBadMan";
            if (rnd < 100) return "LUL";
            if (rnd == 100) return "EleGiggle";
            return "MrDestructoid";
        }

    }
}
