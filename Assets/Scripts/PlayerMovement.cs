using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public float speed = 0.1f;

    void Update()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDir, 0.0f, zDir);

        transform.position += moveDirection * speed;

    }
}