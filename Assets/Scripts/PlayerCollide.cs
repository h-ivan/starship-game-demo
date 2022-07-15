using UnityEngine;

public class PlayerCollide : MonoBehaviour
{

    public GameObject PlayerExplosion;
    public GameObject Firepoint;
    private static readonly int IsCharging = Animator.StringToHash("IsCharging");
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy") 
            && !other.gameObject.CompareTag("Asteroid") 
            && !other.gameObject.CompareTag("AsteroidSmall")
            && !other.gameObject.CompareTag("EnemyBullet")) return;
        
        
        Instantiate(PlayerExplosion, _transform.position, _transform.rotation);
        Firepoint.GetComponent<Animator>().SetBool(IsCharging,false);
        gameObject.SetActive(false);

    }
}
