# NightscoutShareServer

This will install a web server program called NightscoutShareServer, that when installed, will live in parallel with your existing nightscout site. The NightscoutShareServer site then fetches it's glucose values from your configured nightscout site and formats it in the same manner as a dexcom server does.

If you're a nightscout user, you may have heared of the "Dexcom Bridge", where dexcom data is pulled into the nightscout site.
NightscoutShareServer however does the reverse; data from nightscout is fetched and transformed to confirm to the dexcomshareserver protocol.

# Installation

# 1 Prerequisites
* Create a github user .
* Fork this repository into your own repository.
* Create an azure account.
* Then follow either step 2a) or step 2b .

# 2a) Auto deploy
* Click the following button to automatically deploy into a new azure web app. You will be asked to fill in your nightscout host and if you want to enable mocked mode or not.

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)

# 2b) Manual Installation
* Deploy your fork into a new azure site. This can be done from within the azure portal, or from visual studio. *IMPORTANT* Make sure you select .net version 4.6 or later!
* In the azure portal set the following app settings:
```code
NS_Host: https://YOURSITE.azurewebsites.net
```

* You can also enable mocked mode (display fake data, by setting the follow app variable): 
```code
Enable_Mocked_Mode: true
```
Example from an azure portal:
[![Skjermbilde-azuresettings.png](https://s8.postimg.org/jf7i24xn9/Skjermbilde-azuresettings.png)](https://postimg.org/image/cor0spahd/)

* Open your new ShareServer and follow the instructions there!

# 3) Changing Nighscout site

To change to another nightscout site or enable mocked mode, follow the instructions provided in 2b) to change the appsettings in azure. Save your changes. You don't have to restart your app. Settings are updated immediately; simply refresh your browser window
