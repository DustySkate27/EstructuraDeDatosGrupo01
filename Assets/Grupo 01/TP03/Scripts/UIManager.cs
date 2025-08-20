using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleListLibrary;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> storeItems;
    [SerializeField] private List<GameObject> playerItems;

    public void sellActivator(int id)
    {
        switch (id)
        {
            case 01100:

                if (storeItems[0].activeSelf == true)
                {
                    break;
                    
                }
                else
                {
                    storeItems[0].SetActive(true);

                    break;


                }

            case 02151:

                if (storeItems[1].activeSelf == true)
                {
                    break;
                }
                else
                {
                    storeItems[1].SetActive(true);
                    break;



                }
            case 03352:

                if (storeItems[2].activeSelf == true)
                {
                    break;
                }
                else
                {
                    storeItems[2].SetActive(true);
                    break;

                }
            case 04503:

                if (storeItems[3].activeSelf == true)
                {
                    break;
                }
                else
                {
                    storeItems[3].SetActive(true);
                    break;

                }
        }
    }

    public void BuyActivator(int id)
    {
        switch (id)
        {
            case 01100:

                if (playerItems[0].activeSelf == true)
                {
                    break;
                }
                else
                {
                    playerItems[0].SetActive(true);
                    break;


                }

            case 02151:

                if (playerItems[1].activeSelf == true)
                {
                    break;
                }
                else
                {
                    playerItems[1].SetActive(true);
                    break;



                }
            case 03352:

                if (playerItems[2].activeSelf == true)
                {
                    break;
                }
                else
                {
                    playerItems[2].SetActive(true);
                    break;

                }
            case 04503:

                if (playerItems[3].activeSelf == true)
                {
                    break;
                }
                else
                {
                    playerItems[3].SetActive(true);
                    break;

                }
        }
    }

    public void BuyDeactivator(int id)
    {
        switch (id)
        {
            case 01100:

                if (storeItems[0].activeSelf == false)
                {
                    break;
                }
                else
                {
                    storeItems[0].SetActive(false);
                    break;


                }

            case 02151:

                if (storeItems[1].activeSelf == false)
                {
                    break;
                }
                else
                {
                    storeItems[1].SetActive(false);
                    break;



                }
            case 03352:

                if (storeItems[2].activeSelf == false)
                {
                    break;
                }
                else
                {
                    storeItems[2].SetActive(false);
                    break;

                }
            case 04503:

                if (storeItems[3].activeSelf == false)
                {
                    break;
                }
                else
                {
                    storeItems[3].SetActive(false);
                    break;

                }
        }
    }

    public void SellDeactivator(int id)
    {
        switch (id)
        {
            case 01100:

                if (playerItems[0].activeSelf == false)
                {
                    break;
                }
                else
                {
                    playerItems[0].SetActive(false);
                    break;


                }

            case 02151:

                if (playerItems[1].activeSelf == false)
                {
                    break;
                }
                else
                {
                    playerItems[1].SetActive(false);
                    break;



                }
            case 03352:

                if (playerItems[2].activeSelf == false)
                {
                    break;
                }
                else
                {
                    playerItems[2].SetActive(false);
                    break;

                }
            case 04503:

                if (playerItems[3].activeSelf == false)
                {
                    break;
                }
                else
                {
                    playerItems[3].SetActive(false);
                    break;

                }
        }
    }
}