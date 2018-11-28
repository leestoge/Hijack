using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int Points; // set in the unity editor
    public int phishReward; // set in the unity editor
    // some variable to link to the ui element

    public void AwardPhishKill()
    {
        Points += phishReward; // points + the set reward

        // update ui element?
    }
}
