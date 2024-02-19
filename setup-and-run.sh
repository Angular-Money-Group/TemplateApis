git switch develop
git pull
docker container stop notificationv1
docker container rm -f notificationv1
docker build  -t notification-v1 .
docker run -d -p 3010:80 --name notificationv1 notification-v1