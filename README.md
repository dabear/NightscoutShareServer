# NightscoutShareServer
This is a custom server that behaves like a Dexcom Share server, but will fetch its glucose values from nightscout

If you're a nightscout user, you may have heared of the "Dexcom Bridge". This server does the reverse.

# Installation

* Fork this repository into your own repository.
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
