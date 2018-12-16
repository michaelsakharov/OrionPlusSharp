using System.Windows.Forms;
using System;
using System.Timers;

namespace Engine
{
    internal enum TimeOfDay : byte
    {
        Day = 0,
        Night = 1,
        Dawn = 2,
        Dusk = 3
    }

    internal delegate void HandleTimeEvent(ref Time source);

    internal class Time
    {
        private static Time _mInstance = null;

        internal static Time Instance
        {
            get
            {
                if ((_mInstance == null))
                    _mInstance = new Time();

                return _mInstance;
            }
        }

        internal event HandleTimeEvent OnTimeChanged;
        internal event HandleTimeEvent OnTimeOfDayChanged;
        internal event HandleTimeEvent OnTimeSync;

        private readonly System.Timers.Timer _mTimer;

        private DateTime _mTime;

        internal DateTime _Time
        {
            get
            {
                return this._mTime;
            }
            set
            {
                this._mTime = value;
                int hour = this._Time.Hour;
                TimeOfDay newTimeOfDay = GetTimeOfDay(ref hour);
                bool flag = this.TimeOfDay != newTimeOfDay;
                if (flag)
                {
                    this.TimeOfDay = newTimeOfDay;
                }
                HandleTimeEvent onTimeChangedEvent = this.OnTimeChanged;
                if (onTimeChangedEvent != null)
                {
                    HandleTimeEvent handleTimeEvent = onTimeChangedEvent;
                    Time time = this;
                    handleTimeEvent(ref time);
                }
            }
        }

        private double _mGameSpeed;

        internal double GameSpeed
        {
            get
            {
                return this._mGameSpeed;
            }
            set
            {
                this._mGameSpeed = value;
                HandleTimeEvent onTimeSyncEvent = this.OnTimeSync;
                if (onTimeSyncEvent != null)
                {
                    HandleTimeEvent handleTimeEvent = onTimeSyncEvent;
                    Time time = this;
                    handleTimeEvent(ref time);
                }
            }
        }

        private int mSyncInterval;

        internal int SyncInterval
        {
            get
            {
                return this.mSyncInterval;
            }
            set
            {
                this.mSyncInterval = value;
                this._mTimer.Stop();
                this._mTimer.Interval = (double)this.mSyncInterval;
                this._mTimer.Start();
                HandleTimeEvent onTimeSyncEvent = this.OnTimeSync;
                if (onTimeSyncEvent != null)
                {
                    HandleTimeEvent handleTimeEvent = onTimeSyncEvent;
                    Time time = this;
                    handleTimeEvent(ref time);
                }
            }
        }

        private TimeOfDay mTimeOfDay;

        internal TimeOfDay TimeOfDay
        {
            get
            {
                return this.mTimeOfDay;
            }
            set
            {
                this.mTimeOfDay = value;
                HandleTimeEvent onTimeOfDayChangedEvent = this.OnTimeOfDayChanged;
                if (onTimeOfDayChangedEvent != null)
                {
                    HandleTimeEvent handleTimeEvent = onTimeOfDayChangedEvent;
                    Time time = this;
                    handleTimeEvent(ref time);
                }
            }
        }

        internal Time()
        {
            this.mSyncInterval = 6000;
            this._mTimer = new System.Timers.Timer((double)this.SyncInterval);
            this._mTimer.Elapsed += this.HandleTimerElapsed;
            this._mTimer.Start();
        }

        private void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            HandleTimeEvent onTimeSyncEvent = this.OnTimeSync;
            if (onTimeSyncEvent != null)
            {
                HandleTimeEvent handleTimeEvent = onTimeSyncEvent;
                Time time = this;
                handleTimeEvent(ref time);
            }
        }

        public override string ToString()
        {
            string text = "h:mm:ss tt";
            return this.ToString(ref text);
        }

        internal string ToString(ref string format)
        {
            return this._Time.ToString(format);
        }

        internal void Reset()
        {
            _Time = new DateTime(0);
        }

        internal void Tick()
        {
            _Time = _Time.AddSeconds(GameSpeed);
        }

        internal static TimeOfDay GetTimeOfDay(ref int hours)
        {
            if ((hours < 6))
                return TimeOfDay.Night;
            else if ((6 <= hours && hours <= 9))
                return TimeOfDay.Dawn;
            else if ((9 < hours && hours < 18))
                return TimeOfDay.Day;
            else
                return TimeOfDay.Dusk;
        }
    }
}
