using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGame : MonoBehaviour
{
    public Button[] buttonsList = new Button[9];
    public Text result;
    List<int> arr = new List<int>();
    public int count = 0;
    public int number1 = 0;
    public int number2 = 0;
    public int total;
    Animator Anim;

    private void OnEnable()
    {
        RestGame();
    }

    int GetRandomNumber() {
        int random =Random.Range(0, arr.Count-1);
        int randomArr = arr[random];
        arr.RemoveAt(random);
        return randomArr;
    }

    public void RestGame() {
        arr.Clear();
        for (int i = 0; i < 9; i++)
        {
            arr.Add(i);
        }
        for (int i = 0; i < 9; i++)
        {
            int random = GetRandomNumber();
            buttonsList[i].transform.GetChild(0).GetComponent<Text>().text = random + "";
            buttonsList[i].transform.GetChild(0).gameObject.SetActive(false);
        }

    }

}
