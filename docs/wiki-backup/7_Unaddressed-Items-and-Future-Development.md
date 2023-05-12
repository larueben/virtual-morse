# Unaddressed Notes and Questions during the v2023.0.0 development

This page lists certain notes and questions for the client that were unable to be addressed, as well as a few thoughts given to what steps could be taken if they were to be addressed.

## Notes

* There was some discussion about having email addresses read out letter by letter, but this has not been implemented.

  * Creating a Prompt that is spoken out letter by letter has been done before with reading out entered letters and punctuation, so the same method could be applied here if that becomes an issue.

* Hyperlinks in emails are read out in full.

  * This has partly been alleviated since the reading of emails can be cancelled. Going further with this might involve retrieving the HTML data from MailKit and trying to identify hyperlinks with that.

## Questions

* Should punctuation entered through the 2nd command mode fill the "last entered letter" used when repeatedly hitting Enter?

  * This seems like a good idea and consistent with the rest of Virtual Morse.  That is, if a Punctuation Mode shortcut key is used to add a punctuation symbol, should it be stored in memory as the last "letter" entered, where pressing SW-7 (letter enter) would add that same symbol again- similar to how it repeats previously added letters (as opposed to shortcut-generated punctuation symbols.)

* Should the "last entered letter" used when repeatedly hitting Enter respect capitalization from Shift?

  * This is probably not necessary.

* Currently, hitting Backspace while there is morse-in-progress will delete a letter from the current word or document, but keep the morse string. Should Backspace instead do nothing when there is morse-in-progress?

  * It might take some time using the system to see if the current behavior is bothersome, and if changes are needed.

# Future Development Ideas

* Email Reply: build an option to reply directly to the last email read, as opposed to having to identify the reply target with its email index number.
* Address Book: build and option for saving email address from last email read direct to the address book without having to enter it in manually.
* On program startup, have the text window and the console window automatically arranged so they do not overlap.
* Speech Synthesizer speed: there is a setting in the source code to adjust the speed of the text-to-speech synthesizer from -10 to +10. Add a variable for this that can be set/adjusted in the .env file instead of the source code.
* COM Port: the COM port expected to be connected to the Arduino is hard-coded as COM4. Add a variable to the .env file to designate the COM port.
## Major Development Areas
* Facebook integration.  Looking for a way to use Virtual Morse to navigate messaging on Facebook.  Suggest starting with Messenger app. Possible growing to be able to navigate/create posts/comments.
* Non-Facebook type messaging.  Use some sort of SMS test platform.  Most of Josh's correspondence currently done over email would be well suited for an SMS-type approach.