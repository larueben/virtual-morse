
# Overview
Virtual Morse is an assistive technology system for writing and communicating written text. It was custom built for a user with a particular combination of impairments following a brain injury. The user is legally blind, unable to speak clearly and without motor control or dexterity to operate keyboards or many other computer interfaces.  

The core of the program is to allow the user to write to a simple text document. From there, the user can carry out basic text document operations like save, clear and print. There is also a suite of email functions, allowing the user to check, read, delete, or create and send emails. Feedback to the user is through text-to-speech and other spoken announcements based on what operations are performed.

The system has three main parts: 
1. The switch device activated by the user.  
2. An interface to convey the switch inputs to the computer.  
3. The Software to convert the inputs and manage the text doc functions.

## 1. Switch Device
The current switch interface device is akin to a harmonica with ten buttons on the face that activate microswitches within the device.  Josh uses his tongue to activate the different buttons.  The device is on a stand fixed to a desk.  

Input to the system is via custom switch device operated by the user's tongue. Written text is input through Morse code (using separate dot and dash switches). Additional switches on the device allow for Shift, Save, Space, Backspace, and activating special "command" modes.

Here is a picture of the existing device:

<img src="https://github.com/larueben/virtual-morse/blob/main/docs/pictures%20and%20sketches/Legacy%20Switch%20Device.png" width="1200">

A new 9-button layout is being developed with different shaped buttons and a slightly different layout. Here is a picture of the new layout:

![This is a picture of the new 9-button layout](https://github.com/larueben/virtual-morse/blob/main/docs/pictures%20and%20sketches/New%20switch%20layout9.jpg)

Below is a sketch showing Josh’s existing switch layout with the new layout for Jed’s switch device.  For Virtual Morse 2023, the switches are identified in order left to right, and according to Jed’s layout.  Note SW-1 and SW-2 are reversed between Jed’s device and Josh’s existing device.  This has been accounted for in the conversion patch cable wiring.  When Josh presses his existing SW-1 (SHIFT), Virtual Morse 2023 sees it as SW-2, which is SHIFT in the new layout.  His existing SW-2 (COMMAND) is seen by Virtual Morse 2023 as SW-1, which is COMMAND in the new layout.

Here is a sketch showing the function of each button between the old and new layouts:

![Switch layouts sketch](https://github.com/larueben/virtual-morse/blob/main/docs/pictures%20and%20sketches/Switch%20devices%20layout%20sketch.png)
The existing switch uses a DB-25 cable connection to connect to the USB interface.  The original interface was a gamepad controller.  For Virtual Morse 2023 an Arduino is used to interface the switch to the PC via USB.  To facilitate testing the new system with the original switch device, the DB-25 cabling approach has been retained.

The legacy pinout wiring to each of the 10 switches to the DB-25 connector is not straightforward at all.  The new pinout wiring scheme has Switch 1 (SW-1) wiring to pinouts 1,2; SW-2 to pinouts 3,4; etc.  In order to leave the existing switch as-is but still be able to use it for testing the new system, a converter cable was made to reconcile the wiring differences.  This is only needed for connecting the old switch device to the new system.  Once Josh is using the new switch the converter cable is not needed.

Below is the pinout wiring for the legacy switch device connector followed by the pinout wiring for the converter cable:

![legacy switch pinouts](https://github.com/larueben/virtual-morse/blob/main/docs/pictures%20and%20sketches/Legacy%20switch%20pinout.png)

![converter cable pinout diagram](https://github.com/larueben/virtual-morse/blob/main/docs/pictures%20and%20sketches/Jack-to-Jed%20cable%20pinouts.png)

## 2. Switch to PC Interface - Arduino

#### <ins>Arduino Interface Overview</ins>

The interface between the switch device and the computer is an Arduino Uno.  The Arduino's entire job is to convert individual switch closures on the external switch device into signals the Virtual Morse Software on the PC can recognize via USB connection.  Each switch is wired to a separate digital input pin on the Arduino.  The Arduino in turn prints to the serial port a number corresponding to each switch: 0-9 correlate to switches 1-10.

For this project, besides the Arduino we needed a way to transition from a DB-25 cable connector and hopefully enclose everything neatly.  Below are two pictures of the solution:

![Arduino assembly 1](https://github.com/larueben/virtual-morse/blob/main/docs/pictures%20and%20sketches/Arduino%20Assembly%201.jpg)

![Arduino assembly 2](https://github.com/larueben/virtual-morse/blob/main/docs/pictures%20and%20sketches/Arduino%20Assembly%202.jpg)

From left to right you see:  
* DB-25 cable end
* DB-25 breakout board from Winford Engineering.  Winford.com, p/n BRKSD25.
* Prototyping breadboard- used to manage common connection for ground leads.  From Adafruit.com, p/n 4539.
* Arduino Uno.

The enclosure from Protostax worked out very well.  One enclosure specifically for Arduino footprints and one generic for breadboards, etc. stacked end-to-end.  Protostax.com.

#### <ins>Arduino Interface Wiring</ins>

* The Arduino takes the status of the switches in Josh’s device as inputs and reports their status to Virtual Morse via serial communication over the USB connection.  
* The input terminals (or pins) are switched to ground by the physical switches in Josh’s device.
  * Pins 2-11 are used for the 10 switch inputs.  Pins 0 and 1 are reserved for serial communication and not available for switch inputs.
  * Internal to the Arduino chip, each input is anchored to +5V via resistors.  They have to be anchored or they will flutter erratically if long wires are connected (acting like antennae).  The inputs have floating potential otherwise.  Since they are tied to 5V, each input reads HIGH (or ON) when the switch is open or not pressed.  The Arduino programming inverts the logic for each switch.
*The wiring diagram for a typical switch looks like this:
 
<img src="https://github.com/larueben/virtual-morse/blob/main/docs/pictures%20and%20sketches/Arduino%20typical%20switch%20wiring.png" width="300">

#### <ins>Arduino Programming</ins>
* The C++ style programming for the Arduino is uploaded/flashed to the Arduino and saved as a .ino file.  
* There is not a way to “read” nor download the program or .ino file on an Arduino, just a way to reflash with a new program.
* The goal of this Arduino program is simply to take switch inputs and report them over the USB connection to be used by the Virtual Morse program.  There are a lot of way to accomplish this, but the salient features required are:
  * Inputs 2 through 11 used for switches 1-10, respectively.
  * Input pins configured as INPUT_PULLUP (using internal resistors tied to 5V).
  * When each switch is pressed, the Arduino “prints” to serial a number.  The numbers correspond to the order of the inputs in an array.  Switches 1 through 10 report the numbers 0 through 9, respectively.  (The info it prints is arbitrary- but Virtual Morse has been programmed to expect 0-9 to indicate the switches.)
  * The Arduino needs to report the number corresponding to the switch once and only once per each time the switch is pressed.  This takes some conditioning in the programming- otherwise there is a tendency for it to print multiple times, erratically, per each switch press.
  * The serial communication needs to be set for 9600 baud.
* You can verify how the switches are working with the Arduino by using the Arduino IDE.  Turn on the Serial Monitor.  When each switch is pressed, the corresponding number (0-9) should be printed to the serial monitor.  Note: you have to close the IDE so Virtual Morse can read the data from the Arduino.

#### <ins>Arduino Power</ins>
* The Arduino has a port for an external power supply but can also be powered by the USB connection- which is how Josh’s is powered.
* If the power is lost / USB unplugged the Arduino retains its program and settings.



## 3. Virtual Morse Software

The program is written in C# and uses .NET framework.  The email integration is via MailKit.  The program provides a simple text doc window where the text generation occurs.  There is also always an active console window helpful for troubleshooting and testing, though the user does not interact with or need any of the console-displayed info to operate the system.

See the Program Functions Wiki page for in-depth program info.