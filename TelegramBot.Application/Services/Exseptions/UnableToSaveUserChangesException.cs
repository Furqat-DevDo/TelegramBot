﻿using System.Runtime.Serialization;

namespace TelegramBot.Application.Services.Exseptions
{
    [Serializable]
    internal class UnableToSaveUserChangesException : Exception
    {
        public UnableToSaveUserChangesException()
        {
        }

        public UnableToSaveUserChangesException(string? message) : base(message)
        {
        }

        public UnableToSaveUserChangesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnableToSaveUserChangesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}