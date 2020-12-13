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
13. Day 13:

### Notes

* Day 12 Part 1 - pass, Part 2 - fail.  I think program is ok but there's
a bug(s) in it.  Is there an easier way to do the rotations and transformation?
Matrices maybe?

* Day 10 Part 1 - pass, Part 2 - fail. I attempted Part 2, but no go and did not compute the right answer.
After much thought I think the key is keep track of adapters which are dead ends (are not the last adapter in the chain and cannot connect to anything else) in a
reference object outside the recursion and prune out dead end pathways.
I couldn't pull it off.

* Abandoned Day 7 Part 2 - could not work out the T-SQL solution to calculate correct answer.  If I have time I'll return an redo part 2 in Python or C#.

* Day 5:  Binary Boarding was the puzzle I liked the best, so far.