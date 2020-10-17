using UnityEngine;

public class ShipMotor : MonoBehaviour
{
    public float AccelerationTime = 1;
    public float DecelerationTime = 1;
    public float MaxSpeed = 1;
    float xSpeed = 0, ySpeed = 0;
    int xDir = 1, yDir = 1;

    /// <summary>
    /// Move the ship using it's transform only based on the current input vector. Do not use rigid bodies.
    /// </summary>
    /// <param name="input">The input from the player. The possible range of values for x and y are from -1 to 1.</param>
    public void HandleMovementInput( Vector2 input )
    {
        // Update input values based on camera rotation
        float camAngle;
        GameController.GetCamera().transform.rotation.ToAngleAxis(out camAngle, out _);
        camAngle = Mathf.RoundToInt(camAngle) * Mathf.Deg2Rad;

        float temp = input.x;
        input.x = input.x * Mathf.Cos(camAngle) - input.y * Mathf.Sin(camAngle);
        input.y = input.y * Mathf.Cos(camAngle) + temp * Mathf.Sin(camAngle);

        // Update horizontal speed
        if (input.x < 0.001 && input.x > -0.001)
        {
            xSpeed -= (MaxSpeed / DecelerationTime) * Time.deltaTime;
        }
        else
        {
            xSpeed += (MaxSpeed / AccelerationTime) * Time.deltaTime;
            xDir = (int)(input.x / Mathf.Abs(input.x));
        }

        if (xSpeed > MaxSpeed)
            xSpeed = MaxSpeed;
        else if (xSpeed <= 0)
            xSpeed = 0;

        // Update vertical speed
        if (input.y < 0.001 && input.y > -0.001)
        {
            ySpeed -= (MaxSpeed / DecelerationTime) * Time.deltaTime;
        }
        else
        {
            ySpeed += (MaxSpeed / AccelerationTime) * Time.deltaTime;
            yDir = (int)(input.y / Mathf.Abs(input.y));
        }

        if (ySpeed > MaxSpeed)
            ySpeed = MaxSpeed;
        else if (ySpeed <= 0)
            ySpeed = 0;

        // Move player
        transform.Translate(xSpeed * Time.deltaTime * xDir, ySpeed * Time.deltaTime * yDir, 0, Space.World);
    }
    
}
