using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SuperAudioPlayer
{
    public class Database
    {
        public SQLiteConnection dbConnection;
        public SQLiteCommand command;
        public SQLiteDataReader dataReader;

        /// <summary>
        /// Creates a table and open the database.
        /// </summary>
        public void OpenDB()
        {
            dbConnection = new SQLiteConnection("Data Source=SAudioPlayerDB.db;Version=3;");
            dbConnection.Open();
        }

        public void CreateTable()
        {
            command = dbConnection.CreateCommand();
            command.CommandText = "DROP TABLE IF EXISTS Song;";
            command.ExecuteNonQuery();

            command = dbConnection.CreateCommand();
            command.CommandText = @"CREATE TABLE Song(
                                            ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                            Title STRING NOT NULL,
                                            Album STRING,
                                            Band STRING,
                                            Duration STRING NOT NULL,
                                            FileType STRING,
                                            Path STRING NOT NULL
                                    ); ";
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Insert the data sent in parameters in the opened database.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="album"></param>
        /// <param name="band"></param>
        /// <param name="duration"></param>
        /// <param name="fileType"></param>
        /// <param name="path"></param>
        public void InsertSongDB(string title, string album, string band, string duration, string fileExtension, string path)
        {
            command = dbConnection.CreateCommand();
            command.CommandText = "INSERT INTO Song (Title, Album, Band, Duration, FileType, Path) VALUES ('" + title + "','" + album + "','" + band + "','" + duration + "','" + fileExtension + "','" + path + "');";
            command.ExecuteNonQuery();
        }

        public List<List<string>> ReadDataDB()
        {
            command = dbConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Song;";

            dataReader = command.ExecuteReader();

            List<List<string>> songsList = new List<List<string>>();

            while (dataReader.Read())
            {
                var title = dataReader.GetString(1);
                var album = dataReader.GetString(2);
                var band = dataReader.GetString(3);
                var duration = dataReader.GetString(4);
                var filetype = dataReader.GetString(5);
                var path = dataReader.GetString(6);

                songsList.Add(new List<string> { title, album, band, duration, filetype, path });
            }

            return songsList;
        }

        public string getSongPath(string songTitle)
        {
            string songPath = "";
            command = dbConnection.CreateCommand();
            command.CommandText = "SELECT Path FROM Song WHERE Title = '" + songTitle + "';";

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                songPath = dataReader.GetString(0);
            }

            return songPath;
        }

        public string getNextOrPreviousSongPath(int Id)
        {
            string nextSongPath = "";
            Id++;
            command = dbConnection.CreateCommand();
            command.CommandText = "SELECT Path FROM Song WHERE ID = '" + Id + "';";

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                nextSongPath = dataReader.GetString(0);
            }

            return nextSongPath;
        }

        public int getSongId(string songPath)
        {
            int id = 0;
            command = dbConnection.CreateCommand();
            command.CommandText = "SELECT Id FROM Song WHERE Path = '" + songPath + "';";

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                id = dataReader.GetInt16(0);
            }

            return id;
        }

        public string getSongLength(string songPath)
        {
            string songLength = "";
            command = dbConnection.CreateCommand();
            command.CommandText = "SELECT Duration FROM Song WHERE Path = '" + songPath + "';";

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                songLength = dataReader.GetString(0);
            }

            return songLength;
        }

        public string getSongTitle(string songPath)
        {
            string songTitle = "";
            command = dbConnection.CreateCommand();
            command.CommandText = "SELECT Title FROM Song WHERE Path = '" + songPath + "';";

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                songTitle = dataReader.GetString(0);
            }

            return songTitle;
        }

        public void updateData(string oldTitle, string newTitle)
        {
            command = dbConnection.CreateCommand();
            command.CommandText = "UPDATE Song SET Title = '" + newTitle + "' WHERE Title = '" + oldTitle + "';";
            command.ExecuteNonQuery();
        }
    }
}
