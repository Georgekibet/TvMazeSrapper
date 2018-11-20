# TvMazeSrapper
Small assignment

Usage:

To retrieve the tv shows and cast information as required in this excercise, type the url in the following format.
url/api/shows/itemsperpage/pagenumber e.g http://localhost:18338/api/shows/50/1 to get page 1 of paginated data containing 50 items per page

Technical Details:

1. Used Qartz -v 3.0.7 job scheduler library to schedule Job for data scraping from http://www.tvmaze.com/api.
2. Used SQL database with Microsoft.EntityFrameworkCore 2.1.4 for database.
3. Used http://json2csharp.com/ to generate DTOs for the raw remote data objects scraped from http://www.tvmaze.com/api.
4. Solution developed with VS 2017 -v15.8.9 IDE using .Net core 2.1.
