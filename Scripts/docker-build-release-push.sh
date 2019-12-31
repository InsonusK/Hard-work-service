#!/usr/bin/env bash
ls
docker build -t insonusk/hard-work-service -f ./HardWorkService/Dockerfile ./HardWorkService
echo "$DOCKERHUBPASSWORD" | docker login -u insonusk --password-stdin
docker push insonusk/hard-work-service