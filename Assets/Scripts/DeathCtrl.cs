using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCtrl : MonoBehaviour
{
    //[SerializeField] private GameObject background;
    [SerializeField] private CanvasGroup canvas;

    //private void Start()
    //{
    //    CanvasGroup canvas = background.GetComponent<CanvasGroup>();
    //}

    public void FadeToBlack()
    {
        for (int i = 100; i >= 0; i++)
        {
            canvas.alpha += 0.1f;
        }
    }
}
