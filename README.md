# multimodel-dotnet-quickstart

## In this repository
.  
├── LICENSE  
├── README.md  
└── src  
    ├── Airport.cs  
    ├── Location.cs  
    └── MultimodelQS.cs  

## Guided tutorial
For a guided tutorial using this sample, visit [Accessing Data in .NET Using Multiple Data Models](https://learning.intersystems.com/course/view.php?name=DotNETMultiModel) on the InterSystems learning site. 

## How to use this sample on your own
This sample code shows object, relational, and native access from a .NET application to InterSystems IRIS. Airport data is stored using objects and retrieved using SQL, and a custom data structure is created to handle route information between airports.

1. Start with an installation of .NET and a running instance of InterSystems IRIS.
2. Download the latest ADO.NET driver from the [InterSystems Drivers Download page](https://intersystems-community.github.io/iris-driver-distribution/)
3. Clone this repository.
4. In your preferred IDE, create a project which includes this repository and the ADO.NET driver as a dependency according to the [Connection Your Application documentation page](https://docs.intersystems.com/components/csp/docbook/DocBook.UI.Page.cls?KEY=ADRIVE#ADRIVE_dotnet)
5. In `multimodelQS.cs`, on lines 20-24, change the username, password, IP, port and namespace to point to your instance of InterSystems IRIS.
4. Uncomment the following two lines and run code to see objects and SQL working side-by-side:
```
// storeAirfare(irisNative);
// checkAirfare(irisNative);
```