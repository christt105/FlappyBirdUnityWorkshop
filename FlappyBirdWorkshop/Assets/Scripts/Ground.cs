using UnityEngine;

public class Ground : MonoBehaviour
{
    private const float Offset = -3.36f / 14f; // Width of sprite in meters / number of tiles
    public float speed = 2f;

    private float _initialPosition;

    private void Start()
    {
        _initialPosition = transform.position.x;
    }

    private void Update()
    {
        if (GameManager.Instance.state == GameManager.State.Playing)
        {
            transform.position += Vector3.left * (speed * Time.deltaTime);
        }

        float offset = transform.position.x - Offset; 
        if (offset < 0f)
        {
            Vector3 vector3 = transform.position;
            vector3.x = _initialPosition - offset;
            transform.position = vector3;
        }
    }
}