using System;
using System.Collections.Generic;
using System.Data;
using eid.Models;
using MySql.Data.MySqlClient;

namespace eid.Savers
{
    class StaffDetailsSavers
    {
        public DataTable getStaffDetails()
        {
            string qry;
            qry = "select ER_EMP_NO, ER_EMP_NAME from employee_registry where ER_DELETED='N'";
            return MysqlConn.getDataTable(qry);
        }

        public DataTable getSearchDetails(string empName, string empNo)
        {
            string qry;
            qry = "select  ER_EMP_NO as EMPLOYEE_NO,ER_EMP_NAME as EMPLOYEE_NAME from employee_registry where ER_DELETED='N' ";

            //the following loops work for both txtempname and txtempno 
            //to search among the datagridview
            if (!string.IsNullOrEmpty(empName))
                qry += "and ER_EMP_NAME like '" + empName + "%'";
            if (!string.IsNullOrEmpty(empNo))
                qry += "and ER_EMP_NO like '" + empNo + "%'";

            return MysqlConn.getDataTable(qry);
        }

        public void deleteStaffDetails(string empNo)
        {
            string qry;
            qry = "update employee_registry set ER_DELETED = 'Y' where ER_EMP_NO='" + empNo + "'";
            MysqlConn.executeQry(qry);
        }

        public void deleteStaffProof(string empNo)
        {
            string qry;
            qry = "update employee_proof set EP_DELETED = 'Y' where EP_EMP_NO='" + empNo + "'";
            MysqlConn.executeQry(qry);
        }

        public MySqlDataReader fetchStaffDetails(string empNo)
        {
            string qry = "select * from employee_registry as er,employee_proof as ep where ER_EMP_NO='" + empNo + "' AND er.ER_EMP_NO=ep.EP_EMP_NO";
            return MysqlConn.GetSQLDataReader(qry);
        }

        public void saveStaffProof(string[] Dest_Image_ImagePath, string empNo, bool marriedStatus, bool childProof, bool othrQualProof)
        {
            string qry = "insert into employee_proof(EP_EMP_NO, EP_EMP_PIC, EP_EMP_DOB_PROOF, EP_EMP_PER_ADDRESS_PROOF, EP_EMP_PRES_ADDRESS_PROOF, EP_EMP_EDU_QUAL_PROOF,EP_EMP_NOCHILD_PROOF,EP_EMP_OTHR_QUAL_PROOF) values ('" + empNo + "',";

            for (int i = 0; i < Dest_Image_ImagePath.Length - 2; i++)
                qry += "'" + Dest_Image_ImagePath[i].Replace("\\", "\\\\\\").Replace("\\\\\\b", "\\\\b") + "',";

            qry += ((marriedStatus) && (childProof)) ? "'" + Dest_Image_ImagePath[6].Replace("\\", "\\\\\\").Replace("\\\\\\b", "\\\\b") + "'," : "NULL,";
            qry += (!othrQualProof) ? "'" + Dest_Image_ImagePath[5].Replace("\\", "\\\\\\").Replace("\\\\\\b", "\\\\b") + "')" : "NULL)";
            MysqlConn.executeQry(qry);

        }

        public void saveStaffProof(string[] source, string[] Dest_Image_ImagePath, string empNo, bool marriedStatus, bool childProof, bool othrQualProof)
        {
            string qry = "update employee_proof set ";
            for (int i = 0; i < Dest_Image_ImagePath.Length - 2; i++)
                qry += "" + source[i] + "='" + Dest_Image_ImagePath[i].Replace("\\", "\\\\\\").Replace("\\\\\\b", "\\\\b") + "',";

            if (marriedStatus && childProof)
                qry += "EP_EMP_NOCHILD_PROOF='" + Dest_Image_ImagePath[6].Replace("\\", "\\\\\\").Replace("\\\\\\b", "\\\\b") + "',";
            else
                qry += "EP_EMP_NOCHILD_PROOF=NULL,";

            qry += (!othrQualProof) ? "EP_EMP_OTHR_QUAL_PROOF='" + Dest_Image_ImagePath[5].Replace("\\", "\\\\\\").Replace("\\\\\\b", "\\\\b") + "'" : "EP_EMP_OTHR_QUAL_PROOF=NULL";
            qry += " where EP_EMP_NO='" + empNo + "'";
            MysqlConn.executeQry(qry);
            /*shift to saver*/
        }

        public object fetchStaffCount(string empNo)
        {
            string qry = "select count(*) from employee_registry where ER_EMP_NO='" + empNo + "'";
            return MysqlConn.returnFirstCell(qry);
        }

        public int saveUpdateDetails(Dictionary<String, Object> dict)
        {
           return MysqlConn.dictionaryToTable(dict, "update_Emp_Details");
        }
    }
}
