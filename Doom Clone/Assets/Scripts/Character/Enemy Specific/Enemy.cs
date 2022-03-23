using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float startingEnemyHealth = 2f;
    public Health healthScript;
    private EnemyManager enemyManager;

    void Start()
    {
        healthScript = GetComponent<Health>();
        healthScript.currentHealth = startingEnemyHealth;
        enemyManager = GameObject.FindWithTag("Enemy Manager").GetComponent<EnemyManager>();
    }

    void Update()
    {
        if (healthScript.currentHealth <= 0)
        {
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }

}
