GIT TASK2
This application is a simple console project that simulates an equipment rental service.
It allows user to add people, add equipment, check which equipment is available, 
rent equipment, return it and see a simple summary report.
The console is used as the user interface.

Project structure

I divided the code into folders:
Models – contains basic classes with data, for example Equipment, User, Rental
Services – contains the main logic of the application, for example renting and returning equipment
Database– contains Singleton, which stores all users, equipment and rentals in memory
Interfaces – contains service interface
Program.cs– shows how the application works in console
Because of this structure, the code is more clear and responsibilities are not mixed.

Business rules
The application includes these rules:
Student can have maximum 2 active rentals
Employee can have maximum 5 active rentals
Equipment with status Unavailablecannot be rented
Equipment that is already rented also cannot be rented again
Late return gives penalty of 5 for each day
Overdue rentals can be detected
Main business rules are placed in RentalService, so it is easier to manage and change them later

Cohesion in this project is good, because each class has its own role.
For example:
equipment classes store only information about equipment
User stores only user data 
Rental stores rental information 
RentalService handles application logic
So each class does one main thing.

Coupling is lower because logic is separated into different classes.
Program.cs is used only to show the scenario in console, while the main logic is inside the service class.
This way the code is easier to read, test and improve.

--Running the project
The project can be run in Rider 

Hope to the better