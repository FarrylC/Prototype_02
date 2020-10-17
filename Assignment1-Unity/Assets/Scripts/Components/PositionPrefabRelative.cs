using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPrefabRelative : MonoBehaviour
{
    public GameObject Prefab;
    public Vector3 SpawnOffset;

    /// <summary>
    /// Instantiates the game object stored in the variable Prefab at SpawnOffset distance away from the player. The object is a 
    /// root object.
    /// </summary>
    /// <returns>the newly spawned object int he right position.</returns>
    public GameObject PositionPrefabAtRelativePosition()
    {
        return Instantiate<GameObject>(Prefab, SpawnOffset + GameController.GetPlayerObject().transform.position, Quaternion.identity);
    }
    
}
