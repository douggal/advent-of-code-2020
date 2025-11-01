#   Advent of Code 2020  Day 15 Rambunctious Recitation https://adventofcode.com
#   Created 12/23/2020

# Part 2 what is the 30 000 000th number spoken?

# 12/23/2020 (dg) let's try a dictionary object first
# Some day is very efficient at finding item in dictionary
# https://stackoverflow.com/questions/2701173/most-efficient-way-for-a-lookup-search-in-a-huge-list-python

# changes from Pt 1:
# can't use "count" method on numbers list - too slow
#   improvement:  change numbers  to a dict  and  number spoken is key, value is turn
#   improvement:  create a 2nd dict to keep track of how many times each number was called



import collections
from datetime import datetime
import numpy as np

print('Advent of Code 2020')
print('--- Day 15: Rambunctious Recitation ---')
print('Part 2')


#start_string = "0,3,6".split(',')
#start_string = "1,3,2".split(',')
#start_string = "2,1,3".split(',')
#start_string = "1,2,3".split(',')
#start_string = "2,3,1".split(',')
#start_string = "3,2,1".split(',')
#start_string = "3,1,2".split(',')

# official input
start_string = "6,3,15,13,1,0".split(',')

start_numbers = []
for s in start_string:
    start_numbers.append(int(s))

#nth_number_spoken = 2020 
nth_number_spoken = 30000000
numbers = {}   # contains tuples.  number spoken is key, value is (turn, prev turn)
numbers_score_board = {}

# begin with starting numbers
for i in range(0, len(start_numbers)):
    numbers[start_numbers[i]] = (i+1, 0)  # value tuple (turn, last turn this number was spoken)
    numbers_score_board[start_numbers[i]] = 1

# play game
last_number_spoken = start_numbers[-1]
print('Start ', datetime.now().strftime('%Y-%m-%d %H:%M:%S'))

if not 0 in numbers_score_board:
    numbers[0] = (0,0)  # account for 0 if not present
    numbers_score_board[0] = 0

t = len(start_numbers)   # Turns
while True:
    t += 1
    # consider the last number spoken: is it first time it's been spoken
    # count items in a list:  https://stackoverflow.com/questions/2600191/how-can-i-count-the-occurrences-of-a-list-item
    if last_number_spoken in numbers_score_board and numbers_score_board[last_number_spoken] == 1:
        new_nbr = 0
        old, old_old = numbers[new_nbr]
        numbers[new_nbr] = (t, old)
        numbers_score_board[new_nbr] += 1
    else:
        #  next number is diff between last time number was spoken and time before that

        i2, i3 = numbers[last_number_spoken] #i2 = last turn, i3 prev last turn

        new_nbr = i2 - i3

        if new_nbr in numbers:
            old, old_old = numbers[new_nbr]
            numbers[new_nbr] = (t, old)
            numbers_score_board[new_nbr] += 1
        else:
            numbers[new_nbr] = (t, 0)
            numbers_score_board[new_nbr] = 1  

    last_number_spoken = new_nbr   

    #print(new_nbr)

    if t >= nth_number_spoken:
        break

    if t % 3e6 == 0:
        print(t,datetime.now().strftime('%H:%M:%S'), last_number_spoken, sep=',')
    if t > 31e6:
        print('Error runaway loop')
        break

print('Finish ', datetime.now().strftime('%Y-%m-%d %H:%M:%S'))



# 12/28/2020 is there an invariant in the algorithm?  Maybe don't need to run it 30e6 times?

sqls = "PuzzleOutputNbrsSpoken.txt"
with open(sqls, 'w') as output:
    for n in numbers_score_board:
        output.write(str(n) + ', ' + str(numbers_score_board[n]) + '\n')


#https://stackoverflow.com/questions/15579649/python-dict-to-numpy-structured-array

# names = ['n','cnt']
# formats = ['i','i']
# dtype = dict(names = names, formats=formats)
# a = np.array(list(numbers_score_board.items()), dtype=dtype)
# print('Min', np.min(a, axis=2))
# print('Max', np.max(a, axis=2))
# print('Count', np.count(a))

# https://stackoverflow.com/questions/3518778/how-do-i-read-csv-data-into-a-record-array-in-numpy
from numpy import genfromtxt
my_data = genfromtxt('PuzzleOutputNbrsSpoken.txt', delimiter=',')
print('Min', np.min(my_data))
print('Max', np.max(my_data))
print('Count', len(numbers_score_board))


#print(numbers)

# Part 2 of the Day 15 puzzle:
print()
print('Day 15 Part 2:  given starting numbers the 30 000 000th number spoken will be?', last_number_spoken)
