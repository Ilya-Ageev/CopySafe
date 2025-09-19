namespace CopySafe
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSearchFlash = new Button();
            lstAllFlash = new ListBox();
            dataCopybtn = new Button();
            SuspendLayout();
            // 
            // btnSearchFlash
            // 
            btnSearchFlash.Location = new Point(255, 12);
            btnSearchFlash.Name = "btnSearchFlash";
            btnSearchFlash.Size = new Size(171, 49);
            btnSearchFlash.TabIndex = 0;
            btnSearchFlash.Text = "Поиск подключённых флеш-накопителей";
            btnSearchFlash.UseVisualStyleBackColor = true;
            btnSearchFlash.Click += btnSearchFlash_Click;
            // 
            // lstAllFlash
            // 
            lstAllFlash.FormattingEnabled = true;
            lstAllFlash.ItemHeight = 15;
            lstAllFlash.Location = new Point(12, 12);
            lstAllFlash.Name = "lstAllFlash";
            lstAllFlash.Size = new Size(237, 109);
            lstAllFlash.TabIndex = 1;
            // 
            // dataCopybtn
            // 
            dataCopybtn.Location = new Point(255, 67);
            dataCopybtn.Name = "dataCopybtn";
            dataCopybtn.Size = new Size(171, 49);
            dataCopybtn.TabIndex = 5;
            dataCopybtn.Text = "Скопировать данные";
            dataCopybtn.UseVisualStyleBackColor = true;
            dataCopybtn.Click += dataCopybtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(457, 152);
            Controls.Add(dataCopybtn);
            Controls.Add(lstAllFlash);
            Controls.Add(btnSearchFlash);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnSearchFlash;
        private ListBox lstAllFlash;
        private ListBox lstSavedFlashes;
        private Button dataCopybtn;
    }
}
