using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUpController : MonoBehaviour
{
    [SerializeField] private int money;

    [SerializeField] private int levelUpCost;

    [SerializeField] private int currentLevel;

    [SerializeField] private PlayerDropCorpseController dropCorpseController;

    [SerializeField] private Button levelUpButton;

    private PlayerGrabController grabController;

    void Awake()
    {
        grabController = GetComponent<PlayerGrabController>();
        levelUpButton.onClick.AddListener(OnButtonTouchLevelUp);
        dropCorpseController = GetComponent<PlayerDropCorpseController>();
    }

    private void OnEnable()
    {
        PlayerDropCorpseController.onCorpseDropped += GainMoney;
    }

    private void OnDisable()
    {
        PlayerDropCorpseController.onCorpseDropped -= GainMoney;
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GainMoney()
    {
        money += 2 * dropCorpseController.zombieCorpse.Length;

        Debug.Log(money);
    }

    private void OnButtonTouchLevelUp()
    {
        if(grabController.maximumCarryAmmount <= 14 && money >= levelUpCost)
        {
         currentLevel += 1;

        grabController.maximumCarryAmmount += 1;

            money -= levelUpCost;

            levelUpCost += 4;


            Debug.Log(currentLevel);
        }
        else if (grabController.maximumCarryAmmount == 15)
        {
            Debug.Log(" You have reached the maximum level!");
        }

    }
}
