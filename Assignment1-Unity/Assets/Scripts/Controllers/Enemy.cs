using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    
    private void Update()
    {
        if ( Input.GetButtonDown( "CheckVisionCone" ) ) // 'c' key
        {
            Debug.Log( GetComponent<VisionCone>().IsPlayerInVisionCone() );
        }

        if ( Input.GetButtonDown( "MoveEnemy" ) ) // 'm' key
        {
            GameController.MoveEnemy();
        }
    }

}
