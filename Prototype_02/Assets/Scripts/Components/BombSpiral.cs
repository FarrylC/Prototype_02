using UnityEngine;
using System.Collections;

public class BombSpiral : MonoBehaviour
{
    public GameObject BombPrefab;
    [Range(5, 25)]
    public float SpiralAngleInDegrees = 10;
    public int BombCount = 10;
    public float StartRadius = 1;
    public float EndRadius = 3;

    /// <summary>
    /// Spawns spirals of BombPrefab game objects around the player. Create BombCount number of bombs 
    /// around the player, with each bomb being spaced SpiralAngleInDegrees apart from the next. The spiral 
    /// starts at StartRadius away from the player and ends at EndRadius away from the player.
    /// </summary>
    /// <returns>An array of the spawned bombs</returns>
    public GameObject[] SpawnBombSpiral()
    {
        GameObject[] bombArray = new GameObject[BombCount];

        for(int i = 0; i < BombCount; i++)
        {
            Vector2 playerPos = GameController.GetPlayerObject().transform.position;
            float radius = StartRadius + i * (EndRadius - StartRadius) / (BombCount - 1);
            float theta = -Mathf.Deg2Rad * (SpiralAngleInDegrees) * i + Mathf.PI/2;
            Vector2 bombPos = new Vector2(playerPos.x + radius * Mathf.Sin(theta), playerPos.y + radius * Mathf.Cos(theta));

            bombArray[i] = Instantiate<GameObject>(BombPrefab, bombPos, Quaternion.identity);
            
        }

        return bombArray;
    }

}
