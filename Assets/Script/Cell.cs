using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public bool alive = false;
    public int aliveCount;
    // Start is called before the first frame update
    void Start()
    {
        int cellState = Random.Range(0, 2);
        alive = cellState == 0 ? true : false;
        StateChange(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StateChange(GameObject gameObject)
    {
        gameObject.GetComponent<Image>().color = alive == true ? Color.black : Color.white;
    }

}
