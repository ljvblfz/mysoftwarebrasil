using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MobileTools.Power
{
    /// <summary>
    /// Power line status.
    /// <para><b>New in v1.3</b></para>
    /// </summary>
    /// <remarks>Used by <see cref="PowerStatus"/> class.</remarks>
    public enum PowerLineStatus : byte
    {
        /// <summary>
        /// AC power is offline.
        /// </summary>
        Offline = 0x00,
        /// <summary>
        /// AC power is online.
        /// </summary>
        Online = 0x01,
        /// <summary>
        /// Unit is on backup power.
        /// </summary>
        BackupPower = 0x02,
        /// <summary>
        /// AC line status is unknown.
        /// </summary>
        Unknown = 0xFF,
    }

    /// <summary>
    /// Defines identifiers that indicate the current battery charge level or charging state information.
    /// </summary>
    [Flags()]
    public enum BatteryChargeStatus : byte
    {
        /// <summary>
        /// Indicates a high level of battery charge.
        /// </summary>
        High = 0x01,
        /// <summary>
        /// Indicates a low level of battery charge.
        /// </summary>
        Low = 0x02,
        /// <summary>
        /// Indicates a critically low level of battery charge.
        /// </summary>
        Critical = 0x04,
        /// <summary>
        /// Indicates a battery is charging.
        /// </summary>
        Charging = 0x08,
        /// <summary>
        /// Indicates that no battery is present.
        /// </summary>
        NoSystemBattery = 0x80,
        /// <summary>
        /// Indicates an unknown battery condition.
        /// </summary>
        Unknown = 0xFF,
    }


    /// <summary>
    /// Indicates current system power status information.
    /// <para><b>New in v1.3</b></para>
    /// </summary>
    public class PowerStatus
    {
#pragma warning disable 0649, 0169
        private byte mACLineStatus;
        private byte mBatteryFlag;
        private byte mBatteryLifePercent;
        private byte mReserved1;
        private uint mBatteryLifeTime;
        private uint mBatteryFullLifeTime;
        private byte mReserved2;
        private byte mBackupBatteryFlag;
        private byte mBackupBatteryLifePercent;
        private byte mReserved3;
        private uint mBackupBatteryLifeTime;
        private uint mBackupBatteryFullLifeTime;
#pragma warning restore 0649, 0169

        internal PowerStatus()
        {
            Update(true);
        }

        /// <summary>
        /// AC power status.
        /// </summary>
        public PowerLineStatus PowerLineStatus
        {
            get
            {
                Update();
                return (PowerLineStatus)mACLineStatus;
            }
        }

        /// <summary>
        /// Gets the current battery charge status.
        /// </summary>
        public BatteryChargeStatus BatteryChargeStatus
        {
            get
            {
                Update();
                return (BatteryChargeStatus)mBatteryFlag;
            }
        }

        /// <summary>
        /// Gets the approximate percentage of full battery time remaining.
        /// </summary>
        /// <remarks>TThe approximate percentage, from 0 to 100, of full battery time remaining, or 255 if the percentage is unknown.</remarks>
        public byte BatteryLifePercent
        {
            get
            {
                Update();
                return mBatteryLifePercent;
            }
        }

        /// <summary>
        /// Gets the approximate number of seconds of battery time remaining.
        /// </summary>
        /// <value>The approximate number of seconds of battery life remaining, or -1 if the approximate remaining battery life is unknown.</value>
        public uint BatteryLifeRemaining
        {
            get
            {
                Update();
                return mBatteryLifeTime;
            }
        }

        /// <summary>
        /// Gets the reported full charge lifetime of the primary battery power source in seconds.
        /// </summary>
        /// <value>The reported number of seconds of battery life available when the battery is fullly charged, or -1 if the battery life is unknown.</value>
        public uint BatteryFullLifeTime
        {
            get
            {
                Update();
                return mBatteryFullLifeTime;
            }
        }

        /// <summary>
        /// Gets the backup battery charge status.
        /// </summary>
        public BatteryChargeStatus BackupBatteryChargeStatus
        {
            get
            {
                Update();
                return (BatteryChargeStatus)mBackupBatteryFlag;
            }
        }

        /// <summary>
        /// Percentage of full backup battery charge remaining. Must be in the range 0 to 100.
        /// </summary>
        public byte BackupBatteryLifePercent
        {
            get
            {
                Update();
                return mBackupBatteryLifePercent;
            }
        }

        /// <summary>
        /// Number of seconds of backup battery life remaining.
        /// </summary>
        public uint BackupBatteryLifeRemaining
        {
            get
            {
                Update();
                return mBackupBatteryLifeTime;
            }
        }

        /// <summary>
        /// Number of seconds of backup battery life when at full charge. Or -1 If unknown.
        /// </summary>
        public uint BackupBatteryFullLifeTime
        {
            get
            {
                Update();
                return mBackupBatteryFullLifeTime;
            }
        }

        private bool Update(bool update)
        {
            if (GetSystemPowerStatusEx(this, update) == false)
            {
                System.Diagnostics.Debug.Write(Marshal.GetLastWin32Error());
                return false;
            }
            return true;
        }

        private bool Update()
        {
            return Update(false);
        }

        [DllImport("coredll.dll", EntryPoint = "GetSystemPowerStatusEx", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetSystemPowerStatusEx(PowerStatus pStatus, bool fUpdate);
    }
}
