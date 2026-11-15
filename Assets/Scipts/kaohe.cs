using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaohe1 : MonoBehaviour
{
    public float speed = 1.0f;
    public float waitTime = 1.0f;
    public Transform targetPos;
    float totalTime;
    Vector3 startPos;
    private bool waiting;
    private float waitTimer;
    private float moveTimer;
    private float timeCounter;
    private int position = 1;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        Vector3 p1 = this.transform.position;
        Vector3 p2 = targetPos.position;
        Vector3 p = p1 - p2;
        float distant = p.magnitude;
        totalTime = distant / speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                waiting = !waiting;
                waitTimer = 0;
                timeCounter = 0;
                position *= -1;
            }
        }
        else
        {
            timeCounter += Time.deltaTime;
            float t = timeCounter / totalTime;
            t = Mathf.Clamp01(t);
            float curveValue = (1 - Mathf.Cos(Mathf.PI * t)) * 0.5f;
            if (position == 1)
            {
                this.transform.position = Vector3.Lerp(startPos, targetPos.position, curveValue);
            }
            else
            {
                this.transform.position = Vector3.Lerp(targetPos.position, startPos, curveValue);
            }
            if (t >= 1f)
            {
                waiting = true;
                timeCounter = 0;
            }
        }
    }
}

