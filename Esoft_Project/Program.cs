﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    static class Program
    {
        ///создание статического экземпляра класса модели ADO.EDM
        public static Агенство_недвижимостиEntities6 агенство_Недвижимости= new Агенство_недвижимостиEntities6();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
