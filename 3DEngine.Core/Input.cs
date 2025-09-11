using _3DEngine.Core.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine.Core
{
    public enum Keys
    {
        Unknown = -1,

        Space = 32,

        Apostrophe = 39 /* ' */,

        Comma = 44 /* , */,

        Minus = 45 /* - */,

        Period = 46 /* . */,

        Slash = 47 /* / */,

        D0 = 48,

        D1 = 49,

        D2 = 50,

        D3 = 51,

        D4 = 52,

        D5 = 53,

        D6 = 54,

        D7 = 55,

        D8 = 56,

        D9 = 57,

        Semicolon = 59 /* ; */,

        Equal = 61 /* = */,

        A = 65,

        B = 66,

        C = 67,

        D = 68,

        E = 69,

        F = 70,

        G = 71,

        H = 72,

        I = 73,

        J = 74,

        K = 75,

        L = 76,

        M = 77,

        N = 78,

        O = 79,

        P = 80,

        Q = 81,

        R = 82,

        S = 83,

        T = 84,

        U = 85,

        V = 86,

        W = 87,

        X = 88,

        Y = 89,

        Z = 90,

        LeftBracket = 91 /* [ */,

        Backslash = 92 /* \ */,

        RightBracket = 93 /* ] */,

        GraveAccent = 96 /* ` */,

        Escape = 256,

        Enter = 257,

        Tab = 258,

        Backspace = 259,

        Insert = 260,

        Delete = 261,

        Right = 262,

        Left = 263,

        Down = 264,

        Up = 265,

        PageUp = 266,

        PageDown = 267,

        Home = 268,

        End = 269,

        CapsLock = 280,

        ScrollLock = 281,

        NumLock = 282,

        PrintScreen = 283,

        Pause = 284,

        F1 = 290,

        F2 = 291,

        F3 = 292,

        F4 = 293,

        F5 = 294,

        F6 = 295,

        F7 = 296,

        F8 = 297,

        F9 = 298,

        F10 = 299,

        F11 = 300,

        F12 = 301,

        F13 = 302,

        F14 = 303,

        F15 = 304,

        F16 = 305,

        F17 = 306,

        F18 = 307,

        F19 = 308,

        F20 = 309,

        F21 = 310,

        F22 = 311,

        F23 = 312,

        F24 = 313,

        F25 = 314,

        KeyPad0 = 320,

        KeyPad1 = 321,

        KeyPad2 = 322,

        KeyPad3 = 323,

        KeyPad4 = 324,

        KeyPad5 = 325,

        KeyPad6 = 326,

        KeyPad7 = 327,

        KeyPad8 = 328,

        KeyPad9 = 329,

        KeyPadDecimal = 330,

        KeyPadDivide = 331,

        KeyPadMultiply = 332,

        KeyPadSubtract = 333,

        KeyPadAdd = 334,

        KeyPadEnter = 335,

        KeyPadEqual = 336,

        LeftShift = 340,

        LeftControl = 341,

        LeftAlt = 342,

        LeftSuper = 343,

        RightShift = 344,

        RightControl = 345,

        RightAlt = 346,

        RightSuper = 347,

        Menu = 348,

        LastKey = Menu

    }

    public enum MouseButton
    {
        Button1 = 0,

        Button2 = 1,

        Button3 = 2,

        Button4 = 3,

        Button5 = 4,

        Button6 = 5,

        Button7 = 6,

        Button8 = 7,

        Left = Button1,

        Right = Button2,

        Middle = Button3,

        Last = Button8,
    }

    public static class Input
    {
        public static KeyboardState KeyboardState;
        public static MouseState MouseState;

        public static bool IsAnyKeyDown => KeyboardState.IsAnyKeyDown;

        public static bool IsKeyPressed(Keys key)
        {
            return KeyboardState.IsKeyPressed((OpenTK.Windowing.GraphicsLibraryFramework.Keys)key);
        }

        public static bool IsKeyDown(Keys key)
        {
            return KeyboardState.IsKeyDown((OpenTK.Windowing.GraphicsLibraryFramework.Keys)key);
        }

        public static bool IsKeyRelised(Keys key)
        {
            return KeyboardState.IsKeyReleased((OpenTK.Windowing.GraphicsLibraryFramework.Keys)key);
        }

        public static Vector2 GetMousePosition()
        {
            return new Vector2(MouseState.X, MouseState.Y);
        }

        public static bool IsButtonPressed(MouseButton mouseButton)
        {
            return MouseState.IsButtonPressed((OpenTK.Windowing.GraphicsLibraryFramework.MouseButton)mouseButton);
        }

        public static bool IsButtonDown(MouseButton mouseButton)
        {
            return MouseState.IsButtonDown((OpenTK.Windowing.GraphicsLibraryFramework.MouseButton)mouseButton);
        }

        public static bool IsButtonReleased(MouseButton mouseButton)
        {
            return MouseState.IsButtonReleased((OpenTK.Windowing.GraphicsLibraryFramework.MouseButton)mouseButton);
        }
    }
}
