using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class CoinGenerator : MonoBehaviour {

    [SerializeField]
    private Text valueText;

    private int totalCoins = 0;

    private int interval = 60;
    private float nextTime = 0;

	// Use this for initialization
	void Start () {
        string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT number_of_coins " + "FROM user " + "WHERE Name='SB'";
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
    }

	// Update is called once per frame
	void Update () {
        valueText.text = "Coins: " + totalCoins;
	}
}
