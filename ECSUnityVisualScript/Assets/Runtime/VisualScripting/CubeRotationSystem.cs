using System;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;
using Microsoft.CSharp;
using UnityEngine;

public class CubeRotationSystem : ComponentSystem
{
    private Unity.Entities.EntityQuery Cube_Query;
    protected override void OnCreate()
    {
        Cube_Query = GetEntityQuery(ComponentType.ReadWrite<Unity.Transforms.Rotation>(), ComponentType.ReadOnly<CubeRotationComponent>());
    }

    protected override void OnUpdate()
    {
        {
            Entities.With(Cube_Query).ForEach((Unity.Entities.Entity Cube_QueryEntity, ref Unity.Transforms.Rotation Cube_QueryRotation, ref CubeRotationComponent Cube_QueryCubeRotationComponent) =>
            {
                Cube_QueryRotation.Value = math.mul(Cube_QueryRotation.Value, quaternion.AxisAngle(math.normalize(new float3(0F, 1F, 0F)), math.mul(Time.deltaTime, Cube_QueryCubeRotationComponent.speed)));
            }

            );
        }
    }
}