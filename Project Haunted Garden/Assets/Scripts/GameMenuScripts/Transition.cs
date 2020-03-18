using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Transition : MonoBehaviour
{

    public Animator animator;
    private int LevelToLoad;

    public void FadeToLevel(int index)
    {
        LevelToLoad = index;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
