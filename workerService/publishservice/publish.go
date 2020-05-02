package publishservice

import (
	"encoding/json"
	"gopkg.in/redis.v2"
)

// PubSub is
type PubSub struct {
	client *redis.Client
}

// Service this can be call from the main.go
var Service *PubSub

func init() {
	var client *redis.Client
	client = redis.NewTCPClient(&redis.Options{
		Addr:     "redis:6379",
		Password: "password123",
		DB:       0,
		PoolSize: 10,
	})
	Service = &PubSub{client}
}

// PublishString a message with a string as payload
func (ps *PubSub) PublishString(channel, message string) *redis.IntCmd {
	return ps.client.Publish(channel, message)
}

// Publish is a func to send message to redis
func (ps *PubSub) Publish(channel string, message interface{}) *redis.IntCmd {
	// TODO reflect if interface{} type is string, Publish as-is

	jsonBytes, err := json.Marshal(message)

	if err != nil {
		panic(err)
	}

	messageString := string(jsonBytes)
	return ps.client.Publish(channel, messageString)
}
