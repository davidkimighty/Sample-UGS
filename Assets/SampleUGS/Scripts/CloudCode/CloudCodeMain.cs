using System;
using SampleUGS.Authentication;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;

namespace SampleUGS.CloudCode
{
    public class CloudCodeMain : MonoBehaviour
    {
        #region Variable Field

        private const string ProductionEnv = "production";
        private const string DevelopmentEnv = "development";
        
        [SerializeField] private bool isDevelopment;
        [SerializeField] private AuthenticationEventChannel authenticationEventChannel;
        [SerializeField] private CloudCodeEventChannel cloudCodeEventChannel;

        #endregion

        private async void Awake()
        {
            try
            {
                InitializationOptions options = new InitializationOptions();
                options.SetEnvironmentName(isDevelopment ? DevelopmentEnv : ProductionEnv);
                await UnityServices.InitializeAsync(options);
                await authenticationEventChannel.RequestSignInAnonymouslyAsync();
                
                await cloudCodeEventChannel.RequestSayHelloAsync("World");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
