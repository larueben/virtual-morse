# virtual-morse

## Description

Virtual Morse is an assistive technology system for writing and communicating written text. It was custom built for a user with a particular combination of impairments following a brain injury. The user is legally blind and without motor control or dexterity to operate keyboards or many other computer interfaces.  

The core of the program is to allow the user to write to a simple text document. From there, the user can carry out basic text document operations like save, clear and print. There is also a suite of email functions, allowing the user to check, read, delete, or create and send emails. Feedback to the user is through text-to-speech and other spoken announcements based on what operations are performed.

The system has three main parts: 1. The switch device activated by the user; 2. An interface to convey the switch inputs to the computer; 3. The program to convert the inputs and manage the text doc functions.

Input to the system is via custom switch device operated by the user's tongue. Written text is input through Morse code (using separate dot and dash switches). Additional switches on the device allow for Shift, Save, Space, Backspace, and activating special "command" modes.

The interface between the switch device and the computer is an Arduino Uno.  Each switch is wired to a separate digital input pin on the Arduino.  The Arduino connects to the computer via USB.

The program is written in C# and uses .NET framework.  The email integration is via MailKit.  The program provides a simple text doc window where the text generation occurs.  There is also always an active console window helpful for troubleshooting and testing, though the user does not interact with or need any of the console-displayed info to operate the system.

*Please see the Wiki for a complete description of the system including all of the program features and an operating instructions.*

## How to Install

### Download from (?)

### Folder to install to (?)

### Port Settings

### .env

- location
- settings

### Auto run


## Credits


## License

## What's new this version


