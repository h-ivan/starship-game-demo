using UnityEngine;


public class EnemyBullet1 : MonoBehaviour
{
    private Transform _playerTransform;
    private Transform _selfTransform;
    private Vector3 _direction;
    
    private float _rndSpeed;
    private float _rndAngle;

    private void Awake()
    {
        _playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _selfTransform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        _rndSpeed = Random.Range(-2.5f, -3.5f);
        _rndAngle = _playerTransform.position.y;
    }

    private void Update()
    {
        _selfTransform.position += new Vector3(_rndSpeed * Time.deltaTime,_rndAngle * Time.deltaTime,0);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}