from locust import HttpLocust, TaskSet, task, between
import json


class UserBehavior(TaskSet):
    # @task
    # def home(self):
    #     r = self.client.get("/")
    @task
    def prediction_salary(self):
        payload = {'experience': 10}
        headers = {'content-type': 'application/json'}
        # print(payload)
        r = self.client.post("/prediction-api/predictions", data=json.dumps(payload),
                             headers=headers)

    # @task
    # def test_get(self):
    #     r = self.client.get("/predictions/test")


class WebApp(HttpLocust):
    task_set = UserBehavior
    wait_time = between(5, 15)
