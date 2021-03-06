﻿using System;
using System.Runtime.InteropServices;

namespace CoreHook
{
    /// <summary>
    /// IntPtr extensions for creating delegates from function pointers.
    /// </summary>
    public static class PointerExtensions
    {
        /// <summary>
        /// Convert a function address to a callable delegate method.
        /// </summary>
        /// <typeparam name="T">The delegate type to cast the function to.</typeparam>
        /// <param name="function">A function address.</param>
        /// <returns>The callable delegate method at <paramref name="function"/>.</returns>
        public static T ToFunction<T>(this IntPtr function) where T : class
        {
            // Verify that T is a Delegate type.
            System.Diagnostics.Debug.Assert(typeof(Delegate).IsAssignableFrom(typeof(T)));

            return Marshal.GetDelegateForFunctionPointer<T>(function);
        }
    }
}
