using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugcontroller : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Camera cam;
    public FirstPersonAIO playerController;
    
    
    bool showConsole;
    bool showhelp;
    string input;

    //commands
    public static DebugCommand KILL_ALL;
    public static DebugCommand<int> SET_HEALTH;
    public static DebugCommand HELP;
    public static DebugCommand SPAWN_ZOMBIE;
    public static DebugCommand<int> SET_SPEED;
   

    public List<object> commandList;

    private void Awake()
    {
        KILL_ALL = new DebugCommand("killall", "removes all enemies from scene", "killall", () =>
        {         
            var en = FindObjectsOfType<enemy>();
            for (int i = 0; i < en.Length; i++)
            {
                en[i].TakeDamage(100000);
            }
        });

        SET_HEALTH = new DebugCommand<int>("sethealth", "sets amount of health", "sethealth <health>", (x) =>
        {
            FindObjectOfType<PlayerHealth>().Health = x;
        });

        HELP = new DebugCommand("help", "shows list Of Commands", "help", () =>
        {
            showhelp = true;
        });

        SPAWN_ZOMBIE = new DebugCommand("spawn_zombie", "spawns a zombie", "spawn_zombie", () =>
        {
            Vector3 offset = new Vector3(10, 0, 0);
            Instantiate(zombiePrefab, cam.transform.position + offset, Quaternion.identity);
        });

        SET_SPEED = new DebugCommand<int>("setspeed", "sets the speed of the player", "setspeed <speed>", (x) =>
        {
            playerController.walkSpeed = x;
            playerController.sprintSpeed = x * 2;
        });


        commandList = new List<object>
        {
            KILL_ALL,
            SET_HEALTH,
            HELP,
            SPAWN_ZOMBIE,
            SET_SPEED,
        };


    }

    #region technical

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (showConsole)
            {
                Debug.Log("enterPressed");
                HandleInput();
                input = "";
            }
        }

        if (Input.GetKeyDown(KeyCode.F8))
        {
            if (showConsole)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;
            showConsole = !showConsole;
            
        }

    }

    Vector2 scroll;

    private void OnGUI()
    {
        if (!showConsole)
            return;
        
        float y = 0f;
        if(showhelp)
        {
            GUI.Box(new Rect(0, y, Screen.width, 100), "");
            Rect viewport = new Rect(0, 0, Screen.width - 30, 20 * commandList.Count);

            scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 90), scroll, viewport);
            for (int i = 0; i < commandList.Count; i++)
            {
                DebugCommandBase command = commandList[i] as DebugCommandBase;

                string label = $"{command.commandformat} - {command.commandDescription}";

                Rect labelRect = new Rect(5, 20 * i, viewport.width - 100, 20);

                GUI.Label(labelRect, label);
            }

            GUI.EndScrollView();
            
            
            y += 100;
        }

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }
    

    void HandleInput()
    {
        string[] properties = input.Split(' ');

        for (int i = 0; i < commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if(input.Contains(commandBase.commandId))
            {
               if(commandList[i] as DebugCommand != null)
               {
                    (commandList[i] as DebugCommand).Invoke();
               }                              
               else if(commandList[i] as DebugCommand<int> != null)
               {
                    (commandList[i] as DebugCommand<int>).Invoke(int.Parse(properties[1]));
               }
            }
        }
    }
    #endregion
}
