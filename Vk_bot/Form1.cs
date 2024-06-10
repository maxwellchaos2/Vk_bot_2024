using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vk_bot.Vk_methods;

namespace Vk_bot
{
    public partial class Form1 : Form
    {
        string access_token;

        public Form1()
        {
            CefSettings settings = new CefSettings();
            settings.CachePath = Application.StartupPath;
            CefSharp.Cef.Initialize(settings);
            
            InitializeComponent();
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            chromiumWebBrowser1.LoadUrl("https://oauth.vk.com/authorize?" +
                                           "client_id=8104769&" +
                                           "display=page&" +
                                           "redirect_uri=https://oauth.vk.com/blank.html&" +
                                           "scope=friends,stories,photos,wall&" +
                                           "response_type=token&" +
                                           "v=5.131&" +
                                           "state=jhgugy57yh69876897");
            chromiumWebBrowser1.Dock = DockStyle.Fill;
        }

        private void chromiumWebBrowser1_AddressChanged(object sender, CefSharp.AddressChangedEventArgs e)
        {
            BeginInvoke(new Action(() => getAccessToken(e.Address.ToString())));
        }

        private void getAccessToken(string address)
        {
            if (address.Contains("access_token="))
            {
                int Position = address.IndexOf("#");

                string Url = address.Remove(0, Position + 1);

                int Position2 = Url.IndexOf("&");
                Url = Url.Remove(Position2);
                access_token = Url;
              


                //Если получили access_token то получаем данные пользователя
                string ApiRequest;
                ApiRequest = "https://api.vk.com/method/users.get?"
                            + "fields=photo_100&"
                            + access_token
                            + "&v=5.199";
                WebClient client = new WebClient();
                string Answer = Encoding.UTF8.GetString(client.DownloadData(ApiRequest));


                usersGet user = JsonConvert.DeserializeObject<usersGet>(Answer);

                pictureBox1.Load(user.response[0].photo_100);
                label1.Text = user.response[0].first_name;

                //после получения access_token скрываем Browser
                chromiumWebBrowser1.Hide();
            }
        }

    }
}
