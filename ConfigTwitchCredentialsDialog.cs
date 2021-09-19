using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;

namespace PagTool
{
    public partial class ConfigTwitchCredentialsDialog : Form
    {
        public ConfigTwitchCredentialsDialog()
        {
            InitializeComponent();
        }
        
        public string[] Show(string[] twitchCredentials)
        {
            // set all components values based on current settings
            if (twitchCredentials.Length >= 2)
            {
                textBox_ChannelName.Text = twitchCredentials[0].Equals("DoesNotExist") ? "Enter your username here..." : twitchCredentials[0];
                textBox_AccessToken.Text = twitchCredentials[1].Equals("DoesNotExist") ? "Use the token generator!" : twitchCredentials[1];
            }
            else
            { //malformed file
                textBox_ChannelName.Text = "Enter your username here...";
                textBox_AccessToken.Text = "Use the token generator!";
            }

            //show the dialog
            var result = ShowDialog();

            //check if user clicked OK 
            if (result == DialogResult.OK)
            {
                //sanitize
                string channelName = textBox_ChannelName.Text.Trim();
                string accessToken = textBox_AccessToken.Text.Trim();

                // check for bad input -- if any of these pass, it's no good. todo add more sanity checks?
                if (String.IsNullOrWhiteSpace(channelName) || String.IsNullOrWhiteSpace(accessToken) || //empty string? no good
                    channelName.Contains(" ") || accessToken.Contains(" "))                             //has spaces? no good
                {
                    //malformed input, don't save changes
                    return twitchCredentials;
                }
                else // it's okay. return it
                    return new[] {channelName, accessToken};
            }
            else //don't make changes, just return 
                return twitchCredentials;
        }

        private void button_OpenTokenGenerator_Click(object sender, EventArgs e)
        {
            //send user to the swiftyspiffy token generator, with the necessary scopes selected
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://id.twitch.tv/oauth2/authorize?response_type=code" +
                           "&client_id=gp762nuuoqcoxypju8c569th9wz7q5" +
                           "&redirect_uri=https://twitchtokengenerator.com" +
                           "&scope=chat:read+chat:edit+channel:moderate+channel:read:subscriptions+moderation:read" + // may need to add more scopes in the future
                           "&state=frontend|Wk00YWV2eXNVZmg0cFk1UWJKd3B3Zz09&force_verify=true",
                UseShellExecute = true
            });
        }
    }
}