https://github.com/user-attachments/assets/ccda8d02-9369-4b14-9e1c-9a24c9b76c23

 
Recreated the classic arcade action game (Metal Slug) in 2D style (Run and Gun) developed in the Unity Engine.

    This game is capable of storing and displaying a lot of information simultaneously. Lots of animations, exaggerated explosions, lots of on-screen elements and big enemies.

    The game also has its style of humor that makes even enemy deaths a little comical.

    Implemented the use of Object Pooling (creation design pattern) to optimize my project and deal with markers that are being instantiated frequently.
 
NOTE: When uploading all the files for this project, the file size limit set by GitHub was exceeded. GitHub imposes a file size limit of 100 MB for Git repositories.
 
    To solve this problem, I used Git LFS (Git Large File Storage):

    Git LFS is a Git extension that allows you to store large files on external servers, such as Git LFS itself or cloud storage services.

I will provide an example of how Git LFS was used for the "Library" and "Assets" folders in this project, along with a sample text instructing people on how to install the necessary libraries and configure the "Library" and "Assets" folders.
Foi configurando o Git LFS para rastrear os arquivos na pasta "libary", "assets" e armazená-los externamente. 

    //Inicializar o Git LFS
    git lfs install 

    //Rastrear a pasta "Library" e "assets" 
    git lfs track "libary/*" 
    git lfs track "Assets/*" 
    
Este é o meu projeto requer algumas bibliotecas para funcionar corretamente. Siga as etapas abaixo:

    ## Pré-requisitos

    Certifique-se de ter as seguintes bibliotecas instaladas em seu sistema:

    - Biblioteca Assets
    - Biblioteca Libary

    ## Configuração da pasta "Libary"

    1. Clone este repositório em seu sistema.
    2. Navegue até a pasta "libary" do projeto: `cd Libary`.
    3. Instale as dependências da pasta "libary" executando o seguinte comando: `npm install` (ou use o gerenciador de pacotes apropriado).

    ## Executando o projeto

    Agora que você instalou as bibliotecas necessárias e configurou a pasta "Libary", você está pronto para executar o projeto. Siga as etapas abaixo:

    1. Abra o terminal e navegue até a raiz do projeto.
    2. Execute o comando `npm start` para iniciar o projeto.

    Isso é tudo! Repita o procedimento para a pasta "Assets"
    

 
 
   
 
 
