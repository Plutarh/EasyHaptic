namespace EasyHaptic_EvilBurgers
{
    public sealed class AndroidPredifinedVariables
    {
        // Duration on milliseconds
        public static long lightImpactDuration = 20;
        public static long mediumImpactDuration = 50;
        public static long heavyImpactDuration = 80;

        // Amplitude of vibration. Remeber if you want add custom variables amplitude must be 'INT' between 0-255 where 0 is 'NO VIBRATION'
        public static int lightImpactAmplitude = 30;
        public static int mediumImpactAmplitude = 120;
        public static int heavyImpactAmplitude = 255;

        // Patterns for wave vibration
        public static long[] successPatternDuration = {
                                0,
                                lightImpactDuration,
                                lightImpactDuration,
                                mediumImpactDuration,
                                lightImpactDuration
                                };

        public static int[] successPatternAmplitude = {
                                0, 
                                lightImpactAmplitude,
                                lightImpactAmplitude,  
                                mediumImpactAmplitude,
                                lightImpactAmplitude
                                };
        
        public static long[] warningPatternDuration = { 
                                mediumImpactDuration, 
                                lightImpactDuration 
                                };

        public static int[] warningPatternAmplitude = { 
                                mediumImpactAmplitude, 
                                lightImpactAmplitude
                                };

        public static long[] failurePatternDuration = {
                                200, 
                                1000, 
                                500, 
                                2000
                                };

        public static int[] failurePatternAmplitude = {
                                mediumImpactAmplitude,
                                mediumImpactAmplitude,
                                heavyImpactAmplitude,
                                mediumImpactAmplitude 
                                };
    }
}

