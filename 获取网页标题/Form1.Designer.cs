namespace 获取网页标题
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开网址ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnAddressGet = new System.Windows.Forms.Button();
            this.txtB4 = new System.Windows.Forms.TextBox();
            this.txtE4 = new System.Windows.Forms.TextBox();
            this.txtE3 = new System.Windows.Forms.TextBox();
            this.txtB3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtE2 = new System.Windows.Forms.TextBox();
            this.txtB2 = new System.Windows.Forms.TextBox();
            this.txtE1 = new System.Windows.Forms.TextBox();
            this.txtB1 = new System.Windows.Forms.TextBox();
            this.chkIsHTTPS = new System.Windows.Forms.CheckBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.saveFileDialogCSV = new System.Windows.Forms.SaveFileDialog();
            this.btnOpenWeb = new System.Windows.Forms.Button();
            this.btnSaveCSV = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMe = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelBlank = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRemainTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTotle = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.lvwResult = new 获取网页标题.DoubleBufferListView();
            this.columnHeaderIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开网址ToolStripMenuItem,
            this.保存结果ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // 打开网址ToolStripMenuItem
            // 
            this.打开网址ToolStripMenuItem.Name = "打开网址ToolStripMenuItem";
            this.打开网址ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打开网址ToolStripMenuItem.Text = "打开网址";
            this.打开网址ToolStripMenuItem.Click += new System.EventHandler(this.打开网址ToolStripMenuItem_Click);
            // 
            // 保存结果ToolStripMenuItem
            // 
            this.保存结果ToolStripMenuItem.Name = "保存结果ToolStripMenuItem";
            this.保存结果ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存结果ToolStripMenuItem.Text = "保存结果";
            this.保存结果ToolStripMenuItem.Click += new System.EventHandler(this.保存结果ToolStripMenuItem_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTest.Location = new System.Drawing.Point(171, 327);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnAddressGet
            // 
            this.btnAddressGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddressGet.Location = new System.Drawing.Point(159, 132);
            this.btnAddressGet.Name = "btnAddressGet";
            this.btnAddressGet.Size = new System.Drawing.Size(75, 23);
            this.btnAddressGet.TabIndex = 1;
            this.btnAddressGet.Text = "通过网址";
            this.btnAddressGet.UseVisualStyleBackColor = true;
            this.btnAddressGet.Click += new System.EventHandler(this.btnAddressGet_Click);
            // 
            // txtB4
            // 
            this.txtB4.Location = new System.Drawing.Point(196, 25);
            this.txtB4.Name = "txtB4";
            this.txtB4.Size = new System.Drawing.Size(38, 21);
            this.txtB4.TabIndex = 3;
            this.txtB4.Text = "0";
            this.txtB4.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            this.txtB4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIP_KeyPress);
            // 
            // txtE4
            // 
            this.txtE4.Location = new System.Drawing.Point(196, 69);
            this.txtE4.Name = "txtE4";
            this.txtE4.Size = new System.Drawing.Size(38, 21);
            this.txtE4.TabIndex = 7;
            this.txtE4.Text = "255";
            this.txtE4.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            this.txtE4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIP_KeyPress);
            // 
            // txtE3
            // 
            this.txtE3.Location = new System.Drawing.Point(152, 69);
            this.txtE3.Name = "txtE3";
            this.txtE3.Size = new System.Drawing.Size(38, 21);
            this.txtE3.TabIndex = 6;
            this.txtE3.Text = "34";
            this.txtE3.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            this.txtE3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIP_KeyPress);
            // 
            // txtB3
            // 
            this.txtB3.Location = new System.Drawing.Point(152, 25);
            this.txtB3.Name = "txtB3";
            this.txtB3.Size = new System.Drawing.Size(38, 21);
            this.txtB3.TabIndex = 2;
            this.txtB3.Text = "34";
            this.txtB3.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            this.txtB3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIP_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "终止IP：";
            // 
            // txtE2
            // 
            this.txtE2.BackColor = System.Drawing.SystemColors.Window;
            this.txtE2.Location = new System.Drawing.Point(108, 69);
            this.txtE2.Name = "txtE2";
            this.txtE2.ReadOnly = true;
            this.txtE2.Size = new System.Drawing.Size(38, 21);
            this.txtE2.TabIndex = 5;
            this.txtE2.Text = "2";
            this.txtE2.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            this.txtE2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIP_KeyPress);
            // 
            // txtB2
            // 
            this.txtB2.Location = new System.Drawing.Point(108, 25);
            this.txtB2.Name = "txtB2";
            this.txtB2.Size = new System.Drawing.Size(38, 21);
            this.txtB2.TabIndex = 1;
            this.txtB2.Text = "2";
            this.txtB2.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            this.txtB2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIP_KeyPress);
            // 
            // txtE1
            // 
            this.txtE1.BackColor = System.Drawing.SystemColors.Window;
            this.txtE1.Location = new System.Drawing.Point(64, 69);
            this.txtE1.Name = "txtE1";
            this.txtE1.ReadOnly = true;
            this.txtE1.Size = new System.Drawing.Size(38, 21);
            this.txtE1.TabIndex = 4;
            this.txtE1.Text = "100";
            this.txtE1.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            this.txtE1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIP_KeyPress);
            // 
            // txtB1
            // 
            this.txtB1.Location = new System.Drawing.Point(64, 25);
            this.txtB1.Name = "txtB1";
            this.txtB1.Size = new System.Drawing.Size(38, 21);
            this.txtB1.TabIndex = 0;
            this.txtB1.Text = "100";
            this.txtB1.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            this.txtB1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIP_KeyPress);
            // 
            // chkIsHTTPS
            // 
            this.chkIsHTTPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsHTTPS.AutoSize = true;
            this.chkIsHTTPS.Location = new System.Drawing.Point(8, 107);
            this.chkIsHTTPS.Name = "chkIsHTTPS";
            this.chkIsHTTPS.Size = new System.Drawing.Size(78, 16);
            this.chkIsHTTPS.TabIndex = 8;
            this.chkIsHTTPS.Text = "使用HTTPS";
            this.chkIsHTTPS.UseVisualStyleBackColor = true;
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.Location = new System.Drawing.Point(159, 103);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 9;
            this.btnGet.Text = "通过IP";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "起始IP：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtE3);
            this.groupBox1.Controls.Add(this.btnGet);
            this.groupBox1.Controls.Add(this.txtE4);
            this.groupBox1.Controls.Add(this.chkIsHTTPS);
            this.groupBox1.Controls.Add(this.txtB3);
            this.groupBox1.Controls.Add(this.txtB4);
            this.groupBox1.Controls.Add(this.txtB1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtE2);
            this.groupBox1.Controls.Add(this.txtE1);
            this.groupBox1.Controls.Add(this.txtB2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP查询";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.txtURL);
            this.groupBox2.Controls.Add(this.btnAddressGet);
            this.groupBox2.Location = new System.Drawing.Point(12, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 161);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "网址查询";
            // 
            // txtURL
            // 
            this.txtURL.AcceptsReturn = true;
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(6, 20);
            this.txtURL.MaxLength = 0;
            this.txtURL.Multiline = true;
            this.txtURL.Name = "txtURL";
            this.txtURL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtURL.Size = new System.Drawing.Size(228, 106);
            this.txtURL.TabIndex = 0;
            // 
            // saveFileDialogCSV
            // 
            this.saveFileDialogCSV.DefaultExt = "csv";
            this.saveFileDialogCSV.Filter = "CSV 文件|*.csv|所有文件|*.*";
            this.saveFileDialogCSV.Title = "保存当前结果至CSV文件";
            // 
            // btnOpenWeb
            // 
            this.btnOpenWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenWeb.Location = new System.Drawing.Point(12, 327);
            this.btnOpenWeb.Name = "btnOpenWeb";
            this.btnOpenWeb.Size = new System.Drawing.Size(123, 23);
            this.btnOpenWeb.TabIndex = 2;
            this.btnOpenWeb.Text = "打开选中的网址";
            this.btnOpenWeb.UseVisualStyleBackColor = true;
            this.btnOpenWeb.Click += new System.EventHandler(this.打开网址ToolStripMenuItem_Click);
            // 
            // btnSaveCSV
            // 
            this.btnSaveCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveCSV.Location = new System.Drawing.Point(12, 356);
            this.btnSaveCSV.Name = "btnSaveCSV";
            this.btnSaveCSV.Size = new System.Drawing.Size(123, 23);
            this.btnSaveCSV.TabIndex = 3;
            this.btnSaveCSV.Text = "保存结果至CSV文件";
            this.btnSaveCSV.UseVisualStyleBackColor = true;
            this.btnSaveCSV.Click += new System.EventHandler(this.保存结果ToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMe,
            this.toolStripStatusLabelBlank,
            this.toolStripStatusLabelRemainTime,
            this.toolStripStatusLabelProgress,
            this.toolStripStatusLabelTotle,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 382);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(824, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "状态栏";
            // 
            // toolStripStatusLabelMe
            // 
            this.toolStripStatusLabelMe.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic);
            this.toolStripStatusLabelMe.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabelMe.Name = "toolStripStatusLabelMe";
            this.toolStripStatusLabelMe.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabelMe.Text = "By JiangChao";
            this.toolStripStatusLabelMe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripStatusLabelMe_MouseDown);
            // 
            // toolStripStatusLabelBlank
            // 
            this.toolStripStatusLabelBlank.Name = "toolStripStatusLabelBlank";
            this.toolStripStatusLabelBlank.Size = new System.Drawing.Size(484, 17);
            this.toolStripStatusLabelBlank.Spring = true;
            // 
            // toolStripStatusLabelRemainTime
            // 
            this.toolStripStatusLabelRemainTime.Name = "toolStripStatusLabelRemainTime";
            this.toolStripStatusLabelRemainTime.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelProgress
            // 
            this.toolStripStatusLabelProgress.Name = "toolStripStatusLabelProgress";
            this.toolStripStatusLabelProgress.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabelProgress.Text = "完成进度：0/0";
            // 
            // toolStripStatusLabelTotle
            // 
            this.toolStripStatusLabelTotle.Name = "toolStripStatusLabelTotle";
            this.toolStripStatusLabelTotle.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Maximum = 1000;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(150, 16);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(171, 356);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lvwResult
            // 
            this.lvwResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIP,
            this.columnHeaderTitle,
            this.columnHeaderState});
            this.lvwResult.ContextMenuStrip = this.contextMenuStrip;
            this.lvwResult.FullRowSelect = true;
            this.lvwResult.HideSelection = false;
            this.lvwResult.Location = new System.Drawing.Point(258, 12);
            this.lvwResult.Name = "lvwResult";
            this.lvwResult.Size = new System.Drawing.Size(554, 367);
            this.lvwResult.TabIndex = 6;
            this.lvwResult.UseCompatibleStateImageBehavior = false;
            this.lvwResult.View = System.Windows.Forms.View.Details;
            this.lvwResult.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwResult_ColumnClick);
            // 
            // columnHeaderIP
            // 
            this.columnHeaderIP.Text = "URL";
            this.columnHeaderIP.Width = 169;
            // 
            // columnHeaderTitle
            // 
            this.columnHeaderTitle.Text = "Title";
            this.columnHeaderTitle.Width = 216;
            // 
            // columnHeaderState
            // 
            this.columnHeaderState.Text = "State";
            this.columnHeaderState.Width = 300;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 404);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnSaveCSV);
            this.Controls.Add(this.btnOpenWeb);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lvwResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(423, 428);
            this.Name = "Form1";
            this.Text = "批量获取网页标题";
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DoubleBufferListView lvwResult; //使用开启双缓冲特性的ListView
        private System.Windows.Forms.ColumnHeader columnHeaderIP;
        private System.Windows.Forms.ColumnHeader columnHeaderTitle;
        private System.Windows.Forms.ColumnHeader columnHeaderState;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnAddressGet;
        private System.Windows.Forms.TextBox txtB4;
        private System.Windows.Forms.TextBox txtE4;
        private System.Windows.Forms.TextBox txtE3;
        private System.Windows.Forms.TextBox txtB3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtE2;
        private System.Windows.Forms.TextBox txtB2;
        private System.Windows.Forms.TextBox txtE1;
        private System.Windows.Forms.TextBox txtB1;
        private System.Windows.Forms.CheckBox chkIsHTTPS;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 打开网址ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存结果ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCSV;
        private System.Windows.Forms.Button btnOpenWeb;
        private System.Windows.Forms.Button btnSaveCSV;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBlank;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelProgress;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMe;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTotle;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRemainTime;
        private System.Windows.Forms.TextBox txtURL;
    }
}

