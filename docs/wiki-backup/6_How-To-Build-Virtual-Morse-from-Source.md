## How to build Virtual Morse from source code if needed
* Open Microsoft Visual Studio (2022)
* Select "Clone a Repository"
  * Under repository location, enter path for Virtual Morse Github repository, https://github.com/larueben/virtual-morse
  * Hit Clone
  * This will create the following folder structure: C:\Users\user\Source\Repos\virtual-morse
* Change the dropdown menu from "Debug" to "Release".
* Go to the Build menu, then select Build VirtualMorse (Ctrl+B).
  * This adds a folder called "Release" here: C:\Users\user\Source\Repos\virtual-morse\src\VirtualMorse\bin\Release
  * The contents of this release folder are all you need to run the application except for the .env file.
* Copy the .env.sample file from C:\Users\user\Source\Repos\virtual-morse and paste it into the Release folder.
## How to build a complete Release Package
* Complete the above steps.
* Copy the Arduino folder from C:\Users\user\Source\Repos\virtual-morse\src (or the most recent Arduino .ino file) to the Release folder.
* Copy the Wiki-backup folder from C:\Users\user\Source\Repos\virtual-morse\docs and add to the release folder.
* Make a copy of the Release folder, rename to Virtual Morse (and the latest version number) and create a .zip file.
* In the Github repository, go to releases, draft new release.
* Add a new tag or use one with the correct version #, like 2023.0.0.
*Write text for the release description.  At the bottom of that window (not in the binaries section) add the .zip file.
* Publish release.
