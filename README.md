# Welcome to EF-Core-Pageination-NET6 Repository
### This is where I test and trying to learn/implement Pagination in a .NET 6 web API project


## Pagination (Summary)
1. Don't use the Product model itself for respone
    - Use the data that is not map to the Database
    - Create a Object(DTO) consist of:
        - List of Products
        - CurrentPage 
2. Use Skip and Take before ToListAsync()