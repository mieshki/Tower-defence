﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    private Transform target;

    public static float damage = 34f;

    public float speed = 70f;
    public GameObject impactEffect;


    public void Seek(Transform _target)
    {
        target = _target;
    }

	
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // magnitude = lenght = dlugosc
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        DamageDetection.CheckDamage(damage);
    }

    void HitTarget()
    {
        //GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(effectIns, 1f);
        //Destroy(gameObject);
    }


}
