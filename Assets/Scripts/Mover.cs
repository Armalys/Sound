using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private float _playerSpeed = 5f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis(Horizontal);
        float z = Input.GetAxis(Vertical);

        Vector3 movement = new Vector3(x, 0, z);
        transform.Translate(movement * _playerSpeed * Time.deltaTime);
    }
}