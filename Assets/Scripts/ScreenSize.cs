
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    public static Vector3 ScreenBounds;

    private void Start()
    {
        if (!(Camera.main is null)) 
            ScreenBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
    }

}
