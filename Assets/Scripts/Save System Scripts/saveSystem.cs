using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/*PROJECT TENDERFOOT
 * Started: 01/03/21 ~ My Birthday :)
 * Last updated: 01/03/21
*/

public static class saveSystem
{
    public static void save(dataVariables dV)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.aqua";
        FileStream stream = new FileStream(path, FileMode.Create);

        saveData data = new saveData(dV);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static saveData LoadData()
    {
        string path = Application.persistentDataPath + "/data.aqua";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            saveData data = formatter.Deserialize(stream) as saveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found in " + path);
            return null;
        }
    }
}
