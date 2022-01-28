namespace EasyHaptic_EvilBurgers
{
    public sealed class AndroidPredifinedVariables
    {
        // Duration on milliseconds
        public static long lightImpactDuration = 20;
        public static long mediumImpactDuration = 75;
        public static long heavyImpactDuration = 120;

        // Amplitude of vibration. Remeber if you want add custom variables amplitude must be 'INT' between 0-255 where 0 is 'NO VIBRATION'
        public static int lightImpactAmplitude = 40;
        public static int mediumImpactAmplitude = 120;
        public static int heavyImpactAmplitude = 255;

        // Patterns for wave vibration. You can easly play with values. For better effect need add more than 2 values in array
        public static long[] successPatternDuration = {
                                30,
                                70,
                                30,
                                70
                                };

        public static int[] successPatternAmplitude = {
                                20,
                                50,
                                20,
                                50
                                };
        
        public static long[] warningPatternDuration = { 
                                50, 
                                100,
                                50,
                                100
                                };

        public static int[] warningPatternAmplitude = { 
                                60, 
                                120,
                                60,
                                120
                                };

        public static long[] failurePatternDuration = {
                                400,
                                50,
                                400,
                                50
                                };

        public static int[] failurePatternAmplitude = {
                                150,
                                50,
                                150,
                                50 
                                };
    }
}

