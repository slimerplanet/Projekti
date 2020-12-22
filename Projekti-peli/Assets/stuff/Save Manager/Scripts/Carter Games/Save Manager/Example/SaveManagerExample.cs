using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/************************************************************************************
 * 
 *							           Save Manager
 *							  
 *				                   ** Example Script **
 *	   This is not needed for the asset to work, it is just used in the example scene.
 * Please do not edit this code as it will break the example scene provided with this asset.
 *			
 *			                        Script written by: 
 *			           Jonathan Carter (https://jonathan.carter.games)
 *			        
 *									Version: 1.0.2
 *						   Last Updated: 05/10/2020 (d/m/y)					
 * 
*************************************************************************************/

namespace CarterGames.Assets.SaveManager.Example
{
    /// <summary>
    /// EXAMPLE ONLY - DO NOT EDIT!
    /// (CLASS) - example class showing the saving and loading of data, used in the example scene.
    /// NOTE - this class only works if the SaveData has not being edited by you, once it is edited the scene will not function.
    /// </summary>
    public class SaveManagerExample : MonoBehaviour
    {
        // Input values
        [Header("Input Fields")]
        public Text playerName;
        public Text playerHealth;
        public Text playerPosition0;
        public Text playerPosition1;
        public Text playerPosition2;
        public Text playerShield;

        // An instance of the custom class used in the example
        private ExampleClass exampleClass = new ExampleClass();

        // output values
        [Header("Output Text Components")]
        public Text displayPlayerName;
        public Text displayPlayerHealth;
        public Text displayPlayerPosition;
        public Text displayPlayerShield;


        /// <summary>
        /// Saves the data by making a new save data and passing the values entered into the scene into it, you don't have to edit all the values each time you save, this example does.
        /// NOTE: int/float.phase() is used here as we are using input fields in the scene, you'd normally have the correct value type to hand, with UI Input fields we don't, so we have to convert them in this example.
        /// </summary>
        public void SaveGame()
        {
            // For you this would be ' SaveData ' not ' ExampleSaveData '
            ExampleSaveData saveData = new ExampleSaveData();

            // Passing in values to be saved
            saveData.examplePlayerName = playerName.text;
            saveData.examplePlayerHealth = float.Parse(playerHealth.text);

            // Creating a SaveVector3 and setting the Vector3 up before saving it.
            SaveVector3 exampleVec = new SaveVector3();
            exampleVec.Vector3 = new Vector3(float.Parse(playerPosition0.text), float.Parse(playerPosition1.text), float.Parse(playerPosition2.text));
            saveData.examplePlayerPosition = exampleVec;

            exampleClass.shieldAmount = int.Parse(playerShield.text);
            saveData.exampleCustomClass = exampleClass;

            // you would just call ' SaveManager.SaveGame(saveData) ' for the sake of not requiring the project to be set up one way to show the asset working... 
            // ...there is an example save manager on this script which runs just like the normal one.
            ExampleSaveManager.SaveGame(saveData);
        }


        /// <summary>
        /// Loads the data and puts it into the display to show it has loaded the entered values
        /// </summary>
        public void LoadGame()
        {
            ExampleSaveData loadData = ExampleSaveManager.LoadGame();

            displayPlayerName.text = loadData.examplePlayerName;
            displayPlayerHealth.text = loadData.examplePlayerHealth.ToString();
            displayPlayerPosition.text = loadData.examplePlayerPosition.Vector3.ToString();
            displayPlayerShield.text = loadData.exampleCustomClass.shieldAmount.ToString();
        }
    }

    /// <summary>
    /// EXAMPLE ONLY - DO NOT EDIT!
    /// </summary>
    [System.Serializable]
    public class ExampleSaveData
    {
        [SerializeField] public string examplePlayerName;
        [SerializeField] public float examplePlayerHealth;
        [SerializeField] public SaveVector3 examplePlayerPosition;
        [SerializeField] public ExampleClass exampleCustomClass;
    }

    /// <summary>
    /// EXAMPLE ONLY - DO NOT EDIT!
    /// </summary>
    public class ExampleSaveManager
    {
        /// <summary>
        /// EXAMPLE ONLY | Static | Saves the game, using the ExampleSaveData class.
        /// </summary>
        /// <param name="_data">The ExampleSaveData to save.</param>
        public static void SaveGame(ExampleSaveData _data)
        {
            string SavePath = Application.persistentDataPath + "/savefile.example";

            // Erased the old save file, done to avoid problems loading as the class changing will cause an error is not done.
            if (File.Exists(SavePath))
            {
                File.Delete(SavePath);
            }

            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream Stream = new FileStream(SavePath, FileMode.OpenOrCreate);

            Formatter.Serialize(Stream, _data);
            Stream.Close();
        }

        /// <summary>
        /// EXAMPLE ONLY | Static | Loads the game and returns an instance of the ExampleSaveData class
        /// </summary>
        /// <returns>An instance of the SaveData class with the loaded values</returns>
        public static ExampleSaveData LoadGame()
        {
            string SavePath = Application.persistentDataPath + "/savefile.example";

            if (File.Exists(SavePath))
            {
                BinaryFormatter Formatter = new BinaryFormatter();
                FileStream Stream = new FileStream(SavePath, FileMode.Open);

                ExampleSaveData _data = Formatter.Deserialize(Stream) as ExampleSaveData;

                Stream.Close();

                return _data;
            }
            else
            {
                Debug.LogError("Save file not found!");
                return null;
            }
        }
    }

    /// <summary>
    /// EXAMPLE ONLY - DO NOT EDIT!
    /// (CLASS) Example class used to show how the class value can be used in the asset
    /// NOTE: The class has to have the "Serializable" attribute to work.
    /// NOTE: This script is not needed for the asset package to function.
    /// </summary>
    [System.Serializable]
    public class ExampleClass
    {
        [SerializeField] public int shieldAmount = 5;
    }
}