# iron-and-glass

## Api
C# WebApi. Scrapes the http://www.jarngler.is/serpantanir/ website for the most recent special orders list. Downloads the Excel sheet and maps it into an array of Beer objects.

### Example of beer object
Beer: {
    Name: 'Decadence 2014 - 10% - 750 ml',
    Id: 'Alesmith-006',
    Manufacturer: 'Alesmith',
    Price: '2600',
    PriceInAtvr: '3804,32',
    PriceWithTax: '3224'
}

### Example of use:
GET localhost:8000/api/beer - returns all Beer objects
GET localhost:8000/api/beer?skip=4 - skips the first 4 rows of the Excel sheet