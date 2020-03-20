## Running The Projects (Visual Studio)

#### Console UI

Under the Src folder, set **ImageIntegration.ConsoleUI** as your startup project & run it. 

The console UI allows the user to retrieve images of mars from the NASA API & save them to their file system.
It will prompt you for a directory to save the images to (on your desktop). It can be a new directory or existing.
After, it reads the dates found in the "dates.txt" file and executes the process.


#### Web UI (Angular)
Under the Src folder, set **ImageIntegration.Api** as your startup project & run it.
NOTE: This should open on a secure connection (https) on localhost port 44304
Next, navigate to **ImageIntegration.WebUI/ClientApp.** You need to open a command prompt in this directory & run the following commands (you need npm/node.js)

- npm i
- ng serve -o

After Angular finishes compiling, it should automatically open a browser page. Here, you can enter a date range & view images from that day.