# ORM/LINQ with [SQLite](https://sqlite.org/index.html)

This library shows snippet that show you how to use ORM with SQLite.

Note: There are more optimal ways to do this with Entity Framework.

## Setup

1. Add the dll "SQLite.Interop.dll" to your **PROJECT**, **not** your references.
2. Set *Copy to Output Directory* to "Copy always" for that dll
3. Add the dll's "System.Data.SQLite.dll" and "System.Data.SQLite.Linq.dll" to your projects *References*

## Usage
See the files of this project

## SQLite Infos

### Datatypes
Here are the datatypes of SQLite and the respective datatypes for C#

| **SQLite** | **C#** |
| ----- | ----- |
| Integer | int (possibly long) |
| Real | double |
| text | string |

The size of integers in SQLite is not static. If large enough values occur in the table, SQLite may use up to 64-bit to store the columns values. For such values, you need to use long in C#, as int is only 32-bit in C#.

### [Autoincremented Primary Keys](https://www.sqlite.org/lang_createtable.html#rowid)

SQLite by design generates a 64-bit unique identifier for every row of a table.
These can be accessed via the column name "rowid", "oid" or "\_rowid\_".
If a column in a table is defined as:
```sql
integer primary key
```
it automatically refers to this value.