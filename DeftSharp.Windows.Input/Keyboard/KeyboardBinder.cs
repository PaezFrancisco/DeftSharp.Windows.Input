﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DeftSharp.Windows.Input.Keyboard.Interceptors;

namespace DeftSharp.Windows.Input.Keyboard;

public sealed class KeyboardBinder : IKeyboardBinder
{
    private readonly KeyboardBinderInterceptor _keyboardBinder = KeyboardBinderInterceptor.Instance;
    public IReadOnlyDictionary<Key, Key> BoundedKeys => _keyboardBinder.BoundedKeys;

    public bool IsKeyBounded(Key key) => _keyboardBinder.IsKeyBounded(key);
    public void Bind(Key oldKey, Key newKey) => _keyboardBinder.Bind(oldKey, newKey);

    public void Bind(IEnumerable<Key> keys, Key newKey)
    {
        foreach (var oldKey in keys.Distinct())
            Bind(oldKey, newKey);
    }

    public void Swap(Key first, Key second)
    {
        Bind(first, second);
        Bind(second, first);
    }

    public void Unbind(Key key) => _keyboardBinder.Unbind(key);

    public void Unbind(IEnumerable<Key> keys)
    {
        foreach (var key in keys.Distinct())
            Unbind(key);
    }

    public void UnbindAll() => _keyboardBinder.UnbindAll();
}