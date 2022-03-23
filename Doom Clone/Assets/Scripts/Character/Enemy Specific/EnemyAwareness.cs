using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    #region components
    [SerializeField] private SphereCollider aggroCollider;
    [SerializeField] private Material aggroMaterial;
    [SerializeField] private Material idleMaterial;
    [SerializeField] public MeshRenderer meshRenderer;
    #endregion
    #region values
    [SerializeField] private float awarenessRadius = 8f;
    #endregion
    #region bools
    [SerializeField] public bool isAware = false;
    #endregion

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        aggroCollider = GetComponent<SphereCollider>();
        aggroCollider.radius = awarenessRadius;
    }
    private void Update()
    {
        if (isAware)
        {
            meshRenderer.material = aggroMaterial;
        } else
        {
            meshRenderer.material = idleMaterial;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Physics.IgnoreCollision(GameObject.FindWithTag("Gun").gameObject.GetComponent<BoxCollider>(), aggroCollider);

        if (other.transform.CompareTag("Player"))
        {
            isAware = true;
        } 
    }
}
