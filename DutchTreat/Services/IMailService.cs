﻿namespace DutchTreat.Services
{
    public interface IMailService
    {
        void SendMail(string to, string subject, string from, string message);
    }
}