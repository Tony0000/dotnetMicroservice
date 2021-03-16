# .NET Microservice

Instructions
-----------
Firstly, you will need to create a free account on [openweather](https://openweathermap.org/) and generate an Api key (it may take some minutes for your key to be activated and usable).

Step 1: Build image
----------
run `docker build -t [image-name]:[version] .` in the root directory.

Step 2: Run container
--------
run `docker run -d -p [port]:80 --name [container-name] -e ServiceSettings:ApiKey=[api-key] [image-name]:[version]`

Step 3: Check if everything is working
----------
Using Postman or any browser, do the following: 
- Send a request to url `localhost:[port]/weather` to see if the service is running correctly. You should receive a message "it is working".
- Send a request to url `localhost:[port]/health` to check if your api is activated and is already usable. You should receive "Healthy" if your Key is usable or "Unhealthy" otherwise.
- Finally you can query the current weather for any city by sending a request to endpoint: `localhost:[port]/weather/[city-name]`
