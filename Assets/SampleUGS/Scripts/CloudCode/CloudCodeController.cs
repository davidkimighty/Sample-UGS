using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.CloudCode;
using UnityEngine;

namespace SampleUGS.CloudCode
{
    [DefaultExecutionOrder(-100)]
    public class CloudCodeController : MonoBehaviour
    {
        #region Variable Field

        private const string ModuleName = "Sample_UGS_CloudCode";

        [SerializeField] private CloudCodeEventChannel eventChannel;

        #endregion

        private void OnEnable()
        {
            eventChannel.OnRequestSayHelloAsync += SayHello;
        }

        private void OnDisable()
        {
            eventChannel.OnRequestSayHelloAsync -= SayHello;
        }

        #region Subscribers

        private async Task SayHello(string name)
        {
            string result = await CloudCodeService.Instance.CallModuleEndpointAsync(ModuleName, CloudCodeFunctions.SayHello.ToString(),
                new Dictionary<string, object>
                {
                    {"name", name}
                });
            Debug.Log($"[ CloudCode ] {result}");
        }

        #endregion
    }
    
    public enum CloudCodeFunctions
    {
        None,
        SayHello
    }
}
