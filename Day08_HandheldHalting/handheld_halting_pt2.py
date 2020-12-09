#   Advent of Code 2020  Day 68Puzzle Handheld Halting https://adventofcode.com
#   Created 12/09/2020
#   Part 2 What is the value of the accumulator at termination of program (after fixing the infinite loop)

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

class HandHeldDevice:
    this_instr_was = 0
    prev_acc_val = 0
    this_instr = 0

    def __init__(self):
        self.program = [] # a list of instructions
        self.inst = [] # an instruction 0 = instruction, 1 = register value
        self.i = 0 # instruction pointer
        self.o = [] # stack of instructions used
        self.c = 0  #instruction count
        self.a = Accumulator(0) # an accumulator
        self.term = False # termination status - true if successfully ran program

        fn = "PuzzleInput.txt"
        with open(fn) as f:
            for line in f:
                if (line.strip() != ""):
                    new_instr = []
                    tmp = re.split(' +', line)
                    new_instr.append(tmp[0].strip())
                    new_instr.append(int(tmp[1].strip()))
                    self.program.append(new_instr)

    def GetTerminationStatus(self):
        return self.term

    def GetInstrPointer(self):
        return self.i
    
    def GetPrevAccumlatorValue(self):
        return self.prev_acc_val

    def GetCurrentAccumulatorVal(self):
        return self.a.total

    def GetThisInstr(self):
        return self.program[self.i]

    def GetInstrAt(self, value):
        return self.program[value]

    def ModifyInstr(self, value):
        if (self.program[value][0] == 'nop'):
            self.program[value][0] = 'jmp'
        else:
            self.program[value][0] = 'nop'

    def RunDevice(self):
        while True:
            self.prev_acc_val = self.a.total
            # carry out instr
            self.o.append(self.i)
            if self.program[self.i][0] == 'nop':
                self.i += 1
            elif self.program[self.i][0] == 'acc':
                self.a.AddValue(self.program[self.i][1])
                self.i += 1
            elif self.program[self.i][0] == 'jmp':
                self.i += self.program[self.i][1]
            else:
                pass

            #print(c, i, program[i], sep=',')

            # check for infinite loop:
            if self.i in self.o:
                break

            # check if past end of program:
            if self.i >= len(self.program):
                self.term = True
                break

print('Advent of Code 2020')
print('--- Day 8: Handheld Halting ---')
print()


# brute force approach
prg = HandHeldDevice()
the_program = prg.program
chg_this_instr = -1

for this_instr in the_program:
    chg_this_instr += 1
    prg = HandHeldDevice()

    prg.ModifyInstr(chg_this_instr)

    # run machine and see if it terminates...
    prg.RunDevice()

    if (prg.GetTerminationStatus()):
        print('Success! changed this instruction: ',chg_this_instr, prg.GetInstrAt(chg_this_instr))
        break


#run it final time corrcted to get accumulator value:
prg = HandHeldDevice()

# fix bad instruction
prg.ModifyInstr(chg_this_instr)

prg.RunDevice()

# Part 2 of the Day 8 puzzle:
print()
print('Part 2:  What was the value in the accumulator after fixing the program? ', prg.a.total)
