# iron-and-glass

## Api
C# WebApi. Scrapes the http://www.jarngler.is/serpantanir/ website for the most recent special orders list. Downloads the Excel sheet and maps it into an array of Beer objects.

### Example of use:
* GET localhost:8000/api/beer - returns all Beer objects
* GET localhost:8000/api/beer?skip=4 - skips the first 4 rows of the Excel sheet

### Demo
http://jarnoggler.azurewebsites.net/api/beer

### Example response
```javascript
[
    {
      "Id": "Alesmith-006",
      "Name": "Decadence 2014 - 10% - 750 ml",
      "Price": "2600",
      "PriceWithTax": "3224",
      "PriceInAtvr": "3804.32"
    },
    {
      "Id": "Alesmith-007dós",
      "Name": "Alesmith IPA 7,25% 355ml dós",
      "Price": "680",
      "PriceWithTax": "755",
      "PriceInAtvr": "890.9"
    }
]
```