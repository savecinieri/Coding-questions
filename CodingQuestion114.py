'''
This problem was asked by Facebook.

Given a string and a set of delimiters, reverse the words in the string while maintaining the relative order of
the delimiters. For example, given "hello/world:here", return "here/world:hello"

Follow-up: Does your solution work for the following cases: "hello/world:here/", "hello//world:here"
'''

inputString = "hello/world:here/";#"hello//world:here";#
delimitersList = ["/", ":", ".", "-"];

words = list();
delimiters = list();
tmpWord = "";
for tmpChar in inputString:
    if tmpChar in delimitersList:
        #print("find: ", tmpWord);
        # the main idea is to merge two delimiters with NO words between them
        if (tmpWord == ""):
            delimiters[len(delimiters) - 1] += tmpChar;
        else:
            words.append(tmpWord);
            tmpWord = "";
            delimiters.append(tmpChar);
        #print("find del: ", tmpChar);
    else:
        tmpWord += tmpChar;
if (tmpWord != ""):
    #print("find: ", tmpWord);
    words.append(tmpWord);
#hello world here
#/ :

print(words);
print(delimiters);

finalString = "";
for i in range(-1, (-1 * len(words)) - 1, -1):
    #print(i, "  ", (i * -1) - 1);
    #print("- ", words[i]);
    finalString += words[i];
    if (((i * -1) - 1) < len(delimiters)):
        finalString += delimiters[(i * -1) - 1];
print(finalString);

