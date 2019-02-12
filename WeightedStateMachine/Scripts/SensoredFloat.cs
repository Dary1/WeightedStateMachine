using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SensoredFloat
{
    float _value = 0;    
    public float Value { get { return _value; }
        set {
            if (_value != value){
                float previousValue = _value;
                _value = value;
                SensorDetected?.Invoke(previousValue);
            }
        }
    }

    delegate void SensorEventHandler(float previousValue);
    event SensorEventHandler SensorDetected;

    public WeightedState bindedWeightedState;

    public float Sensitivity = 1;

    public SensoredFloat(WeightedState WeightedStateBindedTo, float sensitivity) {
        bindedWeightedState = WeightedStateBindedTo;
        SensorDetected += Sensor_SensorDetected;
        Sensitivity = sensitivity;
    }
    
    

    private void Sensor_SensorDetected(float previousValue)
    {
        bindedWeightedState.Weight += (Value - previousValue) * Sensitivity;
    }
}
