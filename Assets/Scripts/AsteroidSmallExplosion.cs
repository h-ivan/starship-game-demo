using System.Collections;
using UnityEngine;

public class AsteroidSmallExplosion : MonoBehaviour
{
    private const float Delaytime = 0.3f;
    private void OnBecameVisible()
    {
        StartCoroutine (Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds (Delaytime);
        gameObject.SetActive(false);
    }
}