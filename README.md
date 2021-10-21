add this config to appsettings.json : 
``` Json
{
 "Payeh": {
    "Services": {
      "Translator": {
         "Type": "Google", <!-- Default | Google -->

        "Google": {
          "ApiKey": "your_api_key"
        }
      },
      "Logger": {
        "Type": "Default" , <!-- Default -->
      }
    }
  }
}

```
