using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Transform _transform;
    private GameObject _p;

    private float _speed;
    private float _rnd;
    private float _dir;
    private bool _visible;
    private float _rndPositionY;

    
    private void Awake()
    { 
        _transform = transform;
        _p = GameObject.FindGameObjectWithTag("Player"); 
        _speed = -1.5f;

    }
    
    private void Update()
    {
        _transform.position += new Vector3(_speed * Time.deltaTime, Mathf.Sin(Time.time)/10 * _rnd * _dir, 1f);
    }

    private void OnEnable()
    {
        _rndPositionY = Random.Range(-1.3f, 1.3f);
        _rnd = Random.Range(0.1f, 0.15f); 
        _dir = Random.Range(-1.0f, 1f);
        _visible = true;
        _transform.position = new Vector3(ScreenSize.ScreenBounds.x, _rndPositionY, 0);

    }

    private void OnBecameVisible()
    {
        StartCoroutine(Shoot());
    }

    private void OnBecameInvisible() {
        gameObject.SetActive(false); 
        _visible = false;

    }


    private IEnumerator Shoot()
    {
        if (!_visible) yield break;
        
        for (var i = 0; i < 2; i++)
        {
            if (!_p.activeSelf) continue;
                        
            var o = ObjectPooler.SharedInstance.GetPooledObject(13);
            o.transform.position = _transform.position;
            o.SetActive(true);
            yield return new WaitForSeconds(2);
            
        }

    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Bullet") 
            && !other.gameObject.CompareTag("BulletBig")
            && !other.gameObject.CompareTag("AsteroidSmall")) return;

        var go = ObjectPooler.SharedInstance.GetPooledObject(2);
        go.transform.position = _transform.position;
        go.SetActive(true);
        
        
        gameObject.SetActive(false);
        Points.SetScore(50);
    }
}
