#   Advent of Code 2020  Day 15 Rambunctious Recitation https://adventofcode.com
#   Created 12/23/2020

# Part 2 what is the 30 000 000th number spoken?

# changes from Pt 1:
# can't use "count" method on numbers list - too slow
#   improvement:  create a dict of numbers and record counts
#   improvement:  change numbers  to a dict  and  number spoken is key, value is turn



import collections
from datetime import datetime

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

nth_number_spoken = 2020 
#nth_number_spoken = 30000000
numbers = {}   # contains tuples.  number spoken is key, value is (turn, prev turn)
numbers_score_board = {}

# begin with starting numbers
for i in range(0, len(start_numbers)):
    numbers[start_numbers[i]] = (i+1, 0)  # value tuple (turn, last turn this number was spoken)
    numbers_score_board[start_numbers[i]] = 1

# play game
last_number_spoken = start_numbers[-1]
print('Start ', datetime.now().strftime('%Y-%m-%d %H:%M:%S'))

t = len(start_numbers)   # Turns
while True:
    t += 1
    # consider the last number spoken: is it first time it's been spoken
    # count items in a list:  https://stackoverflow.com/questions/2600191/how-can-i-count-the-occurrences-of-a-list-item
    if last_number_spoken in numbers_score_board and numbers_score_board[last_number_spoken] == 1:
        last_number_spoken = 0
        old, old_old = numbers[last_number_spoken]
        numbers[last_number_spoken] = (t, old)
        numbers_score_board[0] += 1
    else:
        #  next number is diff between last time number was spoken and time before that

        i2, i3 = numbers[last_number_spoken] #i2 = last turn, i3 prev last turn

        last_number_spoken = i2 - i3

        if last_number_spoken in numbers:
            old, old_old = numbers[last_number_spoken]
            numbers[last_number_spoken] = (t, old)
            numbers_score_board[last_number_spoken] += 1
        else:
            numbers[last_number_spoken] = (t, 0)
            numbers_score_board[last_number_spoken] = 1     

    print(last_number_spoken)

    if t >= nth_number_spoken:
        break

    if t % 2.5e5 == 0:
        print(t,datetime.now().strftime('%H:%M:%S'), last_number_spoken, sep=',')
    if i > 1e8:
        break

print('Finish ', datetime.now().strftime('%Y-%m-%d %H:%M:%S'))

print(numbers)

# Part 2 of the Day 15 puzzle:
print()
print('Day 15 Part 2:  given starting numbers the 30 000 000th number spoken will be?', last_number_spoken)
