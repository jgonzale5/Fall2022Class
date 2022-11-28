using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArsenalScript : MonoBehaviour
{
    public GameObject[] weapons;
    public int selectedWeapon;
    public bool[] activeWeapons;

    // Start is called before the first frame update
    void Start()
    {
        activeWeapons = new bool[weapons.Length];
        selectedWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //float wheel = Input.GetAxis("Mouse ScrollWheel");
        //int possibleSelection = selectedWeapon + (int)wheel;

        int possibleSelection = -1;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            possibleSelection = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            possibleSelection = 1;
        }

        //If the new selection is between 0 and length-1
        if (possibleSelection < weapons.Length && possibleSelection >= 0)
        {
            Debug.Log(possibleSelection);
            //update the selected weapon
            selectedWeapon = possibleSelection;
            //show the appropiate weapon
            SelectWeapon(selectedWeapon);
        }
    }

    public void SelectWeapon(int newSelection)
    {
        for (int n = 0; n < weapons.Length; n++)
        {
            weapons[n].SetActive(false);
        }
        weapons[selectedWeapon].SetActive(true);   
    }
}
