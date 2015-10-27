﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using SummitLog.Services.Model;
using SummitLog.UI.Common;

namespace SummitLog.UI.Main.DesignViewModels
{
    /// <summary>
    /// Design View Model der Hauptansicht
    /// </summary>
    public class MainDesignViewModel: ReactiveObject, IMainViewModel
    {
        /// <summary>
        /// Erstellt eine neue Instanz des Design View Models
        /// </summary>
        public MainDesignViewModel()
        {
            Countries = new ObservableCollection<Country>();
            Countries.Add(new Country() {Name = "Land A"});
            Countries.Add(new Country() {Name = "Land B"});

            AreasInSelectedCountry = new ObservableCollection<Area>();
            AreasInSelectedCountry.Add(new Area() {Name = "Gebiet A"});
            AreasInSelectedCountry.Add(new Area() {Name = "Gebiet B"});

            SummitGroupsInSelectedArea = new ObservableCollection<SummitGroup>();
            SummitGroupsInSelectedArea.Add(new SummitGroup() {Name = "Gruppe A"});
            SummitGroupsInSelectedArea.Add(new SummitGroup() {Name = "Gruppe B"});

            SummitsInSelectedSummitGroup = new ObservableCollection<Summit>();
            SummitsInSelectedSummitGroup.Add(new Summit() {Name = "Gipfel A"});
            SummitsInSelectedSummitGroup.Add(new Summit() {Name = "Gipfel B"});

            RoutesInSelectedCountry = new ObservableCollection<Route>();
            RoutesInSelectedCountry.Add(new Route() {Name = "Land A Route A"});
            RoutesInSelectedCountry.Add(new Route() {Name = "Land A Route B"});

            RoutesInSelectedArea = new ObservableCollection<Route>();
            RoutesInSelectedArea.Add(new Route() {Name = "Gebiet A Route A"});
            RoutesInSelectedArea.Add(new Route() {Name = "Gebiet A Route B"});

            RoutesInSelectedSummitGroup = new ObservableCollection<Route>();
            RoutesInSelectedSummitGroup.Add(new Route() {Name = "Gruppe A Route A"});
            RoutesInSelectedSummitGroup.Add(new Route() {Name = "Gruppe A Route B"});

            RoutesInSelectedSummit = new ObservableCollection<Route>();
            RoutesInSelectedSummit.Add(new Route() {Name = "Gipfel A Route A"});
            RoutesInSelectedSummit.Add(new Route() {Name = "Gipfel A Route B"});

            VariationsOnSelectedRoute = new ObservableCollection<Variation>();
            VariationsOnSelectedRoute.Add(new Variation() {Name = "Var A"});
            VariationsOnSelectedRoute.Add(new Variation() {Name = "Var B"});

            LogEntriesOnSelectedVariation = new ObservableCollection<LogEntry>();
            LogEntriesOnSelectedVariation.Add(new LogEntry() {DateTime = DateTime.Today, Memo = "freeclimb"});
            LogEntriesOnSelectedVariation.Add(new LogEntry() {DateTime = DateTime.Today.AddDays(1), Memo = "freeclimb 2"});

            SelectedCountry = Countries.First();
            SelectedArea = AreasInSelectedCountry.First();
            SelectedSummitGroup = SummitGroupsInSelectedArea.First();
            SelectedSummit = SummitsInSelectedSummitGroup.First();

            SelectedRouteInCountry = RoutesInSelectedCountry.First();
            SelectedRouteInArea = RoutesInSelectedArea.First();
            SelectedRouteInSummitGroup = RoutesInSelectedSummitGroup.First();
            SelectedRouteInSummit = RoutesInSelectedSummit.First();

            SelectedVariation = VariationsOnSelectedRoute.First();

            SelectedLogEntry = LogEntriesOnSelectedVariation.First();
        }

        /// <summary>
        ///     Liefert die Liste aller Länder
        /// </summary>
        public ObservableCollection<Country> Countries { get; }

        /// <summary>
        ///     Liefert oder setzt das gewählte Land
        /// </summary>
        public Country SelectedCountry { get; set; }

        /// <summary>
        ///     Liefert die Liste aller Gebiete im gewählten Land
        /// </summary>
        public ObservableCollection<Area> AreasInSelectedCountry { get; }

        /// <summary>
        ///     Liefert oder setzt das gewählte Gebiet
        /// </summary>
        public Area SelectedArea { get; set; }

        /// <summary>
        ///     Liefert eine Liste aller Gipfelgruppen im gewählten Gebiet
        /// </summary>
        public ObservableCollection<SummitGroup> SummitGroupsInSelectedArea { get; }

        /// <summary>
        ///     Liefert oder setzt die gewählte Gipfelgruppe
        /// </summary>
        public SummitGroup SelectedSummitGroup { get; set; }

        /// <summary>
        ///     Liefert eine Liste aller Gipfel in der Gewählten Gipfelgruppe
        /// </summary>
        public ObservableCollection<Summit> SummitsInSelectedSummitGroup { get; }

        /// <summary>
        ///     Liefert oder setzt den gewählten Gipfel
        /// </summary>
        public Summit SelectedSummit { get; set; }

        /// <summary>
        ///     Liefert eine Liste aller Routen im gewählten Land
        /// </summary>
        public ObservableCollection<Route> RoutesInSelectedCountry { get; }

        /// <summary>
        ///     Liefert oder setzt die gewählte Route eines Landes
        /// </summary>
        public Route SelectedRouteInCountry { get; set; }

        /// <summary>
        ///     Liefert eine Liste aller Routen im gewählten Gebiet
        /// </summary>
        public ObservableCollection<Route> RoutesInSelectedArea { get; }

        /// <summary>
        ///     Liefert oder setzt die gewählte Route in einem Gebiet
        /// </summary>
        public Route SelectedRouteInArea { get; set; }

        /// <summary>
        ///     Liefert eine Liste aller Routen in der gewählten Gipfelgruppe
        /// </summary>
        public ObservableCollection<Route> RoutesInSelectedSummitGroup { get; }

        /// <summary>
        ///     Liefert oder setzt die gewählte Route in einer Gipfelgruppe
        /// </summary>
        public Route SelectedRouteInSummitGroup { get; set; }

        /// <summary>
        ///     Liefert eine Liste aller Routen an einem gewählten Gipfel
        /// </summary>
        public ObservableCollection<Route> RoutesInSelectedSummit { get; }

        /// <summary>
        ///     Liefert oder setzt die gewählte Route an einem Gipfel
        /// </summary>
        public Route SelectedRouteInSummit { get; set; }

        /// <summary>
        ///     Liefert eine Liste aller Variationen einer gewählten Route (Land, Gebiet, Gruppe ODER Gipfel)
        /// </summary>
        public ObservableCollection<Variation> VariationsOnSelectedRoute { get; }

        /// <summary>
        ///     Liefert oder setzt die gewählte Variation
        /// </summary>
        public Variation SelectedVariation { get; set; }

        /// <summary>
        ///     Liefert eine Liste aller Logeinträge zur gewählten Variation
        /// </summary>
        public ObservableCollection<LogEntry> LogEntriesOnSelectedVariation { get; }

        /// <summary>
        ///     Liefert oder setzt den gewählten Logeintrag
        /// </summary>
        public LogEntry SelectedLogEntry { get; set; }

        /// <summary>
        ///     Liefert ein Command um ein Land hinzuzufügen
        /// </summary>
        public RelayCommand AddCountryCommand { get; }

        /// <summary>
        ///     Liefert ein Command um ein Gebiet zu einem gewählten Land hinzuzufügen
        /// </summary>
        public RelayCommand AddAreaInSelectedCountryCommand { get; }

        /// <summary>
        ///     Liefert ein Command um eine Gipfelgruppe zu einem gewählten Gebiet hinzuzufügen
        /// </summary>
        public RelayCommand AddSummitGroupInSelectedAreaCommand { get; }

        /// <summary>
        ///     Liefert ein Command um ein Gipfel einer gewählten Gipfelgruppe hinzuzufügen
        /// </summary>
        public RelayCommand AddSummitInSelectedSummitGroupCommand { get; }

        /// <summary>
        ///     Liefert ein Command um dem gewählten Land eine Route hinzuzufügen
        /// </summary>
        public RelayCommand AddRouteInSelectedCountryCommand { get; }

        /// <summary>
        ///     Liefert ein Command um dem gewählten Gebiet eine Route hinzuzufügen
        /// </summary>
        public RelayCommand AddRouteInSelectedAreaCommand { get; }

        /// <summary>
        ///     Liefert ein Command um der gewählten Gipfelgruppe eine Route hinzuzufügen
        /// </summary>
        public RelayCommand AddRouteInSelectedSummitGroupCommnad { get; }

        /// <summary>
        ///     Liefert ein Command um dem gewählten Gipfel eine Route hinzuzufügen
        /// </summary>
        public RelayCommand AddRouteInSelectedSummitCommand { get; }

        /// <summary>
        ///     Liefert ein Command um einer gewählten Route eine Variation hinzuzufügen
        /// </summary>
        public RelayCommand AddVariationToSelectedRouteCommand { get; }

        /// <summary>
        ///     Liefert ein Command um der gewählten Variation ein Logeintrag hinzuzufügen
        /// </summary>
        public RelayCommand AddLogEntryToSelectedVariationCommand { get; }

        /// <summary>
        ///     Liefert ein Command für die Verwaltung der Schwierigkeitsgrad und Skalen
        /// </summary>
        public RelayCommand ManageDifficultiesCommand { get; }

        public void LoadData()
        {
            
        }
    }
}