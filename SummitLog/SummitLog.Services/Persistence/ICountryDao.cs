﻿using System.Collections.Generic;
using SummitLog.Services.Model;

namespace SummitLog.Services.Persistence
{
    /// <summary>
    ///     Schnittstelle für DAOs für Länder
    /// </summary>
    public interface ICountryDao
    {
        /// <summary>
        ///     Liefert alle Länder
        /// </summary>
        /// <returns></returns>
        IList<Country> GetAll();

        /// <summary>
        ///     Erstellt ein neues Land
        /// </summary>
        /// <param name="country"></param>
        void Create(Country country);
    }
}