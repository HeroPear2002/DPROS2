using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class WeatherDTO
    {
        public WeatherDTO(int Id, string Location, float Temperature,float Humidity,DateTime DateWeater,string Employess)
        {
            this.Id = Id;
            this.Location = Location;
            this.Temperature = Temperature;
            this.Humidity = Humidity;
            this.DateWeater = DateWeater;
            this.Employess = Employess;
        }
        public WeatherDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Location = row["Location"].ToString();
            this.Temperature = (float)Convert.ToDouble(row["Temperature"].ToString());
            this.Humidity = (float)Convert.ToDouble(row["Humidity"].ToString());
            this.DateWeater = (DateTime)row["DateWeater"];
            this.Employess = row["Employess"].ToString();
        }
        private int id;
        private string location;
        private float temperature;
        private float humidity;
        private DateTime dateWeater;
        private string employess;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        public float Temperature
        {
            get
            {
                return temperature;
            }

            set
            {
                temperature = value;
            }
        }
        public DateTime DateWeater
        {
            get
            {
                return dateWeater;
            }

            set
            {
                dateWeater = value;
            }
        }

        public float Humidity
        {
            get
            {
                return humidity;
            }

            set
            {
                humidity = value;
            }
        }

        public string Employess { get => employess; set => employess = value; }
    }
}
