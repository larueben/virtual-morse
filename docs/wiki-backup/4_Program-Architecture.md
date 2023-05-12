# Functional Diagrams
## Overall Architecture
![diagram1](https://github.com/larueben/virtual-morse/blob/main/docs/pictures%20and%20sketches/Software%20diagram1.png)
## Typing State
![diagram2](https://github.com/larueben/virtual-morse/blob/main/docs/pictures%20and%20sketches/Software%20diagram2.png)
## Command State
![diagram3](https://github.com/larueben/virtual-morse/blob/main/docs/pictures%20and%20sketches/Software%20diagram3.png)
## Punctuation State
![diagram4](https://github.com/larueben/virtual-morse/blob/main/docs/pictures%20and%20sketches/Software%20diagram4.png)

# Source Code File Structure
```
.
├── docs
│   ├── Josh_Arduino_Board_final.svg
│   ├── TESTING.md
│   └── virtual-morse-2023-architecture.svg
├── .gitignore
├── .env.sample
├── LICENSE
├── README.md
└── src
    ├── Arduino_INO_Files
    │   └── josh_board
    │       └── josh_board.ino
    └── VirtualMorse
        ├── App.config
        ├── Function.cs
        ├── Input
        │   ├── ArduinoComms.cs
        │   ├── FunctionKeyInput.cs
        │   ├── InputSource.cs
        │   ├── Switch.cs
        │   └── SwitchInputEventArgs.cs
        ├── packages.config
        ├── Printer.cs
        ├── Program.cs
        ├── Properties
        │   └── AssemblyInfo.cs
        ├── Speech.cs
        ├── States
        │   ├── CommandState.cs
        │   ├── ConfirmationState.cs
        │   ├── PunctuationState.cs
        │   ├── State.cs
        │   └── TypingState.cs
        ├── VirtualMorse.csproj
        ├── VirtualMorse.sln
        └── WritingContext.cs
8 directories, 28 files
```