using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);
        transform.Translate(movement * playerSpeed * Time.deltaTime);
    }
}