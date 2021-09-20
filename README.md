# PagTool
custom tool for streamer pagrax @ https://www.twitch.tv/pagrax

This app connects to Twitch chat and allows users in chat to add themselves to a queue. The streamer running the application can then use hotkeys to select users from the queue at random, send a message reporting the selection to chat, and copies their username to the clipboard to be pasted into a game, or similar. It's got lots of other features, like customizable responses and hotkeys, robust logging, and a suite of tools to modify the queues manually if necesasry. It even keeps track of how many times a user has been drawn, and you can save all of this data as separate files for different games or campaigns!

## Installation

Go to the [releases page](https://github.com/corptact/PagTool/tags), download the latest build as an .exe file, and put it in it's own folder somewhere you prefer on your system. The program will create all necessary files on first startup, as well as prompt you to go to twitchtokengenerator.com and generate a token for it to use.

## Usage

The app is divided into three main pages: Modify, Configure, and Debug. 

The Modify page is designed to allow for editing of the primary lists. 

![image](https://user-images.githubusercontent.com/22552031/133957638-6b4417b1-7cfb-4052-823c-9896a03eec33.png)

The Configure page allows access to several dialog windows to change the program's settings.

![image](https://user-images.githubusercontent.com/22552031/133957664-096d99d0-ef4c-4ed4-a662-dbbcd3278e66.png)

The Debug page displays the current log, including chat and any actions occuring internally in the program. You can also change how often the information in the program visually updates, force a visual update, force the program to reconnect to chat, and set a few other options.

![image](https://user-images.githubusercontent.com/22552031/133957740-dc4c2abf-8873-42dc-8caa-5e9ebcd65869.png)

## Known Bugs

- The force reconnect button causes the application to freeze until the auto-refresh intveral elapses.
- The 'Save Log' button is not yet implemented.
- The application does not currently support an icon.
- The 'Launch Token Generator' button in the ConfigureTwitchCredentials dialog launches the token generator webpage successfully, but token validation causes its backend to fail, and requires the user to scroll to the bottom of the page and use the 'Generate Token' button again to create a properly validated token.
- Forcing the application to reconnect, either by updating the credentials, or by use of the 'Force Reconnect' button, clears the entire log and starts it afresh.
- The log is not checked for length or truncated at any point and may eventually cause a memory leak if left running constantly. It is not known how long this would take in a production setting.
- There is no minimize-to-taskbar functionality yet.
- Generally, several other features are also still missing while in pre-release.
