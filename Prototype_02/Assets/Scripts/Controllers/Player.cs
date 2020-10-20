using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject HomingMissilePrefab;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("SpawnObjectRelative")) // 'o' key
        {
            GetComponent<PositionPrefabRelative>().PositionPrefabAtRelativePosition();
        }

        if (Input.GetButtonDown("GetPlayerToEnemyVector")) // 'v' key
        {
            Debug.Log(GetComponent<VectorToEnemy>().GetVectorToEnemy());
        }

        if (Input.GetButtonDown("GetPlayerDistanceEnemy")) // 'd' key
        {
            Debug.Log(GetComponent<VectorToEnemy>().GetDistanceToEnemy());
        }

        if (Input.GetButtonDown("SpawnBombLine")) // 'b' key
        {
            GetComponent<BombLine>().SpawnBombs();
        }

        if (Input.GetButtonDown("PlacePowerUps")) // 'p' key
        {
            GetComponent<PowerUps>().SpawnPowerUps();
        }

        if (Input.GetButtonDown("PlaceBombSpiral")) // 's' key
        {
            GetComponent<BombSpiral>().SpawnBombSpiral();
        }

        if (Input.GetButtonDown("SpawnHomingMissile")) // 'h' key, alt key is Left Click/mouse 0
        {
            SpawnHomingMissile();
        }

        if (Input.GetButtonDown("RotateCamera")) // 'r' key
        {
            GameController.RotateScreenClockwise90Deg();
        }

        // Look towards mouse position
        Vector3 lookPoint = GameController.GetCamera().ScreenToWorldPoint(Input.mousePosition);
        lookPoint.z = this.transform.position.z;
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.LookRotation(Vector3.forward, lookPoint - this.transform.position), 8f);

        GetComponent<ShipMotor>().HandleMovementInput(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    /// <summary>
    /// Creates a homing missile based on the prefab stored in HomingMissilePrefab at the position of the player facing the same direction.
    /// </summary>
    public HomingMissile SpawnHomingMissile()
    {
        return Instantiate<GameObject>(HomingMissilePrefab, this.transform.position, this.transform.rotation).GetComponent<HomingMissile>();
    }
}
