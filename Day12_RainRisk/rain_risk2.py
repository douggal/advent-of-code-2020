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
curr_pos = [0,0]
waypoint = [10, 1]   # 10 units east and 1 unit north
cardinal_pts = ['N','S','E','W']

# Part 2: following the instructions in the input file where does the ship end up?

#z1 = 0
for inst in nav_instr:
    # if z1 > 100:
    #     break
    # else:
    #     z1 += 1
    print(inst,',', end='')
    n = inst[0]  # nav instruction cardinal directon or 'F'
    d = inst[1]  # units / distance
    if (n == 'F'):
        # N-S
        curr_pos[1] += waypoint[1] * d

        # E-W
        curr_pos[0] += waypoint[0] * d
    elif (n in cardinal_pts):
        if ( n == 'N'):
            waypoint[1] += d
        if (n == 'S'):
            waypoint[1] -= d
        if ( n == 'E'):
            waypoint[0] += d
        if (n == 'W'):
            waypoint[0] -= d
    elif (n in ['R','L'] and d == 180):
            waypoint[0] = -waypoint[0]
            waypoint[1] = -waypoint[1]
    elif (n == 'R' and d == 90):
        if waypoint[0]>= 0 and waypoint[1] >= 0:
            # swap and N-S becomes negative
            tmp = waypoint[0]
            waypoint[0] = waypoint[1]
            waypoint[1] = -tmp
        elif waypoint[0]>= 0 and waypoint[1] <= 0:
            # 2nd quadrant swap and both are now negative
            tmp = -waypoint[0] # make negative
            waypoint[0] = waypoint[1]
            waypoint[1] = tmp
        elif waypoint[0] <= 0 and waypoint[1] <= 0:
            # 3rd quadrant swap N-S becomes positive
            tmp = -waypoint[0] # becomes positive
            waypoint[0] = waypoint[1]
            waypoint[1] = tmp
        else: # waypoint[0] < 0 and waypoint[1] > 0:
            # 4th quadrant - swap and both become positive
            tmp = waypoint[0]
            waypoint[0] = -waypoint[1] # becomes positive
            waypoint[1] = tmp
    elif (n == 'R' and d==270):
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
        elif waypoint[0] <= 0 and waypoint[1] <= 0:
            # 3rd quadrant - 2nd swap and E-W becomes positive
            tmp = waypoint[0]
            waypoint[0] = -waypoint[1] # becomes positive
            waypoint[1] = tmp
        else:  # waypoint[0] <= 0 and waypoint[1] >= 0:
            # 4th quadrant - 1st swap and both become positive
            tmp = waypoint[0]
            waypoint[0] = -waypoint[1] # becomes negative
            waypoint[1] = tmp
    elif n == 'L' and d == 90:
        if waypoint[0]>= 0 and waypoint[1] >= 0:
            # 1st - 4th uadrant swap E-W becomes negative
            tmp = waypoint[0]
            waypoint[0] = -waypoint[1] # becomes negative
            waypoint[1] = tmp
        elif waypoint[0]>= 0 and waypoint[1] <= 0:
            # 2nd quadrant swap and both become negative
            tmp = waypoint[0]
            waypoint[0] = -waypoint[1] # becomes negative
            waypoint[1] = tmp
        elif waypoint[0] <= 0 and waypoint[1] <= 0:
            # 3rd quadrant swap and E-W becomes positive
            tmp = waypoint[0]
            waypoint[0] = -waypoint[1] # becomes postive
            waypoint[1] = tmp
        else:  # waypoint[0] <= 0 and waypoint[1] >= 0:
            # 4th quadrant - 1st swap and N-S become positive
            tmp = waypoint[0]
            waypoint[0] = -waypoint[1] # becomes negative
            waypoint[1] = tmp
    elif (n == 'L' and d==270):
        if waypoint[0]>= 0 and waypoint[1] >= 0:
            # 1st to 2nd quadrant swap E-W becomes negative
            tmp = -waypoint[0]  # becomes negative
            waypoint[0] = waypoint[1]
            waypoint[1] = tmp
        elif waypoint[0]>= 0 and waypoint[1] <= 0:
            # 2nd quadrant - 3rd swap and both become negative
            tmp = waypoint[0]
            waypoint[0] = waypoint[1] # becomes negative
            waypoint[1] = -tmp
        elif waypoint[0] <= 0 and waypoint[1] <= 0:
            # 3rd quadrant to 4th swap and n-s becomes positive
            tmp = waypoint[0]
            waypoint[0] = waypoint[1]
            waypoint[1] = -tmp
        else:  # waypoint[0] <= 0 and waypoint[1] >= 0:
            # 4th quadrant - 1st swap and both become positive
            tmp = -waypoint[0]  # becomes positive
            waypoint[0] = waypoint[1]
            waypoint[1] = tmp
    else:
        print()
        print('E R R O R')
        print()

    print("curr_pos,",curr_pos[0],',',curr_pos[1], end='')
    print(",way_point, ", waypoint[0],',',waypoint[1])


print('Manhattan distance from starting curr_pos is ', abs(curr_pos[0]) + abs(curr_pos[1]))

# That's not the right answer. If you're stuck, make sure you're using the 
# full input data; there are also some general tips on the about page, 
# or you can ask for hints on the subreddit. Because you have guessed 
# incorrectly 6 times on this puzzle, please wait 5 minutes before 
# trying again. (You guessed 9297.)
# 42841
# 105963

# 49649
