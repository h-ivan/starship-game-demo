using System;
using System.Collections;
using UnityEngine;

public class PlayerGhost : MonoBehaviour
{
    private const float Delaytime = 0.3f;
    private SpriteRenderer _playerSpriteRenderer;
    private SpriteRenderer _selfSpriteRenderer;

    private void Start()
    {
        _playerSpriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        _selfSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnBecameVisible()
    {
        _selfSpriteRenderer.sprite = _playerSpriteRenderer.sprite;
        StartCoroutine (Delay());
    }
    


    private IEnumerator Delay()
    {
        yield return new WaitForSeconds (Delaytime);
        gameObject.SetActive(false);
    }

}