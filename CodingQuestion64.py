'''

This problem was asked by Google.

A knight's tour is a sequence of moves by a knight on a chessboard such that all squares are visited once.

Given N, write a function to return the number of knight's tours on an N by N chessboard.

'''

def func(solut, vals, marked, currentInd, pos):
    if (currentInd >= N * N):
        # save solution
        # pos ( [0, 0], ... [2, 3], ..., ...) is parallel to solution ( [2, 3, 5, ...])
        tmpMatrix = np.zeros((N, N));
        ind = 0;
        for tmpPos in pos:
            # pos[0] == x   pos[1] == y
            tmpMatrix[tmpPos[0]][tmpPos[1]] = solut[ind];
            ind += 1;
        #print("Solution: ", tmpMatrix);
        allSolutions.append(tmpMatrix.copy());
        return;
    else:
        for i in range(len(vals)):
            if (marked[i] == 0):
                solut[currentInd] = vals[i];
                marked[i] = 1;
                func(solut, vals, marked, currentInd + 1, pos);
                marked[i] = 0;

import numpy as np

allSolutions = list();
N = 3;
matrix = np.zeros((N, N));
mark = list();
val = list();    # all the possible moves
sol = list(); # must have N * N cells, each cell contains a val
positions = list();

for i in range(N * N):
    val.append(i + 1);
    mark.append(0);
    sol.append(-1);

for i in range(N):
    for j in range(N):
        positions.append([i, j]);

print("Positions: ", positions);
print("Moves: ", val);
print("Mark: ", mark);
print(matrix);


func(sol, val, mark, 0, positions);
print("There are ", len(allSolutions));
for tmpEl in allSolutions:
    print(tmpEl);