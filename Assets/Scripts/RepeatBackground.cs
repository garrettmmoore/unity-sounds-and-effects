using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Vector3 b/c we want the position our object starts at
    private Vector3 _startPos;

    private float _repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        // Divide by 2 to get half the width of the background where it repeats
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _startPos.x - _repeatWidth)
        {
            transform.position = _startPos;
        }
    }
}
