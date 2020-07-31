using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
    // This is really messy I shall fix it when I learn a better way
    public static void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if(File.Exists(Application.persistentDataPath + "savedgame.dat"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "savedgame.dat", FileMode.Open);
            ScoresData data = new ScoresData();

            data.gems = ScoresData.current.gems;

            bf.Serialize(file, ScoresData.current);
            file.Close();
        }
        else
        {
            FileStream file = File.Create(Application.persistentDataPath + "savedgame.dat");
            ScoresData data = new ScoresData();

            data.gems = ScoresData.current.gems;
            bf.Serialize(file, ScoresData.current);
        }
    }

    public static void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "savedgame.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "savedgame.dat", FileMode.Open);
            ScoresData data = (ScoresData)bf.Deserialize(file);
            file.Close();

            ScoresData.current.gems = data.gems;

            Debug.Log("Loaded the file");
        }
        else
        {
            Debug.Log("File Does not exist");
        }
    }

    public static void SaveDeaths()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "deathCount.ded"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "deathCount.ded", FileMode.Open);
            DeathData data = new DeathData();

            data.deathCount = DeathData.current.deathCount;

            bf.Serialize(file, DeathData.current);
            file.Close();
        }
        else
        {
            FileStream file = File.Create(Application.persistentDataPath + "deathCount.ded");
            DeathData data = new DeathData();

            data.deathCount = DeathData.current.deathCount;
            bf.Serialize(file, DeathData.current);
            file.Close();
        }
    }

    public static void LoadDeaths()
    {
        if (File.Exists(Application.persistentDataPath + "deathCount.ded"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "deathCount.ded", FileMode.Open);
            DeathData data = (DeathData)bf.Deserialize(file);
            file.Close();

            DeathData.current.deathCount = data.deathCount;

            Debug.Log("Loaded the file");
        }
        else
        {
            Debug.Log("File Does not exist");
        }
    }
    /*    public static void SaveScores(ScoringSystem scores)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "scores.txt";
            FileStream stream = new FileStream(path, FileMode.Create);

            ScoresData data = new ScoresData(scores);

            formatter.Serialize(stream, data);
            stream.Close();
        }*/

    /*    public static ScoresData LoadScores()
        {
            string path = Application.persistentDataPath + "scores.txt";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                ScoresData data = formatter.Deserialize(stream) as ScoresData;
                stream.Close();

                return data;
            }
            else
            {
                Debug.LogError("Save File not found in " + path);
                return null;
            }
        }*/
}
