using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEventArgs : System.EventArgs
{
    public abstract int Id { get; }

    public abstract void Clear();
}
