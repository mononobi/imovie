using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

namespace iMovie
{
    public class SystemParameter
    {
        public const int ParamID_Min_Value = 1;
        public const int ParamName_Min_Length = 1;
        public const int ParamName_Max_Length = 100;
        public const int ParamValue_Min_Length = 1;
        public const int ParamValue_Max_Length = 100;
        
        private long paramID = 0;
        private string paramName = "";
        private string paramValue = "";

        public SystemParameter(long paramID, string paramName, string paramValue)
        { 
            try 
            {
                string result = "";

                if (SystemParameter.Validate(paramID, paramName, paramValue, out result) == true)
                {
                    this.ParamID = paramID;
                    this.ParamName = paramName;
                    this.ParamValue = paramValue;
                }
                else
                {
                    throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SystemParameter()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Validate(long paramID, string paramName, string paramValue, out string result)
        { 
            try
            {
                result = "";

                if (IsParamID(paramID.ToString()) == false)
                {
                    result += Messages.InvalidParamID + Environment.NewLine;
                }

                if (IsParamName(paramName) == false)
                {
                    result += Messages.InvalidParamName + Environment.NewLine;
                }

                if (IsParamValue(paramValue) == false)
                {
                    result += Messages.InvalidParamValue + Environment.NewLine;
                }

                if (result.Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long ParamID
        {
            get
            {
                try
                {
                    return this.paramID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            set
            {
                try
                {
                    if (IsParamID(value.ToString()) == true)
                    {
                        this.paramID = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidParamID);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string ParamName
        {
            get
            {
                try
                {
                    return this.paramName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            set
            {
                try
                {
                    if (IsParamName(value) == true)
                    {
                        this.paramName = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidParamName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string ParamValue
        {
            get
            {
                try
                {
                    return this.ParamValue;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            set
            {
                try
                {
                    if (IsParamValue(value) == true)
                    {
                        this.paramValue = value;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidParamValue);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static bool IsParamID(string value)
        {
            try
            {
                long tmp = 0;

                if (long.TryParse(value, out tmp) == true)
                {
                    if (tmp >= ParamID_Min_Value || tmp == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsParamName(string value)
        {
            try
            {
                if (value.Length >= ParamName_Min_Length && value.Length <= ParamName_Max_Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsParamValue(string value)
        {
            try
            {
                if (value.Length >= ParamValue_Min_Length && value.Length <= ParamValue_Max_Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  

        public void FetchSingleParam(DataTable dtParam)
        {
            try
            {
                if (dtParam.Rows.Count >= 1)
                {
                    SystemParameter param = FetchAllParam(dtParam)[0];

                    this.ParamID = param.ParamID;
                    this.ParamName = param.ParamName;
                    this.ParamValue = param.ParamValue;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SystemParameter[] FetchAllParam(DataTable dtParam)
        {
            try
            {
                SystemParameter[] paramTemp = new SystemParameter[dtParam.Rows.Count];
                int i = 0;

                while (i < dtParam.Rows.Count)
                {
                    paramTemp[i] = new SystemParameter();
                    i++;
                }

                i = 0;

                while (i < dtParam.Rows.Count)
                {
                    paramTemp[i].ParamID = Convert.ToInt64(dtParam.Rows[i]["ParamID"].ToString());
                    paramTemp[i].ParamName = dtParam.Rows[i]["ParamName"].ToString();
                    paramTemp[i].ParamValue = dtParam.Rows[i]["ParamValue"].ToString();

                    i++;
                }

                return paramTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
