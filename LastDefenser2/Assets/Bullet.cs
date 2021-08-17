using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject hitEffect;
    public float speed = 70f;

    public void Seek(Transform _target) {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;

        // Quaternion lookRotation = Quaternion.LookRotation(dir);
        // Vector3 rotation = lookRotation.eulerAngles;
        // transform.rotation = Quaternion.Euler(0f, 0f, rotation.y);


        float disThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= disThisFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * disThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget() {
        GameObject hitEffectIns = (GameObject) Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(hitEffectIns, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
        return;
    }
}
