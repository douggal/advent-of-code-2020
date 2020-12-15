#   Advent of Code 2020  Day 14 Puzzle Docking Data https://adventofcode.com
#   Created 12/14/2020

import re
import collections
from array import array

print('Advent of Code 2020')
print('--- Day 14: Docking Data ---')
print()

# Python find letter in list
# https://stackoverflow.com/questions/26355191/python-check-if-a-letter-is-in-a-list
# slicing string
# https://stackoverflow.com/questions/663171/how-do-i-get-a-substring-of-a-string-in-python


#count = 65535
#sea_port_comp = array('Q', (0x0 for i in range(count)))
sea_port_comp = {}

fn = "PuzzleInputTest.txt"
with open(fn) as f:
    for line in f:
        if (line.strip() != ""):
            l = line.strip()
            if l[:4] == "mask":
                mask = l[7:]
            else:
                instr = re.split(r' = ',l)
                v = int(instr[1])
                j = 0
                for i in reversed(range(0,36)):
                    if j==35:
                        s = mask[35:]
                    else:
                        s = mask[j:j+1]
                    if s =='1':
                        # number |= 1UL << n;   SET BIT I to a 1
                        v |= 0x1 << i
                    elif s=='0':
                        # https://stackoverflow.com/questions/47981/how-do-you-set-clear-and-toggle-a-single-bit
                        # number &= ~(1UL << n);  CLEAR BIT I (  = 0)
                        v &= ~(0x1 << i)
                    j += 1
                sea_port_comp[instr[0]] = v

print(mask)
print(sea_port_comp)


# Part 2 of the Day 14 puzzle:
print()
print('Part 2:  ? ')
