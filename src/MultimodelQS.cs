/* Purpose: This demo shows using objects, SQL, and native access side-by-side in a .NET application, 
* connecting to InterSystems IRIS.
*
* To Test: Run to see objects and SQL working side-by-side. Then uncomment the lines to execute storeAirfare and checkAirfare to see
* creating a custom data structure using the Native API.	
*/

using System;
using InterSystems.Data.IRISClient;
using InterSystems.Data.IRISClient.ADO;
using InterSystems.XEP;
using System.Collections.Generic;

namespace Demo{

    class multimodelQS {

		static void Main(String[] args) {
			// If you are using a remote instance, update IP and password here
			String ip = "localhost";
			int port = 51773;
			String user = "tech";
			String pass = "demo";
			String Namespace = "USER";
			
			try {
				// Connect to database using EventPersister, which is based on IRISDataSource
				// For more details on EventPersister, visit 
				// https://docs.intersystems.com/irislatest/csp/docbook/DocBook.UI.Page.cls?KEY=BNETXEP_xep
		        EventPersister xepPersister = PersisterFactory.CreatePersister();
		        xepPersister.Connect(ip,port,Namespace,user,pass); 
		        Console.WriteLine("Connected to InterSystems IRIS");
				xepPersister.DeleteExtent("Demo.Airport");   // Remove old test data
	            xepPersister.ImportSchemaFull("Demo.Airport");   // Import full schema
		       
		        // Create XEP Event for object access
		        Event xepEvent = xepPersister.GetEvent("Demo.Airport");

		        // Create IRIS Native object
                IRISADOConnection connection = (IRISADOConnection) xepPersister.GetAdoNetConnection();
		        IRIS irisNative = IRIS.CreateIRIS(connection);
		        
		        Console.WriteLine("Generating airport table...");
				
		        // Populate 5 airport objects and save to the database using XEP
				populateAirports(xepEvent);
				
				// Get all airports using ADO.NET
				getAirports(connection);
				
				// Store natively - Uncomment the following lines to see Native access
				// storeAirfare(irisNative);
                // checkAirfare(irisNative);
					
				// Close everything
			    xepEvent.Close();
			    xepPersister.Close();
							
			} catch (Exception e) {
				 Console.WriteLine("Error creating airport listing: " + e);
			}
		        
		}

        // Store objects directly to InterSystems IRIS
		public static void populateAirports(Event xepEvent) {
			List<Airport> airportList = new List<Airport>();

			// 1. Boston
			Demo.Airport newAirport = new Demo.Airport();
			newAirport.setName("Boston Logan International");
			newAirport.setCode("BOS");
			Demo.Location loc = new Demo.Location();
			loc.setCity("Boston");
			loc.setState("MA");
			loc.setZip("02128");
			newAirport.setLocation(loc);
			airportList.Add(newAirport);
		
			// 2. Philadelphia
			Demo.Airport newAirport2 = new Demo.Airport();
			newAirport2.setName("Philadelphia International");
			newAirport2.setCode("PHL");
			Demo.Location loc2 = new Demo.Location();
			loc2.setCity("Philadelphia");
			loc2.setState("PA");
			loc2.setZip("19153");
			newAirport2.setLocation(loc2);
			airportList.Add(newAirport2);
			
			// 3. Austin
			Demo.Airport newAirport3 = new Demo.Airport();
			newAirport3.setName("Austin–Bergstrom International");
			newAirport3.setCode("AUS");
			Demo.Location loc3 = new Demo.Location();
			loc3.setCity("Austin");
			loc3.setState("TX");
			loc3.setZip("78719");
			newAirport3.setLocation(loc3);
			airportList.Add(newAirport3);
			
			// 4. San Francisco
			Demo.Airport newAirport4 = new Demo.Airport();
			newAirport4.setName("San Francisco International");
			newAirport4.setCode("SFO");
			Demo.Location loc4 = new Demo.Location();
			loc4.setCity("San Francisco");
			loc4.setState("CA");
			loc4.setZip("94128");
			newAirport4.setLocation(loc4);
			airportList.Add(newAirport4);
			
			// 5. O'hare
			Demo.Airport newAirport5 = new Demo.Airport();
			newAirport5.setName("Chicago O'hare International");
			newAirport5.setCode("ORD");
			Demo.Location loc5 = new Demo.Location();
			loc5.setCity("Chicago");
			loc5.setState("IL");
			loc5.setZip("60666");
			newAirport5.setLocation(loc5);

			airportList.Add(newAirport5);
			
			Airport[] airportArray = airportList.ToArray();
			xepEvent.Store(airportArray);
			Console.WriteLine("Stored 5 airports");
		}
		
		// Display all airports using ADO.NET
		public static void getAirports(IRISADOConnection connection)
		{
			try {
				// This query uses a special shorthand notation (->, known as an implicit join) 
				// to retrieve data from a related table without requiring you to think about how to join tables
                String sql = "SELECT name, code, location->city, location->state, location->zip FROM demo.airport";
                IRISCommand cmd = new IRISCommand(sql, connection);
                IRISDataReader reader = cmd.ExecuteReader();
			
				Console.WriteLine("Name\t\t\t\t\tCode\t\tLocation");
				while(reader.Read())
				{
                    String name = (String) reader[reader.GetOrdinal("name")];
                    String code = (String) reader[reader.GetOrdinal("code")];
                    String city = (String) reader[reader.GetOrdinal("city")];
					String state = (String) reader[reader.GetOrdinal("state")];
					String zip = (String) reader[reader.GetOrdinal("zip")];
					Console.WriteLine(name + "\t\t" + code + "\t\t" + city + ", " + state + " " + zip);
				}
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}
		
	    // Create a custom data structure to store airport distance and airfare information in a graph-like structure.
	    // Query this information with the interactive checkAirfare() method
		public static void storeAirfare(IRIS irisNative)
		{		
			// Store routes and distance between airports 
			// The global we'll populate has two levels:
		    // ^airport(from, to) = distance
		    // ^airport(from, to, flight) = fare

		    // This IRIS native API sets the value for a global at the specified subscript level(s)
		    // For example, to set ^airport("BOS","AUS") = 1698
			irisNative.Set("1698","^airport", "BOS","AUS");
			irisNative.Set("450","^airport", "BOS","AUS","AA150");
			irisNative.Set("550","^airport", "BOS","AUS","AA290");

            irisNative.Set("280","^airport", "BOS", "PHL");
			irisNative.Set("200","^airport", "BOS","PHL","UA110");

            irisNative.Set("1490","^airport","BOS","BIS");
			irisNative.Set("700","^airport", "BOS","BIS","AA330");
			irisNative.Set("710","^airport", "BOS","BIS","UA208");
			
			Console.WriteLine("Stored fare and distance data in ^airport global.");
        }

        // Simple interactive method using IRIS native API to consult the data structure populated in storeAirfare()
        public static void checkAirfare(IRIS irisNative)
        {		
            // Prompt for input
            Console.Write("Enter departure airport: (e.g. BOS)");
            String fromAirport = Console.ReadLine();
            Console.Write("Enter destination airport: (e.g. AUS)");
            String toAirport = Console.ReadLine();
                        
            // ^airport(from, to) = distance
            Console.WriteLine("");
            Console.WriteLine("The distance in miles between "+ fromAirport + " and " + toAirport + 
                        " is: " + irisNative.GetString("^airport", fromAirport, toAirport) + ".");
            
            // Now loop through routes: ^airport(from, to, flight) = fare
            int isDefined = irisNative.IsDefined("^airport", fromAirport, toAirport);
            if (isDefined==11) {
                Console.WriteLine("The following routes exist for this path:");
                IRISIterator iterator = irisNative.GetIRISIterator("^airport", fromAirport, toAirport);
                while (iterator.MoveNext()) {
                    string fare = System.Text.Encoding.Default.GetString((byte[])iterator.Current);
		    string flightNumber = System.Text.Encoding.Default.GetString((byte[])iterator.CurrentSubscript);
                    Console.WriteLine("  - " + flightNumber + ": " + fare + " USD");
                } 
            } else {
                Console.WriteLine("No routes exist for this path.");
            }
        }

    }
}
