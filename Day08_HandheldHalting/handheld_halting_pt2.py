#   Advent of Code 2020  Day 68Puzzle Handheld Halting https://adventofcode.com
#   Created 12/09/2020
#   Part 2 What is the value of the accumulator at termination of program (after fixing the infinite loop)

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


with open(fn) as f:
    for line in f:
        if (line.strip() != ""):
            new_instr = []
            tmp = re.split(' +', line)
            new_instr.append(tmp[0].strip())
            new_instr.append(int(tmp[1].strip()))
            prg.append(new_instr)

# brute force approach
c = 0 # counter where in program prg are we?
chg_this_instr =-1

for this_instr in prg:
    this_instr_was = this_instr[0]
    term = False
    i = 0
    a = 0
    o = []
    c += 1 # keep track of what instruction needs to be changes - c will be one ahead of act value

    if this_instr[0] == 'acc':
        continue
    else:
        if (this_instr[0] == 'nop'):
            this_instr[0] = 'jmp'
        else:
            this_instr[0] = 'nop'
    # run machine and see if it terminates...
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

        #print(c, i, prg[i], sep=',')

        if i in o:
            break

        if i >= len(prg):
            term = True
            break

    this_instr[0] = this_instr_was

    if (term):
        chg_this_instr = c-1
        print('Success! changed this instruction: ',c - 1, this_instr)
    else:
        this_instr[0] = this_instr_was

#run it final time corrcted to get accumulator value:
i = 0
a = 0
o = []

# fix bad instruction
if (prg[chg_this_instr][0] == 'nop'):
    prg[chg_this_instr][0]  = 'jmp'
else:
    prg[chg_this_instr][0]  = 'nop'

print(chg_this_instr,':',prg[chg_this_instr])

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

    #print(c, i, prg[i], sep=',')

    # if i in o:
    #     break

    if i >= len(prg):
        term = True
        break

# Part 1 of the Day 8 puzzle:
print()
print('Part 2:  What was the value in the accumulator after fixing the program? ', a)
