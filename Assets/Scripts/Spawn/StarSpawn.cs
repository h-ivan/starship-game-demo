using UnityEngine;

namespace Spawn
{
    public class StarSpawn : MonoBehaviour
    {
        private int _arrStarsIndex;
        private float _rndStarsY, _rndStarsX;
        private Vector2 _pos;

        private void Start()
        {
            for (var i = 0; i < 30; i++)
            {
               _rndStarsX = Random.Range(-1 * ScreenSize.ScreenBounds.x, ScreenSize.ScreenBounds.x);
               _rndStarsY = Random.Range(-1.5f, 1.5f);
               _arrStarsIndex = Random.Range(10, 13);
               
               var go = ObjectPooler.SharedInstance.GetPooledObject(_arrStarsIndex);
               go.transform.position = new Vector3(_rndStarsX, _rndStarsY);
               go.SetActive(true); 
            }
            

        }


    }
}
