﻿#region References

using System;

#endregion

namespace Raspberry.IO.Components.Sensors.Temperature.Tmp36
{
    /// <summary>
    /// Represents a connection to a TMP36 temperature sensor.
    /// </summary>
    /// <remarks>See <see cref="http://learn.adafruit.com/send-raspberry-pi-data-to-cosm"/>.</remarks>
    public class Tmp36Connection : IDisposable
    {
        #region Fields

        private readonly IInputAnalogPin inputPin;
        private readonly decimal referenceVoltage;

        #endregion

        #region Instance Management

        /// <summary>
        /// Initializes a new instance of the <see cref="Tmp36Connection"/> class.
        /// </summary>
        /// <param name="inputPin">The input pin.</param>
        /// <param name="referenceVoltage">The reference voltage.</param>
        public Tmp36Connection(IInputAnalogPin inputPin, decimal referenceVoltage)
        {
            this.inputPin = inputPin;
            this.referenceVoltage = referenceVoltage;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        void IDisposable.Dispose()
        {
            Close();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the temperature, in Celsius.
        /// </summary>
        /// <returns>The temperature, in Celsius.</returns>
        public decimal GetTemperature()
        {
            var voltage = inputPin.Read().Relative * referenceVoltage;
            return voltage*100 - 50;
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            inputPin.Dispose();
        }

        #endregion
    }
}
