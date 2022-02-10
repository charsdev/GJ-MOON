using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField] private GameObject moonrakerGUI;
    [SerializeField] private GameObject fragmentsWarning;
    [SerializeField] private GameObject winMessage;
    [SerializeField] private TMP_Text peopleCount;
    [SerializeField] private Image fragmentsGUI;
    [SerializeField] private TMP_Text fragmentsCountUI;
    [SerializeField] private GameObject VisualGuide;
    [SerializeField] private GameObject maxAmoutWarning;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject shopAlt;
    [SerializeField] private Button drinkButton;
    [SerializeField] private Button drinkButtonAlt;
    [SerializeField] private bool staffState;
    [SerializeField] private GameObject staff;
    [SerializeField] private TMP_Text fragmentsDeliveredStaffCountUI;
    [SerializeField] private GameObject staffMessage;
    
    [Header("Values")]
    [SerializeField] private float fragments = 0.00f;
    [SerializeField] private int healedPeople = 0;
    [SerializeField] private int peopleToHelp = 15;
    //[SerializeField] private int explosiveForce = 10;
    //[SerializeField] private int explosionRadius = 3;
    [SerializeField] private GameObject[] villagersSaved;
    [SerializeField] private GameObject houseToRemove;
    private EnemyAI[] enemiesToDelete;
    [SerializeField] private GameObject soundToActivate;
    [SerializeField] private int moonlightFragmentsDelivered = 0;
    [SerializeField] private int targetAmount = 0;
    private void Start()
    {
        moonrakerGUI.SetActive(false);
        fragmentsWarning.SetActive(false);
        winMessage.SetActive(false);
        fragmentsDeliveredStaffCountUI.text =
                    "Moonlight Fragments Delivered: " + moonlightFragmentsDelivered + "/" + targetAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fragment"))
        {
            if(fragments < 1.00f)
            {
                Destroy(other.gameObject);
                fragments += 0.10f;
                fragmentsGUI.fillAmount = fragments;
                soundToActivate.SetActive(true);
            }
            else
            {
                maxAmoutWarning.SetActive(true);
                //other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, Vector3.forward, explosionRadius);
            }
        }
        else if (other.CompareTag("moonraker"))
        {
            moonrakerGUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) && other.CompareTag("moonraker"))
            {
                if (fragments < 1.00f)
                {
                    fragmentsWarning.SetActive(true);
                }
                else
                {
                    if (!staffState)
                    {
                        if (gameObject.GetComponent<Health>().currentHealth == gameObject.GetComponent<Health>().maxHealth)
                        {
                            drinkButtonAlt.interactable = false;
                        }
                        else
                        {
                            drinkButtonAlt.interactable = true;
                        }
                        shopAlt.SetActive(true);
                    }
                    else
                    {
                        if (gameObject.GetComponent<Health>().currentHealth == gameObject.GetComponent<Health>().maxHealth)
                        {
                            drinkButton.interactable = false;
                        }
                        else
                        {
                            drinkButton.interactable = true;
                        }
                        shop.SetActive(true);
                    }
                    Time.timeScale = 0.0f;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Physics.autoSimulation = false;
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F) && other.CompareTag("moonraker"))
        {
            if (fragments < 1.00f)
            {
                fragmentsWarning.SetActive(true);
            }
            else
            {
                if (!staffState)
                {
                    if (gameObject.GetComponent<Health>().currentHealth == gameObject.GetComponent<Health>().maxHealth)
                    {
                        drinkButtonAlt.interactable = false;
                    }
                    else
                    {
                        drinkButtonAlt.interactable = true;
                    }
                    shopAlt.SetActive(true);
                }
                else
                {
                     if (gameObject.GetComponent<Health>().currentHealth == gameObject.GetComponent<Health>().maxHealth)
                     {
                         drinkButton.interactable = false;
                     }
                     else
                     {
                         drinkButton.interactable = true;
                     }
                     shop.SetActive(true);
                }
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Physics.autoSimulation = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        moonrakerGUI.SetActive(false);
        fragmentsWarning.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(fragments >= 1.00f)
        {
            VisualGuide.SetActive(true);
        }
        peopleCount.text = "People Healed: " + healedPeople + "/" + peopleToHelp;
        fragmentsCountUI.text = ((int)(fragments * 10.000f)).ToString();
    }

    public void lose()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Physics.autoSimulation = false;
        foreach (EnemyAI enemy in enemiesToDelete)
        {
            Destroy(enemy.gameObject);
        }
    }

    public void RemoveFragment()
    {
        fragments = 0.00f;
        fragmentsGUI.fillAmount = fragments;
    }

    public void HelpVillager()
    {
        RemoveFragment();
        VisualGuide.SetActive(false);
        healedPeople += 1;
        villagersSaved[healedPeople - 1].gameObject.SetActive(true);
        if (healedPeople == 2)
        {
            houseToRemove.SetActive(false);
        }

        if (healedPeople == peopleToHelp)
        {
            winMessage.SetActive(true);
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Physics.autoSimulation = false;
            enemiesToDelete = FindObjectsOfType<EnemyAI>();
            foreach (EnemyAI enemy in enemiesToDelete)
            {
                Destroy(enemy.gameObject);
            }
        }
    }

    public bool GetStaffState()
    {
        return staffState;
    }
    
    public void SetStaffState(bool state)
    {
        staffState = state;
    }

    public void ShowStaff()
    {
        staff.SetActive(true);
    }

    public void FragmentsDelivered()
    {
        moonlightFragmentsDelivered += 10;
        RemoveFragment();
        fragmentsDeliveredStaffCountUI.text =
            "Moonlight Fragments Delivered: " + moonlightFragmentsDelivered + "/" + targetAmount;
        if (moonlightFragmentsDelivered == targetAmount)
        {
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Physics.autoSimulation = false;
            staffMessage.SetActive(true);
            ShowStaff();
            SetStaffState(true);
        }
    }
}