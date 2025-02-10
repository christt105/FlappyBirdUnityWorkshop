using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 5f;
    public float destroyPoint = -10f;

    private void Update()
    {
        if (GameManager.Instance.state == GameManager.State.Playing)
        {
            transform.position += Vector3.left * (speed * Time.deltaTime);
            if (transform.position.x < destroyPoint)
            {
                Destroy(gameObject);
            }
        }
    }
}