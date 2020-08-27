using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tom : MonoBehaviour
{
    public float period = 1;
    private float lastBallTime;
    public Stew prefab;
    public Transform startTransform;
    public float rotationSpeed = 50;
    // Start is called before the first frame update
    void Start()
    {
        lastBallTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lastBallTime += Time.deltaTime;
        if (lastBallTime > period)
        {
            lastBallTime = 0;
            Instantiate(prefab, startTransform.position, startTransform.rotation);
        }

    }
}
