using System;
using UnityEngine;
using TMPro;


public class Points : MonoBehaviour
{

    private static TextMeshProUGUI _textMesh;

    private void Start()
    {
        _textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        _textMesh.text = 0.ToString();
    }

    public static void SetScore(int s)
    {
        var score = Convert.ToInt32(_textMesh.text);
        s += score;
        _textMesh.text = s.ToString();
    } 

}
