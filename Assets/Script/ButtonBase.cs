using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBase : MonoBehaviour
{
    public Button button;
    public virtual void Start()
    {
        LoadComponent();       
        AddonClickEvent();
    }
    public virtual void LoadComponent()
    {      
        LoadButton();
    }

    public virtual void LoadButton()
    {
        if (button != null) return;
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogWarning(transform.name + " does not have a Button component", gameObject);
        }
        else
        {
            Debug.LogWarning(transform.name + " LoadButton", gameObject);
        }
    }

    public virtual void AddonClickEvent()
    {
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
        else
        {
            Debug.LogWarning("Button component is not assigned or found.", gameObject);
        }
    }

    public virtual void OnClick()
    {
        Debug.Log("Button clicked!");
    }

}
