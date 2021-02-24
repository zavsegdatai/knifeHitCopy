using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveBinary : MonoBehaviour
{
    public static void Save(int lvl, int apples)
    {
        Data data = new Data();
        if (Load().maxLvl < lvl)
        {
            Debug.Log("Update");
            data.maxLvl = lvl;
            data.appleCount += (data.appleCount + apples) - data.appleCount;
            BinaryFormatter bf = new BinaryFormatter();
            using FileStream fs = new FileStream(Application.dataPath + "/data.sv", FileMode.Create);
            bf.Serialize(fs, data);
            fs.Close();
        }
    }

    public static void Save(int apples)
    {
        Data data = new Data();
        data.appleCount += (data.appleCount + apples) - data.appleCount;
        BinaryFormatter bf = new BinaryFormatter();
        using FileStream fs = new FileStream(Application.dataPath + "/data.sv", FileMode.Create);
        bf.Serialize(fs, data);
        fs.Close();
    }

    public static Data Load()
    {
        if (File.Exists(Application.dataPath + "/data.sv"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            using FileStream fs = new FileStream(Application.dataPath + "/data.sv", FileMode.Open);
            Data data = (Data)bf.Deserialize(fs);
            fs.Close();
            return data;
        }
        else{
            Debug.Log("Отсутствует сохранение!");
            return new Data();
        }
        
    }


    [System.Serializable]
    public class Data
    {
        public int appleCount = 0;
        public int maxLvl = 1;
    }
}
