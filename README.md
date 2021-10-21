add this config to appsettings.json : 
``` Json
{
 "Payeh": {
    "Services": {
      "Translator": {
        "Type": "Google", 
        "Google": {
          "ApiKey": "your_api_key"
        }
      },
      "Logger": {
        "Type": "Default" 
      }
    }
  }
}

```
# Services

## Translator
- type : [ Default | Google ] 
- google : google options

## Logger
- type : [ Default ] 
