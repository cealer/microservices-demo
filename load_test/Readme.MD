docker run -p 8089:8089 --volume $PWD/dir/of/locustfile:/mnt/locust -e LOCUSTFILE_PATH=/mnt/locust/locustfile.py -e TARGET_URL=http://localhost:5000 locustio/locust

http://predictions-app:5000