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
            //   Pista: 
            //      _timer te el numero de segons 
            //      quan el _timer sigui mes gran que el spawnRate
            //      posa el _timer a 0
            //      Instantiate(pipesPrefab, position, Quaternion.identity);
            // <SOL>
            if (_timer > spawnRate) {
                _timer = 0f;
                Vector2 pos = new Vector2(start.position.x, Random.Range(start.position.y, end.position.y));
                Instantiate(pipesPrefab, pos, Quaternion.identity);
            }
            // </SOL>
        }
    }
}