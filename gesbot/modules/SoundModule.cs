using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gesbot.modules
{
    class SoundModule : Module
    {
        private CheckedListBox soundsList;
        private CheckedListBox moduleList;

        public SoundModule(MainForm mainForm)
        {
            this.soundsList = mainForm.GetSoundsList();
            this.moduleList = mainForm.GetModulesList();
        }

        public string OnTick() { return null; }

        public string ProcessMessage(string speaker, string command, string[] arguments)
        {
            if(command == "!playsound")
            {
                if(!isEnabled()) return $"Sorry {speaker} this command is currently disabled.";
                if (arguments.Length <= 0) return GetSoundToolTip();
                string soundPath = GetSoundPathFromFileName(arguments[0]);
                if (SoundExists(arguments[0]) && soundPath != null)
                {
                    int index = GetSoundIndex(soundPath);
                    if (!soundsList.GetItemChecked(index)) return $"Sorry {speaker}, that sound is currently disabled.";
                    SoundPlayer player = new SoundPlayer(soundPath);
                    player.Play();
                    return null;
                }
                else
                {
                    return $"Sorry {speaker}, I was unable to play the sound '{arguments[0]}'. Please make sure the sound exists in the !sounds list.";
                }

            }else if (command == "!sounds") return GetSoundToolTip();
            return null;
        }

        private bool SoundEnabled(string sound)
        {
            foreach (object o in soundsList.CheckedItems) if (sound == Path.GetFileNameWithoutExtension(o.ToString())) return true;
            return false;
        }

        private bool SoundExists(string sound)
        {
            foreach (object o in soundsList.Items) if (sound == Path.GetFileNameWithoutExtension(o.ToString())) return true;
            return false;
        }

        private int GetSoundIndex(string sound)
        {
            for (int i = 0; i < soundsList.Items.Count; i++) if (sound == soundsList.Items[i].ToString()) return i;
            return -1;
        }

        private string GetSoundPathFromFileName(string filename)
        {
            foreach (object o in soundsList.Items) if (filename == Path.GetFileNameWithoutExtension(o.ToString())) return o.ToString();
            return null;
        }

        private string GetSoundToolTip()
        {
            string response = "Sounds avaliable: ";
            foreach (object o in soundsList.CheckedItems)
            {
                response += Path.GetFileNameWithoutExtension(o.ToString()) + " ";
            }
            return response;
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

    }
}
