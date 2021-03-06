﻿using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Jobs;
using System.Collections.Generic;
using UnityEngine;

namespace E7.ECS
{
    public static class ActiveWorld
    {
        public static EntityManager EntityManager => World.Active.GetExistingManager<EntityManager>();

        public static void Issue<ReactiveComponent,ReactiveGroup>()
        where ReactiveComponent : struct, IMessage
        where ReactiveGroup : struct, IMessageGroup
        => World.Active.GetExistingManager<EntityManager>().Message<ReactiveComponent, ReactiveGroup>();

        public static Entity CreateEntityWithComponentData<T>( T componentData)
        where T : struct, IComponentData 
        {
            var em = ActiveWorld.EntityManager;
            Entity e = em.CreateEntity();
            em.AddComponentData<T>(e, componentData);
            return e;
        }
    }
}