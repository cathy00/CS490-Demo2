using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class InitInventory : MonoBehaviour
{
    [SerializeField]
    private Text burgerText;

    [SerializeField]
    private Text donutText;

    [SerializeField]
    private Text milkText;

    [SerializeField]
    private Text ballText;

    [SerializeField]
    private Text towelText;

    [SerializeField]
    private Text medicineText;

    void Start()
    {
        initBall();
        initBurger();
        initDonut();
        initMedicine();
        initMilk();
        initTowel();
    }

    public int init (int ID)
    {
        int total_item_number = 0;

        string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT total_item_number " + "FROM item_list " + "WHERE id=" + ID;
        Debug.Log(sqlQuery);
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            total_item_number = reader.GetInt32(0);
            Debug.Log("value= " + total_item_number);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        System.GC.Collect();

        return total_item_number;
    }

    public void initBurger ()
    {
        burgerText.text = init(1) + " left";
    }

    public void initDonut()
    {
        donutText.text = init(2) + " left";
    }

    public void initMilk()
    {
        milkText.text = init(3) + " left";
    }

    public void initBall()
    {
        ballText.text = init(4) + " left";
    }

    public void initTowel()
    {
        towelText.text = init(5) + " left";
    }

    public void initMedicine()
    {
        medicineText.text = init(6) + " left";
    }

    public void Inventory_button_click()
    {
        Start();
    }
}
