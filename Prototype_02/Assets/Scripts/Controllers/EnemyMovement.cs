using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float distance;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        // Start movement cycle
        StartCoroutine(ChangeDirection());
    }

    // Update is called once per frame
    void Update()
    {
        // Move forward
        transform.Translate(gameObject.transform.up * speed * Time.deltaTime, Space.World);
    }

    // Reverse travel direction
    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(distance / speed);

        gameObject.transform.up *= -1;
        StartCoroutine(ChangeDirection());
    }
}
