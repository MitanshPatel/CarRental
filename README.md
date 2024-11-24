# CarRental

## User Controller

Exposes API endpoints for user registration and authentication.

### Endpoints:

- **POST /users/register:** Register a new user  
  ![Screenshot](images/userreg.png)

- **POST /users/login:** Login and get JWT token  
  ![Screenshot](images/userlog.png)

## Car Controller

Exposes API endpoints for managing cars.

### Endpoints:

- **GET /cars:** Get a list of available cars (anyone can access it, no auth required, only available cars)  
  ![Screenshot](images/getcar.png)

- **POST /cars:** Add a new car to the fleet (added JWT auth in header, only Admin can access)  
  ![Screenshot](images/newcar.png)  
  No JWT token used:  
  ![Screenshot](images/newcarunauth.png)  
  When User tries to access it (JWT of User used in header):  
  ![Screenshot](images/newcarunauth.png)

- **PUT /cars/{id}:** Update car details and availability (only Admin JWT header can access it)  
  ![Screenshot](images/updatecardetails.png)

- **DELETE /cars/{id}:** Delete the car details (only Admin JWT header can access)  
  ![Screenshot](images/deletecar.png)

- **GET /cars/{id}:** Get car details by ID (anyone can access it, no auth required, only available cars)  
  ![Screenshot](images/particularcar.png)

- **POST /cars/rentcar:** Rent a car (only User JWT header can access)  
  ![Screenshot](images/rent1.png)  
  Car Id 2 gets removed from available cars:  
  ![Screenshot](images/rent2.png)  
  Admin cannot access this:  
  ![Screenshot](images/rent3.png)

- **POST /cars/returncar:** Return a car (only User JWT header can access)  
  ![Screenshot](images/return1.png)  
  Car Id 2 gets added to available cars:  
  ![Screenshot](images/return2.png)
