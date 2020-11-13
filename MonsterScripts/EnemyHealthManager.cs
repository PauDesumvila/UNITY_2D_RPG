using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    // enemy health bar
    public EnemyHealthBar enemyHealthBar;

    // to add experience when killed
    private LegionStats legionStats;
    public int EXPToGive;

    // for hunt enemy quests
    public string enemyQuestName;
    private QuestManager theQM;

    void Start()
    {
        currentHealth = maxHealth;

        // enemy health bar
        enemyHealthBar.SetMaxHealth(maxHealth);

        // to add experience when killed
        legionStats = FindObjectOfType<LegionStats>();

        // for hunt enemy quests
        theQM = FindObjectOfType<QuestManager>();
    }

    void Update()
    {
        // enemy health bar
        enemyHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            // for hunt enemy quests
            theQM.enemyKilled = enemyQuestName;

            //gameObject.SetActive(false); // enemies will appear again after reload area
            Destroy(gameObject); // enemies will not appear again after reload area

            // to add experience when killed
            legionStats.AddExperience(EXPToGive);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
