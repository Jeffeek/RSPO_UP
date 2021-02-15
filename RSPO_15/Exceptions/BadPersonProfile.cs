#region Using derectives

using System;

#endregion

namespace RSPO_UP_15.Exceptions
{
    public class BadPersonProfile : Exception
    {
        public BadPersonProfile(string message) : base(message) { }

        public BadPersonProfile() => Message = "Профиль был создан с не валидными полями";

        #region Overrides of Exception

        /// <inheritdoc />
        public override string Message { get; }

        #endregion
    }
}