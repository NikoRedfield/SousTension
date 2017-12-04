using UnityEngine;

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class CameraScroll : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    /// <summary>
    /// Scrolling speed
    /// </summary>
    public Vector2 speed = new Vector2(2, 2);

    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    /// <summary>
    /// Movement should be applied to camera
    /// </summary>
    public bool isLinkedToCamera = false;

    void Start()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }

    void Update()
    {
        // Movement
        Vector3 movement = new Vector3(speed.x * direction.x, 0 , 0);    //Move forward at the given speed

        movement *= Time.deltaTime;
        transform.Translate(movement);
        transform.position= new Vector3(transform.position.x, player.position.y + offset.y, transform.position.z); // Link the camera to the y position of the player

        // Move the camera
        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }
    }
}