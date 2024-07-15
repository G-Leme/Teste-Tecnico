using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUpController : MonoBehaviour
{
    [SerializeField] private int money;

    [SerializeField] private int levelUpCost;

    [SerializeField] private int currentLevel;

    [SerializeField] private Button levelUpButton;

    [SerializeField] private Renderer playerColor;

    [SerializeField] private TextMeshProUGUI levelUpText;

    [SerializeField] private TextMeshProUGUI minimumMoneyText;

    [SerializeField] private TextMeshProUGUI currentMoneyText;

    private PlayerDropCorpseController dropCorpseController;

    private float decreaseRGB = 0.1f;

    private PlayerGrabController grabController;


    void Awake()
    {
        grabController = GetComponent<PlayerGrabController>();

        levelUpButton.onClick.AddListener(OnButtonTouchLevelUp);

        dropCorpseController = GetComponent<PlayerDropCorpseController>();

        levelUpText.text = "LEVEL ATUAL: " + currentLevel;
    }

    private void OnEnable()
    {
        PlayerDropCorpseController.onCorpseDropped += GainMoney;
    }

    private void OnDisable()
    {
        PlayerDropCorpseController.onCorpseDropped -= GainMoney;
    }

    private void Update()
    {
        minimumMoneyText.text = "$:" + levelUpCost;

        currentMoneyText.text = "$ ATUAL: " + money;

        if(grabController.maximumCarryAmmount == 15)
        {
            minimumMoneyText.text = "MAX" ;

            levelUpText.text = "LEVEL ATUAL: MAX" ;
        }
    }

    private void GainMoney()
    {
        money += 2 * dropCorpseController.zombieCorpse.Length;

       
    }

    private void OnButtonTouchLevelUp()
    {
        if(grabController.maximumCarryAmmount <= 14 && money >= levelUpCost)
        {
         currentLevel += 1;

         grabController.maximumCarryAmmount += 1;

         money -= levelUpCost;


         playerColor.material.SetColor("_Color", new Vector4(1,1 - decreaseRGB,1 - decreaseRGB,1));

         decreaseRGB += 0.07f;

         levelUpCost += 4;

          levelUpText.text = "LEVEL ATUAL: " + currentLevel;

        }

    }
}
