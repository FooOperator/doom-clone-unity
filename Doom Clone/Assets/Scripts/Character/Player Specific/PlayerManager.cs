using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region components
    private Scene currentScene;
    public Health healthScript;
    private UIManager uiManager;
    #endregion

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        uiManager = GameObject.Find("Player UI").GetComponent<UIManager>();
        healthScript = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.isDead)
        {
            SceneManager.LoadScene(currentScene.buildIndex);
        }

        if (Input.GetKeyDown("f"))
        {
            healthScript.TakeDamage(1);
        }

        uiManager.UpdateHealth();
        uiManager.UpdateArmor();
    }
}
