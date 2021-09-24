using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameplayManager : MonoBehaviour
{
    public static gameplayManager instance;
    public DaylyRounds DaylyRounds;
    //public List<ButtonCount> ButtonCountsList;
    public List<Cell> cells;
    public GameObject mainCamera, playerCamera; // playerCamera ;
    public List<Building> buildings;
    public GameObject Buzzel;
    public int level=0;

    public Text WoodText, StoneText, WaterText, CoinsText, IronText,levelText;
    public int WoodNumber, StoneNumber, WaterNumber, CoinsNumber, IronNumber;

    private void Awake()
    {
        instance = this;
        for (int i = 0; i < 6 ; i++)
        {
            foreach (var building in buildings[i].buildingParts)
            {
                building.SetActive(false);
            }
        }

    }

    public void startRound()
    {
        //Buzzel.SetActive(true);
        int playerRounds = PlayerPrefs.GetInt(IConstance.playeRonds, 0);
        if(playerRounds < 40)
        {
            Buzzel.SetActive(true);
            FindObjectOfType<AudioManager>().Play("click");
            int tempRouns = PlayerPrefs.GetInt(IConstance.playeRonds, 0);
            tempRouns++;
            PlayerPrefs.SetInt(IConstance.playeRonds, tempRouns);
            
        }
        else
        {
            Debug.Log("you out of rounds todat");
        }



    }
    [Serializable]
    public struct Building {
        public List<GameObject> buildingParts;
    }
    public void BuildBuilding() {
        if (WoodNumber >= 10 && StoneNumber >= 10 && WaterNumber >= 10 && IronNumber >= 10)
        {
            level = 1;
        }
        if (WoodNumber >= 20 && StoneNumber >= 20 && WaterNumber >= 20 && IronNumber >= 20)
        {
            level = 2;
        }
        if (WoodNumber >= 30 && StoneNumber >= 30 && WaterNumber >= 30 && IronNumber >= 30)
        {
            level = 3;
        }
        if (WoodNumber >= 40 && StoneNumber >= 40 && WaterNumber >= 40 && IronNumber >= 40)
        {
            level = 4;
        }
        if (WoodNumber >= 50 && StoneNumber >= 50 && WaterNumber >= 50 && IronNumber >= 50)
        {
            level = 5;
        }
        if (WoodNumber >= 60 && StoneNumber >= 60 && WaterNumber >= 60 && IronNumber >= 60)
        {
            level = 6;
        }

        levelText.text = level + "";
        for (int i = 0; i < 6; i++)
        {
            foreach (var building in buildings[i].buildingParts)
            {
                building.SetActive(false);
            }
        }
        for (int i = 0; i < level; i++)
        {
            foreach (var building in buildings[i].buildingParts)
            {
                building.SetActive(true);
            }
        }
    }
}
