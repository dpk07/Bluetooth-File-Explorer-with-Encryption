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
            this.regDevice = new System.Windows.Forms.Button();
            this.unlockFolder = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            this.lockFolder = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // regDevice
            // 
            this.regDevice.Location = new System.Drawing.Point(89, 54);
            this.regDevice.Name = "regDevice";
            this.regDevice.Size = new System.Drawing.Size(214, 75);
            this.regDevice.TabIndex = 0;
            this.regDevice.Text = "Register your device";
            this.regDevice.UseVisualStyleBackColor = true;
            this.regDevice.Click += new System.EventHandler(this.regDevice_Click);
            // 
            // unlockFolder
            // 
            this.unlockFolder.Location = new System.Drawing.Point(89, 156);
            this.unlockFolder.Name = "unlockFolder";
            this.unlockFolder.Size = new System.Drawing.Size(214, 75);
            this.unlockFolder.TabIndex = 2;
            this.unlockFolder.Text = "Unlock and Decrypt folder";
            this.unlockFolder.UseVisualStyleBackColor = true;
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(58, 293);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(555, 81);
            this.result.TabIndex = 4;
            // 
            // lockFolder
            // 
            this.lockFolder.Location = new System.Drawing.Point(366, 54);
            this.lockFolder.Name = "lockFolder";
            this.lockFolder.Size = new System.Drawing.Size(214, 75);
            this.lockFolder.TabIndex = 5;
            this.lockFolder.Text = "Lock and Encrypt folder";
            this.lockFolder.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(366, 156);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(214, 75);
            this.btn4.TabIndex = 6;
            this.btn4.Text = "Check connection";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Result:";
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(505, 252);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 8;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 386);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.lockFolder);
            this.Controls.Add(this.result);
            this.Controls.Add(this.unlockFolder);
            this.Controls.Add(this.regDevice);
            this.Name = "Form2";
            this.Text = "OptionsPage";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button regDevice;
        private System.Windows.Forms.Button unlockFolder;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button lockFolder;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button stop;
    }
}