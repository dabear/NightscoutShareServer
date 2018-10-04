# NightscoutShareServer

This will install a web server program called NightscoutShareServer, that when installed, will live in parallel with your existing nightscout site. The NightscoutShareServer site then fetches it's glucose values from your configured nightscout site and formats it in the same manner as a dexcom server does.

If you're a nightscout user, you may have heared of the "Dexcom Bridge", where dexcom data is pulled into the nightscout site.
*NightscoutShareServer* however does the reverse; data from nightscout is fetched and transformed to confirm to the dexcomshareserver protocol.


# Installation

# 1 Prerequisites
* Create a github user .
* Fork this repository into your own repository.
* Create an azure or heroku account.
* Then follow either step 2a) or step 2b for azure, or step 3 for heroku.

# 2a) Auto deploy using azure
* Click the following button to automatically deploy into a new azure web app. You will be asked to fill in your nightscout host and if you want to enable mocked mode or not.

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)

# 2b) Manual Installation on azure
* Deploy your fork into a new azure site. This can be done from within the azure portal, or from visual studio. *IMPORTANT* Make sure you select .net version 4.6 or later!
* In the azure portal set the following app settings:
```code
NS_Host: https://YOURSITE.azurewebsites.net
```

* You can also enable mocked mode (display fake data, by setting the follow app variable): 
```code
Enable_Mocked_Mode: true
```

* Open your new ShareServer and follow the instructions there!

# 3) Deploy to heroku using docker containers
*YOU don't need to do this is you've already followed step 2!*

Deploying to heroku is somewhat more difficult, as it requires building the app as a docker container, then pushing it to heroku's docker registry, before creating an heroku app and deploying it. This requires you to install the following tools locally on your computer:

* git
* heroku-cli
* docker-sdk and docker command line tools

## 3a) Clone repository
```
git clone https://github.com/dabear/NightscoutShareServer.git
cd NightscoutShareServer/NightscoutShareServer

```
## 3b) Compile and build app locally
```
dotnet publish -c Release
docker build -t yourusernameshareserver ./bin/Release/netcoreapp2.1/publish/
```

## 3c) Login to heroku and create app
From the command line:
```
heroku login
heroku container:login
heroku create yourusernameshareserver
```

## 3d) Tag and push app to heroku
```
docker tag yourusernameshareserver registry.heroku.com/yourusernameshareserver/web

docker push registry.heroku.com/bjorningedia5shareserver/web
```

## 3e) Set config and deploy (release) app to heroku
```
heroku config:set -a yourusernameshareserver NS_Host="https://yournightscoutsitehere.herokuapp.com" Enable_Mocked_Mode="false" 
heroku container:release web -a yourusernameshareserver
```

## 3f) Open your new Nightscoutshareserverapp in the browser!
https://yourusernameshareserver.herokuapp.com

