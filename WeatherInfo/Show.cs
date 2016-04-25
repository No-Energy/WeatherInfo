using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace WeatherInfo
{
    public partial class Show : Form
    {
        /// <summary>
        /// 是否已经获取到天气信息
        /// </summary>
        private bool isGetInfo = false;
        /// <summary>
        /// 窗体是否已经升起，显示
        /// </summary>
        private bool isFormUp = false;

        /// <summary>
        /// 依次为：
        /// 城市代码字典（城市名称，城市编号）
        /// 城市列表
        /// 当前查询城市
        /// </summary>
        private Dictionary<string, string> cityDict;
        private List<string> cityList;
        private string queryCity = string.Empty;

        /// <summary>
        /// 幕布的长宽
        /// </summary>
        private int curtainWidth = 353;
        private int curtainHeight = 198;

        /// <summary>
        /// 数据源，依次为：
        /// 当前天气信息
        /// 当前空气环境信息
        /// 预测天气信息
        /// </summary>
        private Dictionary<string, string> nowTemperature = new Dictionary<string, string>();
        private Dictionary<string, string> nowEnvironment = new Dictionary<string, string>();
        private List<Dictionary<string, string>> foreTemperature = new List<Dictionary<string, string>>();
        public Show()
        {
            cityDict = GetCityDict();
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(SystemInformation.WorkingArea.Width - this.Size.Width,
                SystemInformation.WorkingArea.Height);
            lblCurtain.Width = curtainWidth;
            lblCurtain.Height = curtainHeight;
            //this.Location = new Point(SystemInformation.WorkingArea.Width - this.Size.Width,
            //    SystemInformation.WorkingArea.Height - this.Size.Height);  
        }

        private void Show_Load(object sender, EventArgs e)
        {
            try
            {
                cityList = cityDict.Keys.ToList();
                Thread getInfo = new Thread(new ThreadStart(GetWeatherInfo));
                getInfo.Start();
                HideAllControls();
                Uptimer.Start();
                timerLoad.Start();
            }
            catch
            {
                //this.Close();
                this.Dispose();
            }
        }
        
        /// <summary>
        /// 获取天气信息
        /// </summary>
        public void GetWeatherInfo()
        {
            try
            {
                string cityCode;
                if (queryCity .Equals( string .Empty) )
                {
                    cityCode = GetCityCode();
                }
                else
                {
                    cityCode = cityDict[queryCity];
                }

                XmlDocument xd = new XmlDocument();
                xd.LoadXml(GetXmlStr(cityCode));

                XmlNodeList rootNode = xd.SelectSingleNode("resp").ChildNodes;
                //使用节点名称创建根节点索引
                Dictionary<string, int> rootNodeIndex = new Dictionary<string, int>();
                for (int i = 0; i < rootNode.Count; i++)
                {
                    rootNodeIndex.Add(rootNode.Item(i).Name, i);
                }
                if (rootNodeIndex.Count > 1)
                {
                    nowTemperature.Clear();
                    nowTemperature.Add("city", rootNode.Item(rootNodeIndex["city"]).InnerXml);
                    nowTemperature.Add("updatetime", rootNode.Item(rootNodeIndex["updatetime"]).InnerXml);
                    nowTemperature.Add("wendu", rootNode.Item(rootNodeIndex["wendu"]).InnerXml);
                    nowTemperature.Add("fengli", rootNode.Item(rootNodeIndex["fengli"]).InnerXml);
                    nowTemperature.Add("shidu", rootNode.Item(rootNodeIndex["shidu"]).InnerXml);
                    nowTemperature.Add("fengxiang", rootNode.Item(rootNodeIndex["fengxiang"]).InnerXml);

                    try//可能存在没有环境指数的城市
                    {
                        XmlNodeList envNode = rootNode.Item(rootNodeIndex["environment"]).ChildNodes;
                        //使用节点名称创建环境节点索引
                        Dictionary<string, int> envNodeIndex = new Dictionary<string, int>();
                        for (int i = 0; i < envNode.Count; i++)
                        {
                            envNodeIndex.Add(envNode.Item(i).Name, i);
                        }
                        nowEnvironment.Clear();
                        nowEnvironment.Add("aqi", envNode.Item(envNodeIndex["aqi"]).InnerXml);
                        nowEnvironment.Add("pm25", envNode.Item(envNodeIndex["pm25"]).InnerXml);
                        nowEnvironment.Add("pm10", envNode.Item(envNodeIndex["pm10"]).InnerXml);
                        nowEnvironment.Add("quality", envNode.Item(envNodeIndex["quality"]).InnerXml);
                        nowEnvironment.Add("time", envNode.Item(envNodeIndex["time"]).InnerXml);
                    }
                    catch
                    {
                        nowEnvironment.Clear();
                        nowEnvironment.Add("aqi", string.Empty);
                        nowEnvironment.Add("pm25", string.Empty);
                        nowEnvironment.Add("pm10", string.Empty);
                        nowEnvironment.Add("quality", "未获取到\r当前城市\r空气质量");
                        nowEnvironment.Add("time", string.Empty);
                    }

                    foreTemperature.Clear();
                    XmlNodeList foreNode = rootNode.Item(rootNodeIndex["forecast"]).ChildNodes;
                    for (int i = 0; i < foreNode.Count; i++)
                    {
                        XmlNodeList tempNode = foreNode.Item(i).ChildNodes;
                        Dictionary<string, string> temp = new Dictionary<string, string>();

                        temp.Add("date", tempNode.Item(0).InnerXml);
                        temp.Add("high", tempNode.Item(1).InnerXml);
                        temp.Add("low", tempNode.Item(2).InnerXml);
                        temp.Add("DayType", tempNode.Item(3).ChildNodes.Item(0).InnerXml);
                        temp.Add("NightType", tempNode.Item(4).ChildNodes.Item(0).InnerXml);
                        
                        foreTemperature.Add(temp);
                    }
                }
                else
                {
                    SetErrorData("没查到");
                }
            }
            catch
            {
                SetErrorData("出错了");
            }
            isGetInfo = true;
        }

        /// <summary>
        /// 设置错误信息
        /// </summary>
        /// <param name="errorMsg">错误信息</param>
        private void SetErrorData(string errorMsg)
        {
            nowTemperature.Clear();
            nowTemperature.Add("city", errorMsg);
            nowTemperature.Add("updatetime", "NULL");
            nowTemperature.Add("wendu", "NULL");
            nowTemperature.Add("fengli", "NULL");
            nowTemperature.Add("shidu", "NULL");
            nowTemperature.Add("fengxiang", "NULL");

            nowEnvironment.Clear();
            nowEnvironment.Add("aqi", "NULL");
            nowEnvironment.Add("pm25", "NULL");
            nowEnvironment.Add("pm10", "NULL");
            nowEnvironment.Add("quality", "NULL");
            nowEnvironment.Add("time", "NULL");

            foreTemperature.Clear();
            for (int i = 0; i < 5; i++)
            {
                Dictionary<string, string> temp = new Dictionary<string, string>();

                temp.Add("date", "NULL");
                temp.Add("high", " NULL");
                temp.Add("low", " NULL");
                temp.Add("DayType", "NULL");
                temp.Add("NightType", "NULL");

                foreTemperature.Add(temp);
            }
        }
        /// <summary>
        /// 获得当前城市天气xml信息
        /// </summary>
        /// <param name="CityCode"></param>
        /// <returns></returns>
        private string GetXmlStr(string CityCode)
        {
            try
            {
                WebClient WebClient = new WebClient();
                Byte[] pageData =
                    Decompress(WebClient.DownloadData(string.Format("http://wthrcdn.etouch.cn/WeatherApi?citykey={0}", CityCode)));
                WebClient.Dispose();

                string xmlStr = Encoding.UTF8.GetString(pageData);
                return xmlStr;
            }
            catch (Exception)
            {         
                throw;
            }       
        }

        /// <summary>
        /// ZIP解压
        /// </summary>
        /// <param name="zippedData"></param>
        /// <returns></returns>
        private byte[] Decompress(byte[] zippedData)
        {
            MemoryStream ms = new MemoryStream(zippedData);
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Decompress);
            MemoryStream outBuffer = new MemoryStream();
            byte[] block = new byte[1024];
            while (true)
            {
                int bytesRead = compressedzipStream.Read(block, 0, block.Length);
                if (bytesRead <= 0)
                    break;
                else
                    outBuffer.Write(block, 0, bytesRead);
            }
            compressedzipStream.Close();
            return outBuffer.ToArray();
        }

        /// <summary>
        /// 获取当前ip地址对应城市信息
        /// </summary>
        /// <returns></returns>
        private string GetCityCode()
        {
            HttpWebResponse theResponse;
            WebRequest theRequest;
            string cityCode = "";
            string city = "";
            string province = "";
            try
            {
                theRequest = WebRequest.Create("http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=xml");
                theResponse = (HttpWebResponse)theRequest.GetResponse();

                using (System.IO.Stream sm = theResponse.GetResponseStream())
                {
                    System.IO.StreamReader read = new System.IO.StreamReader(sm, Encoding.Default);
                    city = read.ReadToEnd();
                }

                theRequest.Abort();
                theResponse.Close();

                if (city.Replace("\t","").Length == 0) throw new Exception();
                string[] strArray = city.Trim('\t').Split('\t');
                city = strArray[strArray.Count() - 1];//最后一个是城市
                province = strArray[strArray.Count() - 2];//最后第二个是省份
                cityCode = cityDict[string.Format("{0},{1}", province, city)];
            }
            catch
            {
                cityCode = "";
            }     

            return cityCode;
        }

        /// <summary>
        /// 获取城市名称，编码对应字典
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetCityDict()
        {
            try
            {
                string[] cityArray = Properties.Resources.city.Split('\r');
                Dictionary<string, string> dict = cityArray.ToDictionary(cityName => cityName.Split(' ')[1], cityCode => cityCode.Split(' ')[0]);
                return dict;
            }
            catch
            {
                throw;
            }
        }

        #region 界面控制

        /// <summary>
        /// 显示天气信息
        /// </summary>
        private void ShowWeatherInfo()
        {
            try
            {
                lblNowWendu.Text = string.Format("{0}℃", nowTemperature["wendu"]);
                lblNowWind.Text = string.Format("{0}{1}", nowTemperature["fengxiang"], nowTemperature["fengli"]);
                lblNowShidu.Text = string.Format("湿度:{0}", nowTemperature["shidu"]);
                lblUpdateTime.Text = string.Format("{0}更新", nowTemperature["updatetime"]);
                if (DateTime.Now.Hour < 18) { picBoxNow.Image = ChooseWeatherImg(foreTemperature[0]["DayType"]); }
                else { picBoxNow.Image = ChooseWeatherImg(foreTemperature[0]["NightType"]); }

                lblCity.Text = nowTemperature["city"];
                if (nowEnvironment["quality"].Length < 3)
                {
                    lblQuality.Text = string.Format("  {0}  ", nowEnvironment["quality"]);
                }
                else
                {
                    lblQuality.Text = string.Format("{0}", nowEnvironment["quality"]);
                }
                if (!nowEnvironment["aqi"].Equals(string.Empty))
                {
                    lblAQI.Text = string.Format("AQI:{0}", nowEnvironment["aqi"]);
                    lblPM25.Text = string.Format("PM2.5:{0}", nowEnvironment["pm25"]);
                    lblPM10.Text = string.Format("PM10:{0}", nowEnvironment["pm10"]);
                }
                else
                {
                    lblAQI.Text = string.Empty;
                    lblPM25.Text = string.Empty;
                    lblPM10.Text = string.Empty;
                }
                int API;
                if (int.TryParse(nowEnvironment["aqi"], out API))
                {
                    API = int.Parse(nowEnvironment["aqi"]);
                    if (API < 51)
                    {
                        lblQuality.BackColor = Color.Lime;
                    }
                    else if (API < 101)
                    {
                        lblQuality.BackColor = Color.Yellow;
                    }
                    else if (API < 151)
                    {
                        lblQuality.BackColor = Color.Orange;
                    }
                    else if (API < 201)
                    {
                        lblQuality.BackColor = Color.OrangeRed;
                    }
                    else if (API < 251)
                    {
                        lblQuality.BackColor = Color.Red;
                    }
                    else if (API < 301)
                    {
                        lblQuality.BackColor = Color.Purple;
                    }
                    else
                    {
                        lblQuality.BackColor = Color.DarkRed;
                    }
                }
                else
                {
                    lblQuality.BackColor = Color.Snow;
                }
                lblDate1.Text = foreTemperature[0]["date"];
                lblDate2.Text = foreTemperature[1]["date"];
                lblDate3.Text = foreTemperature[2]["date"];
                lblDate4.Text = foreTemperature[3]["date"];
                lblDate5.Text = foreTemperature[4]["date"];
                lblTemp1.Text = string.Format("{0}~{1}", foreTemperature[0]["low"].Split(' ')[1], foreTemperature[0]["high"].Split(' ')[1]);
                lblTemp2.Text = string.Format("{0}~{1}", foreTemperature[1]["low"].Split(' ')[1], foreTemperature[1]["high"].Split(' ')[1]);
                lblTemp3.Text = string.Format("{0}~{1}", foreTemperature[2]["low"].Split(' ')[1], foreTemperature[2]["high"].Split(' ')[1]);
                lblTemp4.Text = string.Format("{0}~{1}", foreTemperature[3]["low"].Split(' ')[1], foreTemperature[3]["high"].Split(' ')[1]);
                lblTemp5.Text = string.Format("{0}~{1}", foreTemperature[4]["low"].Split(' ')[1], foreTemperature[4]["high"].Split(' ')[1]);

                if (DateTime.Now.Hour < 18) { picBoxDate1.Image = ChooseWeatherImg(foreTemperature[0]["DayType"]); }
                else { picBoxDate1.Image = ChooseWeatherImg(foreTemperature[0]["NightType"]); }
                picBoxDate2.Image = ChooseWeatherImg(foreTemperature[1]["DayType"]);
                picBoxDate3.Image = ChooseWeatherImg(foreTemperature[2]["DayType"]);
                picBoxDate4.Image = ChooseWeatherImg(foreTemperature[3]["DayType"]);
                picBoxDate5.Image = ChooseWeatherImg(foreTemperature[4]["DayType"]);
            }
            catch
            {
                throw;
            }
        }

        #region Timer控件

        /// <summary>
        /// 窗体初始上升Timer
        /// </summary>
        private int upValue = 0;
        private void Uptimer_Tick(object sender, EventArgs e)
        {
            if (upValue > this.Size.Height)
            {
                Uptimer.Stop();
                isFormUp = true;
            }
            else
            {
                this.Location = new Point(SystemInformation.WorkingArea.Width - this.Size.Width,
                    SystemInformation.WorkingArea.Height - upValue);
                upValue += 4;
            }
        }

        /// <summary>
        /// 窗体隐藏关闭Timer
        /// </summary>
        private int stayTime = 3000;
        private int nowStayTime = 0;
        private double opacityValue = 100;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (nowStayTime == stayTime)
            {
                if (opacityValue < 0)
                {
                    this.Dispose();
                }
                this.Opacity = opacityValue / 100.00;
                opacityValue -= 1;
            }
            else
            {
                nowStayTime += timer.Interval;
            }
        }

        /// <summary>
        /// Load动画Timer，load结束后显示所有控件
        /// </summary>
        private int nowLoad = 0;
        private bool smallToBig = true;
        private void timerLoad_Tick(object sender, EventArgs e)
        {
            try
            {
                if (nowLoad == 15) smallToBig = false;
                if (nowLoad == 0) smallToBig = true;
                if (smallToBig)
                {
                    pictureBoxLoad.Image = GetLoadImage(nowLoad);
                    nowLoad++;
                }
                else
                {
                    pictureBoxLoad.Image = GetLoadImage(nowLoad);
                    nowLoad--;
                }
                if (isGetInfo && isFormUp)
                {
                    timerLoad.Stop();
                    pictureBoxLoad.Visible = false;
                    ShowWeatherInfo();
                    ShowAllControls();
                    timer.Start();
                }
            }
            catch
            {
            }
        }

        #endregion

        #region 控件操作事件
        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            string queryStr = txtCity.Text.Trim();
            if (queryStr.Length > 0)
            {
                List<string> list = cityList.FindAll(delegate(string s) { return s.Contains(txtCity.Text); });
                if (list.Count > 0)
                {
                    if (list.Count > 6) listBoxCity.Height = 76;
                    else
                    {
                        listBoxCity.Height = (12 * list.Count) + 4;
                    }
                    listBoxCity.DataSource = list;
                    listBoxCity.Visible = true;
                }
                else
                {
                    listBoxCity.DataSource = null;
                    listBoxCity.Visible = false;
                }
            }
            else
            {
                listBoxCity.DataSource = null;
                listBoxCity.Visible = false;
            }
        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                if (listBoxCity.Items.Count > 0)
                {
                    listBoxCity.Focus();
                }
            }

            if (e.KeyData == Keys.Escape)
            {
                txtCity.Enabled = false;
                txtCity.Visible = false;
                listBoxCity.Enabled = false;
                listBoxCity.Visible = false;
            }

            if (e.KeyData == Keys.Enter)
            {
                queryCity = txtCity.Text.Trim();
                if (cityList.Contains(queryCity) || queryCity.Equals(string.Empty))
                {
                    txtCity.Visible = false;
                    txtCity.Enabled = false;
                    listBoxCity.Enabled = false;
                    listBoxCity.Visible = false;

                    HideAllControls();

                    isGetInfo = false;
                    Thread getInfo = new Thread(new ThreadStart(GetWeatherInfo));
                    getInfo.Start();

                    nowLoad = 0;
                    timerLoad.Start();
                    pictureBoxLoad.Visible = true;
                }
                else return;
            }
        }

        private void listBoxCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtCity.Text = listBoxCity.SelectedValue.ToString();
                listBoxCity.Visible = false;
            }
            if (e.KeyData == Keys.Escape)
            {
                txtCity.Focus();
            }
        }

        private void listBoxCity_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtCity.Text = listBoxCity.SelectedValue.ToString();
            listBoxCity.Visible = false;
        }

        private void lblCity_MouseClick(object sender, MouseEventArgs e)
        {
            txtCity.Text = "";
            txtCity.Enabled = true;
            listBoxCity.Enabled = true;
            txtCity.Visible = true;
            txtCity.Focus();
        }
        #endregion

        #region 鼠标滑过事件

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            timer.Stop();
            this.Opacity = 1;
        }

        private void Show_MouseMove(object sender, MouseEventArgs e)
        {
            timer.Stop();
            this.Opacity = 1;
        }

        private void Show_MouseLeave(object sender, EventArgs e)
        {
            stayTime = 2000;
            nowStayTime = 0;
            opacityValue = 100;
            timer.Start();
        }

        private void picBoxNow_MouseLeave(object sender, EventArgs e)
        {
            stayTime = 2000;
            nowStayTime = 0;
            opacityValue = 100;
            timer.Start();
        }

        private bool isMoveIn = false;
        private void picBoxDate1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMoveIn)
            {
                isMoveIn = true;
                timer.Stop();
                this.Opacity = 1;
                picBoxDate1.Image = ChooseWeatherImg(foreTemperature[0]["NightType"]);
            }
        }

        private void picBoxDate1_MouseLeave(object sender, EventArgs e)
        {
            isMoveIn = false;
            if (DateTime.Now.Hour < 18) { picBoxDate1.Image = ChooseWeatherImg(foreTemperature[0]["DayType"]); }
            else { picBoxDate1.Image = ChooseWeatherImg(foreTemperature[0]["NightType"]); }
        }

        private void picBoxDate2_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMoveIn)
            {
                isMoveIn = true;
                timer.Stop();
                this.Opacity = 1;
                picBoxDate2.Image = ChooseWeatherImg(foreTemperature[1]["NightType"]);
            }
        }

        private void picBoxDate2_MouseLeave(object sender, EventArgs e)
        {
            isMoveIn = false;
            picBoxDate2.Image = ChooseWeatherImg(foreTemperature[1]["DayType"]);
        }

        private void picBoxDate3_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMoveIn)
            {
                isMoveIn = true;
                timer.Stop();
                this.Opacity = 1;
                picBoxDate3.Image = ChooseWeatherImg(foreTemperature[2]["NightType"]);
            }
        }

        private void picBoxDate3_MouseLeave(object sender, EventArgs e)
        {
            isMoveIn = false;
            picBoxDate3.Image = ChooseWeatherImg(foreTemperature[2]["DayType"]);
        }

        private void picBoxDate4_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMoveIn)
            {
                isMoveIn = true;
                timer.Stop();
                this.Opacity = 1;
                picBoxDate4.Image = ChooseWeatherImg(foreTemperature[3]["NightType"]);
            }
        }

        private void picBoxDate4_MouseLeave(object sender, EventArgs e)
        {
            isMoveIn = false;
            picBoxDate4.Image = ChooseWeatherImg(foreTemperature[3]["DayType"]);
        }

        private void picBoxDate5_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMoveIn)
            {
                isMoveIn = true;
                timer.Stop();
                this.Opacity = 1;
                picBoxDate5.Image = ChooseWeatherImg(foreTemperature[4]["NightType"]);
            }
        }

        private void picBoxDate5_MouseLeave(object sender, EventArgs e)
        {
            isMoveIn = false;
            picBoxDate5.Image = ChooseWeatherImg(foreTemperature[4]["DayType"]);
        }

        private void txtCity_MouseMove(object sender, MouseEventArgs e)
        {
            timer.Stop();
            this.Opacity = 1;
        }

        private void listBoxCity_MouseMove(object sender, MouseEventArgs e)
        {
            timer.Stop();
            this.Opacity = 1;
        }
        #endregion

        #region 控件显示隐藏
        private void HideAllControls()
        {
            try
            {
                lblCurtain.Location = new Point(0, 0);
                lblCurtain.Width = curtainWidth;
                lblCurtain.Height = curtainHeight;
                lblCurtain.Visible = true;
                this.Refresh();
            }
            catch
            {
                throw;
            }
        }

        private void ShowAllControls()
        {
            try
            {
                Random r = new Random();
                int c = r.Next(0, 8);

                switch (c)
                {
                    case 0:
                        for (int i = 0; i < curtainWidth; i += 5)
                        {
                            lblCurtain.Location = new Point(i, lblCurtain.Location.Y);
                            lblCurtain.Width = curtainWidth - i;
                            this.Refresh();
                            Thread.Sleep(10);
                        }
                        lblCurtain.Visible = false;
                        this.Refresh();
                        break;
                    case 1:
                        for (int i = curtainWidth; i > 0; i -= 5)
                        {
                            lblCurtain.Width = i;
                            this.Refresh();
                            Thread.Sleep(10);
                        }
                        lblCurtain.Visible = false;
                        this.Refresh();
                        break;
                    case 2:
                        for (int i = 0; i < curtainHeight; i += 4)
                        {
                            lblCurtain.Location = new Point(lblCurtain.Location.X, i);
                            lblCurtain.Height = curtainHeight - i;
                            this.Refresh();
                            Thread.Sleep(10);
                        }
                        lblCurtain.Visible = false;
                        this.Refresh();
                        break;
                    case 3:
                        for (int i = curtainHeight; i > 0; i -= 4)
                        {
                            lblCurtain.Height = i;
                            this.Refresh();
                            Thread.Sleep(10);
                        }
                        lblCurtain.Visible = false;
                        this.Refresh();
                        break;
                    case 4:
                        for (int i = 0; i < curtainWidth; i += 5)
                        {
                            int y = (i*curtainHeight)/curtainWidth;
                            lblCurtain.Location = new Point(i, y);
                            lblCurtain.Width = curtainWidth - i;
                            lblCurtain.Height = curtainHeight - y;
                            this.Refresh();
                            Thread.Sleep(10);
                        }
                        lblCurtain.Visible = false;
                        this.Refresh();
                        break;
                    case 5:
                        for (int i = curtainWidth; i > 0; i -= 5)
                        {
                            int y = (i * curtainHeight) / curtainWidth;
                            lblCurtain.Width = i;
                            lblCurtain.Height = y;
                            this.Refresh();
                            Thread.Sleep(10);
                        }
                        lblCurtain.Visible = false;
                        this.Refresh();
                        break;
                    case 6:
                        for (int i = curtainHeight; i > 0; i -= 5)
                        {
                            int x = (i*curtainWidth)/curtainHeight;
                            lblCurtain.Location = new Point(lblCurtain.Location.X, (curtainHeight - i));
                            lblCurtain.Width = x;
                            lblCurtain.Height = i;
                            this.Refresh();
                            Thread.Sleep(10);
                        }
                        lblCurtain.Visible = false;
                        this.Refresh();
                        break;
                    default:
                        for (int i = 0; i < curtainWidth; i += 5)
                        {
                            int y = (i * curtainHeight) / curtainWidth;
                            lblCurtain.Location = new Point(i, lblCurtain.Location.Y);
                            lblCurtain.Width = curtainWidth - i;
                            lblCurtain.Height = curtainHeight - y;
                            this.Refresh();
                            Thread.Sleep(10);
                        }
                        lblCurtain.Visible = false;
                        this.Refresh();
                        break;
                }
                
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 对应图片获取
        /// <summary>
        /// 根据天气类型选择对应图片
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        private Image ChooseWeatherImg(string Type)
        {
            if (Type.Contains("晴"))
            {
                if (Type.Contains("转"))
                {
                    if (Type.Contains("阴") || Type.Contains("多云"))
                    {
                        return Properties.Resources.SunToCloudy;
                    }
                    else if (Type.Contains("雨"))
                    {
                        return Properties.Resources.SunToRain;
                    }
                    else
                    {
                        return Properties.Resources.none;
                    }
                }
                else
                {
                    return Properties.Resources.Sun;
                }
            }
            else if (Type.Contains("阴"))
            {
                return Properties.Resources.Cloudy;
            }
            else if (Type.Contains("多云"))
            {
                return Properties.Resources.SunToCloudy;
            }
            else if (Type.Contains("雨"))
            {
                if (Type.Contains("雷"))
                {
                    return Properties.Resources.ThunderRain;
                }
                else
                {
                    return Properties.Resources.Rain;
                }
            }
            else
            {
                return Properties.Resources.none;
            }
        }

        /// <summary>
        /// 加载时对应图片获取
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private Image GetLoadImage(int num)
        {
            switch (num)
            {
                case 0:
                    return Properties.Resources._0;
                case 1:
                    return Properties.Resources._1;
                case 2:
                    return Properties.Resources._2;
                case 3:
                    return Properties.Resources._3;
                case 4:
                    return Properties.Resources._4;
                case 5:
                    return Properties.Resources._5;
                case 6:
                    return Properties.Resources._6;
                case 7:
                    return Properties.Resources._7;
                case 8:
                    return Properties.Resources._8;
                case 9:
                    return Properties.Resources._9;
                case 10:
                    return Properties.Resources._10;
                case 11:
                    return Properties.Resources._11;
                case 12:
                    return Properties.Resources._12;
                case 13:
                    return Properties.Resources._13;
                case 14:
                    return Properties.Resources._14;
                case 15:
                    return Properties.Resources._15;
                default:
                    return Properties.Resources.none;
            }
        }

        #endregion

        #endregion
    }
}
