# Excel Reader

A Small Application that connects to a local SQL Server Database and adds infomation extracted from an Excel document as entries in the database.
## Features

- Fetches business information saved in an Excel document (Existing Id Number, First and Last Name, Email, Phone, and Department Name) using EPPlus to extract data.
- Deletes and Re-creates the Database and it's tables every time the application runs to ensure no outdated records from previous Excel documents.
- Status messages to inform the user of what the application is currently doing in the background. Entries added to database are displayed when database and excel operations are complete!




## Tech Stack

**Runtime & Framework:** .NET 8

**Database ORM:** Entity Framework

**Database:** SQL Server

**Excel Library:** EPPlus


## Lessons Learned

- Manipulating Excel documents with code is something I've done previously, but using Python and Openpyxl, which helped me pick up using EPPlus rather quickly. They share a lot of the same logic (and I imagine limitations) of how to read and write to and from excel files, so this was mostly just finding the C# version of things I already know like accessing the worksheet and individual rows, columns, and cells.

- I took the approach that the "Id" provided in the Excel file would correlate to some other information and shouldn't be changed, so this was the first project with the entity framework where I had to figure out how to still have the "Id" but not allow it to automatically create that when adding an entry to the database. There's a lot of, what I can only assume to be, outdated solutions for this online, so I did end up trying to overengineer this longer than I would have liked. The DatabaseGenerated attribute was effectively a one-line fix to this problem, where I could just instruct the entity framework to not generate that value.
## Acknowledgements

 - [The C# Academy](https://www.thecsharpacademy.com/)
 - [README Editor](https://readme.so/editor)
 - [Mockaroo](https://www.mockaroo.com) - Great source for all kinds of mock data!

