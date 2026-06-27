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

            // TODO 6: Quan el temporitzador (_timer) superi el temps establert (spawnRate), crea una nova canonada i reinicia el temporitzador.
            //   - Comprova si _timer és major que spawnRate amb un: if (condició) { ... }
            //   - Dins del bloc:
            //     1. Torna a posar el temporitzador (_timer) a 0.
            //     2. Crea una posició (Vector2) amb la X del punt 'start' i una alçada Y aleatòria entre 'start.position.y' i 'end.position.y' (fent servir Random.Range).
            //     3. Instancia el prefab de les canonades amb: Instantiate(pipesPrefab, posició_creada, Quaternion.identity);
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