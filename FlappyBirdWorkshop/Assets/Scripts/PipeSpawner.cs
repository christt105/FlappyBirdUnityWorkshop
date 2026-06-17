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
            // El temporitzador compta el temps que passa.
            _timer += Time.deltaTime;

            // TODO 6: Quan hagi passat prou temps (spawnRate), crea una nova canonada
            //   en una alçada a l'atzar (entre start i end) i torna a posar el temporitzador a 0.
        }
    }
}