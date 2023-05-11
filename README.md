# virtual-morse

## Description

Virtual Morse is an assistive technology system for writing and communicating written text. It was custom built for a user with a particular combination of impairments following a brain injury. The user is legally blind, unable to speak clearly and without motor control or dexterity to operate keyboards or many other computer interfaces.  

The core of the program is to allow the user to write to a simple text document. From there, the user can carry out basic text document operations like save, clear and print. There is also a suite of email functions, allowing the user to check, read, delete, or create and send emails. Feedback to the user is through text-to-speech and other spoken announcements based on what operations are performed.

The system has three main parts: 1. The switch device activated by the user; 2. An interface to convey the switch inputs to the computer; 3. The program to convert the inputs and manage the text doc functions.

Input to the system is via custom switch device operated by the user's tongue. Written text is input through Morse code (using separate dot and dash switches). Additional switches on the device allow for Shift, Save, Space, Backspace, and activating special "command" modes.

The interface between the switch device and the computer is an Arduino Uno.  Each switch is wired to a separate digital input pin on the Arduino.  The Arduino connects to the computer via USB.

The program is written in C# and uses .NET framework.  The email integration is via MailKit.  The program provides a simple text doc window where the text generation occurs.  There is also always an active console window helpful for troubleshooting and testing, though the user does not interact with or need any of the console-displayed info to operate the system.

*Please see the Wiki for a complete description of the system including all of the program features and an operating instructions.*

## How to Install
*Note: Some of the below instructions are specific to the original intended user, such as items related to connecting cable types and shortcuts. Also, a new user testing this program does not even need an external switch device or associated Arduino interface as the function keys can be used in lieu of external switches.*
### Virtual Morse Software
1. Download latest release (.zip file) from the Github repository.
2. Unzip folder and locate as desired.
3. Setup/update/test the Arduino (interface between external switch and PC) if needed. *See Arduino guide, below.*
4. In the Virtual Morse software folder, open the .env file using Notepad.  
	- Change the field *GMAIL-USERNAME-ONLY* to the gmail username of the email account to be used with Virtual Morse.
	- Change the field *APP-SPECIFIC-PASSWORD* to the app password allowing Virtual Morse to use the email account (setup app-specific password through Goggle account.)
	- Change the field *FirstName LastName* to whatever you want displayed as a sender name for email.
	- Change the field *MyPrinter* to the name of your printer.
	- Save and close the .env file.
	- Make sure the file type of .env is recognized as an ENV file.
5. Create two shortcuts of the Virtual Morse application file.
	- Place one shortcut on the desktop.
	- Place the other shortcut in the startup folder so the program automatically runs on startup.
	(Use Windows key + R for the command prompt and enter shell:startup to open the startup folder.)
### Arduino Setup/Update/Test (if needed)
1. Connect the switch device to the Arduino enclosure with the DB-25 cable.
	- If using the legacy 10-button switch device, connect the switch device to the Jack-to-Jed patch cable, then to the regular DB-25 cable to the Arduino.
		- Note the labels for properly orienting the direction of the patch cable.
		- Do not connect through the gender changer used in the legacy system.
2. Connect the Arduino to the PC with a USB-B cable.
3. Open the Arduino .ino file provided in the Virtual Morse software folder. This should open up the Arduino IDE (assuming this has already been installed.)  Note this is slow to open- be patient.
4. In the Arduino IDE, use the dropdown to confirm you are connected to the Arduino, and that it is through COM4. If it is not connecting through COM4 you will need to change it through Device Manager as follows:
	- In Device Manager, go to Ports (COM & LPT)
	- Open the Arduino port, go to Port Settings, Advanced.
	- Try changing to COM4.  Might need to delete and/or uninstall drivers for Arduino port(s) and/or restart Arduino IDE to get change to COM4 to take.
5. With Arduino connected to COM4, upload program to Arduino (circle with and arrow pointing to the right.)
6. Open Serial Monitor (if there is not already a Serial Monitor tab available at the bottom of the code window) by selecting the icon in the top right of the code window.
7. Press switches 1-9 of a new switch device (or 1-10 on Josh's legacy switch).
	- The serial monitor should display the numbers 0-8 corresponding to switches 1-9 (or 0-9 corresponding to switches 1-10 if using a 10-switch device.)
	- Each number should be printed to serial once and only once for each switch press, regardless of how long the switch is pressed.
	- *Note: on Josh's legacy switch device, switches 1 and 2 will be reversed.  That is, SW-1 will report the number 1 and SW-2 will report the number 0.  SW-3 through SW-10 will report 2-9 as intended. The SW-1/2 reverse is intentional and needed to reconcile the legacy layout with the new layout going forward.
	- As a troubleshooting aid, anytime a switch is pressed you should see an LED light up on the Arduino.  This LED is labeled 'L' and located next to Pin 13.
8. Close the Arduino IDE to use Virtual Morse.	


## Credits
The original Virtual Morse system was conceived of and named by Josh LaRue in the mid-1990's. An inventor named Tom in the Cambridge, OH area built the first switch device and helped Josh with some ways to incorporate into a computer.
Jack LaRue developed the original software in collaboration with Josh in the late-90's, with continued imrpovements over the next 15 years. See https://github.com/jackdlarue/virtual-morse

Virtual Morse 2023 was a complete rebuild from scratch to work in a modern Windows environment and provide some much needed improvements. A team of four students studying Computer Science at the University of Alaska, Fairbanks (UAF) took the project on as a Senior Capstone class project. See https://github.com/andrewsng/assistive-technology  
Virtual Morse v2023.0.0 was completed May 4th 2023 by:
- Andrew Ng
- Jacob Jakiemiec
- Solomon Himelbloom
- Travis Winterton



## What's new this version
- The previous version of Virtual Morse operated in Wndows XP.  Version 2023 is compatible through Windows 11 and 
built with .Net Framework and using MailKit for email integration.
- Programmed in C#.
- The external switch device is interfaced to the PC through an Arduino as opposed to a gamepad controller.  The signals are numeric corresponding to the switches instead of gamepad signals.
- There is an additional command mode for punctuation shortcuts.
- Added safegaurd against clearing the screen by requiring confirmation.
- Additional document clearing safegaurd where each cleared document goes to a "dumping ground" folder for retrieval if needed.
- Email reply functionality was added.
- "New" email tracking when checking email has been removed (not relevant since the days of having to dial up and download email.)
- During readback of an email or most other announcements, text-to-speech readback can be stopped by pressing any switch, such as Space.
- Email address book is in an easily accessible .csv file and can be manually edited if needed.
- Streamlined test-to-speech readout of email header info.
- Specific user settings can be modified in an environment variables file, for email account and printer info.





