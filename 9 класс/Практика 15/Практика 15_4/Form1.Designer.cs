namespace Практика_15_4
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.explanationText = new System.Windows.Forms.Label();
            this.resultText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(15, 43);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(110, 23);
            this.button.TabIndex = 0;
            this.button.Text = "Новая попытка";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(218, 17);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(49, 20);
            this.textBox.TabIndex = 1;
            // 
            // explanationText
            // 
            this.explanationText.AutoSize = true;
            this.explanationText.Location = new System.Drawing.Point(12, 20);
            this.explanationText.Name = "explanationText";
            this.explanationText.Size = new System.Drawing.Size(200, 13);
            this.explanationText.TabIndex = 2;
            this.explanationText.Text = "Введите число в диапазоне от 0 до 10";
            this.explanationText.Click += new System.EventHandler(this.label1_Click);
            // 
            // resultText
            // 
            this.resultText.AutoSize = true;
            this.resultText.Location = new System.Drawing.Point(12, 84);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(65, 13);
            this.resultText.TabIndex = 3;
            this.resultText.Text = "Результат: ";
            this.resultText.Click += new System.EventHandler(this.resultText_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 162);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.explanationText);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Проверь себя на везучесть";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label explanationText;
        private System.Windows.Forms.Label resultText;
    }
}

