using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSystem : MonoBehaviour
{

    [SerializeField] private List<GameObject> pages;

    private GameObject currentPage;

    private void Start()
    {
        //Just to be sure that all pages are deactivated
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(false);
        }

        pages[0].SetActive(true); //setting our mainmenu to be active at the beginning

        currentPage = pages[0]; //set the current page to be mainmenu
    }

    //This method is triggered by button trigger
    public void OpenPage(int newPage)
    {
        for (int i = 0; i < pages.Count; i++)
        {
            if (i == newPage)
                OpenCurrentPage(pages[i]);
        }
    }

    private void OpenCurrentPage(GameObject newPage)
    {

        //If we have selected the same page but we are in already just do nothing.
        if (currentPage == newPage)
            return;

        //Setting the current page to be disable
        currentPage.SetActive(false);

        //Setting the newPage to be our currentPage
        currentPage = newPage;

        //Activating our new currentPage
        currentPage.SetActive(true);
    }
}
