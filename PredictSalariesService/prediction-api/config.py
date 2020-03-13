import os


class Config(object):
    DEBUG = True
    RABBITMQ_URI = os.environ['RABBITMQ_URI']

class DevelopmentConfig(Config):
    DEBUG = False
