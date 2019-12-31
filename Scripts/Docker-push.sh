#!/usr/bin/env bash
cd ../HardWorkService
docker build -t insonusk/hard-work-service -f Dockerfile .

echo "$DOCKER_PASSWORD" | docker login -u insonusk --password-stdin
docker push insonusk/hard-work-service