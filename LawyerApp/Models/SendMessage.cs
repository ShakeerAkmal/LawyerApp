
using RealtimeChat.Hubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace LawyerApp.Models
{
    public static class MessageService
    {
        static readonly string connString = @"data source=localhost;initial catalog=siteDb;Integrated Security=True;";

        internal static SqlCommand command = null;
        internal static SqlDependency dependency = null;


        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <returns></returns>
        public static string GetNotification()
        {
            try
            {

                var messages = new List<State>();
                using (var connection = new SqlConnection(connString))
                {

                    connection.Open();
                    //// Alwasys use "dbo" prefix of database to trigger change event
                    using (command = new SqlCommand(@"SELECT [id]
      ,[state]
      ,[isDeleted]
  FROM [dbo].[State]", connection))
                    {
                        command.Notification = null;

                        if (dependency == null)
                        {
                            dependency = new SqlDependency(command);
                            dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                        }

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        var reader = command.ExecuteReader();
                        //InventoryManagementEntities db = new InventoryManagementEntities();
                        //var xx = db.tbl_Notifications.Where(a => a.ExtraColumn == null).ToList();
                        while (reader.Read())
                        {
                            messages.Add(item: new State
                            {
                                id = (int)reader["id"],
                                state1 = reader["state"] != DBNull.Value ? (string)reader["state"] : "",
                                //isDeleted = reader["isDeleted"] != DBNull.Value ? (bool)reader["isDeleted"] : false
                                isDeleted = false

                            });
                        }
                    }

                }
                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(messages);
                return json;

            }
            catch (Exception ex)
            {

                return null;
            }


        }

        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (dependency != null)
            {
                dependency.OnChange -= dependency_OnChange;
                dependency = null;
            }
            if (e.Type == SqlNotificationType.Change)
            {
                MyHub.Send();
            }
        }

    }
}