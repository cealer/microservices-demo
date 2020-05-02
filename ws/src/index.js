const WebSocket = require("ws");
const redis = require("redis");

const subscriber = redis.createClient({
  url: `redis://${process.env.redis_uri}:${process.env.redis_port}`,
  password: `${process.env.redis_password}`
});

const publisher = subscriber.duplicate();

const WS_CHANNEL = `${process.env.redis_channel}`;

const wss = new WebSocket.Server({
  port: +process.argv[4] || 8080
});

subscriber.on("message", (channel, message) => {
  console.log(message);
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