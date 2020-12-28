#   Advent of Code 2020  Day 16 Puzzle Docking Data https://adventofcode.com
#   Created 12/27/2020

import re
import collections
from array import array

print('Advent of Code 2020')
print('--- Day 16: Ticket Translation ---')
print()


fn = "PuzzleInputTest.txt"
read_rules = True
rules = dict()
my_tkt = []
nearby_tkts = []
with open(fn) as f:
    for line in f:
        # read first group: the rules
        if (read_rules and line.strip() != ""):
            l = line.strip().split(':')
            name = re.sub(r' ','_',l[0])
            rngs = re.sub(r' or ','-',l[1])
            hilo= rngs.split('-')
            rules[name] = [int(hilo[0].strip()),int(hilo[1].strip()),int(hilo[2].strip()),int(hilo[3].strip())]
        else:
            read_rules = False
            continue

        # next my ticket
        
        

        # next other tickets

print(rules)



print('Day 16 Part 1:  my ticket scanning error rate is ')



# Part 2 of the Day 16 puzzle:
print()
print('Part 2:  ? ')
