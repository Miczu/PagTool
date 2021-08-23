using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;

namespace PagTool
{
    public class ChatBot
    {
        public string LogOutput = ""; // public variable that will be accessed to update debug log in FormMain

        public bool DoVerboseLogging = false;
        
        // TODO: safely load and store credentials in some secure way
        private ConnectionCredentials _credentials;

        private TwitchClient _twitchClient;
        private FormMain _parent; //so i can ask it to do methods directly

        public ChatBot(FormMain parent)
        {
            _parent = parent;
            _twitchClient = new TwitchClient();
        }

        /// <summary>
        /// Connect to the Twitch channel using stored credentials.
        /// </summary>
        
        internal void Connect(string twitchUsername, string twitchOAuth)
        {
            _credentials = new ConnectionCredentials(twitchUsername, twitchOAuth);
            
            _twitchClient.Initialize(_credentials, twitchUsername);
            
            //command handler
            _twitchClient.OnChatCommandReceived += _OnChatCommandReceived;
            
            // set up standard (always-on) event listeners
            _twitchClient.OnConnected += _OnConnected;
            _twitchClient.OnMessageReceived += _OnMessageReceived;
            _twitchClient.OnDisconnected += _OnDisconnected;
            _twitchClient.OnError += _OnError;

            //verbose-only logging
            _twitchClient.OnLog += _OnLog;

            // connect to IRC
            _twitchClient.Connect();
        }

       

        // for use by the 'force reconnect' button
        internal void DisconnectWaitReconnect(string twitchUsername,
            string twitchOAuth, int secondsToWaitBeforeReconnecting = 5)
        {
            LogOutput += $"[INFO] Disconnecting... \n";
            _twitchClient.Disconnect();
            //LogOutput += $"[INFO] Disconnected.\n";

            Task wait = Task.Run(() =>
            { 
                //LogOutput += $"[INFO] Sleeping for {secondsToWaitBeforeReconnecting} seconds... \n";
                Thread.Sleep(1000 * secondsToWaitBeforeReconnecting);
                LogOutput += $"[INFO] Reconnecting... \n";
                _twitchClient.Connect();
                //LogOutput += $"[INFO] Reconnected.\n";
            });
        }

        // write something to chat. 
        internal void Chat(string message)
        {
            _twitchClient.SendMessage(_credentials.TwitchUsername, message);
        }
        
        //handle all !-prefix messages: parse, check against all command aliases, then execute on a match
        private void _OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            //iterate through parent's ConfigCommandAlias for every AliasCmd[] object (maybe TODO make a collection?)
            //check for a match and if so do the associated action if DoCmd is set

            if(_parent.ConfigCommandAlias.DoCmdNameAdd) // NameAdd
                foreach (string s in _parent.ConfigCommandAlias.AliasCmdNameAdd)
                {
                    if (e.Command.CommandText.Equals(s)) 
                        _parent.TryAddNameToWaitingList(e.Command.ChatMessage.Username); //TryAddName
                }
            
            
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
            if(DoVerboseLogging)
                LogOutput += "[VERBOSE] " + e.Data.ToString() + "\n";
        }
        
        private void _OnDisconnected(object sender, OnDisconnectedEventArgs e)
        {
            LogOutput += $"[WARN] Disconnected!\n";
            // TODO reconnect with increasing delay (do this in a Task and wait for ~10 seconds before beginning reconnect attempts in case of manual reconnect job)
            // collect disconnect time, allow option to chat when bot was last available so people in chat can know they should retry !name if it would have been missed
        }
        
        private void _OnError(object sender, OnErrorEventArgs e)
        {
            LogOutput += $"[ERR!] Thrown: {e.Exception.InnerException}. \"{e.Exception.Message}\" ... \n";
        }
    }
}