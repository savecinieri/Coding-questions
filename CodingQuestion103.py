'''
This problem was asked by Square.

Given a string and a set of characters, return the shortest substring containing all the characters in the set.

For example, given the string "figehaeci" and the set of characters {a, e, i}, you should return "aeci".

If there is no substring containing all the characters in the set, return null.
'''


inputString = 'arteyueo'#'figehaeci';
chars =   ['e', 'e']#['a', 'e', 'i'];
fromCharsToString = '';
for el in chars:
    fromCharsToString += el;

lenChars = len(chars);
print("Input string has ", len(inputString), " characters");
print("There are ", lenChars, " characters in ", fromCharsToString );

minimumLenght = len(inputString) + 1;
solutionFound = False;

end_ = lenChars;
while(solutionFound == False and end_ <= len(inputString)): #writing <= we take the last element of the string
    start = 0;
    end = end_;
    while (end <= len(inputString)):
        tmpString = inputString[start : end];
        #print(tmpString, " last index is ", end)
        tmpChars = chars.copy();
        if (len(tmpString) == len(fromCharsToString) and tmpString == fromCharsToString):
            print("Solution found: the shortest substring containing all the chars is ", tmpString);
            solutionFound = True;
            minimumLenght = len(tmpString);
            break;
        else:
            #inside this string I check if there are all the characters
            trov = 0;
            tmpUpdatedString = '';
            for tmpChar in tmpString:
                if (tmpChar in tmpChars):
                    tmpUpdatedString += tmpChar;
                    tmpChars.remove(tmpChar);
            if (len(tmpUpdatedString) == len(fromCharsToString) and tmpUpdatedString == fromCharsToString):
                print("Solution found: the shortest substring containing all the chars is ", tmpString);
                solutionFound = True;
                minimumLenght = len(tmpUpdatedString);
                break;

        start += 1;
        end += 1;
    end_ += 1;

if (solutionFound == False):
    print("Solution not found.");
    