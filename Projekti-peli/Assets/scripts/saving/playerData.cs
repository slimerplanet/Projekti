using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public int health;
    public Vector3 position;
    public Quaternion rotation;
}

[System.Serializable]
public class EnemyData
{
    public int health;

    public Vector3 position;
    public Quaternion rotation;
}
