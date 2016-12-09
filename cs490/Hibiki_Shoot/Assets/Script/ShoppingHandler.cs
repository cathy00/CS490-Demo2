using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class ShoppingHandler : MonoBehaviour {

	public void Food_button_click() {
        string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        
        string sqlQuery = "Update user " + "Set number_of_coins = number_of_coins - 10 " + "WHERE Name='SB'";
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        sqlQuery = "Update item_list " + "Set total_item_number = total_item_number + 1 " + "WHERE id = 1";
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        sqlQuery = "Insert into item_listCitem (item_id, item_list_id) " + "Values (1, 1) ";
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

}
