#   Advent of Code 2020  Day 68Puzzle Handheld Halting https://adventofcode.com
#   Created 12/09/2020
#   Part 1

import re
import collections


print('Advent of Code 2020')
print('--- Day 8: Handheld Halting ---')
print()

fn = "PuzzleInput.txt"
prg = []
instr=[]  # 0=insstruction, 1=value
a = 0 # Accumulator(0)
i = 0 # instr pointer 
o = [] # list of instruction pointer previous values
c = 0 # counter


with open(fn) as f:
    for line in f:
        if (line.strip() != ""):
            new_instr = []
            tmp = re.split(' +', line)
            new_instr.append(tmp[0].strip())
            new_instr.append(int(tmp[1].strip()))
            new_instr.append(0)
            new_instr.append(0)
            prg.append(new_instr)

while True:
    prev_acc_val = a
    # carry out instr
    o.append(i)
    if prg[i][0] == 'nop':
        i += 1
    elif prg[i][0] == 'acc':
        a += prg[i][1]
        i += 1
    elif prg[i][0] == 'jmp':
        i += prg[i][1]
    else:
        pass
  
    c += 1
    print(c, i, prg[i], sep=',')

    if i in o:
        break

    if i >= len(prg):
        break

# Part 1 of the Day 8 puzzle:
print()
print('Part 1:  What was the value in the accumulator just before the infinte loop started? ', prev_acc_val)
