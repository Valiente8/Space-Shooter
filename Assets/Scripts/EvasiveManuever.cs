﻿using UnityEngine;
using System.Collections;

public class EvasiveManuever : MonoBehaviour {

    public float smoothing;
    public float dodge;
    public Boundary boundary;
    public float tilt;
    

    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;

    private float targetManuever;
    private Transform playerTransform;
    private float currentSpeed;

    private Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Evade());
	}
	
    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            //targetManuever = Random.Range(1,dodge)* Mathf.Sign(transform.position.x);
            targetManuever= playerTransform.position.x;
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManuever = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));

        }

    }

	void FixedUpdate () {
        float newManuever = Mathf.MoveTowards(rb.velocity.x, targetManuever, Time.deltaTime*smoothing);
        rb.velocity = new Vector3(newManuever, 0.0f, currentSpeed);
        rb.position= new Vector3
         (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
         );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }
}