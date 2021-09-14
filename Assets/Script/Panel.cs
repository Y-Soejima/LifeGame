using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    [SerializeField] private Cell cellPrefab;
    [SerializeField] GridLayoutGroup panel;
    private Cell[,] cellArray = new Cell[72, 128];
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cellArray.GetLength(0); i++)
        {
            for (int k = 0; k < cellArray.GetLength(1); k++)
            {
                var cell = Instantiate(cellPrefab);
                cell.transform.SetParent(panel.transform);
                cellArray[i, k] = cell;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.1)
        {
            for (int i = 0; i < cellArray.GetLength(0); i++)
            {
                for (int k = 0; k < cellArray.GetLength(1); k++)
                {
                    cellArray[i, k].aliveCount = CellChack(i, k);
                }
            }
            
            for (int i = 0; i < cellArray.GetLength(0); i++)
            {
                for (int k = 0; k < cellArray.GetLength(1); k++)
                {
                    CellChange(cellArray[i, k].aliveCount, i, k);
                }
            }
            time = 0;
        }
    }

    int CellChack(int i, int k)
    {
        int aliveChack = 0;
        if (i != 0)
        {
            if (k != 0)
            {
                if (cellArray[i - 1, k - 1].alive == true)
                {
                    aliveChack++;
                }
            }
            if (cellArray[i - 1, k].alive == true)
            {
                aliveChack++;
            }
            if (k != cellArray.GetLength(1) - 1)
            {
                if (cellArray[i - 1, k + 1].alive == true)
                {
                    aliveChack++;
                }
            }
        }
        if (k != 0)
        {
            if (cellArray[i, k - 1].alive == true)
            {
                aliveChack++;
            }
        }
        if (k != cellArray.GetLength(1) - 1)
        {
            if (cellArray[i, k + 1].alive == true)
            {
                aliveChack++;
            }
        }
        if (i != cellArray.GetLength(0) - 1)
        {
            if (k != 0)
            {
                if (cellArray[i + 1, k - 1].alive == true)
                {
                    aliveChack++;
                }
            }
            if (cellArray[i + 1, k].alive == true)
            {
                aliveChack++;
            }
            if (k != cellArray.GetLength(1) - 1)
            {
                if (cellArray[i + 1, k + 1].alive == true)
                {
                    aliveChack++;
                }
            }
        }
        return aliveChack;
    }

    void CellChange(int aliveChack, int i, int k)
    {
        if (cellArray[i, k].alive == false)
        {
            if (aliveChack == 3)
            {
                cellArray[i, k].alive = true;
            }
            
        }
        else
        {
            if (aliveChack <= 1 || aliveChack >= 4)
            {
                cellArray[i, k].alive = false;
            }

        }
        cellArray[i, k].StateChange(cellArray[i, k].gameObject);
    }
}
