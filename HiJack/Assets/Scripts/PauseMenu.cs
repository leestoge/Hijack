using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject GameMenuHUD;

    // Update is called once per frame
    void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameMenuHUD.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameMenuHUD.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
    }
}
