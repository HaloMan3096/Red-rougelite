using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGems : MonoBehaviour
{
    TMP_Text text;
    [SerializeField] public Player Player;

    private void Start()
    {
        text = this.GetComponent<TMP_Text>();
    }

    private void Update()
    {
        text.text = $"Gems:  {Player.numOfGems}";
    }
}
