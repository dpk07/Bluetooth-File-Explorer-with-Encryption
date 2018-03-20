namespace FileExplorer
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.regDevice = new System.Windows.Forms.Button();
            this.unlockFile = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            this.lockFile = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // regDevice
            // 
            this.regDevice.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regDevice.Image = ((System.Drawing.Image)(resources.GetObject("regDevice.Image")));
            this.regDevice.Location = new System.Drawing.Point(61, 12);
            this.regDevice.Name = "regDevice";
            this.regDevice.Size = new System.Drawing.Size(257, 128);
            this.regDevice.TabIndex = 0;
            this.regDevice.Text = "Register your device";
            this.regDevice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.regDevice.UseVisualStyleBackColor = true;
            this.regDevice.Click += new System.EventHandler(this.regDevice_Click);
            // 
            // unlockFile
            // 
            this.unlockFile.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unlockFile.Image = ((System.Drawing.Image)(resources.GetObject("unlockFile.Image")));
            this.unlockFile.Location = new System.Drawing.Point(61, 146);
            this.unlockFile.Name = "unlockFile";
            this.unlockFile.Size = new System.Drawing.Size(257, 128);
            this.unlockFile.TabIndex = 2;
            this.unlockFile.Text = "Unlock and Decrypt folder";
            this.unlockFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.unlockFile.UseVisualStyleBackColor = true;
            this.unlockFile.Click += new System.EventHandler(this.unlockFile_Click);
            // 
            // result
            // 
            this.result.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result.Location = new System.Drawing.Point(61, 316);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(555, 94);
            this.result.TabIndex = 4;
            this.result.Text = "Result : ";
            // 
            // lockFile
            // 
            this.lockFile.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lockFile.Image = ((System.Drawing.Image)(resources.GetObject("lockFile.Image")));
            this.lockFile.Location = new System.Drawing.Point(359, 146);
            this.lockFile.Name = "lockFile";
            this.lockFile.Size = new System.Drawing.Size(257, 128);
            this.lockFile.TabIndex = 5;
            this.lockFile.Text = "Lock and Encrypt folder";
            this.lockFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lockFile.UseVisualStyleBackColor = true;
            this.lockFile.Click += new System.EventHandler(this.lockFile_Click);
            // 
            // btn4
            // 
            this.btn4.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Image = ((System.Drawing.Image)(resources.GetObject("btn4.Image")));
            this.btn4.Location = new System.Drawing.Point(359, 12);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(257, 128);
            this.btn4.TabIndex = 6;
            this.btn4.Text = "Check connection";
            this.btn4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // stop
            // 
            this.stop.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop.Location = new System.Drawing.Point(525, 280);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(91, 30);
            this.stop.TabIndex = 8;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(683, 422);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.lockFile);
            this.Controls.Add(this.result);
            this.Controls.Add(this.unlockFile);
            this.Controls.Add(this.regDevice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.SizeChanged += new System.EventHandler(this.Form2_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button regDevice;
        private System.Windows.Forms.Button unlockFile;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button lockFile;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}