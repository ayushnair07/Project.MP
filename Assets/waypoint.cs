using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    public Transform position1, position2;
    public float speed = 5;
    public Transform StartPosition;
    private Vector3 nextPos;
    public void Start()
    {
       nextPos = StartPosition.position;
    }
    private void Update()
    {
        if(transform.position==position1.position)
        {
            nextPos = position2.position;
        }
        if (transform.position == position2.position)
        {
            nextPos = position1.position;
        }
        transform.position=Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime); 
    }

}
