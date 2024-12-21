using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private NavMeshAgent AI_Agent;
    private GameObject Player;
    private Animator AI_Animator;

    [SerializeField] private int health = 100;
    [SerializeField] private Enemy enemy;
    private bool isDead = false; 

    void Start()
    {
        AI_Agent = gameObject.GetComponent<NavMeshAgent>();
        AI_Animator = gameObject.GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (isDead)
        {
            AI_Agent.isStopped = true;
            return;
        }

        AI_Agent.SetDestination(Player.transform.position);

        if (AI_Agent.velocity.magnitude > 0.1f)
        {
            AI_Animator.SetBool("isWalking", true);
        }
        else
        {
            AI_Animator.SetBool("isWalking", false);
        }
    }

    public void TakeDamage()
    {
        if (isDead) return; 

        else 
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        AI_Agent.isStopped = true; 
        AI_Animator.SetTrigger("Die"); 
        Destroy(gameObject, 5f); 
    }
}
