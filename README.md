# NightscoutShareServer
This is a custom server that behaves like a Dexcom Share server, but will fetch its glucose values from nightscout

If you're a nightscout user, you may have heared of the "Dexcom Bridge". This server does the reverse.

# Installation

# 1
* Create a github user .
* Fork this repository into your own repository.
* Create an azure account.
* Then follow either step 2a) or step 2b .

# 2a) auto deploy
*Click the following button to automatically deploy into a new azure web app. You will be asked to fill in your nightscout host and if you want to enable mocked mode or not.

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)

# 2b) manual installation
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
