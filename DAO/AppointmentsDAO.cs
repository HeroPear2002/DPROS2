using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class AppointmentsDAO
    {
        private static AppointmentsDAO instance;

        public static AppointmentsDAO Instance
        {
            get
            {
                if (instance == null) instance = new AppointmentsDAO();
                return instance;
            }
            set => instance = value;
        }

        public bool UpdateEndTime(long id  , DateTime Endtime)
        {
            string query = string.Format("UPDATE dbo.Appointments SET EndDate = '{1}' WHERE UniqueId = {0}", id, Endtime);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public long IdAppointment(int idRessource)
        {
            try
            {
                return (long)DataProvider.Instance.ExecuteScalar("SELECT * FROM dbo.Appointments WHERE ResourceId = "+idRessource+ " AND EndDate IN (SELECT MAX(EndDate) FROM dbo.Appointments WHERE ResourceId = " + idRessource + ")");
            }
            catch 
            {
                return -1;
            }
        }
    }
}
