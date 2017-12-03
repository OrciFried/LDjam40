using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Image upgrade1, upgrade2, upgrade3;

    [SerializeField]
    GameObject player, levelUpArrow, upgradePanel, plusXP;

    [SerializeField]
    Vector3 offsetFromPlayerLvlupAndPlusXP = Vector2.one;

    [SerializeField]
    Text fromLevel, toLevel;

    [SerializeField]
    Text pointsText, hpText;

    [Header("The slider values")]
    [SerializeField]
    Slider levelProgress;

    [SerializeField]
    int min = 0, max = 10;

    [SerializeField]
    Slider healthBar;

    [SerializeField]
    GameObject pauseMenu;

    public Slider HealthBar { get { return healthBar; } set { healthBar = value; } }

    public int SliderMax { get { return max; } set { max = value; } }

    private void Awake()
    {
        ToggleUpgradePanel(false);
    }

    public void SubtractValueFromHP(int value)
    {
        healthBar.value -= value;
        hpText.text = string.Format("HP: {0}", healthBar.value);
    }

    public void AddXPToSlider(int addValue)
    {
        levelProgress.value += addValue;
    }

    public void ResetSliderValue()
    {
        levelProgress.value = 0;
    }

    public void ToggleUpgradePanel(bool on)
    {
        upgradePanel.SetActive(on);
    }

    public void LevelUpUIBehaviour(Level levelData)
    {
        Instantiate(levelUpArrow, player.transform.position + offsetFromPlayerLvlupAndPlusXP,Quaternion.identity, transform);
        if (upgrade1.sprite != null)
        {
            upgrade1.sprite = levelData.upgrades[0].icon;
            upgrade2.sprite = levelData.upgrades[1].icon;
            upgrade3.sprite = levelData.upgrades[2].icon;
        }
        ToggleUpgradePanel(true);
        fromLevel.text = Managers.ins.GPM.CurrentLevel.ToString();
        toLevel.text = (Managers.ins.GPM.CurrentLevel + 1).ToString();
    }

    public void AddXPUI()
    {
        Instantiate(plusXP, player.transform.position + offsetFromPlayerLvlupAndPlusXP, Quaternion.identity, transform);
    }

    public void SetPointsText(int value)
    {
        pointsText.text = value.ToString();
    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
}
