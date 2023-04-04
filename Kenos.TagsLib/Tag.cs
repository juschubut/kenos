using System;
using System.Collections.Generic;
using System.Text;

namespace Kenos.TagsLib
{
    public class Tag
    {
        private bool _updating = false;
        private string _time = "";
        private TimeSpan _timeSpan = new TimeSpan();

        public string Description { get; set; }
        
        public TimeSpan TimeSpan 
        {
            get { return _timeSpan; }
            set
            {
                _timeSpan = value;
                if (!_updating)
                    UpdateTime();
            }
        }


        public string Time 
        {
            get { return _time; }
            set 
            { 
                _time = value;
                if (!_updating)
                    UpdateTimeSpan();
            }
 
        }


        internal static Tag Parse(string item)
        {
            Tag timestamp = new Tag();

            int from = item.IndexOf('[') + 1;
            int to = item.IndexOf(']');

            if (from > 0 && to > 0)
            {

                timestamp.Time = item.Substring(from, to - from).Trim();
                if (item.Length > to)
                    timestamp.Description = item.Substring(to + 1).Trim();

                TimeSpan ts = new TimeSpan();

                if (TimeSpan.TryParse(timestamp.Time, out ts))
                {
                    timestamp.TimeSpan = ts;
                }

                return timestamp;
            }

            return null;
        }

        internal void UpdateTimeSpan()
        {
            _updating = true;

            TimeSpan ts;
            if (TimeSpan.TryParse(this.Time, out ts))
            {
                this.TimeSpan = ts;
            }

            _updating = false;
        }

        internal void UpdateTime()
        {
            _updating = true;

            this.Time = string.Format("{0:hh\\:mm\\:ss}", this.TimeSpan);

            _updating = false;
        }
    }
}
