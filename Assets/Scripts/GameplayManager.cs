using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField]
    Level[] levels;

    [SerializeField]
    Player pl;

    int currentLevel = 0;
    bool paused = false;
    private int points;

    public int Points
    {
        get { return points; }
        set
        {
            points = value;
            Managers.ins.UIM.SetPointsText(points);
        }
    }
    public int CurrentLevel { get { return currentLevel; } }
    int xp;
    public int XP
    {
        get { return xp; }
        set
        {
            Managers.ins.UIM.AddXPToSlider(value - xp);
            xp = value;
            if (xp > levels[currentLevel + 1].requiredXP)
                LevelUp();
        }
    }

    public void PauseGame()
    {
        if (paused)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
        Managers.ins.UIM.TogglePauseMenu();
    }

    private void Start()
    {
        Managers.ins.UIM.ResetSliderValue();
        Managers.ins.UIM.SliderMax = levels[currentLevel + 1].requiredXP;
        Managers.ins.ES.CurrentEnemy = levels[currentLevel].upgrades[0].upgradedEnemy;
    }

    public void LevelUp()
    {
        Managers.ins.AM.Play("levelup");
        currentLevel++;
        XP = 0;
        Managers.ins.UIM.LevelUpUIBehaviour(levels[currentLevel]);
        Managers.ins.UIM.SliderMax = levels[currentLevel + 1].requiredXP;
        Time.timeScale = 0;
    }

    public void ChooseUpgrade(int number)
    {
        Managers.ins.AM.Play("select");
        Managers.ins.ES.CurrentEnemy = levels[currentLevel].upgrades[number].upgradedEnemy;
        Managers.ins.UIM.ToggleUpgradePanel(false);
        Time.timeScale = 1;
    }

    public void End()
    {
        Debug.Log("You died.");
    }
}
