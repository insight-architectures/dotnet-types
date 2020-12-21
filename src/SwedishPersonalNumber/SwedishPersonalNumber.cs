﻿using System;

namespace InsightArchitectures.Types
{
    /// <summary>
    /// A representation of the Swedish personal number (personnummer).
    /// </summary>
    public partial record SwedishPersonalNumber
    {
        /// <summary>
        /// Creates a new instance of <see cref="SwedishPersonalNumber" /> from a date and an ordinal number.
        /// </summary>
        /// <param name="dateOfBirth">The date part of the Swedish personal number.</param>
        /// <param name="ordinalNumber">The ordinal number part of the Swedish personal number.</param>
        public SwedishPersonalNumber(DateTime dateOfBirth, int ordinalNumber)
        {
            DateOfBirth = dateOfBirth;

            if (ordinalNumber >= 10_000 || ordinalNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ordinalNumber), "The value should be a positive number less than 10000");
            }

            OrdinalNumber = ordinalNumber;
        }

        /// <summary>
        /// Gets the date part of the Swedish personal number.
        /// </summary>
        public DateTime DateOfBirth { get; init; }

        /// <summary>
        /// Gets the ordinal number part of the Swedish personal number.
        /// </summary>
        public int OrdinalNumber { get; init; }

        /// <summary>
        /// Returns the value of this instance of <see cref="SwedishPersonalNumber" /> as a <see cref="string" /> according to the specified concrete implementation.
        /// </summary>
        /// <param name="formatter">The formatter to use to formatter the Swedish personal number.</param>
        /// <returns>A string containing this <see cref="SwedishPersonalNumber" /> formatted as a <see cref="string" />.</returns>
        public string ToFormattedString(SwedishPersonalNumberFormatter formatter) => formatter?.Format(this) ?? throw new ArgumentNullException(nameof(formatter));

        /// <inheritdoc/>
        public override string ToString() => ToFormattedString(SwedishPersonalNumberFormatter.TwelveDigits);
    }
}
