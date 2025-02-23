# Expense-Tracker

Project URL: https://roadmap.sh/projects/expense-tracker

```
# Use the below operations to play around with Expense Manager:

dotnet run
# displays all options available on Expense Manager

dotnet run -- add --amount 1250 --description health --category gym
# add an expense with the given amount, description, category.
# if no category is specified, item is added with default category of 'general'

dotnet run -- delete --id 2
# deletes entry with id 2

dotnet run -- summary --month 2 --year 2025 --category med
# displays the total expense of items purchased on given month, year and filtered for given category
# the additional filters are optional

dotnet run -- list
# displays all of the items added so far in the list

dotnet run -- budget --amount 2000
# adds budget for the current month. All added expenses post adding a budget is checked against the stored budget
```