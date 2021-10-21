add this config to appsettings.json : 
``` Json
{
 "Payeh": {
    "Services": {
      "Translator": {
        "Type": "Google", //Default
        "Google": {
          "ApiKey": "AIzaSyBig3LjwTquboGMJHV__ZznTvdZFkrRuAQ"
        }
      },
      "Logger": {
        "Type": "Bps"
      }
    }
  }
}

```
