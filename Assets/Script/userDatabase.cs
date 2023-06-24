using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//References
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;
public class userDatabase : MonoBehaviour
{
    private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    private IDataReader reader;
    public int i;

    public int[] highScore = new int[13];
    public int[] perform = new int[4];
    public int lagu;

    string DatabaseName = "user.db";
    // Start is called before the first frame update
    void Start()
    {
        //Application database Path android
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database

            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/user");



            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/user.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);




        }


        conn = "URI=file:" + filepath;

        Debug.Log("Stablishing connection to: " + conn);
        dbconn = new SqliteConnection(conn);
        dbconn.Open();

        string query;
        query = "CREATE TABLE user (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, highScore INTEGER DEFAULT 0 NULL); ";
        try
        {
            dbcmd = dbconn.CreateCommand(); // create empty command
            dbcmd.CommandText = query; // fill the command
            reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        }
        catch (Exception e)
        {

            Debug.Log(e);

        }
        query = "CREATE TABLE lagu (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, lagu INTEGER DEFAULT 1 NULL);";
        try
        {
            dbcmd = dbconn.CreateCommand(); // create empty command
            dbcmd.CommandText = query; // fill the command
            reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        }
        catch (Exception e)
        {

            Debug.Log(e);

        }
        query = "CREATE TABLE performance (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, bad INTEGER DEFAULT 0, poor  INTEGER DEFAULT 0, good INTEGER DEFAULT 0, great INTEGER DEFAULT 0); ";
        try
        {
            dbcmd = dbconn.CreateCommand(); // create empty command
            dbcmd.CommandText = query; // fill the command
            reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        }
        catch (Exception e)
        {

            Debug.Log(e);

        }
        cek();
        cek1();
        cek2();
        
    }

    public void awalan()
    {
        //Application database Path android
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            // If not found on android will create Tables and database

            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/user");



            // UNITY_ANDROID
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/user.db");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);




        }


        conn = "URI=file:" + filepath;

        Debug.Log("Stablishing connection to: " + conn);
        dbconn = new SqliteConnection(conn);
        dbconn.Open();

        string query;
        query = "CREATE TABLE user (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, highScore INTEGER DEFAULT 0 NULL); ";
        try
        {
            dbcmd = dbconn.CreateCommand(); // create empty command
            dbcmd.CommandText = query; // fill the command
            reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        }
        catch (Exception e)
        {

            Debug.Log(e);

        }
        query = "CREATE TABLE lagu (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, lagu INTEGER DEFAULT 1 NULL);";
        try
        {
            dbcmd = dbconn.CreateCommand(); // create empty command
            dbcmd.CommandText = query; // fill the command
            reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        }
        catch (Exception e)
        {

            Debug.Log(e);

        }
        query = "CREATE TABLE performance (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, bad INTEGER DEFAULT 0, poor  INTEGER DEFAULT 0, good INTEGER DEFAULT 0, great INTEGER DEFAULT 0); ";
        try
        {
            dbcmd = dbconn.CreateCommand(); // create empty command
            dbcmd.CommandText = query; // fill the command
            reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        }
        catch (Exception e)
        {

            Debug.Log(e);

        }
        cek();
        cek1();
        cek2();
    }
    public void cek()
    {
        int score = 0;
        using (dbconn = new SqliteConnection(conn))
        {
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "SELECT * " + "FROM user where id = 1";// table name
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    score = reader.GetInt32(0);
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
            }
            if (score == 0)
            {
                insert_function();
            }
            else
            {
                reader_function();
            }

    }

    public void cek1()
    {
        int score = 0;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT * " + "FROM lagu where id = 1";// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                score = reader.GetInt32(0);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
        }
        if (score == 0)
        {
            insert_function1();
        }
        else
        {
            reader_function1();
        }
    }
    public void cek2()
    {
        int score = 0;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT * " + "FROM performance where id = 1";// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                score = reader.GetInt32(0);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
        }
        if (score == 0)
        {
            insert_function2();
        }
        else
        {
            reader_function2();
        }
    }

    //Insert
    public void readData()
    {
        reader_function();

    }

    public void readData1()
    {
        reader_function1();

    }
    //Search 
    /* public void Search_button()
     {
         data_staff.text = "";
         Search_function(t_id.text);

     }

     //Update
     public void Update_button()
     {
         update_function_score(1);

     }
     public void Update_button_maze()
     {
         update_function_maze(1);

     }
     public void Update_button_balon()
     {
         update_function_balon(1);

     }
     public void Update_button_hanoi()
     {
         update_function_hanoi(1);

     }*/

    //Delete
/*    public void Delete_button()
    {
        data_staff.text = "";
        Delete_function(t_id.text);

    }*/

    //Insert To Database
    public void insert_1()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into user default values";// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
    private void insert_function()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            for (int i = 0; i < 13; i++)
            {
                dbconn.Open(); //Open connection to the database.
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "insert into user default values";// table name
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
                
        }
        Debug.Log("Insert Done  ");

        reader_function();
    }

    //Insert To Database
    private void insert_function1()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into lagu default values";// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
        Debug.Log("Insert Done  ");

        reader_function1();
    }

    //Insert To Database
    private void insert_function2()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into performance default values";// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
        Debug.Log("Insert Done  ");

        reader_function2();
    }

    //Read All Data For To Database
    public void reader_function()
    {
        // int idreaders ;
        using (dbconn = new SqliteConnection(conn))
        {
             i = 0;
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT * " + "FROM user";// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                // idreaders = reader.GetString(1);
                highScore[i] = reader.GetInt32(1);
                /*Debug.Log("high score = " + highScore[i]);*/
                i++;
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            //       dbconn = null;
         
        }
        
    }

    public void reader_function1()
    {
        // int idreaders ;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT * " + "FROM lagu where id = 1";// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                // idreaders = reader.GetString(1);
                lagu = reader.GetInt32(1);
                //data_staff.text += " score =" + score + "pecah balon=" + pecah_balon + " maze =" + maze + "hanoi=" + hanoi + "\n";
                /*Debug.Log("lagu =" + lagu);*/
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            //       dbconn = null;

        }

    }
    public void reader_function2()
    {
        // int idreaders ;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT * " + "FROM performance where id = 1";// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                // idreaders = reader.GetString(1);
                perform[0] = reader.GetInt32(1);
                perform[1] = reader.GetInt32(2);
                perform[2] = reader.GetInt32(3);
                perform[3] = reader.GetInt32(4);
                //data_staff.text += " score =" + score + "pecah balon=" + pecah_balon + " maze =" + maze + "hanoi=" + hanoi + "\n";
                /*Debug.Log("lagu =" + lagu);*/
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            //       dbconn = null;

        }

    }

    //Default Value performance
    public void defaultPerform()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "UPDATE performance set bad = 0, poor = 0, good = 0, great = 0 where id = 1 ";

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            reader_function2();
        }
    }

    //Update Table Performance
    public void updatePerform(int[] arr)
    {
        Debug.Log("perform =" + arr[0] + "perform =" + arr[1] + "perform =" + arr[2] + "perform =" + arr[3]);
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE performance set bad = @bad, poor = @poor, good = @good, great = @great where id = 1");

            SqliteParameter bad = new SqliteParameter("@bad", arr[0]);
            SqliteParameter poor = new SqliteParameter("@poor", arr[1]);
            SqliteParameter good = new SqliteParameter("@good", arr[2]);
            SqliteParameter great = new SqliteParameter("@great", arr[3]);

            dbcmd.Parameters.Add(bad);
            dbcmd.Parameters.Add(poor);
            dbcmd.Parameters.Add(good);
            dbcmd.Parameters.Add(great);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            reader_function2();
        }

        // SceneManager.LoadScene("home");
    }

    public void updateHighScore(int song, int score)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "UPDATE user set highScore = @score where id = @song ";

            SqliteParameter skor = new SqliteParameter("@score", score);
            SqliteParameter song1 = new SqliteParameter("@song", song);

            dbcmd.Parameters.Add(skor);
            dbcmd.Parameters.Add(song1);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            reader_function();
        }
    }

    public void updateSong(int song)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "UPDATE lagu set lagu = @song where id = 1 ";

            SqliteParameter song1 = new SqliteParameter("@song", song);

            dbcmd.Parameters.Add(song1);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            reader_function();
        }
    }

    void Update()
    {
        cek();
        cek1();
        cek2();
    }
    public int getLagu()
    {
        return lagu;
    }

    /*   //Search on Database by ID
       private void Search_function(string Search_by_id)
       {
           using (dbconn = new SqliteConnection(conn))
           {
               int score;
               bool pecah_balon, maze, hanoi;
               dbconn.Open(); //Open connection to the database.
               IDbCommand dbcmd = dbconn.CreateCommand();
               string sqlQuery = "SELECT * " + "FROM Users where id =" + Search_by_id;// table name
               dbcmd.CommandText = sqlQuery;
               IDataReader reader = dbcmd.ExecuteReader();
               while (reader.Read())
               {
                   score = reader.GetInt32(1);
                   pecah_balon = (bool)reader["pecah_balon"];
                   maze = (bool)reader["maze"];
                   hanoi = (bool)reader["hanoi"];

                   Debug.Log(" score =" + score + "pecah balon=" + pecah_balon + " maze =" + maze + "hanoi=" + hanoi);

               }
               reader.Close();
               reader = null;
               dbcmd.Dispose();
               dbcmd = null;
               dbconn.Close();


           }

       }

       //Update on  Database score
       public void update_function_score(int score)
       {
           skor += score;
           using (dbconn = new SqliteConnection(conn))
           {
               dbconn.Open(); //Open connection to the database.
               dbcmd = dbconn.CreateCommand();
               sqlQuery = string.Format("UPDATE Users set score = @score where id = 1 ");

               SqliteParameter P_update_name = new SqliteParameter("@score", skor);

               dbcmd.Parameters.Add(P_update_name);

               dbcmd.CommandText = sqlQuery;
               dbcmd.ExecuteScalar();
               dbconn.Close();
               reader_function();
           }

           // SceneManager.LoadScene("home");
       }

       //Update on  Database score
       public void update_function_maze(int score)
       {
           reader_function1();
           skor_maze += score;
           if (cek_maze)
           {


               using (dbconn = new SqliteConnection(conn))
               {
                   dbconn.Open(); //Open connection to the database.
                   dbcmd = dbconn.CreateCommand();
                   sqlQuery = string.Format("UPDATE game set maze = @maze where id = 1 ");

                   SqliteParameter P_update_name = new SqliteParameter("@maze", skor_maze);

                   dbcmd.Parameters.Add(P_update_name);

                   dbcmd.CommandText = sqlQuery;
                   dbcmd.ExecuteScalar();
                   dbconn.Close();
                   reader_function1();
               }
           }

           // SceneManager.LoadScene("home");
       }

       public void update_function_balon(int score)
       {
           reader_function1();
           skor_balon += score;
           if (cek_balon)
           {
               using (dbconn = new SqliteConnection(conn))
               {
                   dbconn.Open(); //Open connection to the database.
                   dbcmd = dbconn.CreateCommand();
                   sqlQuery = string.Format("UPDATE game set balon = @balon where id = 1 ");

                   SqliteParameter P_update_name = new SqliteParameter("@balon", skor_balon);

                   dbcmd.Parameters.Add(P_update_name);

                   dbcmd.CommandText = sqlQuery;
                   dbcmd.ExecuteScalar();
                   dbconn.Close();
                   reader_function1();
               }
           }
           // SceneManager.LoadScene("home");
       }
       public void update_function_hanoi(int score)
       {
           reader_function1();
           skor_hanoi += score;
           if (cek_hanoi)
           {
               using (dbconn = new SqliteConnection(conn))
               {
                   dbconn.Open(); //Open connection to the database.
                   dbcmd = dbconn.CreateCommand();
                   sqlQuery = string.Format("UPDATE game set hanoi = @hanoi where id = 1 ");

                   SqliteParameter P_update_name = new SqliteParameter("@hanoi", skor_hanoi);

                   dbcmd.Parameters.Add(P_update_name);

                   dbcmd.CommandText = sqlQuery;
                   dbcmd.ExecuteScalar();
                   dbconn.Close();
                   reader_function1();
               }
           }
           // SceneManager.LoadScene("home");
       }

       public void enable_function_balon()
       {
           reader_function();
           if (!cek_balon)
           {
               if (skor >= purchase_balon)
               {
                   cek_balon = true;
                   using (dbconn = new SqliteConnection(conn))
                   {
                       dbconn.Open(); //Open connection to the database.
                       dbcmd = dbconn.CreateCommand();
                       sqlQuery = string.Format("UPDATE Users set pecah_balon = @balon where id = 1 ");

                       SqliteParameter P_update_name = new SqliteParameter("@balon", cek_balon);

                       dbcmd.Parameters.Add(P_update_name);

                       dbcmd.CommandText = sqlQuery;
                       dbcmd.ExecuteScalar();

                       dbconn.Close();
                       update_function_score(-1 * (purchase_balon));
                       reader_function();
                   }
               }
               else
               {
                   pop.Open2();
               }
           }
           // SceneManager.LoadScene("home");
       }

       public void enable_function_hanoi()
       {
           reader_function();
           if (!cek_hanoi)
           {
               if (skor >= purchase_hanoi)
               {
                   cek_hanoi = true;
                   using (dbconn = new SqliteConnection(conn))
                   {
                       dbconn.Open(); //Open connection to the database.
                       dbcmd = dbconn.CreateCommand();
                       sqlQuery = string.Format("UPDATE Users set hanoi = @hanoi where id = 1 ");

                       SqliteParameter P_update_name = new SqliteParameter("@hanoi", cek_hanoi);

                       dbcmd.Parameters.Add(P_update_name);

                       dbcmd.CommandText = sqlQuery;
                       dbcmd.ExecuteScalar();
                       dbconn.Close();
                       update_function_score(-1 * (purchase_hanoi));
                       reader_function();
                   }
               }
               else
               {
                   pop.Open2();
               }
           }
           // SceneManager.LoadScene("home");
       }

       public bool getBalon()
       {
           reader_function();
           return cek_balon;
       }
       public bool getHanoi()
       {
           reader_function();
           return cek_hanoi;
       }
       public int getMazeScore()
       {
           reader_function1();
           return skor_maze;
       }
       public int getBalonScore()
       {
           reader_function1();
           return skor_balon;
       }
       public int getHanoiScore()
       {
           reader_function1();
           return skor_hanoi;
       }

       //Delete
       private void Delete_function(string Delete_by_id)
       {
           using (dbconn = new SqliteConnection(conn))
           {

               dbconn.Open(); //Open connection to the database.
               IDbCommand dbcmd = dbconn.CreateCommand();
               string sqlQuery = "DELETE FROM Users where id =" + Delete_by_id;// table name
               dbcmd.CommandText = sqlQuery;
               IDataReader reader = dbcmd.ExecuteReader();


               dbcmd.Dispose();
               dbcmd = null;
               dbconn.Close();
               data_staff.text = Delete_by_id + " Delete  Done ";

           }

       }
       // Update is called once per frame
       void Update()
       {
           cek();
           cek1();
       }

       public void MazeEasy()
       {
           SceneManager.LoadScene("SampleScene");
       }
       public void HanoiEasy()
       {
           SceneManager.LoadScene("SampleScene1");
       }

       public void RestartLevel()
       {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }*/
}