using UnityEngine;
using System.Collections;

public class BombLine : MonoBehaviour
{

    public GameObject BombPrefab;
    public int BombCount;
    public float BombSpacing;

    /// <summary>
    /// Spawn a line of instantiated BombPrefabs behind the player ship. There should be BombCount bombs placed with BombSpacing amount of space between them.
    /// </summary>
    /// <returns>An array containing all the bomb objects</returns>
    public GameObject[] SpawnBombs()
    {
        Transform playerTransform = GameController.GetPlayerObject().transform;
        GameObject[] bombArray = new GameObject[BombCount];

        for(int i = 0; i < BombCount; i++)
            bombArray[i] = Instantiate<GameObject>(BombPrefab, playerTransform.position - playerTransform.up * BombSpacing * (i + 1), Quaternion.identity);

        return bombArray;
    }
    
}
