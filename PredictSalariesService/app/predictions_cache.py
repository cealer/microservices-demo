import redis
from flask import current_app


class PredictionCache():
    def __init__(self):
        redis_Uri = current_app.config['REDIS_URI']
        redis_Password = current_app.config['REDIS_PASSWORD']
        redis_Port = current_app.config['REDIS_PORT']
        redis_DB = current_app.config['REDIS_DB']
        self.redis_instance = redis.Redis(host=redis_Uri,
                                          port=redis_Port, db=redis_DB, password=redis_Password)

    def setPrediction(self, year, salary):
        keyName = f'prediction_{year}'
        self.redis_instance.set(keyName, salary)

    def getPrediction(self, year):
        keyName = f'prediction_{year}'
        value = self.redis_instance.get(keyName)
        if value is not None:
           return round(float(value),2)
        return value
