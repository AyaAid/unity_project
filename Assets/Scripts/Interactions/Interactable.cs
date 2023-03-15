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
    private bool canBeUsed;

    [SerializeField]
    private bool locked;

    private static int s_Liste = 0;

    public string InteractionText;

    public void Interact()
    {
        if (!locked && canBeUsed && s_Liste == 3)
        {
            m_OnInteract.Invoke();
            s_Liste = -1;
        }
        if (locked && !canBeUsed)
        {
            return;
        }
        else
        {
            if (m_IsOnce)
                canBeUsed = false;

            s_Liste += 1;
            Debug.Log(s_Liste);
            if (s_Liste > 3)
                s_Liste = -1;
        }

        if (locked && s_Liste == 3)
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
    public void Update()
    {
        if (locked && !canBeUsed && s_Liste == 3)
        {
            canBeUsed = true;
            locked = false;
        }
    }
}