using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/************************************************************************************
 * 
 *							           Save Manager
 *							  
 *				                   Save Manager Script
 *			
 *			                        Script written by: 
 *			           Jonathan Carter (https://jonathan.carter.games)
 *			        
 *									Version: 1.0.2
 *						   Last Updated: 05/10/2020 (d/m/y)					
 * 
*************************************************************************************/

namespace CarterGames.Assets.SaveManager
{
    /// <summary>
    /// Class (*Static*) | The Save Manager class, used the save and load the game. This script can be called from anywhere in your code and can't be attached to a gameobject.
    /// </summary>
    public static class SaveManager
    {
        /// <summary>
        /// Static | Saves the game, using the SaveData class.
        /// </summary>
        /// <param name="_data">The SaveData to save.</param>
        public static void SaveGame(SaveData _data)
        {
            string SavePath = Application.persistentDataPath + "/savefile.sf";

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
        /// Static | Loads the game and returns an instance of the SaveData class
        /// </summary>
        /// <returns>An instance of the SaveData class with the loaded values</returns>
        public static SaveData LoadGame()
        {
            string SavePath = Application.persistentDataPath + "/savefile.sf";

            if (File.Exists(SavePath))
            {
                BinaryFormatter Formatter = new BinaryFormatter();
                FileStream Stream = new FileStream(SavePath, FileMode.Open);

                SaveData _data = Formatter.Deserialize(Stream) as SaveData;

                Stream.Close();

                return _data;
            }
            else
            {
                Debug.LogError("Save file not found!");
                return null;
            }
        }

        /// <summary>
        /// Static | Resets the save file to be a blank file with no values saved in it.
        /// </summary>
        public static void ResetSaveFile()
        {
            string SavePath = Application.persistentDataPath + "/savefile.sf";

            // Erased the old save file, done to avoid problems loading as the class changing will cause an error is not done.
            if (File.Exists(SavePath))
            {
                File.Delete(SavePath);
            }

            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream Stream = new FileStream(SavePath, FileMode.OpenOrCreate);

            Formatter.Serialize(Stream, new SaveData());
            Stream.Close();
        }
    }
}