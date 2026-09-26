
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class test123 : MonoBehaviour
{
    [SerializeReference, SubclassSelector]
    public IEntityAction action;
    [SerializeReference]
    public List<IEntityAction> actions = new List<IEntityAction>();
}

public interface IEntityAction
{
    IEntityAction Clone { get; }


    string EntityModName { get; set; }

    string ActionName { get; }

    bool DoesUseUpdate { get; }

    void ResetForReuse();
}