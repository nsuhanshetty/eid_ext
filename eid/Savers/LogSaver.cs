using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eid.Savers
{
    class LogSaver
    {
        public void insert(int userID, string date, string time)
        {
            Common common = new Common();
            string qry = "insert into log_table(LT_USER_ID,LT_DATE_ENTRY,LT_TIME_OF_ENTRY)values ('" + userID + "','" + date + "','" + time + "')";
             MysqlConn.executeQry(qry);
        }
    }
}
