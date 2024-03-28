using CSScripting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitMqSim
{
    public partial class Main : Form
    {
        public SimulaterBooter simulaterBooter = new SimulaterBooter();
        public string notePad = "notepad++.exe";
        public string selectedMessage = "";
        public bool IsStart { get; set; }


        public Dictionary<string, string> MessageList { get; set; }
        public Main()
        {
            InitializeComponent();
            GetNotePadPath();
            GetMessageList();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            StartMonitor();

        }
        private void StartMonitor()
        {
            string messageDir = Path.Combine(Environment.CurrentDirectory, "messages");
            this.fileSystemWatcher1 = new FileSystemWatcher();
            this.fileSystemWatcher1.Path = messageDir;
            this.fileSystemWatcher1.Filter = "*.xml";//需要监控的文件类型Filter可以包含多种类型.doc,甚至access数据库的mdb文件也可以。
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.MessageFileChanged);//这个Changed函数是要自己写的。
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.EnableRaisingEvents = true;
        }

        private void MessageFileChanged(object sender, FileSystemEventArgs e)
        {
            lock (this)
            {
                GetMessageList();
            }
        }

        private void GetMessageList()
        {
            string messageDir = Path.Combine(Environment.CurrentDirectory, "messages");
            if (!Directory.Exists(messageDir))
            {
                Directory.CreateDirectory(messageDir);
            }

            var files = Directory.GetFiles(messageDir, "*.xml");

            MessageList = new Dictionary<string, string>();
            foreach (var file in files)
            {
                MessageList.Add(file.GetFileNameWithoutExtension(), File.ReadAllText(file));
            }
            string oldSelectedMsg = selectedMessage;
            this.MsgList.DataSource = MessageList.Keys.ToList().OrderBy(p=>p).ToList();
            this.MsgList.Refresh();
            if(!string.IsNullOrEmpty(oldSelectedMsg))
            {
                selectedMessage = oldSelectedMsg;
                this.MsgList.SelectedItem = selectedMessage;
             
            }
        }

        public string GetNotePadPath()
        {
            if (File.Exists("path"))
            {
                notePad = File.ReadAllText("path");
            }
            else
            {
                File.WriteAllText("path", notePad);
            }

            return notePad;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            BtnStart.Enabled = false;
            if (!IsStart)
            {
                simulaterBooter.Start(richTextBoxLog, richTextBoxReceived);
                BtnRestart.Enabled = true;
                BtnSend.Enabled = true;
            }
            else
            {
                simulaterBooter.Stop();
                BtnRestart.Enabled = false;
                BtnSend.Enabled = false;
            }

            IsStart = !IsStart;


            Action action = new Action(() =>
            {
                BtnStart.Text = IsStart ? "Stop" : "Start";
                BtnStart.Enabled = true;

            });
            if (BtnStart.InvokeRequired)
            {
                BtnStart.BeginInvoke(action);
            }
            else
            {
                action();
            }

        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            BtnRestart.Enabled = false;
            simulaterBooter.ReStart(richTextBoxLog, richTextBoxReceived);
            BtnRestart.Enabled = true;
        }


        private void btnOpenConfig_Click(object sender, EventArgs e)
        {

            try
            {
                Process.Start(notePad, Path.Combine(Environment.CurrentDirectory, "config.json"));
            }
            catch (Exception ex)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "请选择编辑器路径";
                ofd.Filter = "(*.exe)|*.exe";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    notePad = ofd.FileName;
                    File.WriteAllText("path", notePad);
                }
            }

        }

        private void btnOpenScript_Click(object sender, EventArgs e)
        {

            try
            {
                Process.Start(notePad, Path.Combine(Environment.CurrentDirectory, "scripts", "RabbitMqSimScript.cs"));
            }
            catch (Exception ex)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "请选择编辑器路径";
                ofd.Filter = "(*.exe)|*.exe";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    notePad = ofd.FileName;
                    File.WriteAllText("path", notePad);
                }
            }
        }

        private void MsgList_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox list = (ListBox)sender;

            if (list.SelectedItems.Count > 0)
            {
                selectedMessage = list.SelectedItems[0].ToString();
                if (MessageList.ContainsKey(selectedMessage))
                {
                    this.richTextBoxSend.Text = MessageList[selectedMessage];
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddMessageDialog addMessageDialog = new AddMessageDialog();
            if (addMessageDialog.ShowDialog() == DialogResult.OK)
            {
                var fileStream = File.Create(Path.Combine(Environment.CurrentDirectory, "messages", $"{addMessageDialog.MessageName}.xml"));

                fileStream.Close();
                GetMessageList();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete?") == DialogResult.OK)
            {

                string name = MsgList.SelectedItem.ToString();

                File.Delete(Path.Combine(Environment.CurrentDirectory, "messages", $"{name}.xml"));
                selectedMessage = "";
                GetMessageList();
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            simulaterBooter.Send(richTextBoxSend.Text);
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            simulaterBooter.Send(richTextBoxSend.Text);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msgname = MsgList.SelectedItem.ToString();

            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "messages", $"{msgname}.xml"), richTextBoxSend.Text);
        }

        private void openWithNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msgname = MsgList.SelectedItem.ToString();

            try
            {
                Process.Start(notePad, Path.Combine(Environment.CurrentDirectory, "messages", $"{msgname}.xml"));
            }
            catch (Exception ex)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "请选择编辑器路径";
                ofd.Filter = "(*.exe)|*.exe";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    notePad = ofd.FileName;
                    File.WriteAllText("path", notePad);
                }
            }
        }
    }
}
