using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace iMovie
{
    public class SystemParameters_SP
    {
        public static long Insert(SystemParameter param)
        {
            try
            {
                long paramID = 0;
                paramID = AccessDatabase.Insert(QueryRepository.Param_Insert,
                                                "@ParamID", param.ParamID,
                                                "@ParamName", param.ParamName,
                                                "@ParamValue", param.ParamValue);

                if (paramID <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                return paramID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByParamID(long paramID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = AccessDatabase.Select(QueryRepository.Param_Get_By_ParamID,
                                           "@ParamID", paramID);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long Update(SystemParameter param)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Update(QueryRepository.Param_Update_By_ParamID,
                                              "@ParamID", param.ParamID,
                                              "@ParamValue", param.ParamValue);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
