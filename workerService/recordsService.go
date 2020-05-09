package main

import (
	"context"
	"fmt"
	"log"

	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

type Records struct {
	ID          string `bson:"-"`
	Description string `bson:"description"`
	UserId      string `bson:"userId"`
	Uri         string `bson:"uri"`
}

// MongoDB struct
type MongoDB struct {
	client *mongo.Client
}

// ServiceMongo this can be call from the main.go
var ServiceMongo *MongoDB

func init() {
	user := "root"
	password := "example"
	host := "mongo"
	port := 27017

	clientOpts := options.Client().ApplyURI(fmt.Sprintf("mongodb://%s:%s@%s:%d", user, password, host, port))
	client, err := mongo.Connect(context.TODO(), clientOpts)
	if err != nil {
		log.Fatal(err)
	}

	// Check the connections
	err = client.Ping(context.TODO(), nil)
	if err != nil {
		log.Fatal(err)
	}

	fmt.Println("Congratulations, you're already connected to MongoDB!")

	ServiceMongo = &MongoDB{client}

}

func (ps *MongoDB) saveRecord(description string, uri string, userID string) {

	collection := ps.client.Database("RecordsDb").Collection("Records")

	record := Records{
		Description: description,
		Uri:         uri,
		UserId:      userID,
	}

	insertResult, err := collection.InsertOne(context.TODO(), record)
	if err != nil {
		log.Fatal(err)
	}

	fmt.Println("Record had been inserted: ", insertResult)
}
