import numpy as np
import math 

##### valid only when sqrt(dim) is an integer

###
def funcValidMatrix(tMat, dimMat, cInd, pList):
    res = True;

    r = pList[cInd - 1][0];
    c = pList[cInd - 1][1];

    #############print(tMat);
    #test along a row
    for i in range(r + 1): #dimMat
        for e in range(1, dimMat + 1):
            trov = 0;
            if (i == r):
                c_ = c + 1;
            else:
                c_ = dimMat;
            for j in range(c_): #dimMat
                currentElem = tMat[i][j];
                if currentElem == e:
                    trov += 1;
            if (trov > 1):
                res = False;
                return res;

    for i in range(dimMat):
        for e in range(1, dimMat + 1):
            trov = 0;
            for j in range(r + 1):
                currentElem = tMat[j][i];
                if currentElem == e:
                    trov += 1;
            if (trov > 1):
                res = False;
                return res;
      
    return res;
    
def funcValidSubMatrix(tMat, dimMat, v):
    for i in range(0, len(v), int(math.sqrt(len(v)))):
        for j in range(0, len(v), int(math.sqrt(len(v)))):
            tmpMat = tMat[i : i + (int(math.sqrt(len(v)))), j : j + (int(math.sqrt(len(v))))];
            #############print(tmpMat, "\n");
            #check on the subMatrix
            for el in v:
                trov = 0;
                for i_ in range(int(math.sqrt(len(v)))):
                    for j_ in range(int(math.sqrt(len(v)))):
                        if (tmpMat[i_][j_] == el):
                            trov += 1;
                            if (trov > 1):
                                return False; 
        print("-\n\n");
    return True;
    
def f(currentInd, posWithVals, posList, mat, val, dim):

    #pruning check -> the previous move must be checked
    '''
    testMatrix = np.zeros((dim, dim));
    for i in range(len(posWithVals)):
        testMatrix[posList[i][0], posList[i][1]] = posWithVals[i];
    if (funcValidMatrix(testMatrix, dim, currentInd, posList) == False):
        return False;
    '''
    foundSol = False;
    
    #end condition
    if (currentInd >= (dim * dim)):
        #fill up a matrix with posWithVals
        testMatrix = np.zeros((dim, dim));
        for i in range(len(posWithVals)):
            testMatrix[posList[i][0], posList[i][1]] = posWithVals[i];
        #print("Matrix generated...\n", testMatrix);
        if (funcValidSubMatrix(testMatrix, dim, val) == True and funcValidMatrix(testMatrix, dim, currentInd, posList) == True): #if (funcValidMatrix(testMatrix, dim) == True):
            print("Solution found");
            print(testMatrix);
            return True;
        else:
            #############print("Matrix not valid");
            return False



    #pruning
    '''
    posWithVals[currentInd - 1] is the last cell 
    '''
    if (currentInd >= 2): # if at least two cells were filled up
        tmpRow = posList[currentInd - 1][0];
        #tmpColumn = ;
        tmpMatrix = np.zeros((tmpRow + 1, dim));
        tmpIndex = 0;
        for tmpCoordinate in posList:
            if (tmpIndex >= currentInd):
                break;
            # tmpCoordinate[0] tmpCoordinate[1]
            tmpMatrix[tmpCoordinate[0]][tmpCoordinate[1]] = posWithVals[tmpIndex];
            tmpIndex += 1;

        #check on tmpMatrix
        for tmpI in range(tmpRow + 1):
            for tmpElement in val:
                tmpTrov = 0;
                for tmpC in range(dim):
                    if (tmpMatrix[tmpI][tmpC] == 0):
                        break;
                    if (tmpMatrix[tmpI][tmpC] == tmpElement):
                        tmpTrov += 1;
                        if (tmpTrov > 1):
                            return;

        for tmpC in range(dim):
            for tmpElement in val:
                tmpTrov = 0;
                for tmpI in range(tmpRow + 1):
                    if (tmpMatrix[tmpI][tmpC] == 0):
                        break;
                    if (tmpMatrix[tmpI][tmpC] == tmpElement):
                        tmpTrov += 1;
                        if (tmpTrov > 1):
                            return;
        # 1 2 3 4 / 
        # 1 0 0 0 /
        #


    for _i_ in range(len(val)):
        posWithVals[currentInd] = val[_i_];
        foundSol = f(currentInd + 1, posWithVals, posList, mat, val, dim);
        if (foundSol == True):
            return foundSol;
        
    
    return foundSol;




### MAIN ###


matrixDim = 9;
matrix = np.zeros((matrixDim, matrixDim));

positionsList = list();
positionsWithValues = list();

for i in range(matrixDim):
    for j in range(matrixDim):
        #subElemList = list();
        #subElemList.append(i);
        #subElemList.append(j);
        positionsList.append([i, j]);
        positionsWithValues.append(-1);
    
vals = list();

for i in range(matrixDim):
    vals.append(i + 1);
    
print("DP: ", matrix, "\n");
print("DP", positionsList, "\n");
print("DP", positionsWithValues, "\n");
print("DP", vals, "\n\n\n");




f(0, positionsWithValues, positionsList, matrix, vals, matrixDim, );






