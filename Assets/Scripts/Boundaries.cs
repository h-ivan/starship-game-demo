using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 _screenBounds;

    private void Start()
    {
        if (!(Camera.main is null))
            _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 1));
    }

    private void LateUpdate()
    {
        var viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, _screenBounds.x * -1, _screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, _screenBounds.y * -1, _screenBounds.y);
        transform.position = viewPos;

        
    }
}
