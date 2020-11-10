# Entity Framework Project

## Project Goal
The goal of this project is to create an application in which users can either buy or sell products. Customers should be able to browse through the products, place orders and view these orders. Sellers should be able to list all of their available products, view how well these products are doing and manage a list of all currently placed orders.

## Definition of Done
- [ ] Program should be fully functional, matching the minimum viable product specified
- [ ] Business layer should be fully unit tested
- [ ] GUI layer should be fully separated from business layer
- [ ] The project should be fully documented throughout the entire process
- [ ] User stories should be achieved

## Sprint 1
### Review
#### Sprint Goals
- [x] Create a template for the README
- [x] Model the database to be used within the project
- [x] Implementation of user account creation and modification through the GUI
- [x] Provide the ability through the GUI to switch between different users and account types
- [x] Implementation of basic CRUD operations
- [x] Unit tests for CRUD operations

#### Project Board 
![Sprint 1 Snapshot](Snapshots/Sprint1Snapshot.PNG)

#### User Stories Completed
* Product Browsing
* User Configuration
* User Login
* Seller Account Creation
* Customer Account Creation

### Retrospective
#### Overview
* Code first approach worked well and I was able to successfully create a database within the entity framework
* This was not completely without issue however and time was spent solving issues with the package manager console and rebuilding the database whenever these issues arose
* CRUD operations for the different entities currently in use were implemented successfully 
* CRUD operations for entities that are currently not implemented in the application do not exist yet such as Order operations
* All Unit tests for currently implemented CRUD operations are implemented and pass
* A parent CRUD manager was created that all other CRUD managers inherit from which allowed for generic operations such as SetSelected and RetrieveAll  to be simplified, as shown below:
``` C#
		public List<T> RetrieveAll<T>(DbSet<T> set) where T : class
		{
			using (ProjectContext db = new ProjectContext())
			{
				return set.ToList();
			}
		}
```
*  Time was spent learning the most effective methods to navigate between different pages and while this was achieved, there may be potential issues going forward which will have to be addressed in the next sprint
*  Both the Customer and Seller entities exist as children to the User entity and this is reflected in the database
*  All the sprint goals were achieved

#### Action Plan For Next Sprint
* Spend more time researching page navigation within WPF applications
* Continue developing CRUD operations for entities as they are implemented in the application
* Continue to complete the defined user stories

## Sprint 2
### Review
#### Sprint Goals
- [x] Complete layout of seller page on the GUI
- [x] Implementation of product listing including both creating and viewing products
- [x] Implementation of product viewing on the GUI for customers
- [x] Basic functionality for customers viewing and ordering products
- [x] Unit test new features

#### Project Board
![Sprint 2 Snapshot](Snapshots/Sprint2Snapshot.PNG)

#### User Stories Completed
* User Switching
* Product Information
* Customer Product Order
* Seller Page Layout
* Product Listing

### Retrospective
#### Overview
* Issues with page navigation have been solved and the implementation now uses frames to display different pages within a parent window
* This took longer than expected and left me with less time to focus on the other aspects of the sprint
* Despite this, the rest of the sprint goals were completed on time
* The product aspect of the application has been completed with the ability for sellers to now create and update different products and the customers to browse these products
* Most of the user interface has now been created despite not all the functionality being there
* Some logic within the GUI has been repeated and could instead be moved to a seperate class, specifically the code used to display the product information
* New CRUD operations were implemented along side the new functionality
* These operations have been fully unit tested and pass

#### Action Plan For Final Sprint
* Going into the final sprint it will be important to organise the remaining project backlog by priority

## Sprint 3

![Sprint 3 Snapshot](Snapshots/Sprint3Snapshot.PNG)
### Review

#### What Went Well?

Custom event system allowing for two pages to communicate when running concurrently

#### Improvements?

Not all features that were originally planned were implemented

#### Action Plan



### Retrospective



*Class Diagrams and ERD*