using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : MonoBehaviour, IPickup
{
    public string _name { get; set; }
    public string _type { get; set; }
    public float _value { get; set; }

    [SerializeField] private string name;
    [SerializeField] private string type;
    [SerializeField] private float value;

    // Start is called before the first frame update
    void Start()
    {
        _name = name;
        _type = type;
        _value = value;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            playerHealth.RecoverArmor(_value);
            Destroy(gameObject);
        }
    }
}
