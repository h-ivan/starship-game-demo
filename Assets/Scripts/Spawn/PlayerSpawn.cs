using System.Collections;
using UnityEngine;

namespace Spawn
{
    public class PlayerSpawn : MonoBehaviour
    {
        public GameObject player;
        private IEnumerator _enumerator;
        private BoxCollider2D _boxCollider2D;
        private SpriteRenderer _spriteRenderer;
        private Color _spriteAlpha;
        private Color _spriteNormal;

        private void Start()
        {
            _spriteRenderer = player.GetComponent<SpriteRenderer>();
            _boxCollider2D = player.GetComponent<BoxCollider2D>();
            _spriteAlpha = new Color(255f,255f,255f,0.3f);
            _spriteNormal = new Color(255f,255f,255f,1f);
        }

        private void Update()
        {
            if (player.gameObject.activeSelf || !Input.GetKey(KeyCode.Return)) return;
        
            player.transform.position = new Vector3(0, 0, 0);
            player.SetActive(true);
            _boxCollider2D.enabled = false;

            StartCoroutine(WaiterPlayerReady());

        }

        private IEnumerator WaiterPlayerReady()
        {
            for (var n = 0; n < 10; n++)
            {
                _spriteRenderer.color = _spriteAlpha;
                yield return new WaitForSeconds(0.1f);
                _spriteRenderer.color = _spriteNormal;
                yield return new WaitForSeconds(0.1f);
            }

            _boxCollider2D.enabled = true;


        }


    }
}
