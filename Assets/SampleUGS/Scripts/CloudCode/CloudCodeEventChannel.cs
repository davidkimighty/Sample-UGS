using System;
using System.Threading.Tasks;
using UnityEngine;

namespace SampleUGS.CloudCode
{
    [CreateAssetMenu(fileName = "EventChannel_CloudCode", menuName = "SampleUGS/EventChannel/CloudCode")]
    public class CloudCodeEventChannel : ScriptableObject
    {
        #region Events
        public event Func<string, Task> OnRequestSayHelloAsync = null;

        #endregion

        #region Publishers
        public async Task RequestSayHelloAsync(string name)
        {
            if (OnRequestSayHelloAsync != null)
                await OnRequestSayHelloAsync.Invoke(name);
        }
    
        #endregion
    }
}