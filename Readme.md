# First build the services
docker-compose build
# start the services
docker-compose up -d
### you need to wait like 2 min because rabbitMQ is starting 
# stop and remove the services
docker-compose down
