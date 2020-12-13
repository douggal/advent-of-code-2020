#   Advent of Code 2020  Day 12 Puzzle Rain Risk https://adventofcode.com
#   Created 12/12/2020

import collections


print('Advent of Code 2020')
print('--- Day 12: Rain Risk ---')
print('Part 2')

# Taxicab aka Manhattan distance  https://en.wikipedia.org/wiki/Taxicab_geometry
# sum of absolute dist  (p1,p1), (q2,q2) = |p1 - q1| + |p2 - q2|

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
waypoint = [10, 1]   # 10 units east and 1 unit north
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


# Part 2: following the instructions in the input file where does the ship end up?

z1 = 0
for inst in nav_instr:
    # if z1 > 100:
    #     break
    # else:
    #     z1 += 1
    print(inst, ' : ', end='')
    n = inst[0]  # nav instruction cardinal directon or 'F'
    d = inst[1]  # units / distance
    di = curr_pos[0]  # current direction ship is facing
    if (n in ['F']):
        # N-S
        if waypoint[1] >= 0 and curr_pos[2] >= 0:
            curr_pos[2] = curr_pos[2] + waypoint[1] * d
        elif waypoint[1] >= 0 and curr_pos[2] < 0:
            curr_pos[2] = curr_pos[2] + waypoint[1] * d
        elif waypoint[1] <= 0 and curr_pos[2] > 0:
            curr_pos[2] = curr_pos[2] + waypoint[1] * d
        else:
            curr_pos[2] = curr_pos[2] + waypoint[1] * d

        # E-W
        if waypoint[0] >= 0 and curr_pos[1] >= 0:
            curr_pos[1] = curr_pos[1] + waypoint[0] * d
        elif waypoint[0] >= 0 and curr_pos[1] <= 0:
            curr_pos[1] = curr_pos[1] + waypoint[0] * d
        elif waypoint[0] <= 0 and curr_pos[1] >= 0:
            curr_pos[1] = curr_pos[1] + waypoint[0] * d
        elif waypoint[0] <= 0 and curr_pos[1] <= 0:
            curr_pos[1] = curr_pos[1] + waypoint[0] * d
    elif (n in cardinal_pts):
        if ( n == 'N'):
            waypoint[1] += d * 1
        if (n == 'S'):
            waypoint[1] += d * -1
        if ( n == 'E'):
            waypoint[0] += d * 1
        if (n == 'W'):
            waypoint[0] += d * -1
    elif (n == 'R'):
        if (d == 90):
            if waypoint[0]>= 0 and waypoint[1] >= 0:
                # swap and N-S becomes negative
                tmp = waypoint[0]
                waypoint[0] = waypoint[1]
                waypoint[1] = -tmp
            elif waypoint[0]>= 0 and waypoint[1] <= 0:
                # 2nd quadtrant swap and both are now negative
                tmp = waypoint[0]
                waypoint[0] = waypoint[1]
                waypoint[1] = -tmp
            elif waypoint[0] < 0 and waypoint[1] <= 0:
                # 3rd quadrant swap N-S becomes positive
                tmp = waypoint[0]
                waypoint[0] = waypoint[1]
                waypoint[1] = -tmp
            else: # waypoint[0] < 0 and waypoint[1] > 0:
                # 4th quadrant - swap and both become positive
                tmp = waypoint[0]
                waypoint[0] = -waypoint[1]
                waypoint[1] = tmp
        elif (d==180):
             if waypoint[0]>= 0 and waypoint[1] >= 0:
                waypoint[0] = -waypoint[0]
                waypoint[1] = -waypoint[1]
             elif waypoint[0]>= 0 and waypoint[1] <= 0:
                waypoint[0] = -waypoint[0]
                waypoint[1] = waypoint[1]
             elif waypoint[0] < 0 and waypoint[1] <= 0:
                waypoint[0] = -waypoint[0]
                waypoint[1] = -waypoint[1]
             else:  #waypoint[0] < 0 and waypoint[1]> 0:
                waypoint[0] = -waypoint[0]
                waypoint[1] = -waypoint[1]
        elif (d==270):
            if waypoint[0]>= 0 and waypoint[1] >= 0:
                # 1st - 4th quadrant swap E-W becomes negative
                tmp = waypoint[0]
                waypoint[0] = -waypoint[1]
                waypoint[1] = tmp
            elif waypoint[0]>= 0 and waypoint[1] <= 0:
                # 2nd quadrant - 1st swap and both become positive
                tmp = waypoint[0]
                waypoint[0] = -waypoint[1]
                waypoint[1] = tmp
            elif waypoint[0] < 0 and waypoint[1] <= 0:
                # 3rd quadrant - 2nd swap and E-W becomes positive
                tmp = waypoint[0]
                waypoint[0] = -waypoint[1]
                waypoint[1] = tmp
            if waypoint[0] <= 0 and waypoint[1] >= 0:
                # 4th quadrant - 1st swap and both become positive
                tmp = waypoint[0]
                waypoint[0] = waypoint[1]
                waypoint[1] = -tmp
    elif (n == 'L'):
        if (d == 90):
            if waypoint[0]>= 0 and waypoint[1] >= 0:
                # 1st - 4th uadrant swap E-W becomes negative
                tmp = waypoint[0]
                waypoint[0] = -waypoint[1]
                waypoint[1] = tmp
            elif waypoint[0]>= 0 and waypoint[1] <= 0:
                # 2nd quadrant swap and both become negative
                tmp = waypoint[0]
                waypoint[0] = waypoint[1]
                waypoint[1] = -tmp
            elif waypoint[0] < 0 and waypoint[1] <= 0:
                # 3rd quadrant swap and N-S becomes positive
                tmp = waypoint[0]
                waypoint[0] = waypoint[1]
                waypoint[1] = -tmp
            if waypoint[0] <= 0 and waypoint[1] >= 0:
                # 4th quadrant - 1st swap and both become positive
                tmp = waypoint[0]
                waypoint[0] = waypoint[1]
                waypoint[1] = -tmp
        elif (d==180):
            if waypoint[0]>= 0 and waypoint[1] >= 0:
                waypoint[0] = -waypoint[0]
                waypoint[1] = -waypoint[1]
            elif waypoint[0]>= 0 and waypoint[1] <= 0:
                waypoint[0] = -waypoint[0]
                waypoint[1] = -waypoint[1]
            elif waypoint[0] < 0 and waypoint[1] <= 0:
                waypoint[0] = -waypoint[0]
                waypoint[1] = -waypoint[1]
            else:  #waypoint[0] < 0 and waypoint[1]> 0:
                waypoint[0] = -waypoint[0]
                waypoint[1] = -waypoint[1]
        elif (d==270):
            if waypoint[0]>= 0 and waypoint[1] >= 0:
                # 1st - 2nd quadrant swap E-W becomes negative
                tmp = waypoint[0]
                waypoint[0] = waypoint[1]
                waypoint[1] = -tmp
            elif waypoint[0]>= 0 and waypoint[1] <= 0:
                # 2nd quadrant - 3rd swap and both become negative
                tmp = waypoint[0]
                waypoint[0] = -waypoint[1]
                waypoint[1] = tmp
            elif waypoint[0] <= 0 and waypoint[1] <= 0:
                # 3rd quadrant - 4th swap and E-W becomes positive
                tmp = waypoint[0]
                waypoint[0] = -waypoint[1]
                waypoint[1] = tmp
            if waypoint[0] <= 0 and waypoint[1] >= 0:
                # 4th quadrant - 1st swap and both become positive
                tmp = waypoint[0]
                waypoint[0] = -waypoint[1]
                waypoint[1] = tmp
    else:
        pass

    print("curr_pos is now ",curr_pos, end='')
    print("  way point is now ", waypoint)


print('Manhattan distance from starting curr_pos is ', abs(curr_pos[1]) + abs(curr_pos[2]))
