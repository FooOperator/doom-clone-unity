using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region components
    private Animator animator;
    private UIManager uiManager;
    #endregion
    #region values
    [Header("Values")]
    [SerializeField] public float currentHealth;
    [SerializeField] public float maximumHealth;
    [SerializeField] public float currentArmor;
    [SerializeField] public float maximumArmor;
    #endregion
    #region bools
    [Header("Bools")]
    [SerializeField] public bool isDead;
    [SerializeField] public bool hasArmor;
    #endregion

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        hasArmor = currentArmor <= 0 ? false : true;
        animator.SetBool("isDead", isDead);
    }

    public void TakeDamage(float damageTaken)
    {
        if (hasArmor)
        {
            if (currentArmor >= damageTaken)
            {
                currentArmor -= damageTaken;
            } else
            {
                float remainingDamage = damageTaken - currentArmor;
                currentArmor = 0;
                currentHealth -= remainingDamage;
            }
        } else {
            currentHealth -= damageTaken;
        }

        if (currentHealth <= 0)
        {
            isDead = true;
        }

    }

    public void RecoverHealth(float health)
    {
        if (currentHealth <= maximumHealth)
        {
            currentHealth += health;
        }
    }

    public void RecoverArmor(float armor)
    {
        if (currentArmor <= maximumArmor)
        {
            currentArmor += armor;
        }
    }

}
