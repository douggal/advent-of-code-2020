#   Advent of Code 2020  Day 14 Puzzle Docking Data https://adventofcode.com
#   Part 2
#   Created 12/22/2020

import re
import collections
from array import array
import copy
import itertools

print('Advent of Code 2020')
print('--- Day 14 ---')
print(' Part 2 ')

# memory address decoder
# instead of applying mask to values, now apply mask to the memory locations


# Python find letter in list
# https://stackoverflow.com/questions/26355191/python-check-if-a-letter-is-in-a-list
# slicing string
# https://stackoverflow.com/questions/663171/how-do-i-get-a-substring-of-a-string-in-python


#count = 65535
#sea_port_comp = array('Q', (0x0 for i in range(count)))
sea_port_comp = {}

fn = "PuzzleInput.txt"
with open(fn) as f:
    for line in f:
        if (line.strip() != ""):
            l = line.strip()
            if l[:4] == "mask":
                mask = l[7:]
            else:
                instr = re.split(r' = ',l)
                v = int(instr[1])
                tmp = re.sub(r'mem\[([0-9]+)\]', "\\1" ,instr[0])
                mem = int(tmp)

                #print(instr, mem, sep=',')
                #continue

                # apply 1's and 0's mask first to mem location
                j = 0
                for i in reversed(range(0,36)):
                    if j==35:
                        s = mask[35:]
                    else:
                        s = mask[j:j+1]
                    if s =='1':
                        # overwrite this bit with a 1
                        # https://stackoverflow.com/questions/47981/how-do-you-set-clear-and-toggle-a-single-bit
                        # C++:  number |= 1UL << n;   SET BIT I to a 1
                        mem |= 0x1 << i
                    else:
                        # 0 so no change
                        pass
                    j += 1

                # now expand Xs into generate all possible values
                # TODO: is there a better way to do this? this seems cumbersome 
                j = 0 # j is string index (starts at 0), i is power of 2 for this digit (starts at 35)
                a = list()  # list of memory locations
                a.append(mem)   # mem loc and all the X float bits are 0.
                b = list()  # helper list
                for i in reversed(range(0,36)):
                    t = mem
                    b.clear()
                    b = copy.deepcopy(a)   # pretty sure not allowed to mod an obj iterated over
                    if j==35:
                        s = mask[35:]
                    else:
                        s = mask[j:j+1]
                    if s =='X':
                        for item in b:
                            t = item
                            # set bit to a 1
                            t |= 0x1 << i
                            if t not in a:
                                a.append(t)
                            # set bit to a 0
                            t &= ~(0x1 << i)
                            if t not in a:
                                a.append(t)
                    else:
                        pass
                    j += 1

                # for each memory location decoded, assign the value 
                for m in a:
                    sea_port_comp[m] = v

#print(sea_port_comp)

# https://stackoverflow.com/questions/4880960/how-to-sum-all-the-values-in-a-dictionary

# Part 2 of the Day 14 puzzle:
print()
print('Part 2 ', sum(sea_port_comp.values()))
