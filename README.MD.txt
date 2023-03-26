1. the attached solution is a basic solution to depict a basic ecommerce API project
2. I had issues getting my local sql instance up and running as i was running low on memory, so i have attached a mock in memory database which sits in the database Folder. 
3. i used a delegate to be a little fancy it's not always necessary an interface works just as well :)
4. to pass an order through here is what the post body should look like when using postman:
{
  "products": [
    {
      "id": 1,
      "quantity": 2,
      "name": "string",
      "description": "Double Edge Basin",
      "price": 2.99
    },
	{
	  "id": 1,
      "quantity": 2,
      "name": "string",
      "description": "Double Edge Basin",
      "price": 2.99
	}
  ],
  "ordertotal": 0,
  "customer": {
    "id": 0,
    "firstname": "string",
    "lastname": "string",
    "emailAddress": "string",
    "isGuest": true
  }
}

orderTotal is not necessary as software will work it out. 
