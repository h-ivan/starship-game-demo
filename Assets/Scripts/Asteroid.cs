using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    private float _rndSpeed;
    private float _rndAngle;
    private float _rndAngleUpAsteroidSmall;
    private float _rndAngleDownAsteroidSmall;
    private float _rndForceAsteroidSmall;
    private float _rndAsteroidSize;
    private float _rndPositionY;
    private Vector3 _transformPosition;
    private Vector2 _pos;
    private Transform _transform;
    

    private void Awake()
    {
        _transform = transform;
        

    }

    private void OnEnable()
    {
        _rndSpeed = Random.Range(-1f, -3f); 
        _rndAngle = Random.Range(-0.2f, 0.2f);
        _rndAsteroidSize = Random.Range(-0.4f, -1.5f);
        _rndPositionY = Random.Range(-1.3f, 1.3f);
        _transform.localScale = new Vector3(_rndAsteroidSize,_rndAsteroidSize,0);
        _transform.position = new Vector3(ScreenSize.ScreenBounds.x, _rndPositionY, 0);
    }

    private void Update()
    {
        _transform.position += new Vector3(_rndSpeed * Time.deltaTime,_rndAngle * Time.deltaTime,0);
    }

    
    private void OnBecameInvisible() {
        
        _transform.position = new Vector3(ScreenSize.ScreenBounds.x, _rndPositionY, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (!other.gameObject.CompareTag("Bullet") 
            && !other.gameObject.CompareTag("BulletBig")) return;
            
        
            _rndForceAsteroidSmall = Random.Range(10f, 60f);
            _rndAngleUpAsteroidSmall = Random.Range(0.5f, 1.5f);
            _rndAngleDownAsteroidSmall = Random.Range(0.5f, 1.5f);

            var position = _transform.position;
            
            var xp = ObjectPooler.SharedInstance.GetPooledObject(9);
            xp.transform.position = position;
            xp.SetActive(true);

            var go = ObjectPooler.SharedInstance.GetPooledObject(4);
            var go2 = ObjectPooler.SharedInstance.GetPooledObject(4);

            go.transform.position = position;
            go.SetActive(true);
            go.GetComponent<Rigidbody2D>()
                .AddForce(new Vector2(_rndForceAsteroidSmall*_rndAngleUpAsteroidSmall, _rndForceAsteroidSmall));
            
            go2.transform.position = position;
            go2.SetActive(true);
            go2.GetComponent<Rigidbody2D>()
                .AddForce(new Vector2(_rndForceAsteroidSmall*_rndAngleDownAsteroidSmall, _rndForceAsteroidSmall*-1));

            gameObject.SetActive(false);
            Points.SetScore(10);
        


    }
}
