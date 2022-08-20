﻿using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools;

public class ObjectPool : EntityPool<IObject>
{
    public ObjectPool(IEntityFactory<IObject> objectFactory) : base(objectFactory)
    {
    }

    protected override ushort GetId(IntPtr objectPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.Object_GetID(objectPointer);
        }
    }
}