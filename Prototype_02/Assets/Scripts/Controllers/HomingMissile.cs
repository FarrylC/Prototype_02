using UnityEngine;
using System.Collections;

public class HomingMissile : MonoBehaviour
{
    public float bulletCount;
    public float speed = 4f;
    public float destroyTime = 5f;
    Rigidbody2D rb;


    /*    public float ForwardSpeed = 1;
        public float RotateSpeedInDeg = 45;*/


    // In Update, you should rotate and move the missile to rotate it towards the player.  It should move forward with ForwardSpeed and rotate at RotateSpeedInDeg.
    // Do not use the RotateTowards or LookAt methods.

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.gravityScale = 0;
        rb.AddForce(transform.up * speed, ForceMode2D.Force);


        #region HomingMissileOriginal
        /*  Vector2 vectorToEnemy = GameController.GetEnemyObject().transform.position - transform.position;

          float magnitude = Mathf.Sqrt(Mathf.Pow(vectorToEnemy.x, 2) + Mathf.Pow(vectorToEnemy.y, 2));
          if (magnitude == 0)
              magnitude += 0.001f;

          float theta = Mathf.Rad2Deg * Mathf.Acos(Vector2.Dot(transform.up, vectorToEnemy) / magnitude);

          if (Mathf.Rad2Deg * Mathf.Acos(Vector2.Dot(transform.right, vectorToEnemy) / magnitude) < Mathf.Rad2Deg * Mathf.Acos(Vector2.Dot(-transform.right, vectorToEnemy) / magnitude))
              theta *= -1;

          if (theta > RotateSpeedInDeg)
              theta = RotateSpeedInDeg;
          else if(theta < -RotateSpeedInDeg)
              theta = -RotateSpeedInDeg;

          transform.Rotate(0, 0, theta * Time.deltaTime, Space.Self);
          transform.Translate(transform.up * ForwardSpeed * Time.deltaTime, Space.World);
      }*/
        #endregion


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.GetComponent<Enemy>() == true)
        {
            //Destroys Enemy Object
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
