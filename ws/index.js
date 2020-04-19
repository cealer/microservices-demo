const WebSocket = require("ws");
const redis = require("redis");

const subscriber = redis.createClient({
  url: "redis://localhost:6379",
  password: "password123"
});

const publisher = subscriber.duplicate();

const WS_CHANNEL = "ws:messages";

const wss = new WebSocket.Server({
  port: +process.argv[4] || 8080
});

subscriber.on("message", (channel, message) => {
  if (channel === WS_CHANNEL) {
    wss.clients.forEach(client => {
      if (client.readyState === WebSocket.OPEN) {
        client.send(message);
      }
    });
  }
});

wss.on("connection", ws => {
  console.log("new connection");
  // ws.on("message", data => {
  //   console.log(data);
  //   const message = JSON.parse(data);

  //   if (message.type === "get-users") {
  //     ws.send(JSON.stringify(mockedUsers));
  //   }

  //   if (message.type === "broadcast") {
  //     publisher.publish(WS_CHANNEL, JSON.stringify(mockedUsers));
  //   }
  // });
});

subscriber.subscribe(WS_CHANNEL);