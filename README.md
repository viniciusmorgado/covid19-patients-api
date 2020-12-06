# Coronavirus Patients List ASP.NET Web API

ASP.NET Web API with MongoDB Atlas Cluster integration, a API that receive a list of data about infected covid-19 patients, and persist this data using a cluster of three instances on MongoDB Atlas.

<img src="https://github.com/viniciusmorgado/asp-mongo-api/blob/main/Assets/ClusterScreenshot2020-12-06%20010018.png"></img>

## Install
```
git clone https://github.com/viniciusmorgado/asp-mongo-api.git
```

```
cd asp-mongo-api
```

```
dotnet restore
```
## Configuration

Change API/appsettings.json property "ConnectionString":

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "__comment__": "Removed string to push on Github",
  "ConnectionString":"",
  "DatabaseName":"coronavirus"
}
```
Using Atlas Cluster Connection String:

Replace <password> with the password for the morgado user. Replace <dbname> with the name of the database that connections will use by default.
