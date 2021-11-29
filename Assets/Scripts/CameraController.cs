using UnityEngine;

public class CameraController : MonoBehaviour
{
    private AudioSource _cameraAudioSource;
    private PlayerController _playerControllerScript;

    // Start is called before the first frame update
    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        _cameraAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        // If game over, then stop the main camera audio
        if (_playerControllerScript.isGameOver)
        {
            _cameraAudioSource.Stop();
        }
    }
}
