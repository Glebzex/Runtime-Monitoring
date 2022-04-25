using System;
using Baracuda.Monitoring.Management;
using UnityEngine.Scripting;

namespace Baracuda.Monitoring
{
    /// <summary>
    /// Mark a Field or Property to be monitored at runtime.
    /// When monitoring non static members, instances of the monitored class must be registered and unregistered
    /// when they are created and destroyed using:
    /// <see cref="MonitoringManager.RegisterTarget"/> or <see cref="MonitoringManager.UnregisterTarget"/>.
    /// This process can be simplified by using monitored base types:
    /// <br/><see cref="MonitoredObject"/>, <see cref="MonitoredBehaviour"/> or <see cref="MonitoredSingleton{T}"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    [Preserve]
    public class MonitorValueAttribute : MonitorAttribute
    {
        /// <summary>
        /// When enabled, the monitored value may be set by the MonitorUnit. This will enable UI scripts to set the value
        /// directly.
        /// </summary>
        public bool EnableSetAccess { get; set; }
        
        /// <summary>
        /// The name of an event that is invoked when the monitored value is updated. Use to reduce the evaluation of the
        /// monitored member. Events can be of type <see cref="Action"/> or <see cref="Action{T}"/>, with T being the type of the monitored value. 
        /// </summary>
        /// <footer>Note: use the nameof keyword to pass the name of the event.</footer> 
        public string UpdateEvent { get; set; } = null;
    }
}