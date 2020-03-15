# Microservices demo with event driven architecture to the services communication
# First build the services
docker-compose build
# Start the services
docker-compose up -d
### You need to wait like 2 min because rabbitMQ is starting 
# Prediction salary service
Make a salary prediction with a post to http://localhost:5000/predictions with a body like: {
	"experience":[10]
}
# History service
Every time prediction salary service is called, this service save that action like a record.
You can get all the records with a get in http://localhost:61945/Records
# Stop and remove the services
docker-compose down

## Architecture

![alt text](https://github.com/cealer/microservices-demo/blob/master/architecture.png)
