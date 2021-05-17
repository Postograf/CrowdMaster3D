using UnityEngine;

public class MoveTransition : PlayerTransition
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            NeedTransit = true;
    }
}
