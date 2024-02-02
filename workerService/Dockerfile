# Start from a Debian image with the latest version of Go installed
# and a workspace (GOPATH) configured at /go.
FROM golang:1.22rc2-bookworm

RUN go get github.com/streadway/amqp
RUN go get gopkg.in/redis.v2
RUN go get go.mongodb.org/mongo-driver/mongo

COPY ./main.go ./src
COPY ./recordsService.go ./src
COPY ./publishservice/ ./src/publishservice

WORKDIR /go/src
RUN go build -o /go/bin/worker-service

ENTRYPOINT /go/bin/worker-service