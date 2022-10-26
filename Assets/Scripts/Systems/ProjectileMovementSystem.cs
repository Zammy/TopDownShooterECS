using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

[BurstCompile]
partial struct ProjectileMovementSystem : ISystem
{
    const float SPEED = 15f;

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var dt = SystemAPI.Time.DeltaTime;

        foreach (var transform in SystemAPI.Query<TransformAspect>().WithAll<Projectile>())
        {
            transform.Position += transform.Forward * dt * SPEED;
        }
    }
}