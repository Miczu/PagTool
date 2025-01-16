namespace PagTool
{
    //this result: stores every string needed to be accessed by ChatBot to send upon !chatCommand execution.
    public class ConfigCommandBehaviorResult
    {
        //defaults:
        public string ResponseCmdNameAdd = "$USERNAME, you are now waiting. $WAITCOUNT users are waiting in total.";
        public string ResponseCmdNameAlreadyExists = "$USERNAME, you have already been added! Wait for the list to be shuffled.";
        public string ResponseCmdCheckStatus = "$FULLSTATUS";
        public string ResponseCmdUserDrawn = "$USERNAME, you have been selected! Your lineage is now $LINEAGE.";
        public string ResponseCmdBlacklistTriggered = "$USERNAME, your name is blacklisted. Please change your displayname if you wish to be added.";
        public string ResponseCmdWaitlistEmpty = "The waitlist is currently empty! Type !name to be added to the waitlist.";
        public string ResponseCmdChatReconnect = "The program is reconnecting to chat... please wait a moment...";
        public string ChatReminder = "Type !name in chat to add yourself to the waitlist.";
        public int ChatReminderSeconds = 600; //10 minutes
        public string ResponseCmdMoveToDead = "$USERNAME, fare thee well! You are now dead.";
        public string ResponseCmdCannotDie = "$USERNAME, you cannot die! Your name is not active!";
        public string ResponseCmdHelp = "Use !name to add yourself to the list. Use !dead to mark yourself as dead, when you die in battle.";
        public string ResponseCmdAutoShuffledDead = "The waitlist is empty! All those marked as dead have been shuffled back into the waiting list automatically. Newcomers, use !name to add yourself to the list!";
        public string ResponseCmdAutoShuffleNoDead = "Waiting list is empty and no dead to shuffle";

        //constructor using only default values
        public ConfigCommandBehaviorResult() { }
    }
}