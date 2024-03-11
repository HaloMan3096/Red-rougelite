using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCtrl : MonoBehaviour
{
    [SerializeField] private GameObject background;

    public void FadeToBlack()
    {
        background.SetActive(true);
    }
}
