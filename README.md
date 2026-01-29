https://github.com/user-attachments/assets/ccda8d02-9369-4b14-9e1c-9a24c9b76c23

 
Recreated the classic arcade action game (Metal Slug) in 2D style (Run and Gun) developed in the Unity Engine.

    This game is capable of storing and displaying a lot of information simultaneously. Lots of animations, exaggerated explosions, lots of on-screen elements and big enemies.
 
NOTE: When uploading all the files for this project, the file size limit set by GitHub was exceeded. GitHub imposes a file size limit of 100 MB for Git repositories.
 
    To solve this problem, I used Git LFS (Git Large File Storage):

    Git LFS is a Git extension that allows you to store large files on external servers, such as Git LFS itself or cloud storage services.

I will provide an example of how Git LFS was used for the "Library" and "Assets" folders in this project, along with a sample text instructing people on how to install the necessary libraries and configure the "Library" and "Assets" folders.

Git LFS was configured to track files in the "library" and "assets" folders and store them externally.

    //Inicializar o Git LFS
    git lfs install 

    //Rastrear a pasta "Library" e "assets" 
    git lfs track "libary/*" 
    git lfs track "Assets/*" 
    
This project requires some libraries to function correctly. Follow the steps below:

Prerequisites

    Make sure you have the following libraries installed on your system:

    - Biblioteca Assets
    - Biblioteca Libary

Folder configuration "Libary"

    1. Clone this repository to your system.
    2. Navigate to the project's "library" folder: `cd Library`.
    3. Install the dependencies in the "library" folder by running the following command: `npm install` (or use the appropriate package manager).

Running the project

    Now that you have installed the necessary libraries and configured the "Library" folder, you are ready to run the project. Follow the steps below:

    1. Open the terminal and navigate to the project root.
    2. Run the command `npm start` to start the project.

    Repeat the procedure for the "Assets" folder.
    

 
 
   
 
 
