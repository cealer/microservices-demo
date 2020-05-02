package publishservice

import (
	"fmt"
	"gopkg.in/redis.v2"
	"os"
)

// PubSub is
type PubSub struct {
	client *redis.Client
}

// Service this can be call from the main.go
var Service *PubSub

func init() {

	uri := fmt.Sprintf("%v:%v", os.Getenv("redis_uri"), os.Getenv("redis_port"))

	var client *redis.Client
	client = redis.NewTCPClient(&redis.Options{
		Addr:     uri,
		Password: os.Getenv("redis_password"),
		DB:       0,
		PoolSize: 10,
	})
	Service = &PubSub{client}
}

// PublishString a message with a string as payload
func (ps *PubSub) PublishString(message string) *redis.IntCmd {
	return ps.client.Publish(os.Getenv("redis_channel"), message)
}
