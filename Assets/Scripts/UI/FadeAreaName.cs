using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeAreaName : MonoBehaviour
{
    private Image image;
    [SerializeField] private TextMeshProUGUI text;
    public FadeState FadeState;
    private float timer = 0;
    private float betweenFade = 0.01f;

    private float fadeOutTimer = 0;
    private float waitToFadeOut = 0.1f;
    [SerializeField] private bool isFading = true;

    private void Start()
    {
        image = GetComponent<Image>();
        FadeState = FadeState.fadingIn;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        isFading = true;
    }

    private void Update()
    {
        switch (FadeState)
        {
            case FadeState.nothing:
                fadeOutTimer += Time.deltaTime;

                if (fadeOutTimer >= waitToFadeOut && isFading)
                {
                    FadeState = FadeState.fadingIn;
                    isFading = false;
                }
            break;

            case FadeState.fadingOut:
                timer += Time.deltaTime;
                if (timer >= betweenFade)
                {
                    if (image.color.a >= 1)
                    {
                        FadeState = FadeState.nothing;
                    }
                    timer = 0;
                    Fade(false);
                }
                break;

            case FadeState.fadingIn:
                timer += Time.deltaTime;
                if (timer >= betweenFade)
                {
                    if (image.color.a <= 0)
                        FadeState = FadeState.nothing;

                    timer = 0;
                    Fade(true);
                }

                break;
        }
    }

    private void Fade(bool isIn)
    {
        if (!isIn)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + 0.01f);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + 0.01f);
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 0.01f);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 0.01f);
        }
    }
}
