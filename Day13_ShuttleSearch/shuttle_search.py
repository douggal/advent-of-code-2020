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

fn = "PuzzleInput.txt"
nav_instr = list()
with open(fn) as f:
    for line in f:
        if (line.strip() != ""):
            new_instr = []
            new_instr.append(line[0])
            new_instr.append(int(line[1:].strip()))
            nav_instr.append(new_instr)

#print(nav_instr)

# ship starts at East 0, North 0 and is facing East
# postion = list of direction ship is facing followed by coords of curr curr_pos (East-West, North-South)
# the ship starts at the center of a cartesian grid
curr_pos = ['E',0,0]
NE = ['E','N']
SW = ['W','S']
cardinal_pts = ['N','S','E','W']
right_turns = ['E','S','W','N']
left_turns = ['E','N','W','S']
turns = {}
for y in right_turns:
    i = right_turns.index(y)
    for x in [90, 180, 270, 360]:
        if i < 3:
            i += 1
        else:
            i = 0

        turns['R' + '_' + y + '_' + str(x)] = right_turns[i]

for y in right_turns:
    i = left_turns.index(y)
    for x in [-90, -180, -270, -360]:
        if i < 3:
            i += 1
        else:
            i = 0
        turns['R' + '_' + y + '_' + str(x)] = left_turns[i]

for y in left_turns:
    i = left_turns.index(y)
    for x in [90, 180, 270, 360]:
        if i < 3:
            i += 1
        else:
            i = 0
        turns['L' + '_' + y + '_' + str(x)] = left_turns[i]

for y in left_turns:
    i = right_turns.index(y)
    for x in [-90, -180, -270, -360]:
        if i < 3:
            i += 1
        else:
            i = 0
        turns['L' + '_' + y + '_' + str(x)] = right_turns[i]

#print(turns)


# Part 1: 

for inst in nav_instr:
    print(inst, ' : ', end='')
    n = inst[0]  # nav instruction cardinal directon or 'F' 
    d = inst[1]  # units / distance
    di = curr_pos[0]  # current direction ship is facing
    if (n in ['F']):
        if ( di == 'N'):
            curr_pos[2] += d * 1
        elif (di == 'S'):
            curr_pos[2] += d * -1
        elif ( di == 'E'):
            curr_pos[1] += d * 1
        elif (di == 'W'):
            curr_pos[1] += d * -1
    elif (n in cardinal_pts):
        if ( n == 'N'):
            curr_pos[2] += d * 1
        elif (n == 'S'):
            curr_pos[2] += d * -1
        elif ( n == 'E'):
            curr_pos[1] += d * 1
        elif (n == 'W'):
            curr_pos[1] += d * -1
    elif (n in ['R','L']):
        new_di = turns[n + '_' + di + '_' + str(d)]
        curr_pos[0] = new_di
    else:
        pass

    print("curr_pos is now ",curr_pos)


print('Manhattan distance from starting curr_pos is ', abs(curr_pos[1]) + abs(curr_pos[2]))

# Part 2 of the Day 13 puzzle:
print()
print('Part 2:  ? ')
