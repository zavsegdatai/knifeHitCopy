using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveBinary
{
    public static void Save(int lvl, int apples, int knifeCount)
    {
        Data data = Load();
        if (data.maxLvl < lvl)
        {
            if (data.maxKnifesFixed < knifeCount)
            {
                data.maxKnifesFixed = knifeCount;
            }
            data.maxLvl = lvl;
            data.appleCount += (apples - data.appleCount);
            BinaryFormatter bf = new BinaryFormatter();
            using FileStream fs = new FileStream(Application.persistentDataPath + "/data.sv", FileMode.Create);
            bf.Serialize(fs, data);
        }
        else
        {
            if (data.maxKnifesFixed < knifeCount)
            {
                data.maxKnifesFixed = knifeCount;
            }
            data.appleCount += (apples - data.appleCount);
            BinaryFormatter bf = new BinaryFormatter();
            using FileStream fs = new FileStream(Application.persistentDataPath + "/data.sv", FileMode.Create);
            bf.Serialize(fs, data);
        }
    }

    public static Data Load()
    {
        if (File.Exists(Application.persistentDataPath + "/data.sv"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            using FileStream fs = new FileStream(Application.persistentDataPath + "/data.sv", FileMode.Open);
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
        public int maxKnifesFixed = 0;
    }
}
