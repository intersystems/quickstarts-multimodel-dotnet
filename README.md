# Multimodel QuickStart for .NET

This code shows multi-model access to InterSystems IRIS Data Platform in .NET.

The QuickStart can be found at https://learning.intersystems.com/course/view.php?name=Multimodel 
It shows object, relational, and native access from a .NET application to InterSystems IRIS. Airport data is stored using objects, retrieved using SQL, and a custom data structure is created using the Native API to handle route information between airports.

## To run in InterSystems Learning Labs or a cloud marketplace Evaluator Edition (on AWS, GCP, or Azure)
1. Open MultiModelQS.cs to view the code.
2. On AWS, GCP, or Azure ONLY: Modify ip to "try-iris". Verify username and password are valid for your instance of InterSystems IRIS as well. ((Please skip this step if using InterSystems Learning Labs)
3. In the integrated terminal, type: `dotnet run`

## To run locally
1. Clone the repo and open it in Visual Studio Code
2. Change ip, port, username, and password to point to your instance of InterSystems IRIS
3. Run: `dotnet run`
