using context;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using TestGame.Signals;
using UnityEngine;

public class TestRoot : ContextView
{
    [SerializeField] private EnemySettings _enemySettings;

    private TestContext _testGameContext;
    void Awake()
    {
        _testGameContext = new TestContext(this, ContextStartupFlags.MANUAL_MAPPING);
        _testGameContext.EnemySettings = _enemySettings;
        context = _testGameContext;
        context.Start();
    }
}