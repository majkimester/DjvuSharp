﻿/*
*   DjvuSharp - .NET bindings for DjvuLibre
*   Copyright (C) 2021 Prajwal Jadhav
*   
*   This program is free software; you can redistribute it and/or
*   modify it under the terms of the GNU General Public License
*   as published by the Free Software Foundation; either version 2
*   of the License, or (at your option) any later version.
*   
*   This program is distributed in the hope that it will be useful,
*   but WITHOUT ANY WARRANTY; without even the implied warranty of
*   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*   GNU General Public License for more details.
*   
*   You should have received a copy of the GNU General Public License
*   along with this program; if not, write to the Free Software
*   Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/

using System;
using System.Runtime.InteropServices;
using DjvuSharp.Interop;

namespace DjvuSharp
{
    public class Djvu
    {
        /// <summary>
        /// Returns the current version of the underlying DjvuLiber version number
        /// </summary>
        /// <returns>The version of underlying DjvuLibre library</returns>
        public static string GetDjvuVersion()
        {
            IntPtr charPtr = Native.ddjvu_get_version_string();

            string version = Marshal.PtrToStringAnsi(charPtr);

            return version;
        }
    }
}
