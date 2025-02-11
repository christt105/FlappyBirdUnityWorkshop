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
            if (Input.GetButtonDown("Jump"))
            {
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }
            
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
        if (other.CompareTag("Point"))
        {
            GameManager.Instance.AddPoint();
        }

        if (other.CompareTag("Obstacle"))
        {
            _animator.SetTrigger("Dead");
            GameManager.Instance.GameOver();
        }
    }

    public void StartGame()
    {
        _rigidbody2D.isKinematic = false;
    }
}