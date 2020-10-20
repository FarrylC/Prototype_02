using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject HomingMissilePrefab;
    private int bulletCount = 3;

    public Text text;

    public ShipMotor shipmotor;

    private Rigidbody2D playerShip;
    private BoxCollider2D ship;

    // Update is called once per frame
    void Update()
    {

        playerShip = GetComponent<Rigidbody2D>();

        if (Input.GetButtonDown("SpawnObjectRelative")) // 'o' key
        {
            GetComponent<PositionPrefabRelative>().PositionPrefabAtRelativePosition();
        }

        if (Input.GetButtonDown("GetPlayerToEnemyVector")) // 'v' key
        {
            Debug.Log(GetComponent<VectorToEnemy>().GetVectorToEnemy());
        }

        /*if (Input.GetButtonDown("GetPlayerDistanceEnemy")) // 'd' key
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
        }*/

        if (Input.GetButtonDown("SpawnHomingMissile")) // 'h' key, alt key is Left Click/mouse 0
        {
            SpawnHomingMissile();
        }

        if (Input.GetButtonDown("RotateCamera")) // 'r' key
        {
            GameController.RotateScreenClockwise90Deg();
        }

        if(Input.GetButtonDown("AddBullet")) // right click/Mouse 1
        {
            AddBullet();
        }

        // Look towards mouse position
        Vector3 lookPoint = GameController.GetCamera().ScreenToWorldPoint(Input.mousePosition);
        lookPoint.z = this.transform.position.z;
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.LookRotation(Vector3.forward, lookPoint - this.transform.position), 8f);

        GetComponent<ShipMotor>().HandleMovementInput(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        text.text = "Ammo:" + bulletCount;

    }

    /// <summary>
    /// Creates a homing missile based on the prefab stored in HomingMissilePrefab at the position of the player facing the same direction.
    /// </summary>
    public HomingMissile SpawnHomingMissile()
    {
        //Checks if we have enough bullets to shoot

        if (bulletCount > 0)
        {
            SubtractBullet();
            return Instantiate<GameObject>(HomingMissilePrefab, this.transform.position, this.transform.rotation).GetComponent<HomingMissile>();
        }
            

        return null;
    }

    public void SubtractBullet()
    {
        bulletCount--;
        Debug.Log("bullets:" + bulletCount);

    }
    public void AddBullet()
    {
        bulletCount++;
        Debug.Log("bullets:" + bulletCount);

    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject.CompareTag("Fuel")) 
        {
            other.gameObject.SetActive(false);
            shipmotor.currentFuel += 10;
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            bulletCount++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Fuck");
    }
}
