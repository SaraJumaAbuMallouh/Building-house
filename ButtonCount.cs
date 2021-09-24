using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCount : MonoBehaviour
{

    public PuzzleGame puzzleGame;
    
    public void ClickMe() {
        puzzleGame.count++;
        transform.GetChild(0).gameObject.SetActive(true);

        if (puzzleGame.count == 1) {
            puzzleGame.number1 = int.Parse(transform.GetChild(0).GetComponent<Text>().text);
        }
        if (puzzleGame.count == 2) {
            puzzleGame.number2 = int.Parse(transform.GetChild(0).GetComponent<Text>().text);
            puzzleGame.total = (puzzleGame.number1 + puzzleGame.number2);
            puzzleGame.result.text = "Result : "+ puzzleGame.total ;
            StartCoroutine(Wait());
            
        }
    }
    IEnumerator Wait() {
        yield return new WaitForSeconds(2);
        puzzleGame.gameObject.SetActive(false);
        Player.instance.MoveToCell(puzzleGame.total);
        puzzleGame.number1 = 0;
        puzzleGame.number2 = 0;
        puzzleGame.RestGame();
        puzzleGame.count = 0;
    }
}
