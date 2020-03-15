from locust import HttpLocust, TaskSet, task, between
import json

class UserBehavior(TaskSet):
    @task
    def prediction_salary(self):
        payload = {'experience': [10]}
        headers = {'content-type': 'application/json'}
        print(payload)
        r = self.client.post("/predictions", data=json.dumps(payload),
                             headers=headers, catch_response=True)

class WebApp(HttpLocust):
    task_set = UserBehavior
    wait_time = between(5, 15)
