namespace DotaSkillScreenshot
{
    partial class DotaSkillScreenshot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DotaSkillScreenshot));
            this.label1 = new System.Windows.Forms.Label();
            this.DotaStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Resolution = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.transparency = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CheckDotaStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Zoom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dota2状态 :";
            // 
            // DotaStatus
            // 
            this.DotaStatus.AccessibleDescription = "DotaStatus";
            this.DotaStatus.AutoSize = true;
            this.DotaStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DotaStatus.ForeColor = System.Drawing.Color.Red;
            this.DotaStatus.Location = new System.Drawing.Point(121, 22);
            this.DotaStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DotaStatus.Name = "DotaStatus";
            this.DotaStatus.Size = new System.Drawing.Size(35, 19);
            this.DotaStatus.TabIndex = 0;
            this.DotaStatus.Text = "关闭";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(202, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "分辨率 :";
            // 
            // Resolution
            // 
            this.Resolution.AccessibleDescription = "Resolution";
            this.Resolution.AutoSize = true;
            this.Resolution.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Resolution.Location = new System.Drawing.Point(293, 22);
            this.Resolution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Resolution.Name = "Resolution";
            this.Resolution.Size = new System.Drawing.Size(31, 19);
            this.Resolution.TabIndex = 0;
            this.Resolution.Text = "0*0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(20, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "透明度 :";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(83, 69);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(460, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 80;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // transparency
            // 
            this.transparency.AutoSize = true;
            this.transparency.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.transparency.Location = new System.Drawing.Point(551, 69);
            this.transparency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.transparency.Name = "transparency";
            this.transparency.Size = new System.Drawing.Size(37, 19);
            this.transparency.TabIndex = 0;
            this.transparency.Text = "80%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(20, 135);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(303, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "F5 : 技能截图保存到粘贴板和当前文件夹(透明背景)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(20, 175);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(263, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "~  : 波浪键技能截图保存到粘贴板(游戏背景)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(20, 217);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(465, 114);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tips :\r\n1.确保当前目录不包含中文.\r\n2.使用全屏或无边框窗口全屏.\r\n3.在游戏界面按下快捷键后3秒内不要操作鼠标,截图完成后切换到直播界面粘贴.\r\n" +
    "4.目前仅适配了1920*1080和2560*1440游戏分辨率,如果有特殊分辨率需求,请\r\n进群联系作者.\r\n";
            // 
            // CheckDotaStatusTimer
            // 
            this.CheckDotaStatusTimer.Tick += new System.EventHandler(this.CheckDotaStatusTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(427, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "系统缩放 :";
            // 
            // Zoom
            // 
            this.Zoom.AccessibleDescription = "Zoom";
            this.Zoom.AutoSize = true;
            this.Zoom.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Zoom.Location = new System.Drawing.Point(518, 22);
            this.Zoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Zoom.Name = "Zoom";
            this.Zoom.Size = new System.Drawing.Size(45, 19);
            this.Zoom.TabIndex = 0;
            this.Zoom.Text = "100%";
            // 
            // DotaSkillScreenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 375);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.DotaStatus);
            this.Controls.Add(this.Zoom);
            this.Controls.Add(this.Resolution);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.transparency);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "DotaSkillScreenshot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OMG技能截图工具(群518615024)";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DotaStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Resolution;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label transparency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer CheckDotaStatusTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Zoom;
    }
}

