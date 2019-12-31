#!/usr/bin/env bash
cd ../HardWorkService
docker build -t insonusk/hard-work-service_test -f Dockerfile.test .