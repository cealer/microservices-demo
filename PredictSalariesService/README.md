README 

linear_regression.ipynb is the notebook where the model was build.

--Dev Mode
docker build -t predictions-app .
docker run -it --rm --name predictions-app -p 5000:5000 predictions-app

-- Windows env 
 ${env:FLASK_APP}='main.py'; ${env:FLASK_ENV}='development'; ${env:FLASK_DEBUG}='1'; ${env:RABBITMQ_URI}='localhost'; ${env:REDIS_URI}='localhost'; ${env:REDIS_PASSWORD}='password123'; ${env:REDIS_PORT}='6379'; ${env:REDIS_DB}='0';