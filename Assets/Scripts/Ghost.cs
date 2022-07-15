using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float ghostDelay;
    private float _ghostDelaySeconds;
    private Transform _transform;
    public bool makeGhost = false;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _ghostDelaySeconds = ghostDelay;
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if (!makeGhost) return;
        
        if (_ghostDelaySeconds > 0)
        {
            _ghostDelaySeconds -= Time.deltaTime;
        }
        else
        {
            var o = ObjectPooler.SharedInstance.GetPooledObject(14);
            o.transform.position = _transform.position;
            o.transform.rotation = _transform.rotation;
            o.SetActive(true);
            _ghostDelaySeconds = ghostDelay;

        }

    }
}
