using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameObject player;
    private PlayerManager playerManager;
    private Health healthScript;
    
    private TextMeshProUGUI health;
    private TextMeshProUGUI armor;
    private TextMeshProUGUI ammo;

    private GameObject statePortrait;
    private GameObject keyInventory;

    void Start()
    {
        const string DYNAMIC_TAG = "Dynamic";

        health = gameObject.transform.Find(DYNAMIC_TAG).Find("Health").gameObject.GetComponent<TextMeshProUGUI>();
        armor = gameObject.transform.Find(DYNAMIC_TAG).Find("Armor").GetComponent<TextMeshProUGUI>();
        ammo = gameObject.transform.Find(DYNAMIC_TAG).Find("Ammo").GetComponent<TextMeshProUGUI>();
        statePortrait = gameObject.transform.Find(DYNAMIC_TAG).Find("State").gameObject;

        player = GameObject.Find("Player");

        playerManager = player.GetComponent<PlayerManager>();
        healthScript = player.GetComponent<Health>();

        health.text = healthScript.currentHealth.ToString() + "%";
        armor.text = healthScript.currentArmor.ToString() + "%";

    }

    public void UpdateHealth()
    {
        health.text = healthScript.currentHealth.ToString() + "%";
    }
    public void UpdateArmor()
    {
        armor.text = healthScript.currentArmor.ToString() + "%";
    }
    public void UpdateAmmo()
    {

    }
    public void UpdateKeys(string key)
    {

    }
}
