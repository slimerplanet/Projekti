using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<tabButton> tabbuttons;

    public Color tabidle;
    public Color tabHover;
    public Color tabactive;
    public tabButton selectedTab;
    public List<GameObject> objectsToSwap;

    public void Subscribe(tabButton button)
    {
        if (tabbuttons == null)
        {
            tabbuttons = new List<tabButton>();
        }

        tabbuttons.Add(button);
    }

    public void OnTabEnter(tabButton button)
    {
        ResetTabs();
        if(selectedTab == null || button != selectedTab)
            button.background.color = tabHover;
    }

    public void OnTabExit(tabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(tabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.color = tabactive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            if(i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (tabButton button in tabbuttons)
        {
            if(selectedTab != null && button == selectedTab) { continue; }
            button.background.color = tabidle;
        }
    }

}
