git switch develop
git pull
docker container stop apiauthorizerv2
docker container rm -f apiauthorizerv2
docker build  -t apiauthorizer-v2 .
docker run -d -p 3010:80 --name apiauthorizerv2 apiauthorizer-v2