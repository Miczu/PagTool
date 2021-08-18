using System;
using System.Diagnostics;
using System.Linq;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace PagTool
{
    public class ChatBot
    {
        public string LogOutput = ""; // public variable that will be accessed to update debug log in FormMain
        
        // TODO: safely load and store credentials in some secure way
        private ConnectionCredentials _credentials;

        private TwitchClient _twitchClient;

        public ChatBot()
        {
            _twitchClient = new TwitchClient();
        }

        /// <summary>
        /// Connect to the Twitch channel using stored credentials.
        /// </summary>
        
        internal void Connect(string twitchUsername, string twitchOAuth)
        {
            _credentials = new ConnectionCredentials(twitchUsername, twitchOAuth);
            
            _twitchClient.Initialize(_credentials, twitchUsername);
            
            // set up event listeners
            _twitchClient.OnConnected += _OnConnected;
            _twitchClient.OnMessageReceived += _OnMessageReceived;
            _twitchClient.OnLog += _OnLog;
            
            // connect to IRC
            _twitchClient.Connect();
        }

        // event listener methods: basically just append any info received to the LogOutput variable
        // TODO: this needs to be truncated eventually so as to not have some infinitely large string
        
        // TODO: clean these up + implement
        private void _OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            LogOutput += $"[CHAT] <{e.ChatMessage.Username}>: {e.ChatMessage.Message}\n";
        }
        
        private void _OnConnected(object sender, OnConnectedArgs e)
        {
            LogOutput += $"[INFO] Connected to IRC: {e.BotUsername}\n";
        }
        
        private void _OnLog(object sender, OnLogArgs e)
        {
            // TODO: use a bool flag to choose whether or not to log vebose information
            //LogOutput += "[VERBOSE] " + e.Data + "\n";
        }
    }
}