/*   Advent of Code 2020  Day 7 Handy Haversacks https://adventofcode.com
   Created 12/07/2020
*/

/*
drop table luggage_rules
*/
create table luggage_rules (
    rule_id smallint not null,
    seq_id smallint not null,
    bag_color varchar(25) not null,
    bag_count smallint null,
    contains_color varchar(25) null,
    node_id int not null identity(0, 1)  -- for debugging not really needed?
)


drop table #bag_colors
drop table #owt
GO

select bag_color
 into #bag_colors
from luggage_rules
where contains_color = 'shiny_gold'

select bag_color into #owt from #bag_colors

--select * from #bag_colors

declare @bag_color_count smallint
declare @this_bag_color varchar(25)

select @bag_color_count = count(*) from #bag_colors

while @bag_color_count > 0
begin
    -- POP a bag color off stack
    select top 1 @this_bag_color = bag_color
    from #bag_colors

    delete from #bag_colors where bag_color = @this_bag_color

    -- find all rules / bag colors with this color as contaning/child color
    insert into #owt
    select bag_color
    from luggage_rules
    where contains_color = @this_bag_color
    and bag_color not in ( select bag_color from #owt)

    insert into #bag_colors
    select bag_color
    from luggage_rules
    where contains_color = @this_bag_color
    and bag_color not in (select bag_color from #bag_colors)

    -- are we done yet?
    select @bag_color_count = count(*)  from #bag_colors
end

--select 'Part 1 Day 7 Puzzle list possible containers of ''shiny gold'''
select bag_color from #owt --group by bag_color

--select * from #owt


-- Part 2:  how many bags must my shiny gold bag contain?
-- given a bag_color node, hit every node in its tree and count up the bag count

set nocount on

drop table #stack
drop table #rule_stack
drop table #bag_totals
drop table #owt2
drop table #bag_totals_by_bag_color
go

create table #stack (
    rule_id smallint not null,
    seq_id smallint not null,
    bag_color varchar(25) not null,
    bag_count smallint null,
    contains_color varchar(25) null,
    node_id int not null
)

-- given a child/contains color stack for rule that applies to that color
-- rules can have more than one row so need separate table to hold just the rule IDs
create table #rule_stack (
    rule_id smallint not null,
    stack_id int not null identity(0, 1)  -- same rule can appear more than once on stack
)

create table #bag_totals (
  bag_count smallint,
  child_bag_count smallint
)

--push root of the tree rule and 1 or more contains (seq_id) colors for color 'shiny_gold'
--insert into #stack (rule_id, seq_id, bag_color, contains_color, bag_count, node_id)
--select rule_id, seq_id, bag_color, contains_color, bag_count, node_id
--from luggage_rules
--where bag_color = 'shiny_gold'

insert into #rule_stack
select rule_id
from luggage_rules
where bag_color = 'shiny_gold'
group by rule_id

declare @stack_count smallint
declare @rule_id smallint
declare @seq_id smallint
declare @this_contains_color varchar(25)
declare @this_bag_color varchar(25)

select @stack_count = count(*) from #stack

--bag count total per bag_color
--this table will give us the total bag count when were done
-- insert row for each seq or containing color how many and how many bags it's children may contain
insert into #bag_totals
select a.bag_count, 1 --root node is count of how many bags each seq in the rule contain
from luggage_rules a
where bag_color = 'shiny_gold'

declare @this_node_id int
declare @cnt smallint
declare @this_bag_count smallint
declare @bagtot smallint
declare @loopctr SMALLINT
select @loopctr = 0

declare @stack_id smallint
declare @rule_stack_count smallint
select @rule_stack_count = count(*) from #rule_stack

while @rule_stack_count > 0
begin
    --ordering doesn't matter just pop a rule/node and keep going
    select top 1 @rule_id = rule_id, @stack_id = stack_id
    from #rule_stack

    delete from #rule_stack where stack_id = @stack_id

    -- get rules that apply to this color
    insert into #stack
    select
      rule_id,
      seq_id,
      bag_color,
      bag_count,
      contains_color,
      node_id
    from luggage_rules
    where @rule_id = rule_id

     select @stack_count = count(*) from #stack

    --loop over each component of this rule
    while  @stack_count > 0
    begin
      select top 1
        @seq_id = seq_id,
        @this_bag_color = bag_color,
        @this_contains_color = contains_color,
        @this_bag_count= bag_count,
        @this_node_id = node_id
      from #stack
      where @rule_id = rule_id

      -- insert row for each seq or containing color how many and how many bags it's children may contain
      insert into #bag_totals
      select bag_count,
        (select sum(bag_count) from luggage_rules where bag_color = @this_contains_color)
      from luggage_rules a
      where @rule_id = rule_id
      and @seq_id = seq_id

      -- push the child 'node' (rule set) on to stack
      insert into #rule_stack (rule_id)
      select rule_id
      from luggage_rules
      where bag_color = @this_contains_color
      and contains_color != '-'  --don't push same rule back on stack
      group by rule_id

      delete from #stack where node_id = @this_node_id
      
      select @stack_count = count(*) from #stack


    -- bail out if infinite loop
    -- select @loopctr = @loopctr + 1
    -- if @loopctr > 25  return

    end

    --update stack count items could have added in the inner loop
    select @rule_stack_count = count(*) from #rule_stack

    -- bail out if infinite loop
    select @loopctr = @loopctr + 1
    if @loopctr > 1e6  return

end

--select 'Part 2 Day 7 Puzzle'
select sum(bag_count*child_bag_count) as bag_total
from #bag_totals

select * from #bag_totals

sp_who2 'active'
kill 72

select * from #rule_stack

/* data */
/* demo data */
insert into luggage_rules values (1,1,'light_red', 1, 'bright_white')
insert into luggage_rules values (1,2,'light_red', 2, 'muted_yellow')
insert into luggage_rules values (2,1,'dark_orange', 3, 'bright_white')
insert into luggage_rules values (2,2,'dark_orange', 4, 'muted_yellow')
insert into luggage_rules values (3,1,'bright_white', 1, 'shiny_gold')
insert into luggage_rules values (4,1,'muted_yellow', 2, 'shiny_gold')
insert into luggage_rules values (4,2,'muted_yellow', 9, 'faded_blue')
insert into luggage_rules values (5,1,'shiny_gold', 1, 'dark_olive')
insert into luggage_rules values (5,2,'shiny_gold', 2, 'vibrant_plum')
insert into luggage_rules values (6,1,'dark_olive', 3, 'faded_blue')
insert into luggage_rules values (6,2,'dark_olive', 4, 'dotted_black')
insert into luggage_rules values (7,1,'vibrant_plum', 5, 'faded_blue')
insert into luggage_rules values (7,2,'vibrant_plum', 6, 'dotted_black')
insert into luggage_rules values (8,1,'faded_blue', 0, '-')
insert into luggage_rules values (9,1,'dotted_black', 0, '-')


/* demo 2 */
insert into luggage_rules values (1,1,'shiny_gold', 2, 'dark_red')
insert into luggage_rules values (2,1,'dark_red', 2, 'dark_orange')
insert into luggage_rules values (3,1,'dark_orange', 2, 'dark_yellow')
insert into luggage_rules values (4,1,'dark_yellow', 2, 'dark_green')
insert into luggage_rules values (5,1,'dark_green', 2, 'dark_blue')
insert into luggage_rules values (6,1,'dark_blue', 2, 'dark_violet')
insert into luggage_rules values (7,1,'dark_violet', 0, '-')


select count(*) from luggage_rules
select * from luggage_rules

/* check count and don't include the test data in file run :)  */
/* delete from luggage_rules */

/* run python script to generate SQL inserts. */
/* sample output ... */
insert into luggage_rules values (1,1,'mirrored_gold', 3, 'light_teal')
insert into luggage_rules values (2,1,'clear_gold', 5, 'light_maroon')
insert into luggage_rules values (2,2,'clear_gold', 4, 'pale_tomato')
insert into luggage_rules values (2,3,'clear_gold', 5, 'clear_blue')
insert into luggage_rules values (3,1,'dark_olive', 5, 'plaid_black')
insert into luggage_rules values (3,2,'dark_olive', 2, 'dim_plum')
insert into luggage_rules values (3,3,'dark_olive', 2, 'light_cyan')
insert into luggage_rules values (4,1,'bright_white', 2, 'pale_violet')
insert into luggage_rules values (4,2,'bright_white', 5, 'mirrored_orange')
insert into luggage_rules values (4,3,'bright_white', 3, 'faded_beige')
insert into luggage_rules values (5,1,'posh_green', 4, 'shiny_gray')
insert into luggage_rules values (6,1,'posh_lime', 3, 'muted_lavender')
insert into luggage_rules values (6,2,'posh_lime', 1, 'clear_magenta')
insert into luggage_rules values (6,3,'posh_lime', 5, 'muted_orange')
insert into luggage_rules values (6,4,'posh_lime', 3, 'mirrored_cyan')
insert into luggage_rules values (7,1,'striped_turquoise', 3, 'pale_red')
insert into luggage_rules values (7,2,'striped_turquoise', 4, 'wavy_lime')
insert into luggage_rules values (7,3,'striped_turquoise', 4, 'wavy_aqua')
insert into luggage_rules values (8,1,'pale_fuchsia', 1, 'striped_purple')
insert into luggage_rules values (9,1,'dark_magenta', 4, 'light_indigo')
insert into luggage_rules values (9,2,'dark_magenta', 1, 'wavy_lavender')
insert into luggage_rules values (9,3,'dark_magenta', 1, 'clear_teal')
insert into luggage_rules values (10,1,'drab_teal', 5, 'pale_bronze')

