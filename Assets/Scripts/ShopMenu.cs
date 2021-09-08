using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    private Animator animator;

    public void OnEnable() {
        FindAnimatorIfNone();
    }

    public void FindAnimatorIfNone() {
        animator = GameObject.FindWithTag("TransitionImage").GetComponent<Animator>();
        animator.CrossFade("SceneSwitchInShop", 0, 0, 0, 0);
    }

    public void Back() {
        Time.timeScale = 1f;
        StartCoroutine(Transition("HomeScreen"));
    }

     private IEnumerator Transition(string scene) {
        animator.CrossFade("SceneSwitchOutShop", 0, 0, 0, 0);
        yield return new WaitForSeconds((float) 1);
        SceneManager.LoadScene(scene);
    }
}
