#   Advent of Code 2020  Day 7 Handy Haversacks https://adventofcode.com
#   Created 12/07/2020
#   Refactored code on 12/8/2020 to get part 2 solution

import re
import collections
import sys


print('Advent of Code 2020')
print('--- Day 7: Handy Haversacks ---')
print()

file_name = "PuzzleInput.txt"
sqls = "PuzzleInputSQLs.sql"

rule_id = 0
seq_id = 0

with open(sqls, 'w') as output:
    with open(file_name) as f:
        for line in f:
            new_line = re.sub(r'\bbags', '', line.strip())
            new_line = re.sub(r'\bbag', '', new_line)
            new_line = re.sub(r'\bcontain\b', ',', new_line)
            new_line = re.sub(r"no other",'0, -',new_line)
            new_line = re.sub(r"([a-z]) ([a-z])", "\\1_\\2",new_line)
            new_line = re.sub(r"([0-9]) ([a-z])", '\\1,\\2',new_line)
            new_line = re.sub(r'\b', '', new_line)
            new_line = re.sub(r"\.",'',new_line)

            # new_line should now be a comma separated list

            l = new_line.split(',')
            #print(l)
            #sys.exit()

            key = l.pop(0)
            rule_id += 1   # rule ID number
            seq_id =0      # number each component of rule together the rule ID and seq ID form a primary key
            while len(l) > 0:
                v = l.pop(0)
                child = l.pop(0)
                seq_id += 1
                sql = "insert into luggage_rules values (" + str(rule_id) + "," + str(seq_id) + ",'" + key.strip() + "', " + v.strip() + ", '" + child.strip() + "')"
                print(sql)
                output.write(sql + '\n')



# Part 1 of the Day 7 puzzle:

print()
print('Part 1:  ')

# Part 2 of the Day 7 puzzle:

print()
print('Part 2:  ')

