using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    private int wayPointCounter = -1;

    private Transform currentWayPoint;
    private Transform rotationPoint;
    private Rigidbody2D rb2d;
    private GameManager gameManager;
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationPoint = transform.GetChild(0);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        GetNextWayPoint();
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        if(Vector2.Distance(transform.position, currentWayPoint.transform.position) > .1f)
        {
            transform.Translate(rotationPoint.transform.right * moveSpeed * Time.deltaTime);
        }
        else
        { 
            GetNextWayPoint();
        }
    }
    
    private void GetNextWayPoint()
    {
        wayPointCounter++;
        try
        {
            currentWayPoint = gameManager.GetWayPoint(wayPointCounter);

        }
        catch
        {
            Destroy(gameObject);
        }
    }

    private void HandleRotation()
    {
        Vector2 dir = currentWayPoint.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rotationPoint.rotation = Quaternion.Slerp(rotationPoint.rotation, rotation, 50 * Time.deltaTime);
    }
}
