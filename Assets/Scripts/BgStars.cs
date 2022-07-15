using UnityEngine;

public class BgStars : MonoBehaviour
{
    private float _rndSpeed;
    private Transform _transform;
    private Vector2 _pos;

    private void Start()
    {
        _rndSpeed = Random.Range(-0.3f, -1f);
        _transform = transform;
        if (!(Camera.main is null)) 
           _pos = Camera.main.ViewportToWorldPoint(new Vector3(1.5f, 0));

    }

    private void Update()
    {
        _transform.position += new Vector3(_rndSpeed * Time.deltaTime ,0,0);
    }

    private void OnBecameInvisible() {
        
        _rndSpeed = Random.Range(-0.3f, -1f);
        _transform.localScale = new Vector3(_rndSpeed * 1.2f,_rndSpeed * 1.2f,0);
        _transform.position += new Vector3(_pos.x, 0, 0);
    }
    
}
