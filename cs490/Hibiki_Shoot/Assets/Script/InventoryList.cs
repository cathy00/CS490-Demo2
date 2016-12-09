using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Mono.Data.Sqlite;
using System.Data;

public class InventoryList : MonoBehaviour {

    [SerializeField]
    public Sprite img1, img2, img3;
    [SerializeField]
    public Button button1, button2, button3;

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update () {
        Button[] buttons = new Button[3] {button1, button2, button3};
        string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "select item_id from item_listCitem " + "WHERE item_list_id = 1";
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        int item_id = 0;
        int current = 0;
        while (reader.Read())
        {
            item_id = reader.GetInt32(0);
            if (item_id == 1)
            {
                buttons[current] = buttons[current].GetComponent<Button>();
                buttons[current].image.overrideSprite = img1;
            }
            current++;
        }
        Debug.Log("current= " + current);
        for (int i = current; i < 3; i++)
        {
            buttons[i] = buttons[i].GetComponent<Button>();
            buttons[i].image.overrideSprite = img3;
        }
    }
}
