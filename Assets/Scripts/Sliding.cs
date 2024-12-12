using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private string animationParameter = "isPlaying";

    private bool isPlaying = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator не найден!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isPlaying = !isPlaying;
            animator.SetBool(animationParameter, isPlaying);
        }
    }
}
