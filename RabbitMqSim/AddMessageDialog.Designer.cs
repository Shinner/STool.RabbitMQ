namespace RabbitMqSim
{
    partial class AddMessageDialog
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
            this.BtnAddMsg = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnAddMsg
            // 
            this.BtnAddMsg.Location = new System.Drawing.Point(222, 63);
            this.BtnAddMsg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnAddMsg.Name = "BtnAddMsg";
            this.BtnAddMsg.Size = new System.Drawing.Size(128, 31);
            this.BtnAddMsg.TabIndex = 0;
            this.BtnAddMsg.Text = "OK";
            this.BtnAddMsg.UseVisualStyleBackColor = true;
            this.BtnAddMsg.Click += new System.EventHandler(this.BtnAddMsg_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 25);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 23);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "MessageName";
            // 
            // AddMessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 109);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnAddMsg);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddMessageDialog";
            this.Text = "AddMessageDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtnAddMsg;
        private TextBox textBox1;
        private Label label1;
    }
}