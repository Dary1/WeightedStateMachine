using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Human : MonoBehaviour
{
    public SensoredFloat Hunger;
    public SensoredFloat Stamina;
    public WeightedStateMachineManager WeightedStateMachineManager;
    public float HungerSensitivity = 1;
    public float StaminaSensitivity = 1;
    public float MinWeightToWalk = 0.5f;

    public Text NameText;
    public Text CurrentStateText;
    public Image HungerFill;
    public Image StaminaFill;


    public void Start() {
        WeightedStateMachineManager = new WeightedStateMachineManager();

        // eat is binded to hunger
        Hunger = new SensoredFloat(WeightedStateMachineManager.CreateState(new System.Action(()=> this.Eat())), HungerSensitivity);

        // rest is binded to stamina
        Stamina = new SensoredFloat(WeightedStateMachineManager.CreateState(new System.Action(() => this.Rest())), StaminaSensitivity);

        // work has a static weight and not binded to a property
        WeightedStateMachineManager.CreateState(new System.Action(() => this.Work()), MinWeightToWalk);

        NameText.text = this.name;
    }

    private void FixedUpdate()
    {
        WeightedStateMachineManager.Main();
        
        HungerFill.fillAmount = Hunger.Value;
        StaminaFill.fillAmount = Stamina.Value;
    }

    public void Eat() {
        Hunger.Value += 0.4f;
        Stamina.Value += 0.25f;
        CurrentStateText.text = "Eating";
    }

    public void Rest()
    {
        Stamina.Value += 0.25f;
        Hunger.Value -= 0.05f;
        CurrentStateText.text = "Resting";
    }

    public void Work() {
        Hunger.Value -= 0.05f;
        Stamina.Value -= 0.1f;
        CurrentStateText.text = "Working";
    }
}
