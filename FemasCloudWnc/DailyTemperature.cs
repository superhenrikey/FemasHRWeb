using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FemasCloudWnc
{
    public partial class DailyTemperature : Form
    {
        private int steps = 1;
        private string EmpId = string.Empty, nameEmp = string.Empty;
        private List<EmpInfos> EmpInfos = new List<EmpInfos>();
        public DailyTemperature()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            FemasHelper.FixBrowserVersion();
        }

        private void DailyTemperature_Load(object sender, EventArgs e)
        {
            var json = File.ReadAllText(Path.Combine(ConfigurationManager.AppSettings["ConfigPath"], "EmpInfo.json"), System.Text.Encoding.Default);
            if (!string.IsNullOrEmpty(json))
            {
                EmpInfos = JsonConvert.DeserializeObject<List<EmpInfos>>(json);
                EmpId = EmpInfos.First().EmpNo;
                nameEmp = EmpInfos.First().EmpName;
            }
            else
            {
                Environment.Exit(0);
            }
            timerClick.Interval = 5000;
            timerClick.Enabled = true;
            timerClick.Start();
        }

        private void timerClick_Tick(object sender, EventArgs e)
        {
            switch (steps) {
                case 1:
                    btnClick.PerformClick();
                    steps++;
                    break;
                case 2:
                    btnClick2.PerformClick();
                    steps++;
                    break;
                case 3:
                    btnClick3.PerformClick();
                    steps++;
                    break;
                case 4:
                    btnClick4.PerformClick();
                    steps++;
                    break;
                case 5:
                    btnSubmit.PerformClick();
                    steps++;
                    break;
                case 6:
                    steps = CheckClickDone() ? ++steps : 1;
                    break;
                default:
                    //Environment.Exit(0);
                    ResetFunc();
                    break;
            }
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            HtmlElementCollection links = this.wbTemperature.Document.GetElementsByTagName("input");
            //1.員工編號 mã thẻ
            //aria - labelledby = "QuestionId_r9374340848704547a046a670486c34ca"
            //2.姓名 Họ tên
            //aria - labelledby = "QuestionId_ra39d8d6e2527479dbeec45223c8d99f0"
            //3.出勤狀況 Tình trạng chuyên cần
            //name = "r5be07caf872a4e1584f2e864ca80c112" aria - posinset = "2" aria - setsize = "4"
            //aria - label = "2. 居家隔離 Cách ly tại nhà" value = "2. 居家隔離 Cách ly tại nhà"
            foreach (HtmlElement link in links)
            {
                if (link.GetAttribute("aria-labelledby").Contains("QuestionId_r9374340848704547a046a670486c34ca"))
                {
                    //string EmpId = ConfigurationManager.AppSettings["EmpID"];
                    link.SetAttribute("value", EmpId);
                    link.InnerText  = EmpId;
                }
                if (link.GetAttribute("aria-labelledby").Contains("QuestionId_ra39d8d6e2527479dbeec45223c8d99f0"))
                {
                    //string nameEmp = ConfigurationManager.AppSettings["Name"];
                    link.SetAttribute("value", nameEmp);
                    link.InnerText = nameEmp;
                }
                if (link.GetAttribute("name") == "r5be07caf872a4e1584f2e864ca80c112" && link.GetAttribute("value") == "2. 居家隔離 Cách ly tại nhà")
                {
                    link.InvokeMember("click");
                }
            }
                
        }

        private void btnClick2_Click(object sender, EventArgs e)
        {
            var links = this.wbTemperature.Document.GetElementsByTagName("input");
            foreach (HtmlElement link in links)
            {
                var maxlength = link.GetAttribute("maxlength");
                //4.症狀 Triệu chứng
                //aria-label="Other answer" placeholder = "Other"
                if (link.OuterHtml.Contains(" aria-label=\"Other answer\"") && maxlength == "1000")
                {
                    link.SetAttribute("value", "Không");
                    link.InnerText = "Không";
                }
                //5.有無就醫 Tìm kiếm sự chăm sóc y tế
                //< input aria - checked= "false" role = "radio" type = "radio" name = "rae2fa52ed00c44828e085238360b2331"
                //aria - posinset = "2" aria - setsize = "2" aria - label = "No" value = "No" >
                if (link.GetAttribute("name") == "rae2fa52ed00c44828e085238360b2331" && link.GetAttribute("value") == "No")
                {
                    link.InvokeMember("click");
                }
            }
        }

        private void btnClick3_Click(object sender, EventArgs e)
        {
            //6.體溫量測時間 Thời gian đo nhiệt độ cơ thể
            var dtNowHour = DateTime.Now.Hour;
            var links = this.wbTemperature.Document.GetElementsByTagName("input");
            foreach (HtmlElement link in links)
            {
                //< input aria - checked= "false" role = "radio" type = "radio" name = "r8077d5e212bd42d4acb75266195fc6c8"
                //aria - posinset = "1" aria - setsize = "2" aria - label = "上午 Buổi sáng" value = "上午 Buổi sáng" >
                if (link.GetAttribute("name") == "r8077d5e212bd42d4acb75266195fc6c8" )
                {
                    if ((dtNowHour > 7 && dtNowHour < 12 )&& link.GetAttribute("value") == "上午 Buổi sáng")
                        link.InvokeMember("click");
                    else if((dtNowHour > 12 && dtNowHour < 17) && link.GetAttribute("value") == "下午 Buổi chiều")
                        link.InvokeMember("click");
                }
                //< input aria - checked= "false" role = "radio" type = "radio" name = "r8077d5e212bd42d4acb75266195fc6c8"
                //aria - posinset = "2" aria - setsize = "2" aria - label = "下午 Buổi chiều" value = "下午 Buổi chiều" >
            }
        }

        private void btnClick4_Click(object sender, EventArgs e)
        {
            //7.體溫 Nhiệt độ cơ thể
            //aria - labelledby = "QuestionId_r9668f494096447a5b96136c3796a285a"
            HtmlElementCollection links = this.wbTemperature.Document.GetElementsByTagName("input");
            foreach (HtmlElement link in links)
            {
                if (link.GetAttribute("aria-labelledby").Contains("QuestionId_r9668f494096447a5b96136c3796a285a"))
                {
                    string value = "36." + (new Random()).Next(1, 9);
                    link.SetAttribute("value", value);
                    link.InnerText = value;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //< button title = "Submit"
            //class="office-form-theme-primary-background office-form-theme-button office-form-bottom-button button-control light-background-button __submit-button__"
            //role="button"><div class="button-content">Submit</div></button>
            var links = this.wbTemperature.Document.GetElementsByTagName("button");
            foreach (HtmlElement link in links)
            {
                link.InvokeMember("click");
            }
        }
        private bool CheckClickDone() {
            var result = false;
            //thank - you - page - comfirm - text
            HtmlElementCollection links = this.wbTemperature.Document.GetElementsByTagName("div");
            foreach (HtmlElement link in links)
            {
                if (link.GetAttribute("className") == "thank-you-page-confirm")
                {
                    result = true;
                    break;
                }
            }
            if (!result)
                btnReload.PerformClick();
            return result;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            timerClick.Stop();
            wbTemperature.Refresh();
            while (wbTemperature.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            timerClick.Start();
        }
        private void ResetFunc() {
            timerClick.Stop();
            EmpInfos.RemoveAll(r => r.EmpNo == EmpId);
            if (!EmpInfos.Any())
                Environment.Exit(0);
            EmpId = EmpInfos.First().EmpNo;
            nameEmp = EmpInfos.First().EmpName;
            wbTemperature.Refresh();
            while (wbTemperature.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            timerClick.Start();
            steps = 1;
        }
    }
}
