(function (window) {
  window["env"] = window["env"] || {};

  // Environment variables
  window["env"]["apiGatewayUri"] = "${API_GATEWAY}";
  window["env"]["apiGatewayHost"] = "${GATEWAY_HOST}";
})(this);
