endpoints https://localhost:44309/Locations
https://localhost:44309/icons

* images are not stored in the database.Instead URL is stored .Image details can be viewed at https://localhost:44309/icon
I have used foursquares api to retrieve api data.Unfortunatatly the images are restricted on public token.
* Coordinates can be typed into the view whic retrieves data from foursqaures api the http string is set to quary landmarks only and 
with a limit of 1.So there is no performance issues 
.I have used postman to check the return of send an API call so the source.
Database contains 
Location table
Icon/image table
Venues table
Groups table
Solution was developed using APS.Net MVC 
to create the database first add-migration  and update-database 

