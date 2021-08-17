using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float waveGaps = 5f;
    private float countDown = 2f;
    private int waveIndex = 1;
    // public Text waveCountDownText;


    // Update is called once per frame
    void Update() {
        if(countDown <= 0f) {
            StartCoroutine(SpawnWave());
            countDown = waveGaps;
        }
        countDown -= Time.deltaTime;
        // waveCountDownText.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawnWave() {
        waveIndex++;
        for(int i = 0; i < waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.4f);
        }

    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
