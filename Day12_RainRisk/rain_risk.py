#   Advent of Code 2020  Day 12 Puzzle Rain Risk https://adventofcode.com
#   Created 12/12/2020


import re
import collections

class Accumulator:
    # class Accumulator maintains a running total and count of items added
    total = 0
    N = 0

    def __init__(self, value):
        self.total = value
        self.N = 0

    def ToString(self):
        str(self.total)

    def AddValue(self, value):
        self.total += value
        self.N += 1


print('Advent of Code 2020')
print('--- Day 12: Rain Risk ---')
print()


fn = "PuzzleInputTEST.txt"
nav_instr = list()
with open(fn) as f:
    for line in f:
        if (line.strip() != ""):
            new_instr = []
            tmp = re.split('[NSEWLRF]{1}', line)
            new_instr.append(tmp[0].strip())
            new_instr.append(int(tmp[1].strip()))
            nav_instr.append(new_instr)

print(nav_instr)

# Part 1: 


# Part 2 of the Day 8 puzzle:
print()
print('Part 2:  What was the value in the accumulator after fixing the program? ')
