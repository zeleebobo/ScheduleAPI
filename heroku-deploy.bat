docker rmi -f scheduleapilin
docker build --force-rm -t scheduleapilin .
docker tag scheduleapilin registry.heroku.com/scheduleiitapi/web
docker push registry.heroku.com/scheduleiitapi/web