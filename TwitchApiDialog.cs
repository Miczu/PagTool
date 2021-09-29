using System.Collections.Generic;
using System.IO;
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
        public TwitchApiDialog()
        {
            InitializeComponent();
        }

        public void Show(string channelName, HttpClient httpClient)
        {
            // https://stackoverflow.com/questions/4015324/how-to-make-an-http-post-web-request
            var responseString = httpClient.GetStringAsync($"https://tmi.twitch.tv/group/user/{channelName}/chatters").GetAwaiter().GetResult();
            TwitchChatters chatters = JsonConvert.DeserializeObject<TwitchChatters>(responseString);
        }
    }
}