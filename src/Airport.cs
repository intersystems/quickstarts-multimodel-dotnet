/* 
* PURPOSE: This class is used by multimodelQS.cs to get airport infromation 
*/

using System;
using Id = InterSystems.XEP.Attributes.Id;

namespace Demo
{
    class Airport
    {
        [Id(generated = false)]
        private String code;
        private String name;
        private Location location;


        public Airport()
        {

        }

        public Airport(String name, String code, Location location)
        {
            this.name = name;
            this.code = code;
            this.location = location;
        }
        public String getName()
        {
            return name;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public String getCode()
        {
            return code;
        }
        public void setCode(String code)
        {
            this.code = code;
        }
        public Location getLocation()
        {
            return location;
        }
        public void setLocation(Location location)
        {
            this.location = location;
        }
    }
}
