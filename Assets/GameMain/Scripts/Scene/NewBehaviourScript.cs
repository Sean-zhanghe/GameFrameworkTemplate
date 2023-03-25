using UnityEngine;
using GameFramework.Event;
using UnityGameFramework.Runtime;
using StarForce;

public class NewBehaviourScript : MonoBehaviour
{
    private EntityLoader entityLoader;

    // Start is called before the first frame update
    void Start()
    {
        StarForce.GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
        StarForce.GameEntry.Event.Subscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);

        entityLoader = EntityLoader.Create(this);

        entityLoader.ShowEntity<EntityLogicEx>(EnumEntity.Player, null);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StarForce.GameEntry.Sound.PlaySound(20001);
        }
    }

    protected virtual void OnShowEntitySuccess(object sender, GameEventArgs e)
    {
        ShowEntitySuccessEventArgs ne = (ShowEntitySuccessEventArgs)e;
    }

    protected virtual void OnShowEntityFailure(object sender, GameEventArgs e)
    {
        ShowEntityFailureEventArgs ne = (ShowEntityFailureEventArgs)e;
        Log.Warning("Show entity failure with error message '{0}'.", ne.ErrorMessage);
    }
}
