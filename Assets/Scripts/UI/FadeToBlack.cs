using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    private Image image;
    private FadeState state = FadeState.fadingIn;
    private float betweenFade = 0.01f;
    private float timer = 0;
    private string scene;
    private bool isQuiting;

    void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
    }

    private void Update()
    {
        switch(state)
        {
            case FadeState.nothing: break;

            case FadeState.fadingOut:
                timer += Time.deltaTime;
                if (timer >= betweenFade)
                {
                    if (image.color.a >= 1)
                    {
                        state = FadeState.nothing; 
                        if (!isQuiting)
                            SceneManager.LoadScene(scene); 
                        
                        Application.Quit();
                    }
                    timer = 0;
                    Fade(false);
                }
            break;

            case FadeState.fadingIn:
                timer += Time.deltaTime;
                if (timer >= betweenFade)
                {
                    if(image.color.a <= 0)
                        state = FadeState.nothing;

                    timer = 0;
                    Fade(true);
                }
           
            break;
        }
    }

    public void StartFade(string sceneToTransitionTo)
    {
        scene = sceneToTransitionTo;
        state = FadeState.fadingOut;
    }

    public static void StartFade(string sceneToTransitionTo, FadeToBlack fade)
    {
        fade.scene = sceneToTransitionTo;
        fade.state = FadeState.fadingOut;
    }

    public void FadeToQuit()
    {
        isQuiting = true;
        state = FadeState.fadingOut;
    }

    /// <summary>
    /// Fades in or out by 0.01 each time its called, chooses in or out by the bool passed in
    /// </summary>
    /// <param name="isIn"></param>
    private void Fade(bool isIn)
    {
        if(!isIn)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + 0.01f);
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 0.01f);
        }
    }
}

public enum FadeState
{
    nothing,
    fadingOut,
    fadingIn
}
