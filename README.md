# advent-of-code-2020

## My solutions to the Advent of Code 2020 puzzles

Advent of Code Website:  [Advent of Code 2020](https://adventofcode.com)

My solution to each day's puzzles is in its own folder.  Programming language and environment vary.  Solutions are added after the day's puzzles release date has passed.

1. Day 1:  Report Repair. (C# and .NET Core, Console app, Visual Studio Code, macOS)
2. Day 2:  Password Philosophy (C# and .NET Core, Console app, VS Code, macOS)
3. Day 3:  Toboggan Trajectory (C# and .NET Core, Console app, VS Code, macOS)
4. Day 4:  Passport Processing (C# and .NET Core, Console app, VS Code, macOS)
5. Day 5:  Binary Boarding (Python, macOS)
6. Day 6:  Custom Customs (Python, macOS)
7. Day 7:  Handy Haversacks (Python for ETL, macOS, and T-SQL, an Azure SQL db, Azure Data Studio to solve)
8. Day 8:  Handheld Halting (Python, Visual Studio Code, Windows)
9. Day 9:  Encoding Error (C# .NET Core, Console app, Visual Studio 2019, Windows)
10. Day 10: Adapter Array (C# .NET Core, Console app, Visual Studio 2019, Windows)
11. Day 11:  Seating System (C# .NET Core 3.1, Console app, VS 2019, Windows)
12. Day 12:  Rain Risk (Python, macOS)
13. Day 13:  Shuttle Search (Python, macOS)
14. Day 14:  Docking Data (Python, macOS)
15. Day 15:  Rambunctious Recitation (Python, macOS)
16. Day 16:  

### Notes

* Day 12 Part 1 - pass, Part 2 - pass.  Refactored code to improve it, but
still had to create additional test data.  Finally found the bug.  It was
in the rotation code.  I had assume R90 was good but it wasn't.
[subreddit](https://www.reddit.com/r/adventofcode/comments/kbj5me/2020_day_12_solutions/)

* Day 10 Part 1 - pass, Part 2 - pass.  After much failure and re-thinking I finally got a working program
for Part 2.  I drew a picture of the sample data with paper and pencil and finally realized the 
adapter array is not an acyclic directed graph but a directed graph.  
With right picture implementing a recursive algorithm walk the 
tree [Wikipedia](https://en.wikipedia.org/wiki/Directed_graph) was straightforward 
and soon the program was delivering the right answers with test data.  Last problem to solve was how
to make the process more efficient with the full data set, and it didn't take too much longer, with picture in hand, to
see a Dictionary object collecting each adapter with its sum of connections going forward would cut the problem down to size.

* 12/21/2020 (Winter Solstice in Northern Hemisphere) Returned to Day 7 Part 2 - could not work out the T-SQL solution to calculate correct answer.  Pretty sure
I was on right track, but I couldn't get the T-SQL code compute right answer.  Rewrote solution in Python and picked up another star.

* Best: Day 5 Binary Boarding was the puzzle I liked the best so far.

* I found the Day 10 Adapter Array puzzle the most difficult so far, to Day 15.
