# multimodel-dotnet-quickstart

## In this repository
.  
├── LICENSE  
├── README.md  
├── multimodel.csproj  
└── src  
     ├── Airport.cs  
     ├── Location.cs  
     └── MultimodelQS.cs  

## How to use this sample on your own
This sample code shows object, relational, and native access from a .NET application to InterSystems IRIS. Airport data is stored using objects and retrieved using SQL, and a custom data structure is created to handle route information between airports.

1. Start with an installation of .NET and a running instance of InterSystems IRIS.
2. Download the drivers from the ADO.NET section of the [InterSystems Drivers Download page](https://intersystems-community.github.io/iris-driver-distribution/).
3. Clone this repository.
4. In your preferred IDE, create a project which includes this repository and the ADO.NET drivers as dependencies. For help, refer to [Connecting Your Application](https://docs.intersystems.com/components/csp/docbook/DocBook.UI.Page.cls?KEY=ADRIVE#ADRIVE_dotnet)
5. In `multimodelQS.cs`, on lines 20-24, change the username, password, IP, port and namespace to point to your instance of InterSystems IRIS.
6. In multimodel.csproj, make sure that the target framework setting is appropriate for your system. 
7. Uncomment the following two lines:
```
// storeAirfare(irisNative);
// checkAirfare(irisNative);
```
8. Run the code to see objects and SQL working side-by-side.

## Guided tutorial
For a guided tutorial using this sample, visit [Accessing Data in .NET Using Multiple Data Models](https://learning.intersystems.com/course/view.php?name=DotNETMultiModel) on the InterSystems learning site. 
