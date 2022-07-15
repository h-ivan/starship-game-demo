using UnityEngine;

public class BgFar : MonoBehaviour
{

    private float _shift;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _shift = -4.8f;
    }

    private void Update()
    {
        if (_transform.position.x <= _shift)
        {
            _transform.position = new Vector3(0,0,0);
        }
        _transform.position += new Vector3(-1.01f * Time.deltaTime / 4,0,0);
    }
}
