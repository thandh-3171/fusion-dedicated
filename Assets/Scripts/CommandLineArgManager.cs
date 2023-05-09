using System;
using System.Collections;
using UnityEngine;

namespace PJLived.GunnerStars.Managers
{
    public class CommandLineArgManager : MonoBehaviour
    {
        #region serialized
        [SerializeField] private float delayReadArgs = 1f;
        [SerializeField] private EnvironmentData enviData = new();
        #endregion

        #region private vars
        private float time = 0f;
        #endregion

        #region mono
        /// <summary>
        /// Awake is called first when runtime starts.
        /// </summary>
        private void Awake()
        {            
            SetComponents();
        }

        /// <summary>
        /// OnEnable is called when this script's enable-status is on.
        /// </summary>
        private void OnEnable() { SubscribeCallbacks(); }

        /// <summary>
        /// Start is called before the first frame update.
        /// Leave it (not removing) to enable manually pre-runtime.
        /// </summary>
        private void Start()
        {
            this.time = Time.time;
        }

        /// <summary>
        /// Update is called once per frame. Must remove if empty.
        /// </summary>
        private void Update()
        {
            CheckReadArgs();
        }

        /// <summary>
        /// OnDisable is called when this script's enable-status is off.
        /// </summary>
        private void OnDisable() { UnsubscribeCallbacks(); }

        /// <summary>
        /// OnDestroy is called when this script or the gameobject carries this script is destroyed.
        /// </summary>
        private void OnDestroy() { UnsubscribeCallbacks(); }
        #endregion

        #region private methods
        /// <summary>
        /// Components that need to be set by code.
        /// These components should not be in the #serialized section.
        /// </summary>
        private void SetComponents() { }

        /// <summary>
        /// Callbacks set here.
        /// </summary>
        private void SubscribeCallbacks() { }

        /// <summary>
        /// Callbacks removing here.
        /// </summary>
        private void UnsubscribeCallbacks()
        {
            try { }
            catch { }
        }

        private void CheckReadArgs()
        {
            // If delay enough, read the system's arguments.
            if (Time.time - time > delayReadArgs)
            {
                enviData.Update();
                time = Time.time;
            }
        }

        [ContextMenu("DebugEnvirontment")]
        private void DebugEnvirontment()
        {
            this.enviData.Update();
        }
        #endregion

        #region public methods
        #endregion

        #region data
        [Serializable]
        public class EnvironmentData
        {
            public int ExitCode;
            public bool Is64BitProcess;
            public int CurrentManagedThreadId;
            public string CurrentDirectory;
            public string CommandLine;
            public string MachineName;
            public string NewLine;
            public OperatingSystem OSVersion;
            public int ProcessorCount;
            public string StackTrace;
            public string SystemDirectory;
            public int SystemPageSize;
            public int TickCount;
            public string UserDomainName;
            public bool UserInteractive;
            public string UserName;
            public System.Version Version;
            public long WorkingSet;
            public bool HasShutdownStarted;
            public bool Is64BitOperatingSystem;
            public string[] CommandLineArgs = new string[0];
            public IDictionary EnvironmentVariables;
            public string[] LogicalDrives = new string[0];
            public void Update()
            {
                this.ExitCode = Environment.ExitCode;
                this.Is64BitProcess = Environment.Is64BitProcess;
                this.CurrentManagedThreadId = Environment.CurrentManagedThreadId;
                this.CurrentDirectory = Environment.CurrentDirectory;
                this.CommandLine = Environment.CommandLine;
                this.MachineName = Environment.MachineName;
                this.NewLine = Environment.NewLine;
                this.OSVersion = Environment.OSVersion;
                this.ProcessorCount = Environment.ProcessorCount;
                this.StackTrace = Environment.StackTrace;
                this.SystemDirectory = Environment.SystemDirectory;
                this.SystemPageSize = Environment.SystemPageSize;
                this.TickCount = Environment.TickCount;
                this.UserDomainName = Environment.UserDomainName;
                this.UserInteractive = Environment.UserInteractive;
                this.UserName = Environment.UserName;
                this.Version = Environment.Version;
                this.WorkingSet = Environment.WorkingSet;
                this.HasShutdownStarted = Environment.HasShutdownStarted;
                this.Is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
                this.CommandLineArgs = Environment.GetCommandLineArgs();
                this.EnvironmentVariables = Environment.GetEnvironmentVariables();
                this.LogicalDrives = Environment.GetLogicalDrives();
            }
        }
        #endregion
    }
}