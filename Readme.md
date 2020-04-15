# Microservices demo with event driven architecture to the services communication

The purpose of this project is to show the communication between microservices.

## Architecture

![Architecture](https://github.com/cealer/microservices-demo/blob/master/architecture.png)

### Getting Started 🚀

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on production enviroment.

### Prerequisites 📋
```
Docker
```

### Installing 🔧

_Build the services_

```
docker-compose build
```

_Run services_
```
docker-compose up -d
```

### You need to wait like 1 min because rabbitMQ is starting 

# Prediction salary service
_Make a salary prediction with a post to http://localhost:5000/predictions with a body like:_
```
 {
	"experience":[10]
 }
```
_Every time that you make a prediction, the service, save that response as a cache in redis._
# History service
_Every time prediction salary service is called, this service save that action like a record.
You can get all the records with a get in_ 
```
http://localhost:61945/Records
```
_Stop and remove the services_
```
docker-compose down
```

# Angular Client
Coming soon ...

### Deployment 📦
```
docker stack deploy -c compose-file docker-compose.prod.yml salary_app
```
### License 📄

This project is licensed under the MIT License - see the LICENSE.md file for details