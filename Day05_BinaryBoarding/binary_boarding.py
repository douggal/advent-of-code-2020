#   Advent of Code 2020  Day 4 Puzzle Binary Boarding https://adventofcode.com

import math

def binary_space_part(seat, min, max):

    low = min
    high = max

    #print()
    #print(seat,':')

    for c in seat:
        #print(low, high, sep=' to ', end='')
        #print(' (', c, ')', end='')
        #print(' becomes ', end='')

        if c == 'F' or c == 'L':
            low = low
            high = math.floor((low + high) / 2)  # midpoint between min and max
        else:
            low = math.ceil((low + high) / 2)  # midpoint between min and max
            high = high
        
        if low == high:
            return low
        #else:
            #print(low, high, sep=' to ')


fn = "PuzzleInput.txt"
row_max = 127
col_max = 7
row = 0
col = 0
seat_id_list = []

with open(fn) as f:
    for seat in f:
        row = binary_space_part(seat[:7], 0, row_max)
        print(seat.strip(), 'row = ', row, end = ' ')
        col = binary_space_part(seat[7:], 0, col_max)
        print('col = ', col, end=' ')
        seat_id_list.append(row*8+col)
        print('Seat ID = ', seat_id_list[-1])

print('Seat ID max ', max(seat_id_list))
