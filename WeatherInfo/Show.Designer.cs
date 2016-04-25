namespace WeatherInfo
{
    public partial class Show
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Show));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.picBoxNow = new System.Windows.Forms.PictureBox();
            this.picBoxDate1 = new System.Windows.Forms.PictureBox();
            this.picBoxDate2 = new System.Windows.Forms.PictureBox();
            this.picBoxDate3 = new System.Windows.Forms.PictureBox();
            this.picBoxDate4 = new System.Windows.Forms.PictureBox();
            this.picBoxDate5 = new System.Windows.Forms.PictureBox();
            this.lblNowWendu = new System.Windows.Forms.Label();
            this.lblNowWind = new System.Windows.Forms.Label();
            this.lblNowShidu = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblAQI = new System.Windows.Forms.Label();
            this.lblPM25 = new System.Windows.Forms.Label();
            this.lblPM10 = new System.Windows.Forms.Label();
            this.lblDate1 = new System.Windows.Forms.Label();
            this.lblTemp1 = new System.Windows.Forms.Label();
            this.lblDate2 = new System.Windows.Forms.Label();
            this.lblTemp2 = new System.Windows.Forms.Label();
            this.lblTemp3 = new System.Windows.Forms.Label();
            this.lblDate3 = new System.Windows.Forms.Label();
            this.lblTemp4 = new System.Windows.Forms.Label();
            this.lblDate4 = new System.Windows.Forms.Label();
            this.lblTemp5 = new System.Windows.Forms.Label();
            this.lblDate5 = new System.Windows.Forms.Label();
            this.Uptimer = new System.Windows.Forms.Timer(this.components);
            this.lblQuality = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.listBoxCity = new System.Windows.Forms.ListBox();
            this.pictureBoxLoad = new System.Windows.Forms.PictureBox();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.lblCurtain = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxNow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDate3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDate4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDate5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.Font = new System.Drawing.Font("黑体", 9F);
            this.lblUpdateTime.Location = new System.Drawing.Point(6, 181);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(100, 13);
            this.lblUpdateTime.TabIndex = 0;
            this.lblUpdateTime.Text = "16:00更新";
            this.lblUpdateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUpdateTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // picBoxNow
            // 
            this.picBoxNow.Image = global::WeatherInfo.Properties.Resources.Sun;
            this.picBoxNow.Location = new System.Drawing.Point(6, 7);
            this.picBoxNow.Name = "picBoxNow";
            this.picBoxNow.Size = new System.Drawing.Size(100, 100);
            this.picBoxNow.TabIndex = 1;
            this.picBoxNow.TabStop = false;
            this.picBoxNow.MouseLeave += new System.EventHandler(this.picBoxNow_MouseLeave);
            this.picBoxNow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // picBoxDate1
            // 
            this.picBoxDate1.Image = global::WeatherInfo.Properties.Resources.SunToCloudy;
            this.picBoxDate1.Location = new System.Drawing.Point(210, 16);
            this.picBoxDate1.Name = "picBoxDate1";
            this.picBoxDate1.Size = new System.Drawing.Size(50, 50);
            this.picBoxDate1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxDate1.TabIndex = 2;
            this.picBoxDate1.TabStop = false;
            this.picBoxDate1.MouseLeave += new System.EventHandler(this.picBoxDate1_MouseLeave);
            this.picBoxDate1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxDate1_MouseMove);
            // 
            // picBoxDate2
            // 
            this.picBoxDate2.Image = global::WeatherInfo.Properties.Resources.SunToCloudy;
            this.picBoxDate2.Location = new System.Drawing.Point(290, 16);
            this.picBoxDate2.Name = "picBoxDate2";
            this.picBoxDate2.Size = new System.Drawing.Size(50, 50);
            this.picBoxDate2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxDate2.TabIndex = 3;
            this.picBoxDate2.TabStop = false;
            this.picBoxDate2.MouseLeave += new System.EventHandler(this.picBoxDate2_MouseLeave);
            this.picBoxDate2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxDate2_MouseMove);
            // 
            // picBoxDate3
            // 
            this.picBoxDate3.Image = global::WeatherInfo.Properties.Resources.SunToCloudy;
            this.picBoxDate3.Location = new System.Drawing.Point(130, 108);
            this.picBoxDate3.Name = "picBoxDate3";
            this.picBoxDate3.Size = new System.Drawing.Size(50, 50);
            this.picBoxDate3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxDate3.TabIndex = 4;
            this.picBoxDate3.TabStop = false;
            this.picBoxDate3.MouseLeave += new System.EventHandler(this.picBoxDate3_MouseLeave);
            this.picBoxDate3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxDate3_MouseMove);
            // 
            // picBoxDate4
            // 
            this.picBoxDate4.Image = global::WeatherInfo.Properties.Resources.SunToCloudy;
            this.picBoxDate4.Location = new System.Drawing.Point(210, 108);
            this.picBoxDate4.Name = "picBoxDate4";
            this.picBoxDate4.Size = new System.Drawing.Size(50, 50);
            this.picBoxDate4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxDate4.TabIndex = 5;
            this.picBoxDate4.TabStop = false;
            this.picBoxDate4.MouseLeave += new System.EventHandler(this.picBoxDate4_MouseLeave);
            this.picBoxDate4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxDate4_MouseMove);
            // 
            // picBoxDate5
            // 
            this.picBoxDate5.Image = global::WeatherInfo.Properties.Resources.SunToCloudy;
            this.picBoxDate5.Location = new System.Drawing.Point(290, 108);
            this.picBoxDate5.Name = "picBoxDate5";
            this.picBoxDate5.Size = new System.Drawing.Size(50, 50);
            this.picBoxDate5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxDate5.TabIndex = 6;
            this.picBoxDate5.TabStop = false;
            this.picBoxDate5.MouseLeave += new System.EventHandler(this.picBoxDate5_MouseLeave);
            this.picBoxDate5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxDate5_MouseMove);
            // 
            // lblNowWendu
            // 
            this.lblNowWendu.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNowWendu.Location = new System.Drawing.Point(6, 110);
            this.lblNowWendu.Name = "lblNowWendu";
            this.lblNowWendu.Size = new System.Drawing.Size(100, 29);
            this.lblNowWendu.TabIndex = 7;
            this.lblNowWendu.Text = "33℃";
            this.lblNowWendu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNowWendu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblNowWind
            // 
            this.lblNowWind.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNowWind.Location = new System.Drawing.Point(6, 139);
            this.lblNowWind.Name = "lblNowWind";
            this.lblNowWind.Size = new System.Drawing.Size(100, 19);
            this.lblNowWind.TabIndex = 8;
            this.lblNowWind.Text = "东南风10级";
            this.lblNowWind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNowWind.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblNowShidu
            // 
            this.lblNowShidu.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNowShidu.Location = new System.Drawing.Point(6, 158);
            this.lblNowShidu.Name = "lblNowShidu";
            this.lblNowShidu.Size = new System.Drawing.Size(100, 19);
            this.lblNowShidu.TabIndex = 9;
            this.lblNowShidu.Text = "湿度48%";
            this.lblNowShidu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNowShidu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("黑体", 13F);
            this.lblCity.Location = new System.Drawing.Point(117, 14);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(44, 18);
            this.lblCity.TabIndex = 10;
            this.lblCity.Text = "嘉兴";
            this.lblCity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblCity_MouseClick);
            this.lblCity.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblAQI
            // 
            this.lblAQI.AutoSize = true;
            this.lblAQI.Font = new System.Drawing.Font("黑体", 10F);
            this.lblAQI.Location = new System.Drawing.Point(117, 36);
            this.lblAQI.Name = "lblAQI";
            this.lblAQI.Size = new System.Drawing.Size(49, 14);
            this.lblAQI.TabIndex = 11;
            this.lblAQI.Text = "AQI:78";
            this.lblAQI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblPM25
            // 
            this.lblPM25.AutoSize = true;
            this.lblPM25.Font = new System.Drawing.Font("黑体", 10F);
            this.lblPM25.Location = new System.Drawing.Point(117, 69);
            this.lblPM25.Name = "lblPM25";
            this.lblPM25.Size = new System.Drawing.Size(70, 14);
            this.lblPM25.TabIndex = 12;
            this.lblPM25.Text = "PM2.5:111";
            this.lblPM25.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblPM10
            // 
            this.lblPM10.AutoSize = true;
            this.lblPM10.Font = new System.Drawing.Font("黑体", 10F);
            this.lblPM10.Location = new System.Drawing.Point(117, 86);
            this.lblPM10.Name = "lblPM10";
            this.lblPM10.Size = new System.Drawing.Size(63, 14);
            this.lblPM10.TabIndex = 13;
            this.lblPM10.Text = "PM10:111";
            this.lblPM10.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblDate1
            // 
            this.lblDate1.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDate1.Location = new System.Drawing.Point(196, 72);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Size = new System.Drawing.Size(80, 12);
            this.lblDate1.TabIndex = 14;
            this.lblDate1.Text = "3日星期四";
            this.lblDate1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDate1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblTemp1
            // 
            this.lblTemp1.Font = new System.Drawing.Font("黑体", 9F);
            this.lblTemp1.Location = new System.Drawing.Point(196, 88);
            this.lblTemp1.Name = "lblTemp1";
            this.lblTemp1.Size = new System.Drawing.Size(80, 12);
            this.lblTemp1.TabIndex = 15;
            this.lblTemp1.Text = "12℃~22℃";
            this.lblTemp1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTemp1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblDate2
            // 
            this.lblDate2.Font = new System.Drawing.Font("黑体", 9F);
            this.lblDate2.Location = new System.Drawing.Point(276, 72);
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Size = new System.Drawing.Size(80, 12);
            this.lblDate2.TabIndex = 16;
            this.lblDate2.Text = "4日星期五";
            this.lblDate2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDate2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblTemp2
            // 
            this.lblTemp2.Font = new System.Drawing.Font("黑体", 9F);
            this.lblTemp2.Location = new System.Drawing.Point(276, 88);
            this.lblTemp2.Name = "lblTemp2";
            this.lblTemp2.Size = new System.Drawing.Size(80, 12);
            this.lblTemp2.TabIndex = 17;
            this.lblTemp2.Text = "12℃~22℃";
            this.lblTemp2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTemp2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblTemp3
            // 
            this.lblTemp3.Font = new System.Drawing.Font("黑体", 9F);
            this.lblTemp3.Location = new System.Drawing.Point(116, 180);
            this.lblTemp3.Name = "lblTemp3";
            this.lblTemp3.Size = new System.Drawing.Size(80, 12);
            this.lblTemp3.TabIndex = 19;
            this.lblTemp3.Text = "12℃~22℃";
            this.lblTemp3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTemp3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblDate3
            // 
            this.lblDate3.Font = new System.Drawing.Font("黑体", 9F);
            this.lblDate3.Location = new System.Drawing.Point(116, 164);
            this.lblDate3.Name = "lblDate3";
            this.lblDate3.Size = new System.Drawing.Size(80, 12);
            this.lblDate3.TabIndex = 18;
            this.lblDate3.Text = "5日星期六";
            this.lblDate3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDate3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblTemp4
            // 
            this.lblTemp4.Font = new System.Drawing.Font("黑体", 9F);
            this.lblTemp4.Location = new System.Drawing.Point(196, 180);
            this.lblTemp4.Name = "lblTemp4";
            this.lblTemp4.Size = new System.Drawing.Size(80, 12);
            this.lblTemp4.TabIndex = 21;
            this.lblTemp4.Text = "12℃~22℃";
            this.lblTemp4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTemp4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblDate4
            // 
            this.lblDate4.Font = new System.Drawing.Font("黑体", 9F);
            this.lblDate4.Location = new System.Drawing.Point(196, 164);
            this.lblDate4.Name = "lblDate4";
            this.lblDate4.Size = new System.Drawing.Size(80, 12);
            this.lblDate4.TabIndex = 20;
            this.lblDate4.Text = "6日星期天";
            this.lblDate4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDate4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblTemp5
            // 
            this.lblTemp5.Font = new System.Drawing.Font("黑体", 9F);
            this.lblTemp5.Location = new System.Drawing.Point(276, 180);
            this.lblTemp5.Name = "lblTemp5";
            this.lblTemp5.Size = new System.Drawing.Size(80, 12);
            this.lblTemp5.TabIndex = 23;
            this.lblTemp5.Text = "12℃~22℃";
            this.lblTemp5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTemp5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // lblDate5
            // 
            this.lblDate5.Font = new System.Drawing.Font("黑体", 9F);
            this.lblDate5.Location = new System.Drawing.Point(276, 164);
            this.lblDate5.Name = "lblDate5";
            this.lblDate5.Size = new System.Drawing.Size(80, 12);
            this.lblDate5.TabIndex = 22;
            this.lblDate5.Text = "7日星期一";
            this.lblDate5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDate5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // Uptimer
            // 
            this.Uptimer.Interval = 10;
            this.Uptimer.Tick += new System.EventHandler(this.Uptimer_Tick);
            // 
            // lblQuality
            // 
            this.lblQuality.AutoSize = true;
            this.lblQuality.BackColor = System.Drawing.Color.Lime;
            this.lblQuality.Font = new System.Drawing.Font("黑体", 10F);
            this.lblQuality.Location = new System.Drawing.Point(120, 52);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(21, 14);
            this.lblQuality.TabIndex = 24;
            this.lblQuality.Text = "良";
            this.lblQuality.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(112, 14);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(92, 21);
            this.txtCity.TabIndex = 25;
            this.txtCity.Visible = false;
            this.txtCity.TextChanged += new System.EventHandler(this.txtCity_TextChanged);
            this.txtCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCity_KeyDown);
            this.txtCity.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtCity_MouseMove);
            // 
            // listBoxCity
            // 
            this.listBoxCity.FormattingEnabled = true;
            this.listBoxCity.ItemHeight = 12;
            this.listBoxCity.Location = new System.Drawing.Point(112, 36);
            this.listBoxCity.Name = "listBoxCity";
            this.listBoxCity.Size = new System.Drawing.Size(158, 76);
            this.listBoxCity.TabIndex = 26;
            this.listBoxCity.Visible = false;
            this.listBoxCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxCity_KeyDown);
            this.listBoxCity.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxCity_MouseDoubleClick);
            this.listBoxCity.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxCity_MouseMove);
            // 
            // pictureBoxLoad
            // 
            this.pictureBoxLoad.Image = global::WeatherInfo.Properties.Resources._15;
            this.pictureBoxLoad.Location = new System.Drawing.Point(145, 65);
            this.pictureBoxLoad.Name = "pictureBoxLoad";
            this.pictureBoxLoad.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLoad.TabIndex = 27;
            this.pictureBoxLoad.TabStop = false;
            this.pictureBoxLoad.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // timerLoad
            // 
            this.timerLoad.Interval = 30;
            this.timerLoad.Tick += new System.EventHandler(this.timerLoad_Tick);
            // 
            // lblCurtain
            // 
            this.lblCurtain.BackColor = System.Drawing.Color.Snow;
            this.lblCurtain.Location = new System.Drawing.Point(2, 2);
            this.lblCurtain.Name = "lblCurtain";
            this.lblCurtain.Size = new System.Drawing.Size(49, 33);
            this.lblCurtain.TabIndex = 28;
            // 
            // Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(355, 200);
            this.Controls.Add(this.pictureBoxLoad);
            this.Controls.Add(this.lblCurtain);
            this.Controls.Add(this.listBoxCity);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblQuality);
            this.Controls.Add(this.lblTemp5);
            this.Controls.Add(this.lblDate5);
            this.Controls.Add(this.lblTemp4);
            this.Controls.Add(this.lblDate4);
            this.Controls.Add(this.lblTemp3);
            this.Controls.Add(this.lblDate3);
            this.Controls.Add(this.lblTemp2);
            this.Controls.Add(this.lblDate2);
            this.Controls.Add(this.lblTemp1);
            this.Controls.Add(this.lblDate1);
            this.Controls.Add(this.lblPM10);
            this.Controls.Add(this.lblPM25);
            this.Controls.Add(this.lblAQI);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblNowShidu);
            this.Controls.Add(this.lblNowWind);
            this.Controls.Add(this.lblNowWendu);
            this.Controls.Add(this.picBoxDate5);
            this.Controls.Add(this.picBoxDate4);
            this.Controls.Add(this.picBoxDate3);
            this.Controls.Add(this.picBoxDate2);
            this.Controls.Add(this.picBoxDate1);
            this.Controls.Add(this.picBoxNow);
            this.Controls.Add(this.lblUpdateTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Show";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Show_Load);
            this.MouseLeave += new System.EventHandler(this.Show_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Show_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxNow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDate3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDate4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDate5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.PictureBox picBoxNow;
        private System.Windows.Forms.PictureBox picBoxDate1;
        private System.Windows.Forms.PictureBox picBoxDate2;
        private System.Windows.Forms.PictureBox picBoxDate3;
        private System.Windows.Forms.PictureBox picBoxDate4;
        private System.Windows.Forms.PictureBox picBoxDate5;
        private System.Windows.Forms.Label lblNowWendu;
        private System.Windows.Forms.Label lblNowWind;
        private System.Windows.Forms.Label lblNowShidu;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblAQI;
        private System.Windows.Forms.Label lblPM25;
        private System.Windows.Forms.Label lblPM10;
        private System.Windows.Forms.Label lblDate1;
        private System.Windows.Forms.Label lblTemp1;
        private System.Windows.Forms.Label lblDate2;
        private System.Windows.Forms.Label lblTemp2;
        private System.Windows.Forms.Label lblTemp3;
        private System.Windows.Forms.Label lblDate3;
        private System.Windows.Forms.Label lblTemp4;
        private System.Windows.Forms.Label lblDate4;
        private System.Windows.Forms.Label lblTemp5;
        private System.Windows.Forms.Label lblDate5;
        private System.Windows.Forms.Timer Uptimer;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.ListBox listBoxCity;
        private System.Windows.Forms.PictureBox pictureBoxLoad;
        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.Label lblCurtain;
    }
}

