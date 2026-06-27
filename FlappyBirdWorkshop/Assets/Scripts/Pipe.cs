using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 5f;
    public float destroyPoint = -10f;

    private void Update()
    {
        if (GameManager.Instance.state == GameManager.State.Playing)
        {
            // TODO 4: Mou la canonada cap a l'esquerra una mica cada fotograma.
            // <SOL>
            transform.position += Vector3.left * (speed * Time.deltaTime);
            // </SOL>

            // TODO 5: Quan la canonada surti per l'esquerra (x < destroyPoint), esborra-la.
            // <SOL>
            if(transform.position.x < destroyPoint)
            {
                Destroy(gameObject);
            }
            // </SOL>
        }
    }
}