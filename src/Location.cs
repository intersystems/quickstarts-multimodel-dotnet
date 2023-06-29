﻿/* 
* PURPOSE: This class is used by Airport.cs to get airport location infromation 
*/

using System;
using id = InterSystems.XEP.Attributes.Id;
namespace Demo
{
    class Location
    {
        [id(generated = false)]
        private string zip;
        private String city;
        private String state;
        private double longitude;
        private double latitude;

        public Location()
        {

        }

        public Location(String city, String state)
        {
            this.city = city;
            this.state = state;
        }

        public Location(String city, String state, double longitude, double latitude, String zip)
        {
            this.city = city;
            this.state = state;
            this.longitude = longitude;
            this.latitude = latitude;
            this.zip = zip;
        }

        public String getZip()
        {
            return zip;
        }
        public void setZip(String zip)
        {
            this.zip = zip;
        }

        public String getCity()
        {
            return city;
        }
        public void setCity(String city)
        {
            this.city = city;
        }
        public String getState()
        {
            return state;
        }
        public void setState(String state)
        {
            this.state = state;
        }
        public double getLongitude()
        {
            return longitude;
        }
        public void setLongitude(double longitude)
        {
            this.longitude = longitude;
        }
        public double getLatitude()
        {
            return latitude;
        }
        public void setLatitude(double latitude)
        {
            this.latitude = latitude;
        }
    }
}