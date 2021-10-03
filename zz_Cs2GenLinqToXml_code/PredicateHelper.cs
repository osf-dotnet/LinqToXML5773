using System;
using System.Collections.Generic;
using System.Text;

namespace zz_Cs2GenLinqToXml_code
{
    /// <summary>
    /// permet de gerer les predicats pour les proprietes de type string
    /// </summary>
    public class stringPredicateHelper
    {
        private stringComparaison _Comparaison;

        /// <summary>
        /// la comparaison
        /// </summary>
        public stringComparaison Comparaison
        {
            get { return _Comparaison; }
            set { _Comparaison = value; }
        }
        private string _Property;

        /// <summary>
        /// la propriete ciblee de la comparaison
        /// </summary>
        public string Property
        {
            get { return _Property; }
            set { _Property = value; }
        }
        private string _Value;

        /// <summary>
        /// la valeur de comparaison de la propriete ciblee
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        /// <summary>
        /// Constructeur par defaut
        /// </summary>
        public stringPredicateHelper()
        { }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="Comparaison">la comparaison a effectuer</param>
        /// <param name="Property">la propriete ciblee</param>
        /// <param name="Value">la valeur de comparaison</param>
        public stringPredicateHelper(stringComparaison Comparaison, string Property, string Value)
        {
            this.Comparaison = Comparaison;
            this.Property = Property;
            this.Value = Value;
        }
        /// <summary>
        /// methode permettant d'affecter rapidement les valeurs aux proprietes de la classe,
        /// le but etant la reutilisation d'une instance de la classe sans reinstanciation
        /// </summary>
        /// <param name="Comparaison">la comparaison a effectuer</param>
        /// <param name="Property">la propriete ciblee</param>
        /// <param name="Value">la valeur de comparaison</param>
        public void SetProperties(stringComparaison Comparaison, string Property, string Value)
        {
            this.Comparaison = Comparaison;
            this.Property = Property;
            this.Value = Value;
        }
        /// <summary>
        /// compare la valeur courante de l'objet passe a la valeur definie pour un type de comparaison
        /// </summary>
        /// <param name="obj">l'objet re�u</param>
        /// <returns>vrai ou faux</returns>
        public bool Predicate(object obj)
        {
            bool result = false;
            string CurrentPropertyValue = Convert.ToString(PredicateUtils.GetValue(obj, Property));

            switch (Comparaison)
            {
                case stringComparaison.Contains:
                    result = CurrentPropertyValue.Contains(Value);
                    break;
                case stringComparaison.EndWith:
                    result = CurrentPropertyValue.EndsWith(Value);
                    break;
                case stringComparaison.Equals:
                    result = CurrentPropertyValue.Equals(Value);
                    break;
                case stringComparaison.Length:
                    if (CurrentPropertyValue.Length > Convert.ToInt32(Value))
                        result = true;
                    else
                        result = false;
                    break;
                case stringComparaison.StartsWith:
                    result = CurrentPropertyValue.StartsWith(Value);
                    break;
            }

            return result;
        }
    }
    /// <summary>
    /// permet de gerer les predicats pour les proprietes de type int
    /// </summary>
    public class intPredicateHelper
    {
        private intComparaison _Comparaison;

        /// <summary>
        /// la comparaison
        /// </summary>
        public intComparaison Comparaison
        {
            get { return _Comparaison; }
            set { _Comparaison = value; }
        }
        private string _Property;

        /// <summary>
        /// la propriete ciblee de la comparaison
        /// </summary>
        public string Property
        {
            get { return _Property; }
            set { _Property = value; }
        }
        private int _Value;

        /// <summary>
        /// la valeur de comparaison de la propriete ciblee
        /// </summary>
        public int Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        /// <summary>
        /// Constructeur par defaut
        /// </summary>
        public intPredicateHelper()
        { }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="Comparaison">la comparaison a effectuer</param>
        /// <param name="Property">la propriete ciblee</param>
        /// <param name="Value">la valeur de comparaison</param>
        public intPredicateHelper(intComparaison Comparaison, string Property, int Value)
        {
            this.Comparaison = Comparaison;
            this.Property = Property;
            this.Value = Value;
        }
        /// <summary>
        /// methode permettant d'affecter rapidement les valeurs aux proprietes de la classe,
        /// le but etant la reutilisation d'une instance de la classe sans reinstanciation
        /// </summary>
        /// <param name="Comparaison">la comparaison a effectuer</param>
        /// <param name="Property">la propriete ciblee</param>
        /// <param name="Value">la valeur de comparaison</param>
        public void SetProperties(intComparaison Comparaison, string Property, int Value)
        {
            this.Comparaison = Comparaison;
            this.Property = Property;
            this.Value = Value;
        }
        /// <summary>
        /// compare la valeur courante de l'objet passe a la valeur definie pour un type de comparaison
        /// </summary>
        /// <param name="obj">l'objet re�u</param>
        /// <returns>vrai ou faux</returns>
        public bool Predicate(object obj)
        {
            bool result = false;
            Nullable<int> CurrentPropertyValue = (Nullable<int>)PredicateUtils.GetValue(obj, Property);

            switch (Comparaison)
            {
                case intComparaison.Equals:
                    result = CurrentPropertyValue.Equals(Value);
                    break;
                case intComparaison.inf:
                    if (CurrentPropertyValue < Value)
                        result = true;
                    break;
                case intComparaison.Sup:
                    if (CurrentPropertyValue > Value)
                        result = true;
                    break;
            }

            return result;
        }
    }
    /// <summary>
    /// permet de gerer les predicats pour les proprietes de type Double
    /// </summary>
    public class DoublePredicateHelper
    {
        /// <summary>
        /// la comparaison
        /// </summary>
        private DoubleComparaison _Comparaison;

        /// <summary>
        /// la propriete ciblee de la comparaison
        /// </summary>
        public DoubleComparaison Comparaison
        {
            get { return _Comparaison; }
            set { _Comparaison = value; }
        }
        private string _Property;

        /// <summary>
        /// la valeur de comparaison de la propriete ciblee
        /// </summary>
        public string Property
        {
            get { return _Property; }
            set { _Property = value; }
        }
        private Double _Value;

        public Double Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        /// <summary>
        /// Constructeur par defaut
        /// </summary>
        public DoublePredicateHelper()
        { }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="Comparaison">la comparaison a effectuer</param>
        /// <param name="Property">la propriete ciblee</param>
        /// <param name="Value">la valeur de comparaison</param>
        public DoublePredicateHelper(DoubleComparaison Comparaison, string Property, Double Value)
        {
            this.Comparaison = Comparaison;
            this.Property = Property;
            this.Value = Value;
        }
        /// <summary>
        /// methode permettant d'affecter rapidement les valeurs aux proprietes de la classe,
        /// le but etant la reutilisation d'une instance de la classe sans reinstanciation
        /// </summary>
        /// <param name="Comparaison">la comparaison a effectuer</param>
        /// <param name="Property">la propriete ciblee</param>
        /// <param name="Value">la valeur de comparaison</param>
        public void SetProperties(DoubleComparaison Comparaison, string Property, Double Value)
        {
            this.Comparaison = Comparaison;
            this.Property = Property;
            this.Value = Value;
        }
        /// <summary>
        /// compare la valeur courante de l'objet passe a la valeur definie pour un type de comparaison
        /// </summary>
        /// <param name="obj">l'objet re�u</param>
        /// <returns>vrai ou faux</returns>
        public bool Predicate(object obj)
        {
            bool result = false;
            Nullable<Double> CurrentPropertyValue = (Nullable<Double>)PredicateUtils.GetValue(obj, Property);
            switch (Comparaison)
            {
                case DoubleComparaison.Equals:
                    result = CurrentPropertyValue.Equals(Value);
                    break;
                case DoubleComparaison.inf:
                    if (CurrentPropertyValue < Value)
                        result = true;
                    break;
                case DoubleComparaison.Sup:
                    if (CurrentPropertyValue > Value)
                        result = true;
                    break;
            }

            return result;
        }

    }
    /// <summary>
    /// permet de gerer les predicats pour les proprietes de type DateTime
    /// </summary>
    public class DateTimePredicateHelper
    {
        /// <summary>
        /// la comparaison
        /// </summary>
        private DateTimeComparaison _Comparaison;

        /// <summary>
        /// la propriete ciblee de la comparaison
        /// </summary>
        public DateTimeComparaison Comparaison
        {
            get { return _Comparaison; }
            set { _Comparaison = value; }
        }
        private string _Property;

        /// <summary>
        /// la valeur de comparaison de la propriete ciblee
        /// </summary>
        public string Property
        {
            get { return _Property; }
            set { _Property = value; }
        }
        private DateTime _Value;

        /// <summary>
        /// la valeur de comparaison de la propriete ciblee
        /// </summary>
        public DateTime Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        /// <summary>
        /// Constructeur par defaut
        /// </summary>
        public DateTimePredicateHelper()
        { }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="Comparaison">la comparaison a effectuer</param>
        /// <param name="Property">la propriete ciblee</param>
        /// <param name="Value">la valeur de comparaison</param>
        public DateTimePredicateHelper(DateTimeComparaison Comparaison, string Property, DateTime Value)
        {
            this.Comparaison = Comparaison;
            this.Property = Property;
            this.Value = Value;
        }
        /// <summary>
        /// methode permettant d'affecter rapidement les valeurs aux proprietes de la classe,
        /// le but etant la reutilisation d'une instance de la classe sans reinstanciation
        /// </summary>
        /// <param name="Comparaison">la comparaison a effectuer</param>
        /// <param name="Property">la propriete ciblee</param>
        /// <param name="Value">la valeur de comparaison</param>
        public void SetProperties(DateTimeComparaison Comparaison, string Property, DateTime Value)
        {
            this.Comparaison = Comparaison;
            this.Property = Property;
            this.Value = Value;
        }
        /// <summary>
        /// compare la valeur courante de l'objet passe a la valeur definie pour un type de comparaison
        /// </summary>
        /// <param name="obj">l'objet re�u</param>
        /// <returns>vrai ou faux</returns>
        public bool Predicate(object obj)
        {
            bool result = false;
            Nullable<DateTime> CurrentPropertyValue = (Nullable<DateTime>)PredicateUtils.GetValue(obj,Property);

            switch (Comparaison)
            {
                case DateTimeComparaison.Equals:
                    result = CurrentPropertyValue.Equals(Value);
                    break;
                case DateTimeComparaison.inf:
                    if (CurrentPropertyValue < Value)
                        result = true;
                    break;
                case DateTimeComparaison.Sup:
                    if (CurrentPropertyValue > Value)
                        result = true;
                    break;
            }

            return result;
        }

    }
    /// <summary>
    /// classe contenant des methodes utiles pour les classes d'aide aux predicats static 
    /// </summary>
    public class PredicateUtils
    {
        /// <summary>
        /// retourne la valeur de la propriete
        /// </summary>
        /// <param name="obj">le type</param>
        /// <param name="Property">la propriete dont la valeur doit atre extraite</param>
        /// <returns>la valeur de la propriete ou null</returns>
        public static object GetValue(object obj,string Property)
        {
            return obj.GetType().GetProperty(Property).GetValue(obj, null);
        }
    }
    /// <summary>
    /// Types de comparaisons disponibles pour la classe d'aide aux predicats string
    /// </summary>
    public enum stringComparaison
    {
        Contains,
        EndWith,
        Equals,
        Length,
        StartsWith
    }
    /// <summary>
    /// Types de comparaisons disponibles pour la classe d'aide aux predicats int
    /// </summary>
    public enum intComparaison
    {
        Equals,
        Sup,
        inf
    }
    /// <summary>
    /// Types de comparaisons disponibles pour la classe d'aide aux predicats Double
    /// </summary>
    public enum DoubleComparaison
    {
        Equals,
        Sup,
        inf
    }
    /// <summary>
    /// Types de comparaisons disponibles pour la classe d'aide aux predicats DateTime
    /// </summary>
    public enum DateTimeComparaison
    {
        Equals,
        Sup,
        inf
    }

}
