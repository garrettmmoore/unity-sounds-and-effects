using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private const float LeftBound = -10;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // Destroy obstacles when they are off the screen
        if (transform.position.x < LeftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

}
