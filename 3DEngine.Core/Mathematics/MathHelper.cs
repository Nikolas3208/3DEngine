namespace _3DEngine.Core.Mathematics
{
    public static class MathHelper
    {
        public const float Pi = 3.1415927f;


        public const float PiOver2 = Pi / 2;


        public const float PiOver3 = Pi / 3;


        public const float PiOver4 = Pi / 4;


        public const float PiOver6 = Pi / 6;


        public const float TwoPi = 2 * Pi;


        public const float ThreePiOver2 = 3 * Pi / 2;


        public const float E = 2.7182817f;

        public const float DegToRad = MathF.PI / 180.0f;

        public const float RadToDeg = 180.0f / MathF.PI;

        public static int Clamp(int n, int min, int max)
        {
            return Math.Max(Math.Min(n, max), min);
        }

        public static float Clamp(float n, float min, float max)
        {
            return Math.Max(Math.Min(n, max), min);
        }

        public static double Clamp(double n, double min, double max)
        {
            return Math.Max(Math.Min(n, max), min);
        }

        public static float DegreesToRadians(float degrees)
        {
            return degrees * DegToRad;
        }

        public static float RadiansToDegrees(float radians)
        {
            return radians * RadToDeg;
        }


    }
}
