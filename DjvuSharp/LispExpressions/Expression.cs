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

namespace DjvuSharp.LispExpressions
{
    /// <summary>
    /// The most generic lisp-expression.
    /// It can be converted (or cast) to other more specific types of lisp-expression like Pair, etc
    /// But before doing that it's actual type must be checked.
    /// </summary>
    public class Expression: IEquatable<Expression>
    {
        /// <summary>
        /// Pointer to native lisp expression (of type miniexp_t)
        /// </summary>
        internal protected IntPtr _expression;

        public Expression(IntPtr expression)
        {
            if (expression == IntPtr.Zero)
                throw new ArgumentException($"{nameof(expression)} cannot be equal to IntPtr.Zero.", nameof(expression));

            _expression = expression;
        }

        internal Expression()
        {

        }

        /// <summary>
        /// Checks whether the current s-expression is a symbol.
        /// Essential when converting to more specific type like pair, IntExpression, etc
        /// </summary>
        /// <returns>True if this expression is symbol; false otherwise</returns>
        public bool IsSymbol
        {
            get {
                long i = _expression.ToInt64();
                return (i & 3) == 2;
            }
        }

        /// <summary>
        /// Checks whether the current s-expression is a pair.
        /// Essential when converting to more specific type like pair, IntExpression, etc
        /// </summary>
        /// <returns>True if this expression is pair; false otherwise</returns>
        public bool IsListExpression
        {
            get
            {
                long i = _expression.ToInt64();
                return (i & 3) == 0;
            }
        }

        /// <summary>
        /// Checks whether the current s-expression is a StringExpression.
        /// Essential when converting to more specific type like pair, IntExpression, etc
        /// </summary>
        /// <returns>True if this expression is StringExpression; false otherwise</returns>
        public bool IsStringExpression
        {
            get
            {
                int result = Native.miniexp_stringp(_expression);
                return !(result == 0);
            }
        }

        /// <summary>
        /// Checks whether the current s-expression is a FloatExpression.
        /// Essential when converting to more specific type like pair, IntExpression, etc
        /// </summary>
        /// <returns>True if this expression is FloatExpression; false otherwise</returns>
        public bool IsFloatExpression
        {
            get
            {
                int result = Native.miniexp_floatnump(_expression);
                return !(result == 0);
            }
        }

        /// <summary>
        /// Checks whether the current s-expression is a IntExpression.
        /// Essential when converting to more specific type like pair, IntExpression, etc
        /// </summary>
        /// <returns>True if this expression is IntExpression; false otherwise</returns>
        public bool IsIntExpression
        {
            get
            {
                long i = _expression.ToInt64();
                return (i & 3) == 3;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Expression);
        }

        public bool Equals(Expression other)
        {
            if (other is null)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this._expression == other._expression;
        }

        public static bool operator ==(Expression lhs, Expression rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Expression lhs, Expression rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            return _expression.GetHashCode();
        }
    }
}
