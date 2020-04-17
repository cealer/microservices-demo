import os


class Config(object):
    DEBUG = True
    RABBITMQ_URI = os.environ['RABBITMQ_URI']
    REDIS_URI = os.environ['REDIS_URI']
    REDIS_PASSWORD = os.environ['REDIS_PASSWORD']
    REDIS_PORT = os.environ['REDIS_PORT']
    REDIS_DB = os.environ['REDIS_DB']
    SWAGGER = {"title": "Salary prediction service", "uiversion": 2}
    CORS = os.environ['CORS']

class DevelopmentConfig(Config):
    DEBUG = False
