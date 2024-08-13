using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public class WeatherDAO
    {
        private static WeatherDAO instance;

        public static WeatherDAO Instance
        {
            get
            {
                if (instance == null) instance = new WeatherDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        #region Weather
        public List<WeatherDTO> GetlistWeather()
        {
            List<WeatherDTO> listw = new List<WeatherDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Weather");
            foreach (DataRow item in data.Rows)
            {
                WeatherDTO w = new WeatherDTO(item);
                listw.Add(w);
            }
            return listw;
        }
        public List<WeatherDTO> GetlistWeatherByDate(DateTime Date1 ,DateTime Date2)
        {
            List<WeatherDTO> listw = new List<WeatherDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Weather WHERE DateWeater >= '"+Date1+"' AND DateWeater <= '"+Date2+"'");
            foreach (DataRow item in data.Rows)
            {
                WeatherDTO w = new WeatherDTO(item);
                listw.Add(w);
            }
            return listw;
        }
        public bool InsertWeather(string Location,float Temperature, float Humidity, DateTime DateWeather, string Employess)
        {
            string query = string.Format("INSERT dbo.Weather ( Location ,Temperature , Humidity , DateWeater , Employess) VALUES  ( N'{0}' , {1} ,{2} , '{3}' , N'{4}')",  Location,  Temperature,  Humidity,  DateWeather, Employess);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateWeather(int Id,string Location, float Temperature, float Humidity)
        {
            string query = string.Format("UPDATE dbo.Weather SET Location = N'{1}', Temperature = {2} , Humidity = {3}  WHERE Id = {0}",Id, Location, Temperature, Humidity);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteWeather(int Id)
        {
            string query = string.Format("DELETE dbo.Weather WHERE Id = {0}",Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int TestWeather(string name, DateTime date)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Weather WHERE Location = N'" + name + "' AND DateWeater = '" + date + "'");
            if(data.Rows.Count >0)
            {
                return 1;
            }
            return -1;
        }
        #endregion
        #region Location Weather
        public object GetlistLocation()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.LocationWeather");
        }
        public bool InsertLocation(string Name)
        {
            string query = string.Format("INSERT dbo.LocationWeather ( NameLocation ) VALUES  ( N'{0}')",Name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateLocation(int Id,string Name)
        {
            string query = string.Format("UPDATE dbo.LocationWeather SET NameLocation = N'{1}' WHERE Id = {0}", Id,Name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteLocation(int Id)
        {
            string query = string.Format("DELETE dbo.LocationWeather WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        #endregion
    }
}
