from flask import Blueprint, request, jsonify
import json
import pickle
import os
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from . import config
from . import records_bus

bp = Blueprint('predictions', __name__, url_prefix='/predictions')


@bp.route('', methods=['POST'])
def predictions():
    request_body = request.get_json()
    model_path = os.getcwd()+'/model_pickle'
    with open(model_path, 'rb') as f:
        mp = pickle.load(f)
    x = np.array(request_body['experience']).reshape(-1, 1)
    result = mp.predict(x).tolist()

    bus = records_bus.Records_bus('0D9FB199-73A1-4111-8371-78DF782C1AD1',
                      result, '/predictions')
    bus.publish()
    return jsonify(result)
