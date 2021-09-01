public class Health
    {
        public float Max { get; set; }
        public float Current { get; set; }

        public Health(float max, float current)
        {
            Max = max;
            Current = current;
        }
    }
