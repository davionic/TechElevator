using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IParkSqlDal
    {
        Park GetPark(string parkCode);
        List<Park> GetParks();
        List<Weather> GetForecast(string parkCode); 
    }
}
