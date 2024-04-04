using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class BossFightAndHouseHandler : MonoBehaviour
{
    public bool hasKey, fightOn;
    [SerializeField] public CinemachineVirtualCamera virtualcamera;
    private BearBossController bearBossController;
    private readonly float defaultCameraDistance = 10;
    private DuckController duckController;
    private readonly Vector3 insideFight = new(-137, 11, -313);
    private Vector3 outsideFight = new(-128, 11, -286);
    private readonly Vector3 startFight = new(-144, 11, -340);

    private void Start()
    {
        if (virtualcamera is null) Debug.LogWarning("Boss fight missing cinemachine camera.");
    }

    //Detect entering and exiting water.
    private void OnTriggerEnter(Collider other)
    {
        if (!CompareTag("Player")) return;
        if (other.CompareTag("House")) HandleHouseEntry();
        if (other.CompareTag("BossDoor")) HandleFightDoor();
    }

    public void GiveKey()
    {
        duckController.ShowText("You received the key! Return to the house to get home!", 5f);
        hasKey = true;
        fightOn = false;
        duckController.SwitchMusic(duckController.normalMusic);
        RevertDistance();
    }

    public void RegisterController(DuckController controller)
    {
        duckController = controller;
        bearBossController = FindObjectOfType<BearBossController>();
        bearBossController.RegisterHouseHandler(this);
    }

    // UnityEditor.TransformWorldPlacementJSON:{"position":{"x":-144.0,"y":10.931933403015137,"z":-340.44000244140627},"rotation":{"x":0.0,"y":-0.674971878528595,"z":0.0,"w":0.7378434538841248},"scale":{"x":2.0,"y":2.0,"z":2.0}}
    private void HandleHouseEntry()
    {
        if (!hasKey)
            duckController.ShowText("The house is locked! Follow the orange trees to the key.", 2f);
        else
        {
            duckController.SwitchMusic(duckController.victoryMusic);
            SceneManager.LoadScene(3);
        }
    }

    private void HandleFightDoor()
    {
        // Start Fight
        if (!fightOn && !hasKey)
        {
            IncreaseDistance();

            fightOn = true;
            duckController.Stun(5f);
            duckController.agent.Warp(startFight);

            var ducklings = FindObjectsOfType<DucklingController>();
            foreach (var duckling in ducklings) duckling.agent.Warp(startFight);

            duckController.attackRange *= 3;
            
            duckController.SwitchMusic(duckController.bossMusic);

            duckController.ShowText("You hear rumbling from below...", 5f);
            bearBossController.gameObject.SetActive(true);
            bearBossController.enabled = true;
            return;
        }

        if (fightOn && !bearBossController.IsDead())
        {
            duckController.agent.Warp(insideFight);
            duckController.ShowText("The Bear has trapped you inside!", 1f);
        }
    }

    public void IncreaseDistance()
    {
        if (virtualcamera == null) return;

        var componentBase = virtualcamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        if (componentBase is CinemachineFramingTransposer)
        {
            (componentBase as CinemachineFramingTransposer).m_CameraDistance = 20; // your value
        }
    }

    public void RevertDistance()
    {
        if (virtualcamera == null) return;
        var componentBase = virtualcamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        if (componentBase is CinemachineFramingTransposer)
            (componentBase as CinemachineFramingTransposer).m_CameraDistance = defaultCameraDistance; // your value
    }
}