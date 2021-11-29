using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // we have to use a GameObject b/c it's a prefab
    public GameObject obstaclePrefab;

    private readonly Vector3 _spawnPos = new Vector3(25, 0, 0);
    private const float StartDelay = 2;
    private const float RepeatRate = 2;
    private PlayerController _playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnObstacle), StartDelay, RepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnObstacle()
    {
        // Spawn obstacles if game is not over
        if (_playerControllerScript.isGameOver == false)
        {
            // Create clones or copies of prefab
            Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}