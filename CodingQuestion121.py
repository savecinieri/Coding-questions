'''
This problem was asked by Google.

Given a string which we can delete at most k, return whether you can make a palindrome.

For example, given 'waterrfetawx' and a k of 2, you could delete f and x to get 'waterretaw'.
'''



def f(inputS, n, mark, currentInd, alreadyMarked):
    if (alreadyMarked == n):
        # check palyndrome
        tmpString = "";
        for i in range(len(inputS)):
            if (mark[i] == 1):
                tmpString += inputS[i];
        if (checkPalyndrome(tmpString) == True):
            print(tmpString, " is Palyndrome ****************************");
        else:
            print(tmpString, " NOT Palyndrome");
        return;
    # the following condition is used when the number of marked letter is lower than n
    elif (currentInd >= len(inputS)):
        return;


    mark[currentInd] = 0;
    f(inputS, n, mark, currentInd + 1, alreadyMarked + 1);
    mark[currentInd] = 1;
    f(inputS, n, mark, currentInd + 1, alreadyMarked);


def checkPalyndrome(tmpS):
    startInd = 0;
    endInd = len(tmpS) - 1;
    flag = True;
    while (startInd < endInd and flag == True):
        if (tmpS[startInd] != tmpS[endInd]):
            flag = False;
        startInd += 1;
        endInd -= 1;
    return flag;

##########################
#####                #####
##########################


inputString = "waterrfetawx";
k = 3; # chars to be deleted

if (len(inputString) - k < 2):
    print(len(inputString) - k, " must be greater than 2");
else:
    marked = list(); # 1 1 1 1 1 1 1 .... 1

    for i in range(len(inputString)):
        marked.append(1); # 

    f(inputString, k, marked, 0, 0);