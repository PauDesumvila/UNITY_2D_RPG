using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    // health bar
    public Slider healthBar;
    public TextMeshProUGUI HPText;
    public LegionHealthManager legionHealth;

    // mana bar
    public Slider manaBar;
    public TextMeshProUGUI MPText;    

    // exp bar
    public Slider expBar;
    public TextMeshProUGUI EXPText;
    public LegionStats legionStats;

    // attack & defense stats
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;

    // avoid UI bar duplicates
    private static bool UIBarsExists;

    // game over screen
    public GameObject gameOverScreen;
    private LegionHealthManager theLHM;    

    void Start () {

        // game over screen
        theLHM = FindObjectOfType<LegionHealthManager>();
        gameOverScreen.SetActive(false);

        // avoid UI bar duplicates
        DontDestroyOnLoad(transform.gameObject);
        if (!UIBarsExists)
        {
            UIBarsExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
		
	void Update () {

        // health bar
        healthBar.maxValue = legionHealth.legionMaxHealth;
        healthBar.value = legionHealth.legionCurrentHealth;
        HPText.text = "HP " + legionHealth.legionCurrentHealth;

        // mana bar
        manaBar.maxValue = legionHealth.legionMaxMagic;
        manaBar.value = legionHealth.legionCurrentMagic;
        MPText.text = "MP " + legionHealth.legionCurrentMagic;

        // exp bar        
        expBar.maxValue = legionStats.EXPToLevelUp[legionStats.currentLevel] - legionStats.EXPToLevelUp[legionStats.currentLevel - 1];
        expBar.value = legionStats.currentEXP - legionStats.EXPToLevelUp[legionStats.currentLevel - 1];
        EXPText.text = "LEVEL " + legionStats.currentLevel;

        // attack & defense stats
        attackText.text = "Attack: " + legionStats.currentAttack.ToString();
        defenseText.text = "Defense: " + legionStats.currentDefense.ToString();

        // game over screen
        if (theLHM.legionCurrentHealth <= 0)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
