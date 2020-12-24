#   Advent of Code 2020  Day 15 Rambunctious Recitation https://adventofcode.com
#   Created 12/23/2020

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
print('--- Day 15: Rambunctious Recitation ---')
print()

# 12/23/2020 (dg) let's try a dictionary object first
# Some day is very efficient at finding item in dictionary
# https://stackoverflow.com/questions/2701173/most-efficient-way-for-a-lookup-search-in-a-huge-list-python

starting_numbers = "0,3,6".split(',')
end = 2020
numbers = {}

last_number  = []
for i in range(0, len(starting_numbers)):
    numbers[i] = starting_numbers[i]
    last_number[0] = i
    last_number[1] = starting_numbers[i]

# play game
i = 0
while True:
          
    i += 1
    if i == 2020:
        break


print(numbers)

# Part 2 of the Day 15 puzzle:
print()
print('Day 15 Part 1:  given starting numbers the 2020th number spoken will be?')
