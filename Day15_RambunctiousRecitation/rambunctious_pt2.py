#   Advent of Code 2020  Day 15 Rambunctious Recitation https://adventofcode.com
#   Created 12/23/2020

# Part 2 what is the 30 000 000th number spoken?

import collections

print('Advent of Code 2020')
print('--- Day 15: Rambunctious Recitation ---')
print('Part 2')

# 12/23/2020 (dg) let's try a dictionary object first
# Some day is very efficient at finding item in dictionary
# https://stackoverflow.com/questions/2701173/most-efficient-way-for-a-lookup-search-in-a-huge-list-python

start_string = "0,3,6".split(',')
#start_string = "1,3,2".split(',')
#start_string = "2,1,3".split(',')
#start_string = "1,2,3".split(',')
#start_string = "2,3,1".split(',')
#start_string = "3,2,1".split(',')
#start_string = "3,1,2".split(',')

# official input
#start_string = "6,3,15,13,1,0".split(',')

start_numbers = []
for s in start_string:
    start_numbers.append(int(s))

nth_number_spoken = 30000000
numbers = []

# begin with starting numbers
for i in range(0, len(start_numbers)):
    numbers.append(start_numbers[i])

# play game
i = 0  # count iterations to prevent runaway loop
last_number_spoken = numbers[-1]
i2 = 0  # idx last number spoken prior
i3 = 0  # idx last number spoken 2x prior
while True:

    # consider the last number spoken: is it first time it's been spoken
    # count items in a list:  https://stackoverflow.com/questions/2600191/how-can-i-count-the-occurrences-of-a-list-item
    if numbers.count(last_number_spoken) == 1:
        numbers.append(0)  # last number was a new number so a 0 is appended
    else:
        #  next number is diff between last time number was spoken and time before that
        # minus 2 - don't count what we just added
        j = len(numbers)
        found = False
        while True:
            j -= 1
            if numbers[j] == last_number_spoken and not found:
                found = True
                i2 = j
            elif numbers[j] == last_number_spoken and found:
                i3 = j
                break
            elif j == 0:
                break

        numbers.append(i2 - i3)

    last_number_spoken = numbers[-1]

    if len(numbers) >= nth_number_spoken:
        break

    i += 1
    if i > 1e6:
        break

#print(numbers)

# Part 2 of the Day 15 puzzle:
print()
print('Day 15 Part 2:  given starting numbers the 30 000 000th number spoken will be?', numbers[-1])
