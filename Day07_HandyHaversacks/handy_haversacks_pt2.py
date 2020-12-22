#   Advent of Code 2020  Day 7 Handy Haversacks https://adventofcode.com
#   Created 12/21/2020
#   Part 2 solution

import re
import collections
import sys

# bag color rule object:  
# a bag color
# and contains a dictionary object of 0 or more bag colors and their counts

class BagColorRule:
    color = ''
    must_contain = {}
    N = 0

    def __init__(self, color):
        self.color = color
        self.N = 0
        self.must_contain = {}

    def ToString(self):
        str(self.color)

    def IndexOf(self, clr):
        return self.must_contain.keys().index(clr)

def print_rule_set(rule_set):
    for rule in rule_set:
        print(rule.color,':')
        for c in rule.must_contain:
            print('   ', rule.must_contain[c], ' ', c)


def n_bag_contains_colors(rule_set, this_color):
    sum = 0

    print(this_color)

    # find bag color in the list of rules
    for bag in rule_set:
        if bag.color == this_color:
            if bag.N == 0:
                # end of the road this bag doesn't contain any others
                return 0
            else:
                # for each bag this bag can hold count * count of containing bags
                for key in bag.must_contain:
                    sum +=  bag.must_contain[key] + (bag.must_contain[key] * n_bag_contains_colors(rule_set, key))
                return sum  # break out of loop and return
    
    return sum



print('Advent of Code 2020')
print('--- Day 7: Handy Haversacks ---')
print('Part 2')

file_name = "PuzzleInputDemo2.txt"

rule_id = 0
seq_id = 0

rule_set = []

with open(file_name) as f:
    for line in f:
        new_line = re.sub(r'\bbags', '', line.strip())
        new_line = re.sub(r'\bbag', '', new_line)
        new_line = re.sub(r'\bcontain\b', ',', new_line)
        new_line = re.sub(r"no other", '0, -', new_line)
        new_line = re.sub(r"([a-z]) ([a-z])", "\\1_\\2", new_line)
        new_line = re.sub(r"([0-9]) ([a-z])", '\\1,\\2', new_line)
        new_line = re.sub(r'\b', '', new_line)
        new_line = re.sub(r'\s', '', new_line)
        new_line = re.sub(r"\.", '', new_line)

        # new_line should now be a comma separated list

        l = new_line.split(',')
        # print(l)
        # sys.exit()

        new_bag_rule = BagColorRule(l.pop(0).strip())
        c = 0
        while len(l) > 0:
            v = int(l.pop(0))
            color = l.pop(0)
            new_bag_rule.must_contain[color] = v
            c += v

        new_bag_rule.N = c
        rule_set.append(new_bag_rule)

print_rule_set(rule_set)

# Part 2 of the Day 7 puzzle:

print()
print('Part 2:  ')

sum = n_bag_contains_colors(rule_set, 'shiny_gold')

print('Sum of count of bags contained in shiny gold: ', sum)
