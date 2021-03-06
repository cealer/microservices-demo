from flask import Blueprint, request, jsonify
import json
import pickle
import os
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
import records_bus
import predictions_cache
from flask.wrappers import Response
from flasgger import swag_from

bp = Blueprint('predictions', __name__, url_prefix='/predictions')


@bp.route('', methods=['POST'])
@swag_from("docs/predictions.yml")
def predictions():

    fakeUser = '0D9FB199-73A1-4111-8371-78DF782C1AD1'
    request_body = request.get_json()
    experience = int(request_body['experience'])
    years = np.array([experience])
    cachePrediction = predictions_cache.PredictionCache(
    ).getPrediction(year=years[0])

    if cachePrediction is not None:
        sendHistory(fakeUser, cachePrediction, '/predictions')
        return jsonify({"result": cachePrediction})

    model_path = os.getcwd()+'/model_pickle'
    with open(model_path, 'rb') as f:
        mp = pickle.load(f)
    x = years.reshape(-1, 1)
    result = mp.predict(x).tolist()

    sendHistory(fakeUser, result, '/predictions')
    predictions_cache.PredictionCache().setPrediction(
        year=years[0], salary=result[0])

    return jsonify({"result": result[0]})


def sendHistory(user, result, uri):
    bus = records_bus.Records_bus(user,
                                  result, uri)
    bus.publish()


@bp.route('/test')
def test():
    return jsonify({"test": "test"})
