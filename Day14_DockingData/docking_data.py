#   Advent of Code 2020  Day 14 Puzzle Docking Data https://adventofcode.com
#   Created 12/14/2020

import re
import collections
from array import array

print('Advent of Code 2020')
print('--- Day 14: Shuttle Search ---')
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
                # s = s[::-1]
                # print(s)
                # for i in range(0,35):
                #     if s[i] == "1":
                #         mask += 0x1 * 2**(i*2)
            else:
                instr = re.split(r' = ',l)
                v = int(instr[1])
                m1 = 0x1  # mask 1s
                m0 = 0x1  # mask 0s
                for i in range(35,0):
                    if mask[i+1:i]=='1':
                        # number &= ~(1UL << n);
                        m1 &= ~(0x1 << (2**i))
                    elif (mask[i+1:i]=='0'):
                        # https://stackoverflow.com/questions/47981/how-do-you-set-clear-and-toggle-a-single-bit
                        # number |= 1UL << n;
                        m0 |= 0x1 << (2**i)
                sea_port_comp[instr[0]] = v & m1 # bitwise AND
                sea_port_comp[instr[0]] = v | m0 # bitwise OR set bit to a 0

print(mask)
print(sea_port_comp)


# Part 2 of the Day 14 puzzle:
print()
print('Part 2:  ? ')
