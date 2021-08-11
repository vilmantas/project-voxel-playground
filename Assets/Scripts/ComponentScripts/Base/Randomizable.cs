using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Randomizable : MonoBehaviour, IRandomizable
{
    public IRandomizableState State { get; set; }

    public int IsAdded { get; set; }

    public void Randomize()
    {
        if (ValidateState())
        {
            DoRandomize();
        }

        State.WasRandomized = true;
    }

    public bool ValidateState()
    {
        if (!DoInitializationCheck())
        {
            DoInitialization();
        }

        return DoStateValidCheck();
    }

    public abstract void DoRandomize();

    public abstract void DoInitialization();

    public abstract bool DoStateValidCheck();

    public abstract bool DoInitializationCheck();


}

public interface IRandomizable
{
    IRandomizableState State { get; set; }

    public int IsAdded { get; set; }

    void DoRandomize();

    void DoInitialization();
}

public interface IRandomizableState
{
    bool WasRandomized { get; set; }
}
