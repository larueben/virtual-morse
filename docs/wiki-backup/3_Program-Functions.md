# Virtual Morse Program Overview
The program provides the following main functions:

1. A text document window for all writing activities.  
2. Interpretation of physical switch inputs (through an interposing gamepad controller) into morse code symbols or special text or email functions.
3. Conversion of morse code into English text.
4. Text-to-speech of letter, word, sentence, or entire document.
5. Email:
    * Create/send
    * Check messages
    * Read (text-to-speech)
    * Delete
    * Reply
6. Print document
7. Console window for testing/troubleshooting

## Text Document
Virtual Morse operates in a simple text doc window. It is always working with the same text document file. Note: simple management of different files could be very beneficial but Josh does not desire that complexity. There is no “save-as”. The same document is opened each time. If it was saved with content, he can pick up where he left off and continue to add.  The cursor is always positioned at the end of the document. 
 
The current content of the document can be saved, cleared, printed, or emailed. The very first time the program is started, the text doc file will not exist (and the program will say "error reading file".) Once the page is saved the first time, the text doc is automatically created as "document.txt" in the C:\Users\user\Documents\Virtual Morse folder.  

If the document is cleared, there is a second confirmation required (Space for yes, Backspace for no).  Also, if the doc is actually cleared, the content is actually saved as a separate file and put in a "dumping ground" folder for recovery if needed. The files are named with a timestamp syntax and are located in the folder C:\Users\user\Documents\Virtual Morse\ClearedDocuments.

Note: Josh's workflow does not produce a very lengthy text doc within Virtual Morse.  He takes the content he has worked on for the session and "saves" it by either printing or more commonly be emailing to himself.  Later he works with a caregiver/editor to string together the work sessions' content into a larger document- his poems and novels.

_**Important: The text document window has to be the active window while using Virtual Morse.**_

## Switch Inputs
Virtual Morse monitors a COM port for status of the external switches. The Arduino conveys status of each switch by printing to serial (over USB) a corresponding number (#0-9 correlate to switches 1-10). Here are the switches and their functions:
- Switch 1 - Command: moves to command state. Pressed again moves to punctuation state. Pressed again moves back to typing state.
- Switch 2 - Shift: toggles capitalization.
- Switch 3 - Save: Saves current text document.
- Switch 4 - Space: either adds the current word or adds a space to the document.
- Switch 5 - Dot: adds a dot to the current letter.
- Switch 6 - Dash: adds a dash to the current letter.
- Switch 7 - Enter: adds current letter to the current word.
- Switch 8 - Backspace: deletes current letter and last entered character.
- Switch 9 - Command: moves to command state.  Pressed again moves to punctuation state. Pressed again moves back to typing state.
- Switch 10 - Same as Switch 9. _This switch is redundant and not used in the new layout._

## Working with Text
### Morse Code Input
All text creation is through Morse Code inputs via the Dot and Dash switches.  Here is the text creation process (assuming the text doc window is open and cleared):
1. Dot and Dash switches are pressed to create the Morse code string of an intended letter.  For example, Josh would “type” • • — for the letter ‘u’.  At this point, nothing is in the text doc- just a string of Dots and Dashes stored in memory. The console, however, does show the current letter being built up via dots and dashes.
2. Once the Morse string for a given letter is complete, Switch 7 (SW-7) is pressed to “enter” the letter.  This triggers the program to look up the Dot/Dash string to see what letter or symbol it represents.  The matching English text letter or number or punctuation is then added, virtually, to the word being formed- but still not on the page and the program speaks the letter out loud.  If there is no match for the Morse string that was entered the program speaks “Try again” and clears the string to start over. If a letter is successfully entered and SW-7 is pressed again the previous letter will be entered again as a shortcut to not have to input via Morse.
3. After “entering” the letter, another Dot/Dash Morse sequence is typed for the next letter, with SW-7 adding it to the current word, and so on.  Once all the letters of a word are complete, the word is added to the page using the Space switch, SW-4.  At that time the text-to-speech feature automatically reads aloud the word being added.  

So the process to enter “uaf” for example would be:
1.	• • —
2.	SW-7
3.	• —
4.	SW-7
5.	• • — •
6.	SW-7
7.	SW-4

The program holds a Morse code library for A-Z, 0-9, and punctuation: .,?/!';:-_()@.  Note that the @ symbol has a custom code of ..--
### Punctuation
The above punctuation can be added via Morse code, but the code is lengthy.  A big improvement in Virtual Morse 2023 is Punctuation Mode.  If a Command switch (1,9, or 10) is pressed twice, the system enters Punctuation Mode.  From there, switches 2-8 can be pressed a single time for:
- SW-2 - Single Quote/apostrophe '
- SW-3 - Double Quote "
- SW-4 - Exclamation Mark !
- SW 5 - Period .
- SW 6 - Comma ,
- SW 7 - Question Mark ?
- SW 8 - Hyphen -
### Capitalization
Pressing Shift (SW-2) toggles on capitalization.  After a letter is entered or if Shift is pressed a second time it automatically resets.
### Spacing
SW-4 adds the current built word to the page.  If the word is completed and a new one has not yet been started, SW-4 adds a space and the programs speaks “space.”  So usually one is typing SW-4 twice when completing a word (once to add the word and once to add a space after the word.)  
### Backspace/Delete
If no current word is being built (no letters yet added to a word) then SW-8 performs a traditional backspace and the program speaks “Back Space.”  If there is a word in progress, SW-8 deletes the last letter entered and the program speaks “Delete.”
### Enter/Return
There is no enter or return feature.  Note that one can use the normal keyboard and enter text in parallel with any activity from Morse input from the switch. Josh does not have a use for this himself but a caregiver or someone helping him edit might use that feature.
### Readback
The program can read aloud the entire document (by typing ttt) or just the last sentence by typing Command + l.

Note: The typing sequence for Command Mode using letters (such as Command + l) is as follows.  Type the Morse string for that letter, then presses the Command Mode switch, then presses the Letter Enter switch, SW-7.

## Email
### Check Email
Command + g connects to a gmail account and announces how many unread and total emails are in the inbox.  To navigate some of the other email functions, an index number of a particular email is needed.  The oldest email starts at #1, counting up through the newest email.
### Delete Email
Command + d deletes an email.  First the index number of the email is entered via Morse, then the letter d (but not entered via SW-7), then Command, then SW-7 to execute on the letter d.
### Read Email Header
Command + h reads the header info from a particular email. First the index number of the email is entered via Morse, then the letter h (but not entered via SW-7), then Command, then SW-7 to execute on the letter h. Hearing the header info identifies which email is associated with which index number and also quickly screens if an email is worth reading. At any point during the readback, pressing any switch will cancel the text-to-speech readback.
### Read Email
Command + r is exactly the same as Read Email Header, above, except also reads the contents of the email.
### Reply to Email
Command + y replies to a particular email. Same as above, the index # of the email to be replied to is entered, then the Command + y sequence. However, the content of the email reply needs to already be entered into the text doc. Once the reply command is executed, the contents of the text doc will be sent as a reply to the given email-but first they system asks for an "are-you-sure" confirmation (space for yes, backspace for no) to doublecheck you have the correct recipient for the message. This email reply function is a big improvement in Virtual Morse 2023. A further improvement would be to set the reply based on the last email read as opposed to needing the index # of that email.
### Address Book
To make it easier to send email, an address book feature lets you save a nickname and an associated email address. The input of that info into the address book can be done through Virtual Morse, or by directly opening a .csv file (see additional instructions page.) Note that the .csv file cannot be open when trying to use it through Virtual Morse. If writing to the .csv file fails, the program will speak "Failed to add..."

The Virtual Morse input process is:
1. Enter a nickname. The nickname 'word' is built by entering letters via Morse, but the word is not entered to the page (via SW-4). Then the letter n is built via Morse (but not yet entered via SW-7). Then Command, then SW-7. This stores the nickname to memory.
2. Enter an email address. Same process as above, except the content is the address and the command letter is 'a'. That adds the address to the nickname in memory and the pair get added to the address book .csv file. Note: if the same nickname gets added to the address book in the future with a new address, the system uses the most recent entry when that nickname is called on.  
  
Once the first address book entry is completed, the program automatically creates the AddressBook.csv file located in the C:\Users\user\Documents\Virtual Morse folder.
### Create/Send email
Command + e is used to send email. First the content of the email is written to the text doc. Then the recipient is written (but not "entered" to the page via SW-4.) The recipient info can either be an email address or it can be a previously stored nickname. Then Command, then SW-7 executes the send command.
### Email Account Info
Email account info is input manually during installation into the .env file.  Username (for a gmail account), sender display name, and an app-specific password are entered.  The app password needs to be generated from the google account.
## Printing
The content of the text doc can be printed using Command + SW-2 (SW-2 per the new layout, SW-1 for Josh's legacy switch. Either way the program sees the input as SW-2.)  The name of the printer is setup in the .env file (see README install instructions.) If the print command (Cmd + SW-2) fails, a list of the available printer names will be output to the console.
## Console Window
Whenever Virtual Morse 2023 runs, two windows open: One is the text doc window and the other is the console. The console displays the work in progress, such as Morse character concatenation, the current word being built, and status of commands being executed. The user does not rely on what is being displayed in the console but it is very helpful for testing/troubleshooting. The console is a great improvement in this version.  
 
Here is a snapshot of the console display as the word "hello" is being added to the page:  

<img src="https://github.com/larueben/virtual-morse/blob/main/docs/pictures%20and%20sketches/console%20snapshot.png" width="300">

The first block of the console records the last of the three Morse dashes being input to create the letter 'o' in hello. The letter 'o' hasn't yet been "entered" to the word via SW-7.  
The second block is displayed after SW-7 was pressed to add 'o' to the end of 'hello'. Notice the 'current letter' field is reset.  
The third block shows after SW-4 was pressed to add the word 'hello' to the text doc. Notice the 'current word' field is reset.  
## Misc. Items
* At program startup, it speaks “Virtual Morse” then the version number.
* For testing/troubleshooting, the keyboard F keys are programmed as a parallel set of inputs to match the switches.
* The program is meant to be always active, including automatically restarting if the machine is restarted. (See README installation instructions.)
* If someone happens to type with the regular keyboard it adds text in parallel to the switch input device.  This is not a necessary feature, just how it currently works and potentially helpful for testing or editing by an assistant.
* If in Command mode and a switch is pressed that isn't setup for a specific command the program speaks "That command is not programmed" and resets back to typing mode.