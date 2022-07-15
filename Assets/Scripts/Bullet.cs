using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 6f;
    private bool _superBullet;
    private Transform _transform;
    private int _explosionIndex;

    private void Start()
    {
        _transform = transform;
        _superBullet = gameObject.CompareTag("BulletBig");
    }

    private void OnBecameVisible()
    {
        GetComponent<Rigidbody2D>().velocity = _transform.right * speed;
    }

    private void OnBecameInvisible() {
        gameObject.SetActive(false);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("EnemyBullet")) return;
        
        if (_superBullet)
        {
            _explosionIndex = 7;
        }
        else
        {
            _explosionIndex = 5;
            gameObject.SetActive(false);
        }

        var go = ObjectPooler.SharedInstance.GetPooledObject(_explosionIndex);
        go.transform.position = _transform.position;
        go.SetActive(true);
    }
    

}
