import pika
import sys
import json
from flask import current_app


class Records_bus:
    def __init__(self, userId, description, uri):
        self.userId = userId
        self.description = description
        self.uri = uri
        self.uriRabbimq = current_app.config['RABBITMQ_URI']

    def publish(self):
        parameters = pika.URLParameters(self.uriRabbimq)
        connection = pika.BlockingConnection(parameters)
        channel = connection.channel()

        data = {
            "userId": self.userId,
            "description": json.dumps(self.description),
            "uri": self.uri
        }

        message = json.dumps(data)

        channel.basic_publish(exchange='HistoryService.API.IntegrationEvents.Events:RecordCreatedIntegrationEvent',
                              routing_key='', body=message)
        print(" [x] Sent %r" % message)
        connection.close()
