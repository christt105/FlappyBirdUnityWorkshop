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
            //   - Comprova si es prem el botó amb un condicional: if (condició) { ... }
            //   - Condició a comprovar: Input.GetButtonDown("Jump") per detectar si es prem el botó.
            //   - Dins del bloc, atura la caiguda (_rigidbody2D.velocity = Vector2.zero) i aplica
            //     una empenta vertical: _rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            // <SOL>
            if (Input.GetButtonDown("Jump"))
            {
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }
            // </SOL>

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
        //   - Comprova amb un 'if' si l'objecte que toquem ('other') té el tag de punts: other.CompareTag("Point").
        //   - Si es compleix, crida el mètode de sumar punt del GameManager: GameManager.Instance.AddPoint();
        // <SOL>
        if (other.CompareTag("Point"))
        {
            GameManager.Instance.AddPoint();
        }
        // </SOL>

        // TODO 3: Si toquem un objecte amb l'etiqueta (tag) "Obstacle", l'ocell mor.
        //   - Comprova amb un 'if' si el tag de l'objecte és un obstacle: other.CompareTag("Obstacle").
        //   - Si és així, activa el trigger de mort de l'animador (_animator.SetTrigger("Dead"))
        //     i crida la funció de GameOver del GameManager: GameManager.Instance.GameOver();
        // <SOL>
        if (other.CompareTag("Obstacle"))
        {
            _animator.SetTrigger("Dead");
            GameManager.Instance.GameOver();
        }
        // </SOL>
    }

    public void StartGame()
    {
        _rigidbody2D.isKinematic = false;
    }
}