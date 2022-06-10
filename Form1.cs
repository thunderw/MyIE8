using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyIE8
{
    /// <summary>
    /// ref: https://weblog.west-wind.com/posts/2011/May/21/Web-Browser-Control-Specifying-the-IE-Version
    /// ref: http://msdn.microsoft.com/en-us/library/ee330730%28v=vs.85%29.aspx#browser_emulation
    /// ref: https://stackoverflow.com/questions/3044616/what-is-the-browser-version-of-a-webbrowser-control-in-windows-forms
    /// 相关注册表：
    /// HKEY_CURRENT_USER\SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION
    /// HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION
    /// HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION
    /// </summary>
    public partial class MyIE8 : Form
    {
        public MyIE8()
        {
            InitializeComponent();
        }

        private void MyIE8_Load(object sender, EventArgs e)
        {
            txtUrl.Text = Properties.Settings.Default.LastUrl;
            webBrowser1.Navigate(txtUrl.Text);
            Console.WriteLine(webBrowser1.Version.ToString());
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate(txtUrl.Text);
                Properties.Settings.Default.LastUrl = txtUrl.Text;
                Properties.Settings.Default.Save();
            }
        }
    }
}
