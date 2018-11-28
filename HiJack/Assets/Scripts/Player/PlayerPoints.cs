using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    public int Points; // set in the unity editor
    public int phishReward; // set in the unity editor
    public Text HUD_element; // variable to link to the ui element

    void Start()
    {
        HUD_element.text = Points.ToString();
    }

    public void AwardPhishKill()
    {
        Points += phishReward; // points + the set reward

        HUD_element.text = Points.ToString(); // update ui element
    }
}
