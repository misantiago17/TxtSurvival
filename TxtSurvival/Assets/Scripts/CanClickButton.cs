using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanClickButton : MonoBehaviour
{
    public Resource Resource;

    public float MinimumQuantity;

    private void Update() {

        if (Resource.quantity >= MinimumQuantity) {
            this.GetComponent<Button>().interactable = true;
        } else {
            this.GetComponent<Button>().interactable = false;
        }

    }
}
