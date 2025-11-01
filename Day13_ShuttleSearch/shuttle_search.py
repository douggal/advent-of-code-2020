#   Advent of Code 2020  Day 13 Puzzle Shuttle Search https://adventofcode.com
#   Created 12/13/2020

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
print('--- Day 13: Shuttle Search ---')
print()

# Python find letter in list
# https://stackoverflow.com/questions/26355191/python-check-if-a-letter-is-in-a-list

# fn = "PuzzleInputTest.txt"
# with open(fn) as f:
#     for line in f:
#         if (line.strip() != ""):

#print(nav_instr)

earliest_t = 1001287
notes = "13,x,x,x,x,x,x,37,x,x,x,x,x,461,x,x,x,x,x,x,x,x,x,x,x,x,x,17,x,x,x,x,19,x,x,x,x,x,x,x,x,x,29,x,739,x,x,x,x,x,x,x,x,x,41,x,x,x,x,x,x,x,x,x,x,x,x,23"

bus_list = notes.split(',')
bus_list_int = []
for bus in bus_list:
    if bus != 'x':
        bus_list_int.append(int(bus))

depart_t = list(range(earliest_t, earliest_t + 100))

p = list()
for t in depart_t:
    for bus in bus_list_int:
        if t % bus == 0:
            q = str(t) + '_' + str(bus)
            print(q)
            p.append(q)

print(p.sort())

# Part 2 of the Day 13 puzzle:
print()
print('Part 2:  ? ')
