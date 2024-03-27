﻿using System;
using System.Collections.Generic;
using DeftSharp.Windows.Input.Mouse;

namespace DeftSharp.Windows.Input.Shared.Abstraction.Mouse;

public interface IMouseManipulator : IDisposable
{
    IEnumerable<MouseInputEvent> LockedKeys { get;}
    
    event Action<MouseInputEvent> InputPrevented;
    
    bool IsKeyLocked(MouseInputEvent mouseEvent);
    
    void SetPosition(int x, int y);
    void Click(int x, int y, MouseButton button = MouseButton.Left);
    void Click(MouseButton button = MouseButton.Left);

    void DoubleClick(int x, int y);
    void DoubleClick();

    void Scroll(int scrollAmount);
    
    void Prevent(PreventMouseOption mouseEvent);
    void Release(PreventMouseOption mouseEvent);
    void ReleaseAll();
}