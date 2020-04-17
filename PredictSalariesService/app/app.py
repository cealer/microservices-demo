import os

from flask import Flask
from flasgger import Swagger
import config
import predictions
from flask_cors import CORS


def create_app(test_config=None):
    # Create and configure the app
    app = Flask(__name__, instance_relative_config=True)

    #Configure CORS
    app.config['CORS_HEADERS'] = 'Content-Type'
    cors = CORS(app, resources={r"/*": {"origins": config.Config.CORS}})
    
    if test_config is None:
        app.config.from_object(config.DevelopmentConfig)
    else:
        app.config.from_mapping(test_config)

    # ensure the instance folder exists
    try:
        os.makedirs(app.instance_path)
    except OSError:
        pass

    # Register the BluePrints
    app.register_blueprint(predictions.bp)
    # Register swagger
    swagger_config = {
        "headers": [],
        "specs": [
            {
                "endpoint": "apispec_1",
                "route": "/apispec_1.json",
                "rule_filter": lambda rule: True,
                "model_filter": lambda tag: True,
            }
        ],
        "static_url_path": "/flasgger_static",
        "swagger_ui": True,
        "specs_route": "/swagger/"
    }
    swagger = Swagger(app, config=swagger_config)
    return app
