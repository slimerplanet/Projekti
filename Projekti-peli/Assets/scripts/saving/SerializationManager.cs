using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]

public class SerializationManager : MonoBehaviour
{
    public static bool Save(string saveName, object savedata)
    {
        BinaryFormatter formatter = GetbinaryFormatter();

        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/saves/" + saveName + ".cds";
        FileStream file = File.Create(path);

        formatter.Serialize(file, savedata);

        file.Close();

        return true;
    }
    public static object load(string path)
    {
        if(!File.Exists(path)) {
            return null;
        }

        BinaryFormatter formatter = GetbinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("failed to load file at {0}", path);
            file.Close();
            return null;
        }
    }

    private static BinaryFormatter GetbinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        SurrogateSelector selector = new SurrogateSelector();

        Vector3Serializationsurrogate vector3Surrogate = new Vector3Serializationsurrogate();
        QuaternionSerilizationSurrogate quaternionsurrogate = new QuaternionSerilizationSurrogate();

        selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3Surrogate);
        selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), quaternionsurrogate);

        formatter.SurrogateSelector = selector;

        return formatter;
    }
}
