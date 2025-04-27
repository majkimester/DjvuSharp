/*
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

using DjvuSharp.Marshaler;
using System;
using System.Runtime.InteropServices;

namespace DjvuSharp.Messages
{
    public class NewStreamMessage
    {
        public int StreamId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        private NewStreamMessage(NativeNewStreamMessageStruct newstreamMsgStruct)
        {
            var stringMarshaler = CustomStringMarshaler.GetInstance("");

            StreamId = newstreamMsgStruct.StreamId;
            Name = (string)stringMarshaler.MarshalNativeToManaged(newstreamMsgStruct.Name);
            Url = (string)stringMarshaler.MarshalNativeToManaged(newstreamMsgStruct.Url);
        }

        [StructLayout(LayoutKind.Sequential)]
        private class NativeNewStreamMessageStruct
        {
            public AnyMessage Any;
            public int StreamId;
            public IntPtr Name;
            public IntPtr Url;
        }

        public static NewStreamMessage GetInstance(IntPtr nativeMessageStruct)
        {
            var msg = Marshal.PtrToStructure<NativeNewStreamMessageStruct>(nativeMessageStruct);

            return new NewStreamMessage(msg);
        }
    }
}
