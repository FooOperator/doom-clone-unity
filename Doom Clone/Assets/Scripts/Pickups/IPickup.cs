using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickup
{
    public string _name { get; set; }
    public string _type { get; set; }
    public float _value { get; set; }
}
