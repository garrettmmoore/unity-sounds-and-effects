using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 15;

    // Hold a reference to player controller script
    private PlayerController _playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        // How are we going to know what is happening in our player controller script?
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerControllerScript.isGameOver == false)
        {
            // Move this by time b/c we don't want it to move every frame
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}