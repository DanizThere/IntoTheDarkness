using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{
    public SaveData activeSave;
    public static SaveManager instance;
    public bool hasLoaded;

    private void Awake()
    {
        instance = this;
        Load();
    }
    void Start()
    {
        Save();
        activeSave.saveName = "PersonalSave";
    }
    public void Save()
    {
        string dataPath = Application.persistentDataPath;
        string filePath = dataPath + "/" + activeSave.saveName + ".save"; 

        var fSerializer = new XmlSerializer(typeof(SaveData));

        var fStream = new FileStream(filePath, FileMode.Create);

        fSerializer.Serialize(fStream, activeSave);

        fStream.Close();
        Debug.Log("Э я сохранился");
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;
        string filePath = dataPath + "/" + activeSave.saveName + ".save";
        if (System.IO.File.Exists(filePath))
        {
            var fSerializer = new XmlSerializer(typeof(SaveData));

            var fStream = new FileStream(filePath, FileMode.Open);

            activeSave = fSerializer.Deserialize(fStream) as SaveData;

            fStream.Close();
            Debug.Log("Э я загрузился");
            hasLoaded = true;
        }
        else
        {
            Debug.Log("Э я не загрузился");
        }

        
    }
    public void DeleteSave()
    {
        string dataPath = Application.persistentDataPath;
        string filePath = dataPath + "/" + activeSave.saveName + ".save";

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Load();
        }
        if(Input.GetKeyDown(KeyCode.U)) 
        {
            DeleteSave();
        }
    }
}
[System.Serializable]
public class SaveData
{
    public string saveName;
    public Vector3 respawnPos;
}
