#   Advent of Code 2020  Day 14 Puzzle Docking Data https://adventofcode.com
#   Created 12/14/2020

import collections
import array as arr

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
print('--- Day 14: Shuttle Search ---')
print()

# Python find letter in list
# https://stackoverflow.com/questions/26355191/python-check-if-a-letter-is-in-a-list
# slicing string
# https://stackoverflow.com/questions/663171/how-do-i-get-a-substring-of-a-string-in-python


count = 65535
sea_port_comp = array('Q', (0 for i in range(count)))

fn = "PuzzleInputTest.txt"
with open(fn) as f:
     for line in f:
         if (line.strip() != ""):
             if line[:3] == "mask":
                 s = line[6:]
                 for i in range(0,35):
                     if s[i]=="0":
                         mask = 0x0


#print(nav_instr)


# Part 2 of the Day 14 puzzle:
print()
print('Part 2:  ? ')
