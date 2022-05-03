using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    public enum Direction { down, downright, right, upright, up, upleft, left, downleft };

    /// <summary>
    /// Sets the value of a Direction variable according to a given Vector2, to 'down', 'downright', 'right', 'topright', 'top', 'topleft', 'left' or 'downleft'
    /// </summary>
    /// <param name="action"> Reference to a Direction variable that should be set</param>
    /// <param name="inputDirection"> The given input as Vector 2 for setting the direction </param>
    public static void SetActionDirection(ref Enums.Direction action, Vector2 inputDirection)
    {
        switch (inputDirection)
        {
            case Vector2 v when v.Equals(Vector2.down):
                action = Enums.Direction.down;
                break;
            case Vector2 v when v.Equals(new Vector2(0.707107f, -0.707107f)):
                action = Enums.Direction.downright;
                break;
            case Vector2 v when v.Equals(Vector2.right):
                action = Enums.Direction.right;
                break;
            case Vector2 v when v.Equals(new Vector2(0.707107f, 0.707107f)):
                action = Enums.Direction.upright;
                break;
            case Vector2 v when v.Equals(Vector2.up):
                action = Enums.Direction.up;
                break;
            case Vector2 v when v.Equals(new Vector2(-0.707107f, 0.707107f)):
                action = Enums.Direction.upleft;
                break;
            case Vector2 v when v.Equals(Vector2.left):
                action = Enums.Direction.left;
                break;
            case Vector2 v when v.Equals(new Vector2(-0.707107f, -0.707107f)):
                action = Enums.Direction.downleft;
                break;
        }
    }
}
