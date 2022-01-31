using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private GameObject VisualGuide;
    
    [Header("Values")]
    [SerializeField] private float fragments = 0.00f;
    [SerializeField] private int healedPeople = 0;
    [SerializeField] private int peopleToHelp = 15;
    

    private void Start()
    {
        moonrakerGUI.SetActive(false);
        fragmentsWarning.SetActive(false);
        winMessage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fragment"))
        {
            if(fragments < 1.00f)
            {
                fragments += 0.10f;
                fragmentsGUI.fillAmount = fragments;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("moonraker"))
        {
            moonrakerGUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (fragments < 1f)
                {
                    fragmentsWarning.SetActive(true);
                }
                else
                {
                    fragments = 0.00f;
                    VisualGuide.SetActive(false);
                    healedPeople += 1;
                    if (healedPeople == peopleToHelp)
                    {
                        winMessage.SetActive(true);
                    }
                }
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
    }
}
