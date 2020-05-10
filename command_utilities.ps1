$images = docker image ls cealer/*:latest --format "{{.Repository}}:{{.Tag}}" 

for ($i = 0; $i -lt $images.Count; $i++) {
    docker push $images[$i]
}