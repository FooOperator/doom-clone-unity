using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private BoxCollider gunTrigger;
    [Header("Values")]
    #region values
    [SerializeField] private float horizontalRange;
    [SerializeField] private float verticalRange;
    [SerializeField] private float spreadRange;
    [SerializeField] private float gunDamage;
    [SerializeField] private float fireRate;
    private float nextTimeToFire;
    [SerializeField] private bool canFire;
    #endregion
    [Header("Layers")]
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] private LayerMask enemyLayerMask;
    #region sounds
    private AudioSource gunFireSFX;
    private Collider[] enemyColliders;
    private float gunFireRadius;
    #endregion

    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(spreadRange, verticalRange, horizontalRange);
        gunTrigger.center = new Vector3(0, 0, horizontalRange * 0.5f);
        gunFireSFX = GetComponent<AudioSource>();

        gunFireRadius = horizontalRange;
    }
    void Update()
    {
        GetCanFire();

        if (Input.GetButton("Fire1") && canFire)
        {
            Fire();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }

    private void GetCanFire()
    {
        canFire = Time.time > nextTimeToFire;
    }
    private void Fire()
    {
        enemyColliders = Physics.OverlapSphere(transform.position, gunFireRadius, enemyLayerMask);

        foreach (var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<EnemyAwareness>().isAware = true;
        }

        gunFireSFX.Stop();
        gunFireSFX.Play();

        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            Vector3 direction = enemy.transform.position - transform.position;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, horizontalRange * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    enemy.healthScript.TakeDamage(gunDamage);
                    Debug.DrawRay(transform.position, direction, Color.green);
                }
            }
        }

        nextTimeToFire = Time.time + fireRate;

    }


}
