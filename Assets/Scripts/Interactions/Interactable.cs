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

    [SerializeField]
    private bool locked = false;

    public int liste;

    public string InteractionText;

    public void Interact()
    {
        if (locked && !canBeUsed && liste == 3)
        {
            canBeUsed = true;
            locked = false;
            m_OnInteract.Invoke();
        }
        else if (locked || !canBeUsed)
        {
            return;
        }
        else
        {
            if (m_IsOnce)
                canBeUsed = false;

            liste += 1;
            Debug.Log(liste);
            if (liste > 3)
                liste = 3;
        }

        if (locked && liste == 3)
            locked = false;
    }

    public bool GetUsable()
    {
        return canBeUsed && !locked;
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
