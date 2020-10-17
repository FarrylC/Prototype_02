using UnityEngine;
using System.Collections;

public class VisionCone : MonoBehaviour
{

    public float AngleSweepInDegrees = 60;
    public float ViewDistance = 3;

    /// <summary>
    /// Calculates whether the player is inside the vision cone of an enemy as defined by the AngleSweepIndegrees
    /// and ViewDistance varilables. Do not use any magnitude or Distance methods.  You may use any of the previous
    /// methods you have written.
    /// </summary>
    /// <see cref="GameController"/>
    /// <returns>Whether the player is within the enemy's vision cone.</returns>
    public bool IsPlayerInVisionCone()
    {
        Vector2 vectorToPlayer = GameController.GetPlayerObject().transform.position - transform.position;
        float magnitude = Mathf.Sqrt(Mathf.Pow(vectorToPlayer.x, 2) + Mathf.Pow(vectorToPlayer.y, 2));
        float theta = Mathf.Acos(Vector2.Dot(transform.up, vectorToPlayer) / magnitude);

        if (Mathf.Rad2Deg * theta > AngleSweepInDegrees / 2)
            return false;

        if (magnitude > ViewDistance)
            return false;

        return true;
    }
    
}
