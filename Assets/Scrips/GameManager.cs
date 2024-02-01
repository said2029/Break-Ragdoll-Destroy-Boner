using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Player Configer
    public bool is_Player_Death = false;

    // game manage
    public int level = 1;
    public int FakeLevel = 1;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
        }
        if (PlayerPrefs.HasKey("FakeLevel"))
        {
            FakeLevel = PlayerPrefs.GetInt("FakeLevel");
        }

        UI_Manager.instance.Settext();

        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(level);
        UI_Manager.instance.SplashScreen.SetActive(false);


    }

}
