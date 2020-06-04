# WordCount
Intial design idea:
	Application will have 2 models, 1 controller and 2 view pages. 
	The Models will be StopWord, and CountWord.
		StopWord will take in the stop-word.txt file, and create a hashset of all the words from the file. O(n)
		CountWord will take in the book, and the hashSet from StopWord. 
			CountWord will create a Dictionary set that will have Word and Value.
			It will parse the book to a string. Know the book has something over 9000 words this will be a very large string. 
			String will then be looped through O(N)
				Loop will check words to see if it exist in hashSet
					If doesn't exist, it will check to see if it is in Dictionary
						If it is, it will increase the Value by 1. 
					else
						it will add it to the Dictionary and set value to 1.'
	Once parsing is done, it will return that model to the controller where the controller will send to View
	View will then show results. 