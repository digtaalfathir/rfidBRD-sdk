namespace PortalTest
{
    partial class FormPortalConfig
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numIrTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIrConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIrQuery = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIrTime)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numIrTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnIrConfig);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnIrQuery);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 83);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "延时关闭读卡（红外线）：";
            // 
            // numIrTime
            // 
            this.numIrTime.Location = new System.Drawing.Point(89, 20);
            this.numIrTime.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numIrTime.Name = "numIrTime";
            this.numIrTime.Size = new System.Drawing.Size(87, 21);
            this.numIrTime.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "秒";
            // 
            // btnIrConfig
            // 
            this.btnIrConfig.Location = new System.Drawing.Point(124, 54);
            this.btnIrConfig.Name = "btnIrConfig";
            this.btnIrConfig.Size = new System.Drawing.Size(75, 23);
            this.btnIrConfig.TabIndex = 5;
            this.btnIrConfig.Text = "配置";
            this.btnIrConfig.UseVisualStyleBackColor = true;
            this.btnIrConfig.Click += new System.EventHandler(this.btnIrConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "延时时长：";
            // 
            // btnIrQuery
            // 
            this.btnIrQuery.Location = new System.Drawing.Point(43, 54);
            this.btnIrQuery.Name = "btnIrQuery";
            this.btnIrQuery.Size = new System.Drawing.Size(75, 23);
            this.btnIrQuery.TabIndex = 5;
            this.btnIrQuery.Text = "查询";
            this.btnIrQuery.UseVisualStyleBackColor = true;
            this.btnIrQuery.Click += new System.EventHandler(this.btnIrQuery_Click);
            // 
            // FormPortalConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 105);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPortalConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "门禁配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIrTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numIrTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIrConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIrQuery;
    }
}