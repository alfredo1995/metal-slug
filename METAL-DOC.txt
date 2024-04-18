# MetalSlug

This game is capable of storing and displaying a lot of information simultaneously. A large amount of animations, exaggerated explosions, many on-screen elements and large enemies. The game also has its style of humor that makes even the deaths of enemies a little comical.

     NOTE: When uploading all the files for this project, you ended up exceeding the file size limit defined by GitHub. GitHub imposes a 100 MB file size limit for Git repositories.

     To solve this problem, I used Git LFS (Git Large File Storage):
     Git LFS is a Git extension that allows you to store
     large files on external servers, such as Git LFS itself or cloud storage services.

     I will provide an example of how Git LFS was used for the "Libary" and "Assets" folder in this project,
     along with sample text instructing people to install the necessary libraries and configure the "Libary" and "Assets" folder.

1st I configured Git LFS to track the files in the "libary", "assets" folder and store them externally.

    //Inicializar o Git LFS
    git lfs install 

    //Rastrear a pasta "Library" e "assets"
    git lfs track "libary/*" 
    git lfs track "Assets/*"
    
2° This is my amazing project that requires some libraries to work properly. Follow the steps below:

## Prerequisites

     Make sure you have the following libraries installed on your system:

     - Assets Library
     - Libary Library

     ## Configuration of the "Libary" folder

     1. Clone this repository to your system.
     2. Navigate to the project's "libary" folder: `cd Libary`.
     3. Install the dependencies from the "libary" folder by running the following command: `npm install` (or use the appropriate package manager).

     ## Running the project

     Now that you have installed the necessary libraries and configured the "Libary" folder, you are ready to run the project. Follow the steps below:

     1. Open the terminal and navigate to the project root.
     2. Run the `npm start` command to start the project.

     That is all! Repeat the procedure for the "Assets" folder
    
    



