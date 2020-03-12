import os


class Config(object):
    DEBUG = True
    RABBITMQ = 'amqp://molunfrm:2UB6c3rTGmH7hLaIqxKCinygyUGFPAqZ@salamander.rmq.cloudamqp.com/molunfrm'


class DevelopmentConfig(Config):
    DEBUG = False
    RABBITMQ = 'amqp://molunfrm:2UB6c3rTGmH7hLaIqxKCinygyUGFPAqZ@salamander.rmq.cloudamqp.com/molunfrm'
