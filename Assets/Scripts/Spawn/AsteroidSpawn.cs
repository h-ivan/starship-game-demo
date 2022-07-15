using System.Collections;
using UnityEngine;

namespace Spawn
{
    public class AsteroidSpawn : MonoBehaviour
    {
        private float _rndWaitAsteroid;
        private Vector2 _pos;

        private void Start()
        {
            StartCoroutine(WaiterAsteroids(100));
        
        }

        private IEnumerator WaiterAsteroids(int items)
        {
            for (var i = 0; i < items; i++)
            {
                _rndWaitAsteroid = Random.Range(2f, 3.5f);
                var go = ObjectPooler.SharedInstance.GetPooledObject(8);
                go.transform.position = ScreenSize.ScreenBounds;
                go.SetActive(true);
                yield return new WaitForSeconds(_rndWaitAsteroid);
            }
       
        }
    

    

    }
}
