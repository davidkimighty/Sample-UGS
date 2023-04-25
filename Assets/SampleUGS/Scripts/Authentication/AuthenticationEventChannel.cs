using System;
using System.Threading.Tasks;
using UnityEngine;

namespace SampleUGS.Authentication
{
    [CreateAssetMenu(fileName = "EventChannel_Authentication", menuName = "SampleUGS/EventChannel/Authentication")]
    public class AuthenticationEventChannel : ScriptableObject
    {
        #region Events
        public event Func<Task> OnRequestSignInAnonymouslyAsync = null;

        #endregion

        #region Publishers
        public async Task RequestSignInAnonymouslyAsync()
        {
            if (OnRequestSignInAnonymouslyAsync != null)
                await OnRequestSignInAnonymouslyAsync.Invoke();
        }
    
        #endregion
    }
}
