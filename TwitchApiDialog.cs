using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PagTool
{
    public class TwitchChatters
    {
        private List<string> _links { get; set; }
        public int chatter_count { get; set; }
        public Dictionary<string, List<string>> chatters { get; set; }
    }

    public partial class TwitchApiDialog : Form
    {
        private TwitchChatters chatters;
        
        public TwitchApiDialog()
        {
            InitializeComponent();
        }

        public void Show(string channelName, HttpClient httpClient)
        {
            // https://stackoverflow.com/questions/4015324/how-to-make-an-http-post-web-request
            var responseString = httpClient.GetStringAsync($"https://tmi.twitch.tv/group/user/{channelName}/chatters").GetAwaiter().GetResult();
            chatters = JsonConvert.DeserializeObject<TwitchChatters>(responseString);
            
            listBox1.Items.Clear();
            listBox1.Items.AddRange(chatters.chatters.Keys.ToArray());

            //show the dialog
            var result = ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chatters.chatters.TryGetValue(chatters.chatters.Keys.ElementAt(listBox1.SelectedIndex), out List<string> list);
            
            listBox2.Items.Clear();
            listBox2.Items.AddRange(list.ToArray());
        }
    }
}