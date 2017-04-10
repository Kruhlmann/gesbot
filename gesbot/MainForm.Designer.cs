namespace gesbot
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chatLog = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.moduleTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.moduleList = new System.Windows.Forms.CheckedListBox();
            this.soundTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.removeSoundBtn = new System.Windows.Forms.Button();
            this.addSoundBtn = new System.Windows.Forms.Button();
            this.soundsList = new System.Windows.Forms.CheckedListBox();
            this.autoResponseTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.periodicMessageTab = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.periodicTimeoutBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.periodicMessageBox = new System.Windows.Forms.TextBox();
            this.openSoundFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveTimeoutBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.moduleTab.SuspendLayout();
            this.soundTab.SuspendLayout();
            this.autoResponseTab.SuspendLayout();
            this.periodicMessageTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chatLog
            // 
            this.chatLog.Location = new System.Drawing.Point(497, 13);
            this.chatLog.Name = "chatLog";
            this.chatLog.Size = new System.Drawing.Size(275, 536);
            this.chatLog.TabIndex = 0;
            this.chatLog.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.moduleTab);
            this.tabControl1.Controls.Add(this.soundTab);
            this.tabControl1.Controls.Add(this.autoResponseTab);
            this.tabControl1.Controls.Add(this.periodicMessageTab);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(478, 536);
            this.tabControl1.TabIndex = 1;
            // 
            // moduleTab
            // 
            this.moduleTab.Controls.Add(this.label2);
            this.moduleTab.Controls.Add(this.moduleList);
            this.moduleTab.Location = new System.Drawing.Point(4, 22);
            this.moduleTab.Name = "moduleTab";
            this.moduleTab.Padding = new System.Windows.Forms.Padding(3);
            this.moduleTab.Size = new System.Drawing.Size(470, 510);
            this.moduleTab.TabIndex = 1;
            this.moduleTab.Text = "Modules";
            this.moduleTab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(197, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Modules ";
            // 
            // moduleList
            // 
            this.moduleList.FormattingEnabled = true;
            this.moduleList.Location = new System.Drawing.Point(5, 33);
            this.moduleList.Name = "moduleList";
            this.moduleList.Size = new System.Drawing.Size(461, 469);
            this.moduleList.TabIndex = 4;
            // 
            // soundTab
            // 
            this.soundTab.Controls.Add(this.label1);
            this.soundTab.Controls.Add(this.removeSoundBtn);
            this.soundTab.Controls.Add(this.addSoundBtn);
            this.soundTab.Controls.Add(this.soundsList);
            this.soundTab.Location = new System.Drawing.Point(4, 22);
            this.soundTab.Name = "soundTab";
            this.soundTab.Padding = new System.Windows.Forms.Padding(3);
            this.soundTab.Size = new System.Drawing.Size(470, 510);
            this.soundTab.TabIndex = 0;
            this.soundTab.Text = "Sounds";
            this.soundTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Avaliable sounds";
            // 
            // removeSoundBtn
            // 
            this.removeSoundBtn.Location = new System.Drawing.Point(278, 480);
            this.removeSoundBtn.Name = "removeSoundBtn";
            this.removeSoundBtn.Size = new System.Drawing.Size(90, 23);
            this.removeSoundBtn.TabIndex = 2;
            this.removeSoundBtn.Text = "Remove sound";
            this.removeSoundBtn.UseVisualStyleBackColor = true;
            this.removeSoundBtn.Click += new System.EventHandler(this.removeSoundBtn_Click);
            // 
            // addSoundBtn
            // 
            this.addSoundBtn.Location = new System.Drawing.Point(374, 480);
            this.addSoundBtn.Name = "addSoundBtn";
            this.addSoundBtn.Size = new System.Drawing.Size(90, 23);
            this.addSoundBtn.TabIndex = 1;
            this.addSoundBtn.Text = "Add sound";
            this.addSoundBtn.UseVisualStyleBackColor = true;
            this.addSoundBtn.Click += new System.EventHandler(this.addSoundBtn_Click);
            // 
            // soundsList
            // 
            this.soundsList.FormattingEnabled = true;
            this.soundsList.Location = new System.Drawing.Point(3, 35);
            this.soundsList.Name = "soundsList";
            this.soundsList.Size = new System.Drawing.Size(461, 439);
            this.soundsList.TabIndex = 0;
            // 
            // autoResponseTab
            // 
            this.autoResponseTab.Controls.Add(this.label4);
            this.autoResponseTab.Controls.Add(this.label3);
            this.autoResponseTab.Controls.Add(this.commandBox);
            this.autoResponseTab.Location = new System.Drawing.Point(4, 22);
            this.autoResponseTab.Name = "autoResponseTab";
            this.autoResponseTab.Size = new System.Drawing.Size(470, 510);
            this.autoResponseTab.TabIndex = 2;
            this.autoResponseTab.Text = "Auto responses";
            this.autoResponseTab.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(462, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Example: !discord == $speaker here is the discord link discord.gg";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(163, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Auto responses";
            // 
            // commandBox
            // 
            this.commandBox.Enabled = false;
            this.commandBox.Location = new System.Drawing.Point(3, 50);
            this.commandBox.Multiline = true;
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(464, 457);
            this.commandBox.TabIndex = 0;
            // 
            // periodicMessageTab
            // 
            this.periodicMessageTab.Controls.Add(this.saveTimeoutBtn);
            this.periodicMessageTab.Controls.Add(this.label5);
            this.periodicMessageTab.Controls.Add(this.periodicTimeoutBox);
            this.periodicMessageTab.Controls.Add(this.label6);
            this.periodicMessageTab.Controls.Add(this.periodicMessageBox);
            this.periodicMessageTab.Location = new System.Drawing.Point(4, 22);
            this.periodicMessageTab.Name = "periodicMessageTab";
            this.periodicMessageTab.Size = new System.Drawing.Size(470, 510);
            this.periodicMessageTab.TabIndex = 3;
            this.periodicMessageTab.Text = "Periodic messages";
            this.periodicMessageTab.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 491);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Timeout between messages (seconds)";
            // 
            // periodicTimeoutBox
            // 
            this.periodicTimeoutBox.Location = new System.Drawing.Point(318, 487);
            this.periodicTimeoutBox.Name = "periodicTimeoutBox";
            this.periodicTimeoutBox.Size = new System.Drawing.Size(100, 20);
            this.periodicTimeoutBox.TabIndex = 8;
            this.periodicTimeoutBox.Text = "300";
            this.periodicTimeoutBox.TextChanged += new System.EventHandler(this.periodicTimeoutBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(141, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 22);
            this.label6.TabIndex = 7;
            this.label6.Text = "Periodic messages";
            // 
            // periodicMessageBox
            // 
            this.periodicMessageBox.Enabled = false;
            this.periodicMessageBox.Location = new System.Drawing.Point(3, 32);
            this.periodicMessageBox.Multiline = true;
            this.periodicMessageBox.Name = "periodicMessageBox";
            this.periodicMessageBox.Size = new System.Drawing.Size(464, 449);
            this.periodicMessageBox.TabIndex = 6;
            // 
            // openSoundFileDialog
            // 
            this.openSoundFileDialog.FileName = "openFileDialog1";
            // 
            // saveTimeoutBtn
            // 
            this.saveTimeoutBtn.Location = new System.Drawing.Point(424, 487);
            this.saveTimeoutBtn.Name = "saveTimeoutBtn";
            this.saveTimeoutBtn.Size = new System.Drawing.Size(43, 20);
            this.saveTimeoutBtn.TabIndex = 10;
            this.saveTimeoutBtn.Text = "Save";
            this.saveTimeoutBtn.UseVisualStyleBackColor = true;
            this.saveTimeoutBtn.Click += new System.EventHandler(this.saveTimeoutBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.chatLog);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "gesbot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.moduleTab.ResumeLayout(false);
            this.moduleTab.PerformLayout();
            this.soundTab.ResumeLayout(false);
            this.soundTab.PerformLayout();
            this.autoResponseTab.ResumeLayout(false);
            this.autoResponseTab.PerformLayout();
            this.periodicMessageTab.ResumeLayout(false);
            this.periodicMessageTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox chatLog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage soundTab;
        private System.Windows.Forms.CheckedListBox soundsList;
        private System.Windows.Forms.TabPage moduleTab;
        private System.Windows.Forms.Button addSoundBtn;
        private System.Windows.Forms.OpenFileDialog openSoundFileDialog;
        private System.Windows.Forms.Button removeSoundBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox moduleList;
        private System.Windows.Forms.TabPage autoResponseTab;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.TabPage periodicMessageTab;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox periodicMessageBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox periodicTimeoutBox;
        private System.Windows.Forms.Button saveTimeoutBtn;
    }
}

