README 

--Dev Mode
docker build -t predictions-app .
docker run -it --rm --name predictions-app -p 5000:5000 predictions-app
