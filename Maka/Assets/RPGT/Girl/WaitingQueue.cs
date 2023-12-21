using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class WaitingQueue : MonoBehaviour
{
    private List<GameObject> ds;
    private List<Vector3> positionList;
    private Vector3 entrancePosition;


    public WaitingQueue(List<Vector3> positionList)
    {
        this.positionList = positionList;
        entrancePosition = positionList[positionList.Count - 1] + new Vector3(-3f, 0);

        foreach (Vector3 position in positionList)
        {
            World_Sprite.Create(position, new Vector3(.3f, .3f), Color.green);
        }
        World_Sprite.Create(entrancePosition, new Vector3(.3f, .3f), Color.magenta);
    }
}
