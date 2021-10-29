This is a simple to do proof-of-concept.

This uses repository and service patterns for communication with the datasource.

The datasource in this instance is a MSSQL database. Entity Framework is used to handle the data.

AutoMapper is used to map objects from the datasource to the view model.

Dependency Injection is used to make changing to a different datasource easier. Also, testing is much easier with DI.

The frontend is using React with reactstrap and React Router.

I started with a new React project in Visual Studio using .NET 5. I stripped out most of the example code and began
by building out the Data Access Layer. Once it was in place, I built the UI. With the UI taking shape I build the
controller and view model.

Future enhancement ideas:

* Add OAuth and allow for multiple users and a level of security
* Edit to dos
* Sort to dos
* Hide completed to dos
* Make a better confirmation box when deleting to dos
* Add some sort of notification when to dos are nearing or over due
* Add better validation when adding a new to do
* Add unit testing