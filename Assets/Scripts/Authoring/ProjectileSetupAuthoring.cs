using Unity.Entities;
using UnityEngine;

class ProjectileSetupAuthoring : MonoBehaviour
{
    public GameObject Prefab;
}

class ProjectileSetupBaker : Baker<ProjectileSetupAuthoring>
{
    public override void Bake(ProjectileSetupAuthoring authoring)
    {
        AddComponent(new ProjectileSpawner
        {
            Prefab = GetEntity(authoring.Prefab)
        });
    }
}

struct ProjectileSpawner : IComponentData
{
    public Entity Prefab;
}