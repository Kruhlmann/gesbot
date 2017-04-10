using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace gesbot
{
    public partial class MainForm : Form
    {
        TcpClient tcpClient;
        StreamReader reader;
        StreamWriter writer;

        string userName, password, channel, chatPrefix, chatCommandId;


        DateTime lastMessageTime;
        Queue<string> sendMessageQueue;
        ModuleManager moduleManager;

        public MainForm()
        {
            InitializeComponent();
            sendMessageQueue = new Queue<string>();
            InitializeSounds();
            moduleManager = new ModuleManager(this);
            InitializeModules();
            Reconnect();
        }

        private void Reconnect()
        {

            tcpClient = new TcpClient("irc.twitch.tv", 6667);
            reader = new StreamReader(tcpClient.GetStream());
            writer = new StreamWriter(tcpClient.GetStream());

            var credentials = File.ReadAllLines("credentials.txt");
            userName = credentials[0].ToLower();
            password = credentials[1];
            channel = credentials[2];
            chatCommandId = "PRIVMSG";
            chatPrefix = $":{userName}!{userName}@{userName}.tmi.twitch.tv {chatCommandId} #{channel} :";

            chatLog.Text = "";
            chatLog.Text += DateTime.Now.ToShortDateString() + " #" + channel;

            writer.WriteLine("PASS " + password + Environment.NewLine + "NICK " + userName + Environment.NewLine + "USER " + userName + " 8 * :" + userName);
            writer.Flush();
            writer.WriteLine("JOIN #" + channel);
            writer.Flush();
            lastMessageTime = DateTime.Now;
        }

        private void GetViewers()
        {
            writer.WriteLine("CAP REQ :twitch.tv/membership");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!tcpClient.Connected) Reconnect();
            List<string> responses = moduleManager.OnTick();
            foreach (string response in responses) SendMessage(response);
            TrySendingMessages();
            TryRecieveMessages();
        }

        private void TrySendingMessages()
        {
            if(DateTime.Now - lastMessageTime > TimeSpan.FromSeconds(2) && sendMessageQueue.Count > 0)
            {
                var message = sendMessageQueue.Dequeue();
                chatLog.Text += $"\r\n{userName}: {message}";
                writer.WriteLine($"{chatPrefix}{message}");
                writer.Flush();
                lastMessageTime = DateTime.Now;
            }
        }

        private void TryRecieveMessages()
        {
            if (tcpClient.Available > 0 || reader.Peek() > 0)
            {
                var message = reader.ReadLine();
                var messageColon = message.IndexOf(":", 1);
                if (messageColon > 0)
                {
                    var command = message.Substring(1, messageColon);
                    if (message.Contains(chatCommandId))
                    {
                        var speakerIndex = command.IndexOf("!");
                        if (speakerIndex > 0)
                        {
                            var speaker = command.Substring(0, speakerIndex);
                            var chatMessage = message.Substring(command.Length + 1);
                            OnMessageRecieved(speaker, chatMessage);
                        }
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSoundConfiguration();
        }

        private void OnMessageRecieved(string speaker, string message)
        {
            chatLog.Text += $"\r\n{speaker}: {message}";
            List<string> responses = moduleManager.OnMessageRecieved(speaker, message);
            foreach (string response in responses) SendMessage(response);
        }

        private void removeSoundBtn_Click(object sender, EventArgs e)
        {
            try
            {
                soundsList.Items.RemoveAt(soundsList.SelectedIndex);
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred when trying to remove a sound using the CheckBoxListView.Selected index");
            }
        }

        private void addSoundBtn_Click(object sender, EventArgs e)
        {
            string osUserPath = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                osUserPath = Directory.GetParent(osUserPath).ToString();
            }
            openSoundFileDialog.InitialDirectory = osUserPath;
            openSoundFileDialog.FileName = "";
            openSoundFileDialog.Filter = "WAV files (*.wav)|*.wav";
            if (openSoundFileDialog.ShowDialog() == DialogResult.OK)
            {
                if(Path.GetFileName(openSoundFileDialog.FileName).Contains(' '))
                {
                    MessageBox.Show("Sorry! The file name can't contains any spaces.");
                    return;
                }
                AddSound(openSoundFileDialog.FileName, true);
            }
        }

        private void AddSound(string name, bool isChecked)
        {
            for (int i = 0; i < soundsList.Items.Count; i++) { 
                if(Path.GetFileName(name) == Path.GetFileName(soundsList.Items[i].ToString()))
                {
                    MessageBox.Show($"A sound with the name \"{Path.GetFileName(name)}\" already exists!");
                    return;
                }
            }
            soundsList.Items.Add(name, isChecked);
        }

        private void SendMessage(string message)
        {
            if (message == null) return;
            sendMessageQueue.Enqueue(message);
        }

        private void InitializeSounds() {
            foreach (var line in File.ReadAllLines("sounds.txt"))
            {
                var splitLine = line.Split('-');
                if(splitLine.Length != 2)
                {
                    Console.WriteLine("Unable to load sound with data " + line);
                    continue;
                }
                if (!SoundExists(Path.GetFileName(splitLine[0])))
                {
                    soundsList.Items.Add(splitLine[0], splitLine[1] == "Y");
                }
            }
        }

        private bool SoundExists(string sound)
        {
            foreach (object o in soundsList.Items) if (sound == o.ToString()) return true;
            return false;
        }

        private void SaveSoundConfiguration()
        {
            System.IO.File.WriteAllText("sounds.txt", string.Empty);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("sounds.txt"))
            {
                for (int i = 0; i < soundsList.Items.Count; i++)
                {
                    string checkedString = (soundsList.GetItemChecked(i)) ? "Y" : "N";
                    file.WriteLine($"{soundsList.Items[i].ToString()}-{checkedString}");
                }
            }
            
        }

        private void periodicTimeoutBox_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(periodicTimeoutBox.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                periodicTimeoutBox.Text = "300";
            }

        }

        public void SetPeriodicMessageTimeOut(int i)
        {
            periodicTimeoutBox.Text = i.ToString();
        }

        private void saveTimeoutBtn_Click(object sender, EventArgs e)
        {
            modules.PeriodicMessageModule module = (modules.PeriodicMessageModule)moduleManager.GetModuleByName("Periodic Message Module");
            if (module != null) module.timeout = int.Parse(periodicTimeoutBox.Text);
        }

        private void InitializeModules()
        {
            moduleManager.AddModule(new modules.SoundModule(this));
            moduleManager.AddModule(new modules.AutismModule(this));
            moduleManager.AddModule(new modules.AutoResponseModule(this));
            moduleManager.AddModule(new modules.PeriodicMessageModule(this));
        }

        public CheckedListBox GetModulesList()
        {
            return moduleList;
        }

        public CheckedListBox GetSoundsList()
        {
            return soundsList;
        }


        public TextBox GetCommandBox()
        {
            return commandBox;
        }

        public void AddPeriodicMessage(string message)
        {
            periodicMessageBox.Text += message + Environment.NewLine;
        }

    }
}
