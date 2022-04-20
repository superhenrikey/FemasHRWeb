using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FemasCloudWnc
{
    public partial class FemasCloudWnc : Form
    {
        private int steps = 1;
        private int times = 0, tryTimes = 0;
        private string LogoutLink = ConfigurationManager.AppSettings["LogoutLink"];
        private string UserId = string.Empty, UserPass = string.Empty;
        private bool isNightShift = false;
        private List<EmpInfos> EmpInfos = new List<EmpInfos>();
        private int dtNowHour = DateTime.Now.Hour;
        public FemasCloudWnc()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            FemasHelper.FixBrowserVersion();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //txtUser.Text = string.IsNullOrEmpty(txtUser.Text.Trim()) ? ConfigurationManager.AppSettings["EmpID"] : txtUser.Text.Trim();
            //txtPass.Text = string.IsNullOrEmpty(txtPass.Text.Trim()) ? ConfigurationManager.AppSettings["PassFemas"] : txtPass.Text.Trim();
            try
            {
                txtUser.Text = UserId;
                txtPass.Text = UserPass;
                HtmlDocument doc = this.wbFemas.Document;
                doc.GetElementById("user_username").SetAttribute("Value", UserId);
                doc.GetElementById("user_passwd").SetAttribute("Value", UserPass);
                doc.InvokeScript("new_login");
            }
            catch (Exception)
            {
                SendMail();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            bool chkStart = false;
            HtmlElementCollection links = this.wbFemas.Document.GetElementsByTagName("input");
            foreach (HtmlElement link in links)
            {
                if (link.GetAttribute("value") == "0800"  || link.GetAttribute("value") == "Punch In (1)" || link.GetAttribute("value") == "Thứ1 đoạn lên ca")
                {
                    link.InvokeMember("click");
                    chkStart = true;
                    return;
                }
            }

            if (!chkStart)
                SendMail();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            bool chkEnd = false;
            HtmlElementCollection links = this.wbFemas.Document.GetElementsByTagName("input");
            foreach (HtmlElement link in links)
            {
                if (link.GetAttribute("value") == "1700" || link.GetAttribute("value") == "Punch Off (1)" || link.GetAttribute("value") == "Thứ1 đoạn xuống ca") {
                    link.InvokeMember("click");
                    chkEnd = true;
                    return;
                }
            }
            if (!chkEnd)
                SendMail();
        }

        private void CheckClickDone() {
            times = 0;
            HtmlElementCollection links = this.wbFemas.Document.GetElementsByTagName("td");
            foreach (HtmlElement link in links)
            {
                if (link.GetAttribute("className") == "textBlue")
                {
                    times++;
                }
            }
        }

        private void timerStart_Tick(object sender, EventArgs e)
        {
            switch (steps)
            {
                case 1:
                    btnLogin.PerformClick();
                    steps++;
                    break;
                case 2:
                    steps++;
                    if (!isNightShift)
                    {
                        if (dtNowHour > 6 && dtNowHour < 12)
                            btnStart.PerformClick();
                        else
                            btnEnd.PerformClick();
                    }
                    else {
                        if (dtNowHour > 18 && dtNowHour < 24)
                            btnStart.PerformClick();
                        else
                            btnEnd.PerformClick();
                    }
                    break;
                case 3:
                    CheckClickDone();
                    if (!isNightShift)
                    {
                        if (dtNowHour > 6 && dtNowHour < 12)
                            steps = times < 1 ? --steps : ++steps;
                        else
                            steps = times < 2 ? --steps : ++steps;
                    }
                    else
                    {
                        if (dtNowHour > 18 && dtNowHour < 24)
                            steps = times < 1 ? --steps : ++steps;
                        else
                            steps = times < 2 ? --steps : ++steps;
                    }
                    break;
                default:
                    //Environment.Exit(0);
                    Logout();
                    break;
            }

        }

        private void FemasCloudWnc_Load(object sender, EventArgs e)
        {
            var NightSift = (dtNowHour == 19 && DateTime.Now.Minute > 30) || dtNowHour == 8;
            var jsonPath = Path.Combine(ConfigurationManager.AppSettings["ConfigPath"], "EmpInfo.json");
            try
            {
                var json = File.ReadAllText(jsonPath, System.Text.Encoding.Default);
                if (!string.IsNullOrEmpty(json))
                {
                    EmpInfos = JsonConvert.DeserializeObject<List<EmpInfos>>(json);
#if DEBUG
                    EmpInfos = EmpInfos.Where(r => r.EmpNo == "19700327").ToList();
#else
                    EmpInfos = EmpInfos.Where(r => r.IsNightShift == NightSift).OrderBy(_ => Guid.NewGuid()).ToList();
#endif
                    if (!EmpInfos.Any())
                        Environment.Exit(0);
                    UserId = EmpInfos.First().EmpNo;
                    UserPass = EmpInfos.First().PassWord;
                    isNightShift = EmpInfos.First().IsNightShift;
                }
                else
                {
                    throw new Exception(string.Format("Không thể đọc được dữ liệu Json file. Vui lòng kiểm tra lại tại: {0}!", jsonPath));
                }
            }
            catch (Exception ex) {
                WNC.SFCS.Mail.PMail pMail = new WNC.SFCS.Mail.PMail(WNC.SFCS.Shared.EnvType.VN_Production_VN2.ToString());
                pMail.Subject = "[LỖI] FemasCloudWnc_Load function";
                pMail.IsBodyHtml = false;
                pMail.Body = "Dear Sir,";
                pMail.WriteLine(ex.Message);
                pMail.Priority = System.Net.Mail.MailPriority.High;
                pMail.To.Add("19700327");
                pMail.Send();
                Environment.Exit(0);
            }
            timerStart.Interval = 10000;
            timerStart.Enabled = true;
            timerStart.Start();
        }

        private void Logout(bool isTry = false)
        {
            timerStart.Stop();
            if (!isTry) { 
                EmpInfos.RemoveAll(r => r.EmpNo == UserId);
                if (!EmpInfos.Any())
                    Environment.Exit(0);
                UserId = EmpInfos.First().EmpNo;
                UserPass = EmpInfos.First().PassWord;
                isNightShift = EmpInfos.First().IsNightShift;
                tryTimes = 0;
            }
            else
                tryTimes++;
            //this.wbFemas.Url = new Uri(LogoutLink);
            //this.wbFemas.Refresh();
            wbFemas.Navigate(LogoutLink);
            while (wbFemas.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            timerStart.Start();
            steps = 1;
        }
        private void SendMail()
        {
            if (tryTimes > 2)
            {
                WNC.SFCS.Mail.PMail pMail = new WNC.SFCS.Mail.PMail(WNC.SFCS.Shared.EnvType.VN_Production_VN2.ToString());
                pMail.Subject = "[LỖI] Femas Cloud chấm công thất bại";
                pMail.IsBodyHtml = false;
                pMail.Body = "Dear Sir,";
                pMail.WriteLine(string.Format("Chấm công cho mã thẻ:{0} thất bại. Vui lòng kiểm tra lại!", UserId));
                pMail.Priority = System.Net.Mail.MailPriority.High;
#if DEBUG
                pMail.To.Add("19700327");
#else
                pMail.To.Add(UserId);
#endif
                pMail.Bcc.Add("19700327");
                pMail.Send();
                Logout();
                return;
            }
            Logout(true);
        }
        
    }
    public class EmpInfos { 
        public string EmpNo { get; set; }
        public string PassWord { get; set; }
        public string EmpName { get; set; }
        public bool IsNightShift { get; set; }
    }
}
