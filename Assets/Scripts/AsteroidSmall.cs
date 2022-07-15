using UnityEngine;

public class AsteroidSmall : MonoBehaviour
{
    private void OnBecameInvisible() {
        gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy") && !other.gameObject.CompareTag("Bullet") 
                                                  && !other.gameObject.CompareTag("BulletBig")) return;

        var o = other.gameObject.transform;
        var go = ObjectPooler.SharedInstance.GetPooledObject(3);
        go.transform.position =  o.position;

        go.SetActive(true);
        gameObject.SetActive(false);

    }
    
 
}
