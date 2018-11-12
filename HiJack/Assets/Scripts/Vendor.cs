using UnityEngine;
using UnityEngine.UI;

public class Vendor : MonoBehaviour
{
    public Button Button;
    public GameObject Player;
    public GameObject canvas; // should make seperate canvas to not interfere with screen fade etc.


    private bool _triggeringPlayer;
    private bool _shopEnabled;

    public GameObject Item;
    public int Price;

    public void Start()
    {
        var btn = Button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void Update()
    {
        if (_shopEnabled)
        {
            canvas.SetActive(true); 
        }
        else
        {
            canvas.SetActive(false);
        }
        if (_triggeringPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _shopEnabled = !_shopEnabled;
            }
        }
    }

    public void TaskOnClick()
    {
        if (_shopEnabled)
        {
            Sell();
        }
    }

    public void Sell()
    {
        if (Player.GetComponent<PlayerPoints>().Points >= Price)
        {
            Transform itemSpawn = Instantiate(Item.transform, Player.transform.position, Quaternion.identity);
            itemSpawn.gameObject.SetActive(false);
            itemSpawn.parent = Player.transform;

            Player.GetComponent<PlayerPoints>().Points -= Price;
        }
        else
        {
            print("You don't have enough points.");

            // voiceline probably.
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _triggeringPlayer = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _triggeringPlayer = false;
        }
    }
}
