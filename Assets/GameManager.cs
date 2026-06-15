using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private float timelimit = 5.0f;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI resultText;

    private float timer;
    private int touchCount;
    private bool isMeasuring = false;
    private Camera mainCamera;

    public GameObject targetPrefab;
    private int score = 0;

    public Vector3 spawnAreaCenter = new Vector3(10, 10, 3);
    public Vector3 spawnAreaSize = new Vector3(10, 10, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateScoreUI(); 
        for (int i = 0; i < 3; i++)
        {
            spawnTarget();
        }

        mainCamera = Camera.main;

        ResetGame();

        StartMeasurement();
    }

    public void AddScore()
    {
        score += 1;
        UpdateScoreUI();
        spawnTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMeasuring)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                EndMeasurement();
            }

            DetectObjectTouch();

            if (timerText != null)
            {
                timerText.text = "time left : " + timer.ToString("F2") + "seconds";
            }
        }
    }

    private void DetectObjectTouch()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);
            CheckRayHit(ray);
        }
    }

    private void CheckRayHit(Ray ray)
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
                touchCount++;
            }
        }
    }


    private void StartMeasurement()
    {
        ResetGame();
        isMeasuring = true;
    }

    private void ResetGame()
    {
        timer = timelimit;
        touchCount = 0;
        isMeasuring= false;
        if (resultText != null) resultText.text = "";
    }

    private void EndMeasurement()
    {
        isMeasuring = false;

        if (resultText != null)
        {
            resultText.text = touchCount + "tap";
        }
    }
    void UpdateScoreUI()
    {
    //    if (timer score != null)
    //    {
    //        timerText.text = "time left: " + timer.ToString("F2") + "second";
    //    }
    }

    void spawnTarget()
    {
        Vector3 randomPosition = spawnAreaCenter + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z /2));

        Instantiate(targetPrefab, randomPosition, Quaternion.identity);
    }
}
