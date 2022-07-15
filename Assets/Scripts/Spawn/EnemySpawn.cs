using System.Collections;
using UnityEngine;

namespace Spawn
{
    public class EnemySpawn : MonoBehaviour
    {
        private float _rndWaitEnemy;
        private Vector3 _pos;

        private void Start()
        {
            StartCoroutine(WaiterEnemy());
        }

        private IEnumerator WaiterEnemy()
        {
       
            for (var i = 0; i < 200; i++)
            {
                _rndWaitEnemy = Random.Range(0.2f, 2f);
                var o = ObjectPooler.SharedInstance.GetPooledObject(6);
                o.transform.position = ScreenSize.ScreenBounds;
                o.SetActive(true);
                yield return new WaitForSeconds(_rndWaitEnemy);
            }
        }

    }
}
