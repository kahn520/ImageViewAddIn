namespace ImageViewAddIn
{
    partial class FrmView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCache = new System.Windows.Forms.Button();
            this.btnmOpenCacheDir = new System.Windows.Forms.Button();
            this.lblCacheInfo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCacheInfo);
            this.panel1.Controls.Add(this.btnmOpenCacheDir);
            this.panel1.Controls.Add(this.btnCache);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtCol);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 36);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(161, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCol
            // 
            this.txtCol.Location = new System.Drawing.Point(96, 10);
            this.txtCol.Name = "txtCol";
            this.txtCol.Size = new System.Drawing.Size(59, 21);
            this.txtCol.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片所在的列";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(753, 516);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnCache
            // 
            this.btnCache.Location = new System.Drawing.Point(242, 8);
            this.btnCache.Name = "btnCache";
            this.btnCache.Size = new System.Drawing.Size(75, 23);
            this.btnCache.TabIndex = 2;
            this.btnCache.Text = "缓存图片";
            this.btnCache.UseVisualStyleBackColor = true;
            this.btnCache.Click += new System.EventHandler(this.btnCache_Click);
            // 
            // btnmOpenCacheDir
            // 
            this.btnmOpenCacheDir.Location = new System.Drawing.Point(323, 7);
            this.btnmOpenCacheDir.Name = "btnmOpenCacheDir";
            this.btnmOpenCacheDir.Size = new System.Drawing.Size(90, 23);
            this.btnmOpenCacheDir.TabIndex = 2;
            this.btnmOpenCacheDir.Text = "打开缓存目录";
            this.btnmOpenCacheDir.UseVisualStyleBackColor = true;
            this.btnmOpenCacheDir.Click += new System.EventHandler(this.btnmOpenCacheDir_Click);
            // 
            // lblCacheInfo
            // 
            this.lblCacheInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCacheInfo.Location = new System.Drawing.Point(419, 7);
            this.lblCacheInfo.Name = "lblCacheInfo";
            this.lblCacheInfo.Size = new System.Drawing.Size(119, 23);
            this.lblCacheInfo.TabIndex = 3;
            // 
            // FrmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 552);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmView";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCache;
        private System.Windows.Forms.Button btnmOpenCacheDir;
        private System.Windows.Forms.Label lblCacheInfo;
    }
}