using UnityEngine;
using System.Collections;

public class VectorToEnemy : MonoBehaviour
{

    /// <summary>
    /// Calculated vector from the player to enemy found by GameManager.GetEnemyObject
    /// </summary>
    /// <see cref="GameController.GetEnemyObject"/>
    /// <returns>The vector from the player to the enemy.</returns>
    public Vector3 GetVectorToEnemy()
    {
        if (GameController.GetEnemyObject() != null)
        {
            return GameController.GetEnemyObject().transform.position - GameController.GetPlayerObject().transform.position;
        }
        else
            return Vector3.zero;
    }

    /// <summary>
    /// Calculates the distance from the player to the enemy returned by GameManager.GetEnemyObject without using calls to magnitude.
    /// </summary>
    /// <see cref="GameController.GetEnemyObject"/>
    /// <returns>The scalar distance between the player and the enemy</returns>
    public float GetDistanceToEnemy()
    {
        Vector3 displacement = GetVectorToEnemy();
        return Mathf.Sqrt(Mathf.Pow(displacement.x, 2) + Mathf.Pow(displacement.y, 2));
    }
    
}
