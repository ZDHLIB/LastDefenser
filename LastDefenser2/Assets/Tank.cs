using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{

    [Header("Attributes")]
    public float attactRange = 17f;
    public float turnSpeed = 10f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Object Setups")]
    public Transform target;
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDis = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies) {
            float disToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(disToEnemy < shortestDis) {
                shortestDis = disToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDis <= attactRange) {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) return;

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        // Vector3 rotation = lookRotation.eulerAngles;
        Vector3 rotation = Quaternion.Slerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountDown <= 0f) {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void Shoot() {
        GameObject bulletObj = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.transform.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        if(bullet != null) {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attactRange);
    }
}
