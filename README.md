
# WordCount

Welcome to WordCount. The Web Application that can take in a book and return the top 100 words with a nice pie graph. 

## Project Layout - MVC
 - Controller
	 - HomeController.cs
 - Models
	 - Countword.cs
	 - Stopword.cs
 - Views
	 - Index
	 - WordCount
 - Files
	 - stop-word.txt
	 - mobydick.txt
	 - testFile.txt

## Logic/Design

 Design has 1 controller that does all the calls to models. This **IActionResult WordCount** will first create the StopWord hashSet and pass that onto Countword which creates a Dictionary of all the words in the book while excluding any word found in StopWord. Once that dictionary is created it passes it onto the model for processing and displaying.

**CountWord CreateString** is the helper method that creates the Dictionary inside CountWord. It reads the file and uses a regex pattern to find all the words without any special characters, except for -_ and '. Though because of some technical problems within the book itself, a catch was created to make sure ' was not added to the dictionary. One the a word is matched, it verifies that it doesnt already exist in the dictionary and adds it and sets the value to 1. If it already exists, it increases the value by 1. 

The View page WordCount, takes in the Model, and restructures it in descending order, then only passes on the top 100 words used. From here we pass the information to a JavaScript Pie, and to a List to show all the words and their values. 

## Potential Problems
My Count returns Whale at 910 times. But using things like Notepad++, and Google Docs, along with sites like https://roadtolarissa.com/whalewords/ and of course google. Problem I've come to find out is that my count is smaller then others. But at the same time I can verify that my count is not accurate as I can't validate how the whalewords site validates words, and on Notepad++/Google Docs, they will count words like. WhaleMan as whale even though I ask for exact.

## Testing
I contemplated making a second project to create Unit Tests for my Controller/Model but I decided against it under the pretext that I had been manually testing my code as I went through. The Unit tests would be beneficial if I could prove that the methods used were accurate but because my own tests would just be handcrafted to past the best I could show was that the Functions worked as intended but would not prove that the Functions were accurate. As such I decided to ignore basic Unit Testing and Integration Testing. 

## Sources
https://www.chartjs.org/docs/latest/
