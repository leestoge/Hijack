using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused;

    public GameObject pauseMenuUI;
    public GameObject GameMenuHUD;
    /* public float xMouseSensitivity = 50.0f;
    public float yMouseSensitivity = 50.0f;
    private float rotX;
    private float rotY; */

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
        /* xMouseSensitivity = 50.0f;
        yMouseSensitivity = 50.0f;
        rotX -= Input.GetAxisRaw("Mouse Y") * xMouseSensitivity * 0.02f;
        rotY += Input.GetAxisRaw("Mouse X") * yMouseSensitivity * 0.02f; */
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameMenuHUD.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        /* xMouseSensitivity = 0f;
        yMouseSensitivity = 0f;
        rotX -= Input.GetAxisRaw("Mouse Y") * xMouseSensitivity * 0f;
        rotY += Input.GetAxisRaw("Mouse X") * yMouseSensitivity * 0f; */
    }
}
