using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CampusVenueReservation.Repository
{
    public interface IGenericRepository<T> 
    {
        IEnumerable<T> GetAllRecord();
        int Insert(T t);
        int DeleteRow(int id);
        int UpdateAsync(T t);
        T GetSingleRecord(int id);
        IEnumerable<T> SPWithOutParameter();
        IEnumerable<T> SPWithParameter(object t);
        //Used For All Where Conditions
        IEnumerable<T> GetWhereRecord(object t);
    }
}