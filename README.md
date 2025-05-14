# Printing Press

## About
This is a background Windows Forms application that stays in the appTray and monitors inserts to the Clipboard and then concatenates all the monitored results with a selected delimiter. 

### How to use
While the app is running, the user starts monitoring by clicking the key combination `CTRL` + `ALT` + `C` and ends monitoring by clicking the key combination `CTRL` + `ALT` + `V`.

Once the monitoring is complete, the result will also be copied to the Clipboard and is accessible via the paste command.

It is also possible to start and end monitoring using the application icon in the appTray. Just right-click the app icon and click Start or Stop in the menu.

### Selecting the delimiter
The default delimiter is `Comma (,)`, but it can be changed by right-clicking on the app icon inside the appTray and selecting Settings. The Settings form will open with an option to select the delimiter.
Currently, the supported delimiter options are:
* `Comma (,)`
* `Semicolon (;)`
* `New line (\n)`
* `Tab (\t)`
* `Pipe (|)`
* `Space`
