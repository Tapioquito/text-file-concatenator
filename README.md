# text-file-concatenator

### This is a simple .txt file concatenador;

### Made using C# (.NET 6.0);

### It reads all .txt files in the folder, group them by company name (DANAMED, BRADESCO, DANADEP, BRADESCODEP);

### Then it creates a folder and company specific subfolders (one for each company) with the date of the previous day (client asked for it);

### It then writes with streamwriter a new .txt file concatenating all files from the specific company and inserts it in it's determined folder;

### It also copies all files from the main folder and pastes them in their specific subfolders, so everythings gets really organized;

### The text encoding is ANSI by client's request, but it was UTF-8 in it's previous version;

### This version can be used in Google Drive without consuming Google's API;
