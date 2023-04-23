using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NewOrderGenerator : MonoBehaviour
{

    public TextMeshProUGUI orderText;

    //presets of variables

    bool red_sauce = false;
    bool cheese = false;
    bool pepperoni = false;
    bool mushroom = false;
    bool olive = false;
    string order = "";


    //called everytime button is pressed
    public void ButtonPressed()
    {
        GenerateNewOrder();
        orderText.GetComponent<TextMeshProUGUI>().text = "Please make me a pizza with: \n" + order;
    }


    //random booleans to generate new order
    public void GenerateNewOrder()
    {
        BooleanGenerator boolGen = new BooleanGenerator();

        red_sauce = boolGen.NextBoolean();
        cheese = boolGen.NextBoolean();
        pepperoni = boolGen.NextBoolean();
        mushroom = boolGen.NextBoolean();
        olive = boolGen.NextBoolean();

        printNewOrder(red_sauce, cheese, pepperoni, mushroom, olive);
    }

    //prints true items in list
    public void printNewOrder(bool r_s, bool ch, bool p, bool m, bool o)
    {
        if (r_s) { order = order + "\nRed Sauce"; }
        else { order = order + "\nGreen Sauce"; }
        if (ch) { order = order + "\nCheese"; }
        if (p) { order = order + "\nPepperoni"; }
        if (m) { order = order + "\nMushroom"; }
        if (o) { order = order + "\nOlive"; }
    }

    public class BooleanGenerator
    {
        System.Random rnd;

        public BooleanGenerator()
        {
            rnd = new System.Random();
        }

        public bool NextBoolean()
        {
            return rnd.Next(0, 2) == 1;
        }
    }

}
