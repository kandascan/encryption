namespace WinVernama
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.txtZaszyfrowany = new System.Windows.Forms.TextBox();
            this.btnOdszyfruj = new System.Windows.Forms.Button();
            this.btnSzyfruj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Zaszyfrowany";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Text";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(42, 57);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(328, 20);
            this.txtText.TabIndex = 9;
            // 
            // txtZaszyfrowany
            // 
            this.txtZaszyfrowany.Location = new System.Drawing.Point(42, 126);
            this.txtZaszyfrowany.Name = "txtZaszyfrowany";
            this.txtZaszyfrowany.Size = new System.Drawing.Size(328, 20);
            this.txtZaszyfrowany.TabIndex = 8;
            // 
            // btnOdszyfruj
            // 
            this.btnOdszyfruj.Location = new System.Drawing.Point(295, 97);
            this.btnOdszyfruj.Name = "btnOdszyfruj";
            this.btnOdszyfruj.Size = new System.Drawing.Size(75, 23);
            this.btnOdszyfruj.TabIndex = 7;
            this.btnOdszyfruj.Text = "Odszyfruj";
            this.btnOdszyfruj.UseVisualStyleBackColor = true;
            this.btnOdszyfruj.Click += new System.EventHandler(this.btnOdszyfruj_Click);
            // 
            // btnSzyfruj
            // 
            this.btnSzyfruj.Location = new System.Drawing.Point(295, 28);
            this.btnSzyfruj.Name = "btnSzyfruj";
            this.btnSzyfruj.Size = new System.Drawing.Size(75, 23);
            this.btnSzyfruj.TabIndex = 6;
            this.btnSzyfruj.Text = "Szyfruj";
            this.btnSzyfruj.UseVisualStyleBackColor = true;
            this.btnSzyfruj.Click += new System.EventHandler(this.btnSzyfruj_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 176);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtZaszyfrowany);
            this.Controls.Add(this.btnOdszyfruj);
            this.Controls.Add(this.btnSzyfruj);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.TextBox txtZaszyfrowany;
        private System.Windows.Forms.Button btnOdszyfruj;
        private System.Windows.Forms.Button btnSzyfruj;
    }
}

