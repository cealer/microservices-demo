import sys

from flask import Flask
from predictions import bp
from app import create_app

app = create_app()

if __name__ == "__main__":
    app.run(host="0.0.0.0", debug=True, port=80)