'''
This problem was asked by Lyft.

Given a list of integers and a number K, return which contiguous elements of the list sum to K.

For example, if the list is [1, 2, 3, 4, 5] and K is 9, then it should return [2, 3, 4], since 2 + 3 + 4 = 9.
'''

K = 9;
values = [1, 7, 2];

solutionFound = False;
for i in range(len(values)):
    j = i + 1;
    continueResearch = True;
    sum = values[i];
    solutions = list();
    solutions.append(values[i]);
    while (continueResearch == True and j < len(values)):
        sum += values[j];
        solutions.append(values[j]);
        if (sum > K or sum == K):
            continueResearch = False;
        j += 1;
    if (continueResearch == False and sum == K):
        print("Solution found, the next elements sum to ", K);
        solutionFound = True;
        for tmpElement in solutions:
            print(tmpElement, "\t");
        break;
    #solution not found
    #elif ((continueResearch == True and sum != k) or (continueResearch == False and sum != k)):
        #

if (solutionFound == False):
    print("Solution NOT found.");