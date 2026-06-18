using UnityEngine;

public class Bird : MonoBehaviour
{
    public float force = 1f;
    private Animator _animator;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _rigidbody2D.isKinematic = true;
    }

    private void LateUpdate()
    {
        if (GameManager.Instance.state == GameManager.State.Playing)
        {
            // TODO 1: Fes que l'ocell salti cap amunt quan es premi el botó de salt ("Jump").
            //   (Si t'encalles, mira la GUIA.md)

            float velocityY = _rigidbody2D.velocity.y;
            const float minRotation = -90f;
            const float maxRotation = 30f;
            float rotation = Mathf.Clamp(velocityY * 30f + 60f, minRotation, maxRotation);

            transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        }
        else if (GameManager.Instance.state == GameManager.State.GameOver)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckCollision(collision.collider);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void CheckCollision(Collider2D other)
    {
        // TODO 2: Si toquem un objecte amb l'etiqueta (tag) "Point", suma un punt.
        //   Pista: other.CompareTag("...") i GameManager.Instance.AddPoint();

        // TODO 3: Si toquem un objecte amb l'etiqueta (tag) "Obstacle", l'ocell mor.
        //   Pista: _animator.SetTrigger("Dead"); i GameManager.Instance.GameOver();
    }

    public void StartGame()
    {
        _rigidbody2D.isKinematic = false;
    }
}