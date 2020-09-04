'''
This problem was asked by Palantir.

Given a number represented by a list of digits, find the next greater permutation of a number, in terms of lexicographic
ordering. If there is not greater permutation possible, return the permutation with the lowest value/ordering.

For example, the list [1,2,3] should return [1,3,2]. The list [1,3,2] should return [2,1,3]. The list [3,2,1] should
return [1,2,3].

Can you perform the operation without allocating extra memory (disregarding the input memory)?
'''

def f(vals, marked, sols, ind, saveSols):
    if (ind >= len(marked)):
        str_ = "";
        for c in sols:
            str_ += str(c);
        saveSols.append(str_);
        print(sols);
        return;

    for i in range(len(vals)):
        if (marked[i] == 0):
            marked[i] = 1;
            sols[ind] = vals[i];
            f(vals, marked, sols, ind + 1, saveSols);
            marked[i] = 0;
    
    return;

#########################
val = [1, 2, 3];
mark = list();
sol = list();
saveSol = list();
saveSolStr = list();
for tmpEl in val:
    mark.append(0);
    sol.append(-1);
#print(mark, " ", len(mark));

f(val, mark, sol, 0, saveSol)
print(saveSol);

if (saveSol[1] > saveSol[0]):
    print("Final solution: ", saveSol[1]);
else:
    print("Final solution: ", saveSol[len(saveSol) - 1]);


#########################
#########################
#########################
#########################
#########################
#########################
#########################







