namespace PingHost
{
    partial class Form_Ping
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
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.button_Ping = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.button_Stop = new System.Windows.Forms.Button();
            this.label_Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(38, 12);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(153, 20);
            this.textBox_IP.TabIndex = 0;
            this.textBox_IP.Text = "127.0.0.1";
            // 
            // button_Ping
            // 
            this.button_Ping.Location = new System.Drawing.Point(197, 10);
            this.button_Ping.Name = "button_Ping";
            this.button_Ping.Size = new System.Drawing.Size(75, 23);
            this.button_Ping.TabIndex = 1;
            this.button_Ping.Text = "Ping";
            this.button_Ping.UseVisualStyleBackColor = true;
            this.button_Ping.Click += new System.EventHandler(this.button_Ping_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Enabled = false;
            this.progressBar.Location = new System.Drawing.Point(0, 51);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(358, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 3;
            // 
            // button_Stop
            // 
            this.button_Stop.Enabled = false;
            this.button_Stop.Location = new System.Drawing.Point(278, 10);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(75, 23);
            this.button_Stop.TabIndex = 1;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(35, 35);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(35, 13);
            this.label_Status.TabIndex = 4;
            this.label_Status.Text = "status";
            // 
            // Form_Ping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 74);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Ping);
            this.Controls.Add(this.textBox_IP);
            this.Name = "Form_Ping";
            this.Text = "Ping Host";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Ping_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Button button_Ping;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Label label_Status;
    }
}

