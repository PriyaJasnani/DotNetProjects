namespace EntityFrameworks
{
    partial class DemoForm
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
            txtdemo = new TextBox();
            btnshow = new Button();
            SuspendLayout();
            // 
            // txtdemo
            // 
            txtdemo.Location = new Point(168, 150);
            txtdemo.Margin = new Padding(5, 5, 5, 5);
            txtdemo.Name = "txtdemo";
            txtdemo.Size = new Size(292, 33);
            txtdemo.TabIndex = 0;
            // 
            // btnshow
            // 
            btnshow.Location = new Point(251, 225);
            btnshow.Name = "btnshow";
            btnshow.Size = new Size(148, 55);
            btnshow.TabIndex = 1;
            btnshow.Text = "Show Button";
            btnshow.UseVisualStyleBackColor = true;
            btnshow.Click += btnshow_Click;
            // 
            // DemoForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 749);
            Controls.Add(btnshow);
            Controls.Add(txtdemo);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(5, 5, 5, 5);
            Name = "DemoForm";
            Text = "DemoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtdemo;
        private Button btnshow;
    }
}