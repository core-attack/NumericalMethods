namespace FirstLaba
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxE = new System.Windows.Forms.TextBox();
            this.labelE = new System.Windows.Forms.Label();
            this.richTextBoxGeneral = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelN = new System.Windows.Forms.Label();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.labelM = new System.Windows.Forms.Label();
            this.textBoxM = new System.Windows.Forms.TextBox();
            this.comboBoxLabs = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxE
            // 
            this.textBoxE.Location = new System.Drawing.Point(260, 6);
            this.textBoxE.Name = "textBoxE";
            this.textBoxE.Size = new System.Drawing.Size(100, 20);
            this.textBoxE.TabIndex = 0;
            this.textBoxE.Text = "0,01";
            this.textBoxE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxE_KeyPress);
            // 
            // labelE
            // 
            this.labelE.AutoSize = true;
            this.labelE.Location = new System.Drawing.Point(213, 9);
            this.labelE.Name = "labelE";
            this.labelE.Size = new System.Drawing.Size(41, 13);
            this.labelE.TabIndex = 1;
            this.labelE.Text = "Epsilon";
            this.labelE.Click += new System.EventHandler(this.label1_Click);
            // 
            // richTextBoxGeneral
            // 
            this.richTextBoxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxGeneral.Location = new System.Drawing.Point(0, 32);
            this.richTextBoxGeneral.Name = "richTextBoxGeneral";
            this.richTextBoxGeneral.Size = new System.Drawing.Size(788, 286);
            this.richTextBoxGeneral.TabIndex = 2;
            this.richTextBoxGeneral.Text = "1 0,1 0,1 = 1,2\n0,2 1 0,1 = 1,3\n0,2 0,2 1 = 1,4\n";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(664, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Location = new System.Drawing.Point(12, 9);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(22, 13);
            this.labelN.TabIndex = 5;
            this.labelN.Text = "n =";
            // 
            // textBoxN
            // 
            this.textBoxN.Location = new System.Drawing.Point(40, 6);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(48, 20);
            this.textBoxN.TabIndex = 4;
            this.textBoxN.Text = "3";
            this.textBoxN.TextChanged += new System.EventHandler(this.textBoxN_TextChanged);
            this.textBoxN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxM_KeyPress);
            // 
            // labelM
            // 
            this.labelM.AutoSize = true;
            this.labelM.Location = new System.Drawing.Point(94, 9);
            this.labelM.Name = "labelM";
            this.labelM.Size = new System.Drawing.Size(24, 13);
            this.labelM.TabIndex = 7;
            this.labelM.Text = "m =";
            // 
            // textBoxM
            // 
            this.textBoxM.Location = new System.Drawing.Point(122, 6);
            this.textBoxM.Name = "textBoxM";
            this.textBoxM.Size = new System.Drawing.Size(48, 20);
            this.textBoxM.TabIndex = 6;
            this.textBoxM.Text = "3";
            this.textBoxM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxM_KeyPress);
            // 
            // comboBoxLabs
            // 
            this.comboBoxLabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLabs.FormattingEnabled = true;
            this.comboBoxLabs.Location = new System.Drawing.Point(0, 297);
            this.comboBoxLabs.Name = "comboBoxLabs";
            this.comboBoxLabs.Size = new System.Drawing.Size(788, 21);
            this.comboBoxLabs.TabIndex = 8;
            this.comboBoxLabs.SelectedIndexChanged += new System.EventHandler(this.comboBoxLabs_SelectedIndexChanged);
            this.comboBoxLabs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxLabs_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 321);
            this.Controls.Add(this.comboBoxLabs);
            this.Controls.Add(this.labelM);
            this.Controls.Add(this.textBoxM);
            this.Controls.Add(this.labelN);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBoxGeneral);
            this.Controls.Add(this.labelE);
            this.Controls.Add(this.textBoxE);
            this.MinimumSize = new System.Drawing.Size(504, 312);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Численные методы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxE;
        private System.Windows.Forms.Label labelE;
        private System.Windows.Forms.RichTextBox richTextBoxGeneral;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.Label labelM;
        private System.Windows.Forms.TextBox textBoxM;
        private System.Windows.Forms.ComboBox comboBoxLabs;
    }
}

