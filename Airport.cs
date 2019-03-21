using System;
using System.Numerics;

namespace Demo{
    class Airport{
        private String name;
        private String code;
        private Location location;
        
        
        public Airport() {
            
        }
        
        public Airport(String name, String code, Location location) {
            this.name = name;
            this.code = code;
            this.location = location;
        }
        public String getName() {
            return name;
        }
        public void setName(String name) {
            this.name = name;
        }
        public String getCode() {
            return code;
        }
        public void setCode(String code) {
            this.code = code;
        }
        public Location getLocation() {
            return location;
        }
        public void setLocation(Location location) {
            this.location = location;
        }
    }
}