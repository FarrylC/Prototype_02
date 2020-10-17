using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour
{
    public GameObject PowerUpPrefab;
    public int PowerUpCount = 3;
    public float PowerUpRadius = 1;

    /// <summary>
    /// Spawn a circle of PowerUpCount power up prefabs stored in PowerUpPrefab, evenly spaced, around the player with a radius of PowerUpRadius
    /// </summary>
    /// <returns>An array of the spawned power ups, in counter clockwise order.</returns>
    public GameObject[] SpawnPowerUps()
    {
        GameObject[] powerUpArray = new GameObject[PowerUpCount];

        for(int i = 0; i < PowerUpCount; i++)
        {
            Vector2 playerPos = GameController.GetPlayerObject().transform.position;
            float theta = -i * (2 * Mathf.PI) / PowerUpCount + (Mathf.PI / 2);
            Vector2 powerUpPos = new Vector2(playerPos.x + PowerUpRadius * Mathf.Sin(theta), playerPos.y + PowerUpRadius * Mathf.Cos(theta));

            powerUpArray[i] = Instantiate<GameObject>(PowerUpPrefab, powerUpPos, Quaternion.identity);
            
        }
        
        return powerUpArray;
    }
}
