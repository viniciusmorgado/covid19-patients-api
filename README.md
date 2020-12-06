# Coronavirus Patients List ASP.NET Web API

ASP.NET Web API with MongoDB Atlas Cluster integration, a API that receive a list of data about infected covid-19 patients, and persist this data using a cluster of three instances on MongoDB Atlas.

<img src="https://github.com/viniciusmorgado/asp-mongo-api/blob/main/Assets/ClusterScreenshot2020-12-06%20010018.png"></img>

## Installation
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

<img src="https://github.com/viniciusmorgado/asp-mongo-api/blob/main/Assets/ClusterConnectScreenshot2020-12-06%20013338.png"></img>

<img src="https://github.com/viniciusmorgado/asp-mongo-api/blob/main/Assets/ConnectScreenshot2020-12-06%20013416.png"></img>

<img src="https://github.com/viniciusmorgado/asp-mongo-api/blob/main/Assets/StrintConnection.png"></img>

Replace < password > with the password for the morgado user. Replace < dbname > with the name of the database that connections will use by default.  
```
mongodb+srv://morgado:S4mpl3-P4ssw0rd@cluster1.3bpkg.mongodb.net/coronavirus?retryWrites=true&w=majority
```
Like this:

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
  "ConnectionString":"mongodb+srv://morgado:S4mpl3-P4ssw0rd@cluster1.3bpkg.mongodb.net/coronavirus?retryWrites=true&w=majority",
  "DatabaseName":"coronavirus"
}
```
## Run API

```
cd API
```
```
donet run
```
<img src="RunningScreenshot 2020-12-06 015054.png"></img>

On [Postman](https://www.postman.com/), run a sample of POST using a localhost path and port with route to infected controller for add a inffected covid-19 patient:

```
http://localhost:5000/infected
```
```
{
	"birthday": "1999-09-28",
    "sex": "F",
	"latitude": -23.5630994,
	"longitude": -46.6565712
}
```
Response
```
Infectado adicionado com sucesso!
```
<img src="RunningScreenshot 2020-12-06 015054.png"></img>

