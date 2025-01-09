using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundsManager : MonoBehaviour
{
    private int hordeNumber = 1;
    [SerializeField] private int maxHordeToWin = 3;
    public GameObject enemyPrefab;
    public GameObject player;
    public int enemiesDead = 0;
    [SerializeField] private int maxCoordenateToSpawnEnemy = 25;
    [SerializeField] private float spawnStartInterval = 3f;
    [SerializeField] private TMP_Text roundText;
    [SerializeField] private int intensitySpawnEnemies = 2;

    private void Start()
    {
        roundText.text = "Round: " + hordeNumber;
        StartCoroutine(SpawnEnemyRoutine());
    }

    public void RegisterEnemyDeath()
    {
        enemiesDead++;
        Debug.Log("Enemigos muertos: " + enemiesDead);
    }

    public void SpawnEnemyInRange(float rangeX)
    {
        if (enemyPrefab == null || player == null)
        {
            Debug.Log("EnemyPrefab o Player no asignado en el GameManager.");
            return;
        }

        Vector3 playerPosition = player.transform.position;
        Vector3 spawnPosition;
        float distance;

        do
        {
            float randomOffsetX = Random.Range(-rangeX, rangeX);
            float randomOffsetZ = Random.Range(-rangeX, rangeX);

            spawnPosition = new Vector3(
                playerPosition.x + randomOffsetX,
                playerPosition.y,
                playerPosition.z + randomOffsetZ
            );

            distance = Vector3.Distance(playerPosition, spawnPosition);
        }
        while (distance < maxCoordenateToSpawnEnemy);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Spawned enemy at: " + spawnPosition);
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (hordeNumber <= maxHordeToWin)
        {
            float interval = 3f - (hordeNumber * 0.5f);
            int enemiesToSpawn = intensitySpawnEnemies + (hordeNumber * 2);
            Debug.Log($"Horda {hordeNumber}: {enemiesToSpawn} enemigos aparecerán cada {interval} segundos.");

            enemiesDead = 0;

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemyInRange(maxCoordenateToSpawnEnemy);
                yield return new WaitForSeconds(interval);
            }

            while (enemiesDead < enemiesToSpawn)
            {
                yield return null;
            }

            if (hordeNumber == maxHordeToWin)
            {
                GameManager.Instance.WinGame();
            }
            else
            {
                enemiesDead = 0;
                hordeNumber++;
                roundText.text = "Round: " + hordeNumber;
            }

            yield return new WaitForSeconds(2f);
        }

        Debug.Log("Has superado las " + maxHordeToWin + " hordas!");
    }
}
