# NightscoutShareServer
This is a custom server that behaves like a Dexcom Share server, but will fetch its glucose values from nightscout

If you're a nightscout user, you may have heared of the "Dexcom Bridge". This server does the reverse.

# Installation

* Fork this repository into your own repository.
* Edit GlucoseController.cs and find the following line and edit it to fit your needs:
```csharp
 nsglucose = this.fetchNightscoutPebbleData("https://XXXXX.azurewebsites.net", count);
```
* Deploy your fork into a new azure site. This can be done from within the azure portal, or from visual studio. *IMPORTANT* Make sure you select .net version 4.6.2 or later!
* Open your new ShareServer and follow the instructions there!
