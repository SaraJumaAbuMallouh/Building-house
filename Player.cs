using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    int myPlace =0;
    Vector3 lastPosition,lastRotation;
    private float speed = 2f;
    public GameObject woodeffects;
    public GameObject ironeffects;
    public GameObject stoneeffects;
    public GameObject watereffects;
    public GameObject coineffects;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        myPlace = 0;
        transform.position = gameplayManager.instance.cells[0].position;
        lastPosition = gameplayManager.instance.cells[0].position;
        woodeffects.SetActive(false);
        ironeffects.SetActive(false);
        stoneeffects.SetActive(false);
        woodeffects.SetActive(false);
        coineffects.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        gameplayManager.instance.playerCamera.transform.position = new Vector3(
            transform.position.x + 13.8897f, transform.position.y + 9.9834f, transform.position.z + 20.47634f
            );
        if (lastPosition!=null)
            transform.position = Vector3.Lerp(transform.position, lastPosition, Time.deltaTime * speed);
    }
    public void MoveToCell(int steps) {
        gameplayManager.instance.mainCamera.gameObject.SetActive(false);
        gameplayManager.instance.playerCamera.gameObject.SetActive(true);
        StartCoroutine(WaitForStep(myPlace, (myPlace+steps) % gameplayManager.instance.cells.Count));
        myPlace = (myPlace + steps) % gameplayManager.instance.cells.Count;

    }
    IEnumerator WaitForStep(int currStep,int lastStep) {
        for (int i = currStep; i <= lastStep; i++)
        {
            lastPosition = gameplayManager.instance.cells[i].position;
            transform.eulerAngles = gameplayManager.instance.cells[i].Rotation;
            yield return new WaitForSeconds(0.5f);
        }
        for (int i = 0; i < gameplayManager.instance.cells[myPlace].cellType.Length; i++)
        {
            Cell.CellType cell = gameplayManager.instance.cells[myPlace].cellType[i];
            if (cell == Cell.CellType.Metal)
            {
                
                gameplayManager.instance.IronNumber += gameplayManager.instance.cells[myPlace].effectValue[i];
                //ironeffects.SetActive(true);
                //Destroy(ironeffects, 3.5f);
                FindObjectOfType<AudioManager>().Play("win");

            }
            if (cell == Cell.CellType.Water)
            {
                
                gameplayManager.instance.WaterNumber += gameplayManager.instance.cells[myPlace].effectValue[i];
               // watereffects.SetActive(true);
               // Destroy(watereffects, 3.5f);
                FindObjectOfType<AudioManager>().Play("win");
            }
            if (cell == Cell.CellType.Stone)
            {
                
                gameplayManager.instance.StoneNumber += gameplayManager.instance.cells[myPlace].effectValue[i];
               // stoneeffects.SetActive(true);
                //Destroy(stoneeffects, 3.5f);
                FindObjectOfType<AudioManager>().Play("win");
            }
            if (cell == Cell.CellType.Wood)
            {
                
                gameplayManager.instance.WoodNumber += gameplayManager.instance.cells[myPlace].effectValue[i];
               // woodeffects.SetActive(true);
               // Destroy(woodeffects, 3.5f);
                FindObjectOfType<AudioManager>().Play("win");
            }
            
        }
        
        gameplayManager.instance.BuildBuilding();
        yield return new WaitForSeconds(3f);

        gameplayManager.instance.mainCamera.gameObject.SetActive(true);
        gameplayManager.instance.playerCamera.gameObject.SetActive(false);

       
        gameplayManager.instance.CoinsNumber += gameplayManager.instance.cells[myPlace].coinValue;
        FillTexts(gameplayManager.instance.WaterNumber, gameplayManager.instance.IronNumber, gameplayManager.instance.WoodNumber, gameplayManager.instance.StoneNumber, gameplayManager.instance.CoinsNumber);

            
        if (gameplayManager.instance.cells[myPlace].coinValue<0)
        {
            //coineffects.SetActive(true);
            //Destroy(coineffects, 3.5f);
            FindObjectOfType<AudioManager>().Play("Palyerfailing");
        }

    }
    public void FillTexts(int water,int metal,int wood,int stone,int coin) {
        gameplayManager.instance.WaterText.text = water+"";
        gameplayManager.instance.IronText.text = metal+"";
        gameplayManager.instance.StoneText.text = stone + "";
        gameplayManager.instance.CoinsText.text = coin + "";
        gameplayManager.instance.WoodText.text = wood + "";
    }
}
