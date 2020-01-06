using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SQLite;

namespace iMovie
{
    public class AccessDatabase
    {
        /// <summary>
        /// Gets the current connection string in use
        /// </summary>
        private static string ConnectionString
        {
            get
            {
                try
                {
                    string connectionString = "";
                    connectionString = System.Configuration.ConfigurationSettings.AppSettings.GetValues("SQLite")[0];

                    Regex reg = new Regex(@"data source.*db");
                    string tmp = reg.Match(connectionString).Value;
                    tmp = tmp.Replace("data source=|DataDirectory|", "");

                    if (File.Exists(Application.StartupPath + tmp) == true)
                    {
                        return connectionString;
                    }
                    else
                    {
                        throw new Exception(Messages.InvalidConnectionString);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static DataSet SelectSet(string selectQuery, params object[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand cmd = new SQLiteCommand(selectQuery, connection);

                    int i = 0;
                    object name = null;
                    object value = null;

                    foreach (object o in parameters)
                    {
                        if (i % 2 == 0)
                        {
                            name = o;
                        }
                        else
                        {
                            value = o;
                            cmd.Parameters.AddWithValue(name.ToString(), value);
                        }

                        i++;
                    }

                    SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public static DataTable Select(string selectQuery, params object[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand cmd = new SQLiteCommand(selectQuery, connection);

                    int i = 0;
                    object name = null;
                    object value = null;

                    foreach (object o in parameters)
                    {
                        if (i % 2 == 0)
                        {
                            name = o;
                        }
                        else
                        {
                            value = o;
                            cmd.Parameters.AddWithValue(name.ToString(), value);
                        }

                        i++;
                    }

                    SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public static long Insert(string insertQuery, params object[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection);
                        cmd.Transaction = transaction;

                        int i = 0;
                        object name = null;
                        object value = null;

                        foreach (object o in parameters)
                        {
                            if (i % 2 == 0)
                            {
                                name = o;
                            }
                            else
                            {
                                value = o;
                                cmd.Parameters.AddWithValue(name.ToString(), value);
                            }

                            i++;
                        }

                        cmd.ExecuteNonQuery();
                        long insertedRowID = connection.LastInsertRowId;
                        transaction.Commit();

                        return insertedRowID;
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }

                        throw ex;
                    }
                    finally
                    {
                        if (connection != null)
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        public static int Update(string updateQuery, params object[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLiteCommand cmd = new SQLiteCommand(updateQuery, connection);
                        cmd.Transaction = transaction;

                        int i = 0;
                        object name = null;
                        object value = null;

                        foreach (object o in parameters)
                        {
                            if (i % 2 == 0)
                            {
                                name = o;
                            }
                            else
                            {
                                value = o;
                                cmd.Parameters.AddWithValue(name.ToString(), value);
                            }

                            i++;
                        }

                        cmd.ExecuteNonQuery();
                        int rowsAffected = connection.Changes;
                        transaction.Commit();

                        return rowsAffected;
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }

                        throw ex;
                    }
                    finally
                    {
                        if (connection != null)
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        public static int Delete(string deleteQuery, params object[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SQLiteCommand cmd = new SQLiteCommand(deleteQuery, connection);
                        cmd.Transaction = transaction;

                        int i = 0;
                        object name = null;
                        object value = null;

                        foreach (object o in parameters)
                        {
                            if (i % 2 == 0)
                            {
                                name = o;
                            }
                            else
                            {
                                value = o;
                                cmd.Parameters.AddWithValue(name.ToString(), value);
                            }

                            i++;
                        }

                        cmd.ExecuteNonQuery();
                        int rowsAffected = connection.Changes;
                        transaction.Commit();

                        return rowsAffected;
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }

                        throw ex;
                    }
                    finally
                    {
                        if (connection != null)
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        public static long CountFunction(string functionName, params object[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand cmd = new SQLiteCommand(functionName, connection);

                    int i = 0;
                    object name = null;
                    object value = null;

                    foreach (object o in parameters)
                    {
                        if (i % 2 == 0)
                        {
                            name = o;
                        }
                        else
                        {
                            value = o;
                            cmd.Parameters.AddWithValue(name.ToString(), value);
                        }

                        i++;
                    }

                    SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    long count = Convert.ToInt64(dt.Rows[0]["value"]);

                    return count;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public static string ValueFunction(string functionName, params object[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand cmd = new SQLiteCommand(functionName, connection);

                    int i = 0;
                    object name = null;
                    object value = null;

                    foreach (object o in parameters)
                    {
                        if (i % 2 == 0)
                        {
                            name = o;
                        }
                        else
                        {
                            value = o;
                            cmd.Parameters.AddWithValue(name.ToString(), value);
                        }

                        i++;
                    }

                    SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    string result = string.Empty;

                    if (dt != null & dt.Rows.Count > 0 &&
                        dt.Rows[0]["value"] != null && dt.Rows[0]["value"] != DBNull.Value)
                    {
                        result = dt.Rows[0]["value"].ToString();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
