add this config to appsettings.json : 
``` Json
{
 "Payeh": {
    "Authorization":{
        "Enabled":true
    },
    "Authentication":{
        "Enabled":true,
        "Jwt":{
            "SecretKey": "",
            "Issuer": "",
            "Audience": ""
        }
    },
    "Cors":{
        "Enabled":true
    },
    "Swagger":{
        "Enabled":true,
        "SwaggerDocs":{
            "Version":"v1",
            "Title":"My Application Title",
            "Name":"v1",
            "Url":"/swagger/v1/swagger.json",
        }
    },
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
