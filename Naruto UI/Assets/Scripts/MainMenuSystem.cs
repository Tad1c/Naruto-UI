using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Linq;

public class MainMenuSystem : MonoBehaviour
{

    [SerializeField] private List<GameObject> pages;


    public GameObject backHomeButtons;

    private GameObject currentPage;
    private Stack<GameObject> previousPages = new Stack<GameObject>();

    private void Start()
    {
        //Just to be sure that all pages are deactivated
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(false);
        }

        pages[0].SetActive(true); //setting our mainmenu to be active at the beginning

        backHomeButtons.SetActive(false);
        previousPages.Push(pages[0]);
        currentPage = pages[0]; //set the current page to be mainmenu
    }

    //This method is triggered by button trigger
    public void OpenPage(int newPage)
    {
        for (int i = 0; i < pages.Count; i++)
        {
            if (i == newPage)
            {
                OpenCurrentPage(pages[i]);
            }
        }
    }

    public void BackButton()
    {
        //At this stage we just get the latest page from our stack and close it
        OpenCurrentPage(previousPages.Peek(), true);
    }

    public void HomeButton()
    {
        previousPages.Clear();
        OpenCurrentPage(pages[0]);
    }

    private void OpenCurrentPage(GameObject newPage, bool isGoingBack = false)
    {

        //If we have selected the same page but we are in already just do nothing.
        //if (currentPage == newPage)
        //    return;


        if (!isGoingBack)
            previousPages.Push(newPage); //puhsing the new page in our stack
        else
            previousPages.Pop(); //poping the lates page in our stack

        if (previousPages.Count > 1)
            backHomeButtons.SetActive(true);
        else
            backHomeButtons.SetActive(false);

        //Setting the current page to be disable
        currentPage.SetActive(false);

        //Setting the newPage to be our currentPage
        currentPage = previousPages.Peek();

        //Activating our new currentPage
        currentPage.SetActive(true);
    }
}
