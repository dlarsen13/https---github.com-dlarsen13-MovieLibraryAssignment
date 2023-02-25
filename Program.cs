﻿string dir = Directory.GetCurrentDirectory();
List<string> movieData = new List<string>();
bool menuQuit = false;
// Putting the reading of the data into a try block so it doesn't immediately crash if file is not found
try {
    StreamReader sr = new StreamReader(dir + "\\ml-latest-small\\movies.csv");
    // Reading through the first line to remove the formatting line at top of the file
    sr.ReadLine();
    while (sr.Peek() >= 0){
    // Reading current line of file and splitting on the comma to get all 3 pieces of data
    string currentLine = sr.ReadLine();
    string[] splitLine = currentLine.Split(",");
    // Checking if movieID provided by the .csv file already is in list to avoid duplicate entries
    if (movieData.Contains(splitLine[0])){
        continue;
    }
    movieData.AddRange(splitLine);
}
}
// catch block for file not found errors
catch (FileNotFoundException){
    Console.WriteLine("File not found");
    Console.WriteLine("Please enter the filepath to movies.csv");
    string filePath = Console.ReadLine();
    getFileData(filePath, movieData);
}

// Printing the visible menu choices
while (!menuQuit){
    Console.WriteLine("Please enter 1 to view the current entries of the movie library, 2 to add an entry. or 3 to exit");
    
}



// Method to parse data in catch block with recursion to ensure file is found before proceeding
static void getFileData(string filePath, List<String> list){
    bool fileFound = false;
    while (!fileFound){
        try {
        StreamReader sr = new StreamReader(filePath);
        // Reading through the first line to remove the formatting line at top of the file
        sr.ReadLine();
        while (sr.Peek() >= 0){
            // Reading current line of file and splitting on the comma to get all 3 pieces of data
            string currentLine = sr.ReadLine();
            string[] splitLine = currentLine.Split(",");
            // Checking if movieID provided by the .csv file already is in list to avoid duplicate entries
            if (list.Contains(splitLine[0])){
                continue;
            }
                list.AddRange(splitLine);
            }
            fileFound = true;
        }
        catch{
            Console.WriteLine("File still not found, please check the file path and try again");
        }
    }
}