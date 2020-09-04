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
            ((System.ComponentModel.ISupportInitialize)(this.containers)).BeginInit();
            this.containers.Panel1.SuspendLayout();
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
            this.containers.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            // 
            // button
            // 
            resources.ApplyResources(this.button, "button");
            this.button.Name = "button";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.containers);
            this.Name = "Form1";
            this.containers.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.containers)).EndInit();
            this.containers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer containers;
        private System.Windows.Forms.Button button;
    }
}

