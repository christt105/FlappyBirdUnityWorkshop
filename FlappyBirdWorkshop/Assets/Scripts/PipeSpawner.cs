using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipesPrefab;

    public Transform start;
    public Transform end;

    public float spawnRate = 1.5f;
    
    private float _timer;

    private void Start()
    {
        _timer = spawnRate;
    }

    private void Update()
    {
        if (GameManager.Instance.state == GameManager.State.Playing)
        {
            _timer += Time.deltaTime;

            if (_timer > spawnRate)
            {
                _timer = 0f;
                Vector2 spawnPosition = new Vector2(start.position.x, Random.Range(start.position.y, end.position.y));
                Instantiate(pipesPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}