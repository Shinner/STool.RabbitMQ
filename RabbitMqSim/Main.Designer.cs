namespace RabbitMqSim
{
    partial class Main
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.BtnSend = new System.Windows.Forms.Button();
            this.btnOpenScript = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnRestart = new System.Windows.Forms.Button();
            this.btnOpenConfig = new System.Windows.Forms.Button();
            this.MsgList = new System.Windows.Forms.ListBox();
            this.contextMenuStripMsgList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Send = new System.Windows.Forms.ToolStripMenuItem();
            this.openWithNotepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxReceived = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBoxSend = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.contextMenuStripMsgList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(799, 470);
            this.splitContainer1.SplitterDistance = 148;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.BtnSend);
            this.splitContainer3.Panel1.Controls.Add(this.btnOpenScript);
            this.splitContainer3.Panel1.Controls.Add(this.BtnStart);
            this.splitContainer3.Panel1.Controls.Add(this.BtnRestart);
            this.splitContainer3.Panel1.Controls.Add(this.btnOpenConfig);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.MsgList);
            this.splitContainer3.Size = new System.Drawing.Size(148, 470);
            this.splitContainer3.SplitterDistance = 263;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 6;
            // 
            // BtnSend
            // 
            this.BtnSend.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnSend.Enabled = false;
            this.BtnSend.Location = new System.Drawing.Point(20, 147);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(98, 30);
            this.BtnSend.TabIndex = 5;
            this.BtnSend.Text = "Send";
            this.BtnSend.UseVisualStyleBackColor = false;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // btnOpenScript
            // 
            this.btnOpenScript.Location = new System.Drawing.Point(20, 103);
            this.btnOpenScript.Name = "btnOpenScript";
            this.btnOpenScript.Size = new System.Drawing.Size(98, 23);
            this.btnOpenScript.TabIndex = 3;
            this.btnOpenScript.Text = "OpenScript";
            this.btnOpenScript.UseVisualStyleBackColor = true;
            this.btnOpenScript.Click += new System.EventHandler(this.btnOpenScript_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(20, 8);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(2);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(98, 24);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnRestart
            // 
            this.BtnRestart.Enabled = false;
            this.BtnRestart.Location = new System.Drawing.Point(20, 37);
            this.BtnRestart.Margin = new System.Windows.Forms.Padding(2);
            this.BtnRestart.Name = "BtnRestart";
            this.BtnRestart.Size = new System.Drawing.Size(98, 24);
            this.BtnRestart.TabIndex = 1;
            this.BtnRestart.Text = "ReStart";
            this.BtnRestart.UseVisualStyleBackColor = true;
            this.BtnRestart.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // btnOpenConfig
            // 
            this.btnOpenConfig.Location = new System.Drawing.Point(20, 75);
            this.btnOpenConfig.Name = "btnOpenConfig";
            this.btnOpenConfig.Size = new System.Drawing.Size(98, 23);
            this.btnOpenConfig.TabIndex = 4;
            this.btnOpenConfig.Text = "OpenConfig";
            this.btnOpenConfig.UseVisualStyleBackColor = true;
            this.btnOpenConfig.Click += new System.EventHandler(this.btnOpenConfig_Click);
            // 
            // MsgList
            // 
            this.MsgList.ContextMenuStrip = this.contextMenuStripMsgList;
            this.MsgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MsgList.FormattingEnabled = true;
            this.MsgList.ItemHeight = 17;
            this.MsgList.Location = new System.Drawing.Point(0, 0);
            this.MsgList.Margin = new System.Windows.Forms.Padding(2);
            this.MsgList.Name = "MsgList";
            this.MsgList.Size = new System.Drawing.Size(148, 204);
            this.MsgList.TabIndex = 0;
            this.MsgList.SelectedIndexChanged += new System.EventHandler(this.MsgList_SelectedValueChanged);
            // 
            // contextMenuStripMsgList
            // 
            this.contextMenuStripMsgList.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripMsgList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Add,
            this.Delete,
            this.Send,
            this.openWithNotepadToolStripMenuItem});
            this.contextMenuStripMsgList.Name = "contextMenuStripMsgList";
            this.contextMenuStripMsgList.Size = new System.Drawing.Size(187, 92);
            // 
            // Add
            // 
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(186, 22);
            this.Add.Text = "Add";
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(186, 22);
            this.Delete.Text = "Delete";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Send
            // 
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(186, 22);
            this.Send.Text = "Send";
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // openWithNotepadToolStripMenuItem
            // 
            this.openWithNotepadToolStripMenuItem.Name = "openWithNotepadToolStripMenuItem";
            this.openWithNotepadToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openWithNotepadToolStripMenuItem.Text = "OpenWithNotepad";
            this.openWithNotepadToolStripMenuItem.Click += new System.EventHandler(this.openWithNotepadToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(648, 470);
            this.splitContainer2.SplitterDistance = 314;
            this.splitContainer2.TabIndex = 1;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer4.Size = new System.Drawing.Size(314, 470);
            this.splitContainer4.SplitterDistance = 168;
            this.splitContainer4.SplitterWidth = 3;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBoxReceived);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 168);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Received";
            // 
            // richTextBoxReceived
            // 
            this.richTextBoxReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxReceived.Location = new System.Drawing.Point(3, 19);
            this.richTextBoxReceived.Name = "richTextBoxReceived";
            this.richTextBoxReceived.Size = new System.Drawing.Size(308, 146);
            this.richTextBoxReceived.TabIndex = 0;
            this.richTextBoxReceived.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBoxSend);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(314, 299);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Send";
            // 
            // richTextBoxSend
            // 
            this.richTextBoxSend.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBoxSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSend.Location = new System.Drawing.Point(2, 18);
            this.richTextBoxSend.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxSend.Name = "richTextBoxSend";
            this.richTextBoxSend.Size = new System.Drawing.Size(310, 279);
            this.richTextBoxSend.TabIndex = 0;
            this.richTextBoxSend.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 26);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBoxLog);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 470);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Location = new System.Drawing.Point(3, 19);
            this.richTextBoxLog.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(324, 448);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 470);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "RabbitMQSim 1.0";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.contextMenuStripMsgList.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Button BtnStart;
        private Button BtnRestart;
        private RichTextBox richTextBoxLog;
        private SplitContainer splitContainer2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private RichTextBox richTextBoxReceived;
        private Button btnOpenScript;
        private Button btnOpenConfig;
        private Button BtnSend;
        private SplitContainer splitContainer3;
        private ListBox MsgList;
        private SplitContainer splitContainer4;
        private GroupBox groupBox3;
        private RichTextBox richTextBoxSend;
        private ContextMenuStrip contextMenuStripMsgList;
        private ToolStripMenuItem Add;
        private ToolStripMenuItem Delete;
        private ToolStripMenuItem Send;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem openWithNotepadToolStripMenuItem;
        private FileSystemWatcher fileSystemWatcher1;
    }
}