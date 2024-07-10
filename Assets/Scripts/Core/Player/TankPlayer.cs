using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class TankPlayer : NetworkBehaviour
{

    [SerializeField] private CinemachineVirtualCamera CinemachineVirtualCamera;
    private int priority = 50;

    public NetworkVariable<FixedString32Bytes> PlayerName = new NetworkVariable<FixedString32Bytes>();

    public static event Action<TankPlayer> OnPlayerSpawned;
    public static event Action<TankPlayer> OnPlayerDespawned;

    [SerializeField] public Health Health;
    [SerializeField] public CoinWallet Wallet;
    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            UserData userData = HostSingleton.Instance.GameManager.networkServer.GetUserDatabyClientId(OwnerClientId);

            PlayerName.Value = userData.userName;

            OnPlayerSpawned?.Invoke(this);
        }


        if (IsOwner)
        {
            CinemachineVirtualCamera.Priority = priority;
        }
    }

    public override void OnNetworkDespawn()
    {
        
        if (IsServer)
        {
            OnPlayerDespawned?.Invoke(this);
        }
    }
}
