using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class CoinGenerator : MonoBehaviour {

    [SerializeField]
    private Text valueText;

    private int totalCoins = 0;

    private int interval = 2000;
    private int nextTime = 0;

	// Use this for initialization
	void Start () {
        string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT number_of_coins " + "FROM user " + "WHERE Name='Josh'";
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            totalCoins = reader.GetInt32(0);
            Debug.Log("value= " + totalCoins);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        System.GC.Collect();
    }

	// Update is called once per frame
	void Update () {
        nextTime++;
        if (nextTime == interval)
        {
            totalCoins += 100;
            nextTime = 0;
            string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "UPDATE user set number_of_coins = " + totalCoins + " WHERE Name='Josh'";
            Debug.Log(sqlQuery);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteNonQuery();
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
            System.GC.Collect();
            valueText.text = "Coins: " + totalCoins + " (just increased!)";
        }
        else if (nextTime < interval / 40)
        {
            valueText.text = "Coins: " + totalCoins + " (just increased!)";
        }
        else
        {
            valueText.text = "Coins: " + totalCoins;
        }
	}

    // update coin number on screen after purchasing something
    public void on_click_shop_button()
    {
        Start();
    }
}
