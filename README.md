# Identity App
## Overview
Identity App is a web application that provides a Web API for other applications to access over the Internet using HTTP. It allows other applications to retrieve the identity of a person based on their name by sending an HTTP GET request to the GetIdentity action method in the IdentityController. This action method takes a name parameter and passes it to the IIdentityService, which retrieves the age, gender, and country of the person from external APIs using refit clients. The service then creates an age bracket based on the age of the person, and the collected information is stored in a new IdentityResponse object. The IdentityResponse object is returned to the caller as the response of the GetIdentity action method.

Overall, the IdentityApp provides a convenient way for other applications to retrieve the identity of a person based on their name by using the GetIdentity action method in the IdentityController. The IIdentityService handles the process of retrieving the relevant information from external APIs and creating the appropriate IdentityResponse object, which is then returned to the caller.
## UML Class Diagram
![csit340-final-project-t3sters class diagram](https://user-images.githubusercontent.com/111823676/208244778-ec870025-2b7c-4af1-8bf5-d8dfa2fe7586.png)
The factory pattern allows us to create objects, in this case age brackets, without specifying the exact class of object that will be created. This is useful in our project because we do not know the age of the person beforehand, and the factory pattern allows us to create the appropriate age bracket without knowing the specific age. By using the factory pattern, we can create age brackets in a more flexible and maintainable way, as we can centralize the creation process in a single location and decouple the creation process from the specific age brackets that are created. This can improve code readability and organization, and also make it easier to add new age brackets in the future.
## Endpoint
###### Get Identity
```
GET /api/identity?name=John
```
###### Response
```
{
  "name": "John",
  "gender": "male",
  "country": "IE",
  "age": 71,
  "ageBracket": "Boomers I"
}
```
