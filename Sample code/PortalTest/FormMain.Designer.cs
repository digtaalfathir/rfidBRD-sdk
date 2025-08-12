namespace PortalTest
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Conn = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_ScanConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDisconn = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.MI_PortalConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAvgSpeed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblScanTime = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接ToolStripMenuItem,
            this.配置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 连接ToolStripMenuItem
            // 
            this.连接ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_Conn});
            this.连接ToolStripMenuItem.Name = "连接ToolStripMenuItem";
            this.连接ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.连接ToolStripMenuItem.Text = "连接";
            // 
            // MI_Conn
            // 
            this.MI_Conn.Name = "MI_Conn";
            this.MI_Conn.Size = new System.Drawing.Size(124, 22);
            this.MI_Conn.Text = "门禁连接";
            this.MI_Conn.Click += new System.EventHandler(this.MI_Conn_Click);
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_ScanConfig,
            this.MI_PortalConfig});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.配置ToolStripMenuItem.Text = "配置";
            // 
            // MI_ScanConfig
            // 
            this.MI_ScanConfig.Enabled = false;
            this.MI_ScanConfig.Name = "MI_ScanConfig";
            this.MI_ScanConfig.Size = new System.Drawing.Size(152, 22);
            this.MI_ScanConfig.Text = "扫描配置";
            this.MI_ScanConfig.Click += new System.EventHandler(this.MI_ScanConfig_Click);
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(12, 28);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(75, 23);
            this.btnConn.TabIndex = 2;
            this.btnConn.Text = "连接";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(784, 479);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnDisconn
            // 
            this.btnDisconn.Enabled = false;
            this.btnDisconn.Location = new System.Drawing.Point(93, 28);
            this.btnDisconn.Name = "btnDisconn";
            this.btnDisconn.Size = new System.Drawing.Size(75, 23);
            this.btnDisconn.TabIndex = 2;
            this.btnDisconn.Text = "断开";
            this.btnDisconn.UseVisualStyleBackColor = true;
            this.btnDisconn.Click += new System.EventHandler(this.btnDisconn_Click);
            // 
            // btnScan
            // 
            this.btnScan.Enabled = false;
            this.btnScan.Location = new System.Drawing.Point(174, 28);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "扫描";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(255, 28);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(336, 28);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 2;
            this.btnClean.Text = "清空";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // MI_PortalConfig
            // 
            this.MI_PortalConfig.Enabled = false;
            this.MI_PortalConfig.Name = "MI_PortalConfig";
            this.MI_PortalConfig.Size = new System.Drawing.Size(152, 22);
            this.MI_PortalConfig.Text = "门禁配置";
            this.MI_PortalConfig.Click += new System.EventHandler(this.MI_PortalConfig_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 543);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "运行消息：";
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(83, 543);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 12);
            this.lblMsg.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 543);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "标签总数：";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(326, 543);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(23, 12);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "000";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 543);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tags";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 543);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "平均速度：";
            // 
            // lblAvgSpeed
            // 
            this.lblAvgSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvgSpeed.AutoSize = true;
            this.lblAvgSpeed.Location = new System.Drawing.Point(461, 543);
            this.lblAvgSpeed.Name = "lblAvgSpeed";
            this.lblAvgSpeed.Size = new System.Drawing.Size(23, 12);
            this.lblAvgSpeed.TabIndex = 6;
            this.lblAvgSpeed.Text = "000";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(490, 543);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "T/S";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(519, 543);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "即时速度：";
            // 
            // lblSpeed
            // 
            this.lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(590, 543);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(23, 12);
            this.lblSpeed.TabIndex = 6;
            this.lblSpeed.Text = "000";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(619, 543);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "T/S";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(648, 543);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "扫描时间：";
            // 
            // lblScanTime
            // 
            this.lblScanTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScanTime.AutoSize = true;
            this.lblScanTime.Location = new System.Drawing.Point(719, 543);
            this.lblScanTime.Name = "lblScanTime";
            this.lblScanTime.Size = new System.Drawing.Size(53, 12);
            this.lblScanTime.TabIndex = 6;
            this.lblScanTime.Text = "00:00:00";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblScanTime);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblAvgSpeed);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnDisconn);
            this.Controls.Add(this.btnConn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "门禁测试软件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MI_ScanConfig;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.ToolStripMenuItem MI_Conn;
        private System.Windows.Forms.Button btnDisconn;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClean;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem MI_PortalConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAvgSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblScanTime;
    }
}

