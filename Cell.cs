using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector3 position;
    public Vector3 Rotation;
    public CellType []cellType;
    public int []effectValue;
    public int coinValue;


    public enum CellType
    {
        Wood,
        Metal,
        Water,
        Stone,
        Null
    }
    // Start is called before the first frame update
    void Awake()
    {
       // position = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
