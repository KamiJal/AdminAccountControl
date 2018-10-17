using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminAccountControl.Models
{
    public static class RusTitles
    {
        public const string Title = "Наименование";
        public const string Price = "Стоимость";
        public const string CreatedDate = "Дата добавления";
        public const string Description = "Описание";
        public const string IsInStock = "Есть в наличии";
        public const string Attachment = "Приложение";

        public const string Required = "Это поле обязательно для заполнения";

        public const string AdminEmail = "Адрес администратора";
        public const string RobotEmail = "Адрес для безответного письма";
        public const string MailServer = "Почтовый сервер для отправки (localhost)";
        public const string MailAddress = "Адрес сайта (URL) для постановки в сообщения";
    }
}