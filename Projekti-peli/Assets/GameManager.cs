using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class GameManager : MonoBehaviour
{
    public GameObject player;
    pausemenu pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = FindObjectOfType<pausemenu>();
        pause.Resume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save()
    {
        SaveData.current.playerdata.position = player.transform.position;
        SaveData.current.playerdata.rotation = player.transform.rotation;
        SaveData.current.sceneIndex = SceneManager.GetActiveScene().buildIndex;

        bool saved = SerializationManager.Save("save", SaveData.current);
    }

    public void load()
    {
        SaveData.current = (SaveData)SerializationManager.load(Application.persistentDataPath + "/saves/save.cds");

        //if (SceneManager.GetActiveScene().buildIndex != SaveData.current.sceneIndex)
        //    SceneManager.LoadScene(SaveData.current.sceneIndex);

        player.transform.position = SaveData.current.playerdata.position;
        player.transform.rotation = SaveData.current.playerdata.rotation;
    }
}
