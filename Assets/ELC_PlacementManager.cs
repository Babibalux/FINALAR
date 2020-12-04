using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_PlacementManager : MonoBehaviour
{
    private int verifiedObjects;
    private int verifiedCandles;

    public List<GameObject> objectsPlacements = new List<GameObject>(); //Sud, Ouest, Nord-Ouest, Nord-Est, Est
    public List<GameObject> candlesPlacements = new List<GameObject>(); //Nord, Est, Sud-Est, Sud-Ouest, Ouest

    public List<string> objectsOrder = new List<string>();
    public List<string> candlesOrder = new List<string>();

    private void Start()
    {
        
    }

    private void Update()
    {
        for (int i = 0; i < objectsPlacements.Count; i++)
        {

        }
    }

}
