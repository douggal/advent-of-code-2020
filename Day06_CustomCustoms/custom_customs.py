#   Advent of Code 2020  Day 6 Puzzle Custom Customs https://adventofcode.com
#   Created 12/06/2020

import re
import collections


print('Advent of Code 2020')
print('--- Day 6: Custom Customs ---')
print()

fn = "PuzzleInput.txt"
grp_dict = {}
grp_ctr = 0
grp_dict[grp_ctr] = {}
grp_count = {}
grp_count[0] = 0
count_of_letters = 26

with open(fn) as f:
    for line in f:
        if line.strip() == "":
            # New group
            grp_ctr += 1
            grp_dict[grp_ctr] = {}
            grp_count[grp_ctr] = 0
        else:
            grp_count[grp_ctr] += 1
            for c in line.strip():
                if re.match('[a-z]', c):  #ignore junk data if there is any
                    if c not in grp_dict[grp_ctr]:
                        grp_dict[grp_ctr][c] = {}
                        grp_dict[grp_ctr][c] = 1
                    else:
                        grp_dict[grp_ctr][c] += 1

# Part 1 of the Day 6 puzzle:
gsum = 0
total = 0
for grp in grp_dict:
    gsum = 0
    for customs_form in grp_dict[grp]:
        gsum += 1
    total += gsum
    #print(grp, grpDict[grp], ' group sum = ', gsum, ' total so far = ', total)
    #print()

print()
print('Part 1:  What is the sum of the customs forms ''yes'' counts?  ', total)

# Part 2 of the Day 6 puzzle:
gsum = 0
total = 0
count_of_grp = 0
for grp in grp_dict:
    gsum = 0
    for ques in grp_dict[grp]:
        if grp_dict[grp][ques] == grp_count[grp]:
            gsum += 1
    total += gsum

print()
print('Part 2:  What is the sum of the customs forms counting only q''s with all in group = ''yes'' counts?  ', total)

