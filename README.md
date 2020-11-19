# MathXML
Coding Assignment for Turn10

Notes:

•	The program can easily add more operations in the future by fleshing out the case statement.

•	Different formats can be achieved by calling the ParseJsonDocument function. 

•	An alternative approach would be to have one function called ParseFileToXml and check the extension of the file for different formats.

•	The given XML document had some invalid inputs, so instead of throwing exceptions and halting the program, I decided to output the error to the console.



Some other rooms for improvement could be:

•	Better error handling - There would be ways to implement more thorough parsing of input and better organization of the code related to error handling.

•	Could potentially parse the word "twenty" into an int, I have seen some code that implements it but its seemed overkill.

•	I could have tried to parse the values earlier on in the process as well, for instance right as I am creating the Operations objects during the Linq query.

•	If the user input for the description does not contain at least 2 elements ie <Description>Joe;</Description> or the input is out of order, it will completely break because the array at the index 1 will not exists or the name will get set to the operation variable.

•	I added a couple extra operations in the XML document to test negative numbers, division by zero(I didn’t know C# would output the infinity symbol(neat!), and the power operation. I would test more thoroughly if I had more time allotted. 

Final remarks:
Interesting assignment, I had never worked with parsing XML before and ended up learning a lot. I am eager to hear your feedback.
