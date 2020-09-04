namespace Практика_15
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
            this.button = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.TextBox();
            this.UserNameAsk = new System.Windows.Forms.Label();
            this.resultText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button.Location = new System.Drawing.Point(47, 62);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(292, 29);
            this.button.TabIndex = 0;
            this.button.Text = "Поприветствовать";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // userName
            // 
            this.userName.BackColor = System.Drawing.SystemColors.WindowText;
            this.userName.ForeColor = System.Drawing.SystemColors.Window;
            this.userName.Location = new System.Drawing.Point(210, 36);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(129, 20);
            this.userName.TabIndex = 2;
            // 
            // UserNameAsk
            // 
            this.UserNameAsk.AutoSize = true;
            this.UserNameAsk.BackColor = System.Drawing.SystemColors.Desktop;
            this.UserNameAsk.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameAsk.ForeColor = System.Drawing.Color.Cornsilk;
            this.UserNameAsk.Location = new System.Drawing.Point(44, 36);
            this.UserNameAsk.Name = "UserNameAsk";
            this.UserNameAsk.Size = new System.Drawing.Size(160, 14);
            this.UserNameAsk.TabIndex = 3;
            this.UserNameAsk.Text = "Введите имя для приветствия";
            this.UserNameAsk.Click += new System.EventHandler(this.UserNameAsk_Click);
            // 
            // resultText
            // 
            this.resultText.BackColor = System.Drawing.SystemColors.WindowText;
            this.resultText.ForeColor = System.Drawing.SystemColors.Window;
            this.resultText.Location = new System.Drawing.Point(47, 115);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(292, 20);
            this.resultText.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(381, 182);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.UserNameAsk);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.button);
            this.Name = "Form1";
            this.Text = "Приветствие";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label UserNameAsk;
        private System.Windows.Forms.TextBox resultText;
    }
}

