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
using DjvuSharp.Interop;
using DjvuSharp.Marshaler;
using System.Runtime.InteropServices;

namespace DjvuSharp.LispExpressions
{
    public class StringExpression: Expression
    {
        private readonly ICustomMarshaler _stringMarshaler;

        public StringExpression(string input)
        {
            _expression = Native.miniexp_string(input);
            _stringMarshaler = CustomStringMarshaler.GetInstance("");
        }

        public StringExpression(Expression expression)
        {
            if (!expression.IsStringExpression)
            {
                throw new ArgumentException(
                    $"The parameter {nameof(expression)} doesn't point to a string lisp-expression.",
                    nameof(expression));
            }

            _expression = expression._expression;
            _stringMarshaler = CustomStringMarshaler.GetInstance("");
        }

        public string Value
        {
            get
            {
                IntPtr stringPtr = Native.miniexp_to_str(_expression);
                return _stringMarshaler.MarshalNativeToManaged(stringPtr) as string;
            }
        }
    }
}
