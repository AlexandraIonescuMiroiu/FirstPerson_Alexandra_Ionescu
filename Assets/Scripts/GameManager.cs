using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject enemyPrefab;
    public GameObject player;

    private int hordeNumber = 1;
    private int enemiesDead = 0;

    [SerializeField]
    private int maxHordeToWin = 5;

    [SerializeField]
    private int maxCoordenateToSpawnEnemy = 25;
    [SerializeField]
    private float spawnStartInterval = 3f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    public void GameOver()
    {
        // TODO: parar musica y todo en el juego + CANVAS
        Time.timeScale = 0;
    }

    public void WinGame()
    {
        // TODO:
    }

    public void RestartGame()
    {
        //TODO: PROBABlemente sea mejor reiniciar todo desde cero la ESCENA
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
            int enemiesToSpawn = 5 + (hordeNumber * 2);
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

            hordeNumber++;
            Debug.Log($"Horda {hordeNumber - 1} completada.");
            yield return new WaitForSeconds(2f);
        }

        Debug.Log("Has superado las 5 hordas!");
    }
}
