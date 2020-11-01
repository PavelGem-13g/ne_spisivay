namespace Практика_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.containers = new System.Windows.Forms.SplitContainer();
            this.button = new System.Windows.Forms.Button();
            this.label_C = new System.Windows.Forms.Label();
            this.label_B = new System.Windows.Forms.Label();
            this.lable_A = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.containers)).BeginInit();
            this.containers.Panel1.SuspendLayout();
            this.containers.Panel2.SuspendLayout();
            this.containers.SuspendLayout();
            this.SuspendLayout();
            // 
            // containers
            // 
            resources.ApplyResources(this.containers, "containers");
            this.containers.Name = "containers";
            // 
            // containers.Panel1
            // 
            this.containers.Panel1.Controls.Add(this.button);
            // 
            // containers.Panel2
            // 
            this.containers.Panel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.containers.Panel2.Controls.Add(this.label_C);
            this.containers.Panel2.Controls.Add(this.label_B);
            this.containers.Panel2.Controls.Add(this.lable_A);
            this.containers.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            // 
            // button
            // 
            resources.ApplyResources(this.button, "button");
            this.button.Name = "button";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // label_C
            // 
            resources.ApplyResources(this.label_C, "label_C");
            this.label_C.BackColor = System.Drawing.Color.Transparent;
            this.label_C.Name = "label_C";
            // 
            // label_B
            // 
            resources.ApplyResources(this.label_B, "label_B");
            this.label_B.BackColor = System.Drawing.Color.Transparent;
            this.label_B.Name = "label_B";
            // 
            // lable_A
            // 
            resources.ApplyResources(this.lable_A, "lable_A");
            this.lable_A.BackColor = System.Drawing.Color.Transparent;
            this.lable_A.ForeColor = System.Drawing.Color.Black;
            this.lable_A.Name = "lable_A";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.containers);
            this.Name = "Form1";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.containers.Panel1.ResumeLayout(false);
            this.containers.Panel2.ResumeLayout(false);
            this.containers.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.containers)).EndInit();
            this.containers.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer containers;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label lable_A;
        private System.Windows.Forms.Label label_B;
        private System.Windows.Forms.Label label_C;
    }
}

