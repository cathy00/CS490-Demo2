using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    private float lerpSpeed = 0.5f;

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    [SerializeField]
    private Text valueText;

    //decrease every 600 seconds
    private int interval = 60;
    private float nextTime = 0;

    private int save = 0;

    public float MaxValue { get; set; }

    public float Value {
        set {
            valueText.text = value + "/100";
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }
    
	// Use this for initialization
	void Start () {
        string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT health " + "FROM condition " + "WHERE Id=1";
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            fillAmount = reader.GetInt32(0) / (float)100;
            Debug.Log("value= " + fillAmount);
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
        if (Time.time >= nextTime && fillAmount > 0)
        {
            fillAmount = fillAmount - 0.01f;
            nextTime += interval;
            int a = (int)(fillAmount * 100);
            valueText.text = a + "/100";
        }
        HandleBar();

        save++;
        if (save >= 5000)
        {
            save = 0;
            string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            int new_value = (int)(100 * fillAmount);
            string sqlQuery = "UPDATE condition set health = " + new_value + " WHERE Id=1";
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

    private void HandleBar() {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax) {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
