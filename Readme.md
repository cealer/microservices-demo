# Microservices demo with event driven architecture to the services communication

## Architecture

![alt text](https://github.com/cealer/microservices-demo/blob/master/architecture.png)


# First build the services
docker-compose build
# Start the services in DEV ENV
docker-compose up -d

# Start the services in Prod ENV
Coming soon ...

### You need to wait like 2 min because rabbitMQ is starting 
# Prediction salary service
Make a salary prediction with a post to http://localhost:5000/predictions with a body like: {
	"experience":[10]
}
Every time that you make a prediction, the service, save that response as a cache in redis.
# History service
Every time prediction salary service is called, this service save that action like a record.
You can get all the records with a get in http://localhost:61945/Records
# Stop and remove the services
docker-compose down

# Angular Client
Coming soon ...
