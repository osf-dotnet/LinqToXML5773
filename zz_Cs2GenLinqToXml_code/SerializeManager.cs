using System;
using System.Collections.Generic;
using System.Text;

namespace zz_Cs2GenLinqToXml_code
{
    ///<summary> 
    /// Classe de serialization Xml generique 
    ///</summary> 
    ///<typeparam name="T">Type generique</typeparam> 
    public class SerializeManager<T>
    {
        /// <summary>
        /// methode static permettant de serializer au format Xml n'importe quel objet
        /// </summary>
        /// <param name="obj">l'objet a serializer</param>
        /// <param name="Path">le chemin complet vers le fichier a sauvegarder</param>
        public static void Serialize(T obj, string Path)
        {
            System.Xml.Serialization.XmlSerializer oXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            System.IO.StreamWriter oStreamWriter = new System.IO.StreamWriter(Path);
            oXmlSerializer.Serialize(oStreamWriter, obj);
            oStreamWriter.Close();
        }
        /// <summary>
        /// methode static permettant de deserializer du format Xml n'importe quel objet
        /// </summary>
        /// <param name="Path">le chemin complet vers le fichier Xml a deserializer</param>
        /// <returns>l'objet du type defini</returns>
        public static T Deserialize(string Path)
        {
            System.Xml.Serialization.XmlSerializer oXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            System.IO.StreamReader oStreamReader = new System.IO.StreamReader(Path);
            T obj = (T)oXmlSerializer.Deserialize(oStreamReader);
            oStreamReader.Close();
            return obj;
        }
    } 

}
