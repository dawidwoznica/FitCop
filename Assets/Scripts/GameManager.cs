
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {        

        Vector3 objectPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        objectPosition.y = 1;
        mousePositionObject.transform.position = objectPosition;
    }

    public void Reset()
    {
        Destroy(FindObjectOfType<GameManager>());
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    //tochaneg
    public bool isPlayerAlive = true;
    public bool isEnemyAlive = true;
    public GameObject enemyCarObject;
    public Transform enemyGunTransform;
    public Transform playerGunTransform;
    public ParticleSystem vegetableParticle;
    public ParticleSystem explosionParticle;
    public GameObject mousePositionObject;
    public Camera mainCamera;
    public GameObject[] enemyAmmunition;
}
