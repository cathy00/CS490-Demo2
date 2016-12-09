using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class UpdateInventory : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Burger_button_click()
    {
        Food_button_click(1, 5, 5, 3, 0);
    }

    public void Donut_button_click()
    {
        Food_button_click(2, 10, 10, 6, 0);
    }

    public void Milk_button_click()
    {
        Food_button_click(3, 20, 20, 12, 0);
    }

    public void Ball_button_click()
    {
        Food_button_click(4, 0, 15, 10, 0);
    }

    public void Towel_button_click()
    {
        Food_button_click(5, 0, 15, 15, 20);
    }

    public void Medicine_button_click()
    {
        Food_button_click(6, 0, 10, 20, 0);
    }


    public void Food_button_click(int item_id, int hunger, int happiness, int health, int cleanliness)
    {
        string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "Update condition " + "Set hunger = hunger - " + hunger + ", happiness = happiness - " + happiness + ", health = health - " + health + ", cleanliness = cleanliness - " + cleanliness + " WHERE id=1";
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        sqlQuery = "Update item_list Set total_item_number = total_item_number - 1 where id = " + item_id;
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        System.GC.Collect();
    }
}
