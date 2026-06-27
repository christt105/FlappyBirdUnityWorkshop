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
            //   - Modifica la posició de l'objecte (transform.position) sumant-li un vector de moviment.
            //   - Vector de direcció: Vector3.left.
            //   - Multiplica la direcció per la velocitat ('speed') i pel temps transcorregut ('Time.deltaTime').
            // <SOL>
            transform.position += Vector3.left * (speed * Time.deltaTime);
            // </SOL>

            // TODO 5: Quan la canonada surti per l'esquerra (x < destroyPoint), esborra-la.
            //   - Comprova amb un 'if' si transform.position.x és menor que la variable destroyPoint.
            //   - Dins del bloc, crida la funció Destroy(gameObject) per eliminar l'objecte.
            // <SOL>
            if(transform.position.x < destroyPoint)
            {
                Destroy(gameObject);
            }
            // </SOL>
        }
    }
}