using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gesbot
{
    class ModuleManager
    {
        private Dictionary<Module, bool> modules = new Dictionary<Module, bool>();
        private CheckedListBox moduleList;

        public ModuleManager(MainForm mainForm)
        {
            moduleList = mainForm.GetModulesList();
        }

        public List<string> OnTick()
        {
            List<string> responses = new List<string>();
            foreach (KeyValuePair<Module, bool> module in modules)
            {
                responses.Add(module.Key.OnTick());
            }
            return responses;
        }

        public Module GetModuleByName(string name)
        {
            foreach(KeyValuePair<Module, bool> modulePair in modules)if (modulePair.Key.ToString() == name) return modulePair.Key;
            return null;
        }

        public void AddModule(Module module)
        {
            modules.Add(module, true);
            moduleList.Items.Add(module.ToString(), true);
        }

        public List<string> OnMessageRecieved(string speaker, string message)
        {
            List<string> responses = new List<string>();
            string[] parameters = message.Split(' ');
            string command = parameters[0];
            parameters = parameters.Skip(1).ToArray();
            foreach (KeyValuePair<Module, bool> module in modules)
            {
                responses.Add(module.Key.ProcessMessage(speaker, command, parameters));
            }
            return responses;
        }

        public void reset()
        {
            modules = new Dictionary<Module, bool>();
        }

    }
}
