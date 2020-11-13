using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegionStats : MonoBehaviour {

    // exp manager
    public int currentLevel;
    public int currentEXP;
    public int[] EXPToLevelUp;

    // stats manager
    public int[] HPLevels;
    public int[] MPLevels;
    public int[] attackLevels;
    public int[] defenseLevels;
    public int currentHP;
    public int currentMP;
    public int currentAttack;
    public int currentDefense;

    // show player leveling up(getting yellow)
    private bool levelFlashActive;
    public float levelFlashLength;
    private float levelFlashCounter;
    private SpriteRenderer legionSprite;    

    // link legion stats to legion health manager
    private LegionHealthManager legionHealth;   

    void Start () {

        // stats manager
        currentHP = HPLevels[1];               // start HP stats for level 1
        currentMP = MPLevels[1];               // start MP stats for level 1
        currentAttack = attackLevels[1];       // start Attack stats for level 1
        currentDefense = defenseLevels[1];     // start Defense stats for level 1

        // link legion stats to legion health manager
        legionHealth = FindObjectOfType<LegionHealthManager>();

        // show player leveling up(getting yellow)
        legionSprite = GetComponent<SpriteRenderer>();

    }

    void Update () {

        // exp manager
        if (currentEXP >= EXPToLevelUp[currentLevel])
        {
            //currentLevel++;   
            LevelUp();
        }

        // show player leveling up(getting yellow)
        if (levelFlashActive && currentLevel != 1)
        {
            if(levelFlashCounter > levelFlashLength * 0.66f)
            {
                legionSprite.material.color = new Color(0.913f, 0.850f, 0.262f);  // get yellow
            } else if(levelFlashCounter > levelFlashLength * 0.33f)
            {
                legionSprite.material.color = new Color(legionSprite.color.r, legionSprite.color.g, legionSprite.color.b); // get normal color
            } else if(levelFlashCounter > 0f)
            {
                legionSprite.material.color = new Color(0.913f, 0.850f, 0.262f);  // get yelllow
            } else
            {
                legionSprite.material.color = new Color(legionSprite.color.r, legionSprite.color.g, legionSprite.color.b); // get normal color 
                levelFlashActive = false;
            }
            levelFlashCounter -= Time.deltaTime;
        }
    }

    // exp manager
    public void AddExperience(int experienceToAdd)
    {
        currentEXP += experienceToAdd;
    }

    // stats manager
    public void LevelUp()
    {
        currentLevel++;
        currentHP = HPLevels[currentLevel];
        currentMP = MPLevels[currentLevel];
        currentAttack = attackLevels[currentLevel];      
        currentDefense = defenseLevels[currentLevel];

        // link legion stats to legion health manager
        legionHealth.legionMaxHealth = currentHP;
        legionHealth.legionCurrentHealth += currentHP - HPLevels[currentLevel - 1];
        legionHealth.legionMaxMagic = currentMP;
        legionHealth.legionCurrentMagic += currentMP - MPLevels[currentLevel - 1];

        // show player leveling up(getting yellow)
        levelFlashActive = true;
        levelFlashCounter = levelFlashLength;
        
    }
}
