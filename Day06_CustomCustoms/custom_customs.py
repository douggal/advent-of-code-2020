#   Advent of Code 2020  Day 6 Puzzle Custom Customs https://adventofcode.com

import re
import collections


print('Advent of Code 2020')
print('--- Day 6: Custom Customs ---')
print()

fn = "PuzzleInput.txt"
grpDict = {}
groupCtr = 0
grpDict[groupCtr] = {}

with open(fn) as f:
    for line in f:
        if line.strip() == "":
            # New group
            groupCtr += 1
            grpDict[groupCtr] = {}
        else:
            for c in line.strip():
                if re.match('[a-z]', c):  #ignore junk data if there is any
                    grpDict[groupCtr][c] = {}
                    grpDict[groupCtr][c] = 1

# Part 1 of the Day 6 puzzle:
gsum = 0
total = 0
for grp in grpDict:
    gsum = 0
    for customs_form in grpDict[grp]:
        gsum += 1
    total += gsum
    #print(grp, grpDict[grp], ' group sum = ', gsum, ' total so far = ', total)
    #print()

print()
print('Part 1:  What is the sum of those counts?  ', total)

# Part 2 of the Day 6 puzzle:

