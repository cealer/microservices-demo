import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable()
export class Configuration {
    // desarrollo
    public ApiHistoryService = `${environment.apiGatewayUri}/history-service-api`;
    public ApiPredictionsUri = `${environment.apiGatewayUri}/prediction-api`;
    public ApiWs = `ws://${environment.gatewayHost}`;
}
