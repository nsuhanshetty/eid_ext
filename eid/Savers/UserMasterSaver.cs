using System;
using System.Data;

namespace eid.Savers
{
    class UserMasterSaver
    {
        public int fetchEmpID(string userName)
        {
            Common common = new Common();
            string qry;
            qry = "Select USPUSERID from userprivilege where USPUSERNAME='" + userName + "'";
            return (int)MysqlConn.returnFirstCell(qry);
        }

        public void insertUserPrivileges(string userName, string password)
        {
            Common common = new Common();
            string qry;
            qry = "insert into userprivilege(USPUSERNAME,USPPASSWORD,USPCREATEDBY,USPCREATEDON)values('" + userName + "','" + password + "',";
            qry += common.qrytime("ins", "USP") + ")";
            MysqlConn.executeQry(qry);
        }

        public void insertUserAttribute(int USPUserid, int ID, int checkedID)
        {
            Common common = new Common();
            string qry = "insert into user_attribute(UA_user_id,UA_menu,UA_enable,UA_CREATEDBY,UA_CREATEDON)values('" + USPUserid + "','" + ID + "','" + checkedID + "',";
            qry += common.qrytime("ins") + ")";
            MysqlConn.executeQry(qry);
        }

        public void updateUserPrivilege(int USPUserid)
        {
            Common common = new Common();
            string qry = "update userprivilege set ";
            qry += common.qrytime("upd", "USP_");
            qry += "where USPUSERID='" + USPUserid + "'";
            MysqlConn.executeQry(qry);
        }

        public void updateUserAttribute(int USPUserid, int checkedID, int ID)
        {
            Common common = new Common();
            string qry = "update user_attribute set UA_enable='" + checkedID + "',";
            qry +=common.qrytime("upd", "UA_");
            qry += " where  UA_user_id='" + USPUserid + "' and UA_menu='" + ID + "'";
            MysqlConn.executeQry(qry);
        }

        public DataTable FetchUserAttribute(object USPUserid)
        {
            string qry = "select UA_menu,UA_enable from user_attribute where UA_user_id='" + USPUserid + "'";
            return MysqlConn.getDataTable(qry);
        }

        public object fetchUSPID(string userName,string password)
        {
            string qry = "select USPUSERID from userprivilege where USPUSERNAME='" + userName + "' and USPPASSWORD='" + password + "' and USPdeleted='N' Limit 1";
            return MysqlConn.returnFirstCell(qry);
        }

    }
}
