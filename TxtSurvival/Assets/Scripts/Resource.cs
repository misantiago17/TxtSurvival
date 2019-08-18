using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour { 

    public string Name;

    public bool hasMaxCapacity = false;
    public float MaxCapacity;

    public bool hasProfitPerSecond = false;
    public float ProfitPerSecond;
    private float TimerProfitPerSecond;

    public bool hasItemPerTime = false;
    public float QuantityItem;
    public float Seconds;
    private float TimerItemPerTime;

    public Text counter;

    [HideInInspector] public float quantity;

    private void Update() {

        TimerProfitPerSecond += Time.deltaTime;
        TimerItemPerTime += Time.deltaTime;

        if (hasProfitPerSecond && TimerProfitPerSecond >= 1.0f) {
            TimerProfitPerSecond = 0;
            addCounter(ProfitPerSecond);
        }

        if (hasItemPerTime && TimerItemPerTime >= Seconds) {
            addCounter(QuantityItem);
        }

    }

    // Disable MaxCapacity & Profit per Second

    public void addItemPerSecond(float seconds) {

        if (!this.gameObject.activeSelf)
            this.gameObject.SetActive(true);

        if (!hasItemPerTime)
            hasItemPerTime = true;

        QuantityItem = 1;
        Seconds = seconds;
    }

    public void addProfitPerSecond(float value) {

        if (!this.gameObject.activeSelf)
            this.gameObject.SetActive(true);

        if (!hasProfitPerSecond)
            hasProfitPerSecond = true;

        ProfitPerSecond += value;
    }

    public void addMaxCapacity(float value) {

        if (!this.gameObject.activeSelf)
            this.gameObject.SetActive(true);

        if (!hasMaxCapacity)
            hasMaxCapacity = true;

        MaxCapacity += value;
    }

    // Add & Remove
    public void addCounter(float value) {

        if (!this.gameObject.activeSelf)
            this.gameObject.SetActive(true);

        quantity += value;

        if (hasMaxCapacity && (quantity < MaxCapacity))
            quantity = MaxCapacity;

        updateText();
    }

    public void RemoveCounter(float value) {

        quantity -= value;

        updateText();
    }


    // Texto
    private void updateText() {
    
        string text = Name + ": " + quantity.ToString("F0");

        if (hasMaxCapacity)
        {
            text.Insert(text.Length, "/" + MaxCapacity.ToString("F2"));
        }

        if (hasProfitPerSecond)
        {
            text.Insert(text.Length, "(" + ProfitPerSecond.ToString("F2") + "/sec)");
        }


        counter.text = text;
    }


}
