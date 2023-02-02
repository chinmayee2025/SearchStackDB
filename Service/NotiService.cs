using Microsoft.Data.SqlClient;
using SearchStackDatabase.Common;
using SearchStackDatabase.IService;
using SearchStackDatabase.Models;
using System.Data;
using Dapper;


namespace SearchStackDatabase.Service
{
    public class NotiService : INotiService
    {
        List<Noti> _oNotification = new List<Noti>();
        public List<Noti> GetNotifications(int nToUserId, bool bIsGetOnlyUnread)
        {
            _oNotification = new List<Noti>();
            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            { 
            if (con.State == ConnectionState.Closed)con.Open() ;
            var oNotis = con.Query<Noti>("Select * from View_Notification where ToUserId=" + nToUserId).ToList();
            if (oNotis != null && oNotis.Count() > 0)

            {
                _oNotification = oNotis;
            }
            return _oNotification;
        }
            //throw new NotImplementedException();
        }
    }
}
