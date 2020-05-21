namespace Практика_17
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Do = new System.Windows.Forms.Button();
            this.binarCode = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this._16 = new System.Windows.Forms.RadioButton();
            this._10 = new System.Windows.Forms.RadioButton();
            this._8 = new System.Windows.Forms.RadioButton();
            this.Exit = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.splitContainer1.Panel1.Controls.Add(this.Do);
            this.splitContainer1.Panel1.Controls.Add(this.binarCode);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.splitContainer1.Panel2.Controls.Add(this.groupBox);
            this.splitContainer1.Panel2.Controls.Add(this.Exit);
            this.splitContainer1.Panel2.Controls.Add(this.result);
            this.splitContainer1.Size = new System.Drawing.Size(396, 226);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 0;
            // 
            // Do
            // 
            this.Do.Location = new System.Drawing.Point(28, 12);
            this.Do.Name = "Do";
            this.Do.Size = new System.Drawing.Size(120, 23);
            this.Do.TabIndex = 1;
            this.Do.Text = "Do";
            this.Do.UseVisualStyleBackColor = true;
            this.Do.Click += new System.EventHandler(this.Do_Click);
            // 
            // binarCode
            // 
            this.binarCode.Location = new System.Drawing.Point(28, 60);
            this.binarCode.Name = "binarCode";
            this.binarCode.Size = new System.Drawing.Size(120, 20);
            this.binarCode.TabIndex = 0;
            this.binarCode.Tag = "Binary number";
            this.binarCode.Text = "0";
            this.binarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BinarCode_KeyDown);
            this.binarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BinarCode_KeyPress);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this._16);
            this.groupBox.Controls.Add(this._10);
            this.groupBox.Controls.Add(this._8);
            this.groupBox.Location = new System.Drawing.Point(30, 102);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(120, 89);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Система счстления";
            // 
            // _16
            // 
            this._16.AutoSize = true;
            this._16.Location = new System.Drawing.Point(3, 62);
            this._16.Name = "_16";
            this._16.Size = new System.Drawing.Size(37, 17);
            this._16.TabIndex = 2;
            this._16.Text = "16";
            this._16.UseVisualStyleBackColor = true;
            this._16.CheckedChanged += new System.EventHandler(this._16_CheckedChanged);
            // 
            // _10
            // 
            this._10.AutoSize = true;
            this._10.Location = new System.Drawing.Point(3, 39);
            this._10.Name = "_10";
            this._10.Size = new System.Drawing.Size(37, 17);
            this._10.TabIndex = 1;
            this._10.Text = "10";
            this._10.UseVisualStyleBackColor = true;
            this._10.CheckedChanged += new System.EventHandler(this._10_CheckedChanged);
            // 
            // _8
            // 
            this._8.AutoSize = true;
            this._8.Location = new System.Drawing.Point(3, 16);
            this._8.Name = "_8";
            this._8.Size = new System.Drawing.Size(31, 17);
            this._8.TabIndex = 0;
            this._8.TabStop = true;
            this._8.Text = "8";
            this._8.UseVisualStyleBackColor = true;
            this._8.CheckedChanged += new System.EventHandler(this._8_CheckedChanged);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(30, 12);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(120, 23);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(30, 60);
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Size = new System.Drawing.Size(120, 20);
            this.result.TabIndex = 0;
            this.result.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 226);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(412, 265);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перевод двоичного числа в различные системы счисления";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox binarCode;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Do;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton _8;
        private System.Windows.Forms.RadioButton _10;
        private System.Windows.Forms.RadioButton _16;
    }
}

