using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class ShoppingHandler : MonoBehaviour {

    public void Food_button_click(int price, int item_id) {
        string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        
        string sqlQuery = "Update user " + "Set number_of_coins = number_of_coins - " + price + " WHERE Name='Josh'";
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        sqlQuery = "Update item_list Set total_item_number = total_item_number + 1 where id = " + item_id;
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        System.GC.Collect();
    }


    public void Burger_button_click()
    {
        Food_button_click(10, 1);
    }

    public void Donut_button_click()
    {
        Food_button_click(15, 2);
    }

    public void Milk_button_click()
    {
        Food_button_click(20, 3);
    }

    public void Ball_button_click()
    {
        Food_button_click(15, 4);
    }

    public void Towel_button_click()
    {
        Food_button_click(20, 5);
    }

    public void Medicine_button_click()
    {
        Food_button_click(20, 6);
    }
}
