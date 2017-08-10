using UnityEngine;
using System.Collections;

public abstract class Consumable : MonoBehaviour {

    public double duration;
    public double cooldown;
    private double interval;

    public abstract void consume();

}
