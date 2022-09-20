using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickupSpawner : ObjectPool<PickupItem> {
    [SerializeField] private Vector2 xRange;
    [SerializeField] private Vector2 yRange;
    [SerializeField] private int initialSpawnCount = 2;
    [SerializeField] private int maxSpawnCount = 10;
    [SerializeField] private float spawnInterval = 2;

    private int _currentMax = 0;
    private int _activePickups = 0;
    private bool cooldown = false;
    
    private void Start() {
        _currentMax = initialSpawnCount;
        StartCoroutine(ChangeSpawnCount(maxSpawnCount));
    }
    
    private IEnumerator ChangeSpawnCount(int newCount) {
        for (int i = initialSpawnCount; i < newCount; i++) {
            yield return new WaitForSeconds(spawnInterval/2);
            _currentMax = i;
        }
    }

    private void Update() {
        if (cooldown) return;
        if (_activePickups == _currentMax) {
            cooldown = true;
            StartCoroutine(BeginCooldown());
            return;
        }
        SpawnNewPoint();
    }
    
    private void SpawnNewPoint() {
        _activePickups++;
        float x = Random.Range(xRange.x, xRange.y);
        float y = Random.Range(yRange.x, yRange.y);
        var pickupItem = GetNewObject();
        pickupItem.gameObject.transform.localPosition = new Vector3(x, y);
        pickupItem.Init();
    }

    private IEnumerator BeginCooldown() {
        yield return new WaitForSeconds(spawnInterval);
        cooldown = false;
    }

    public override void RemoveObject(PickupItem obj) {
        base.RemoveObject(obj);
        _activePickups--;
    }
}