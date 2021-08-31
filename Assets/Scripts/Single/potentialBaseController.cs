using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exposedNumber
{
    public float id { get; set; }
    public float exposedTime { get; set; }
    public float percent { get; set; }
    public float plusCount() { return exposedTime++; }
    public float percentCal(float totalCount)
    {
        percent = exposedTime / totalCount * 100.0f;

        return percent;
    }
}
public class potentialBaseController : MonoBehaviour
{
    public int lengthOfPotentialSlice, random;
    public int onoff = 0;
    GameObject[] findPotentialSlice;
    exposedNumber[] exposeNumber = new exposedNumber[6];
    public int count;

    // Use this for initialization
    void Start()
    {        
        onoff = 1;
        random = Random.Range(1, 7);
        count++;
        
        //클래스 배열 생성!
        for (int i = 0; i < exposeNumber.Length; i++)
        {
            exposeNumber[i] = new exposedNumber();
            exposeNumber[i].id = (i + 1);
        }
        exposeNumber[random - 1].plusCount();
    }
    // Update is called once per frame
    void Update()
    {
        findPotentialSlice = GameObject.FindGameObjectsWithTag("potentialSlice");
        lengthOfPotentialSlice = findPotentialSlice.Length;

        if (lengthOfPotentialSlice < 1)
        {
            onoff = 1;        
            reAct:
            if (count < 4)
            {
                random = Random.Range(1, 7);
                if (exposeNumber[random - 1].exposedTime == 0)
                {
                    exposeNumber[random - 1].plusCount();
                }
                else
                {
                    goto reAct; // ☆
                }
                count++;
            }
            else
            {
                chanceAdjust();
                count++;
            }            
        }
        else
        {
            onoff = 0;
        }        
    }
    void chanceAdjust()
    {
        float[] id = new float[6];
        for (int i = 0; i < id.Length; i++)
        {
            id[i] = i + 1;
        }

        for (int i = 0; i < exposeNumber.Length; i++)
        {
            for (int q = i + 1; q < exposeNumber.Length; q++)
            {
                if (exposeNumber[i].exposedTime > exposeNumber[q].exposedTime)
                {
                    float temp = id[i];
                    id[i] = id[q];
                    id[q] = temp;
                }
            }
        }
        // 0-32/ 33-64 / 65-96 / 97-99 / 100 으로 확률 조작
        int random2 = Random.Range(1, 101);

        if (random2 > 0 && random2 <= 32)
        {
            compareId(id[0]);
            random = (int)id[0];
        }
        else if (random2 > 32 && random2 <= 64)
        {
            compareId(id[1]);
            random = (int)id[1];
        }
        else if (random2 > 64 && random2 <= 96)
        {
            compareId(id[2]);
            random = (int)id[2];
        }
        else if (random2 > 96 && random2 <= 99)
        {
            compareId(id[3]);
            random = (int)id[3];
        }
        else if (random2 == 100)
        {
            compareId(id[4]);
            random = (int)id[4];
        }
    }
    void compareId(float idArray)
    {
        if (idArray == exposeNumber[(int)idArray - 1].id)
        {
            exposeNumber[(int)idArray - 1].plusCount();
        }
    }
}
