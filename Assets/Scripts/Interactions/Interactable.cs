using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private UnityEvent m_OnInteract;

    [SerializeField]
    private bool m_IsOnce = false;

    [SerializeField]
    private bool canBeUsed = true;

    public string InteractionText;

    public int liste = 0;

    public void Interact()
    {
        if (liste == 3 && !canBeUsed)
        {
            SetUsable(true);
        }

        if (!canBeUsed)
        {
            
            return;
        }

        if (m_IsOnce && liste < 3)
        {
            liste += 3;
            Debug.Log(liste);
            canBeUsed = false;
            m_IsOnce = false;
        }

        
        
    }

    public bool GetUsable()
    {
        return canBeUsed;
    }

    public void SetUsable(bool truth)
    {
        canBeUsed = truth;
        
    }

    public void SetText(string text)
    {
        InteractionText = text;
    }

    public UnityEvent GetInteractEvent()
    {
        
        return m_OnInteract;
    }
}
