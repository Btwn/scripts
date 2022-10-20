using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace PreliminarCobro.Controllers
{
    internal class FuncionesGlobales
    {       
        /// <summary>
        /// Retorna la conversión de un datatable a una lista de clases.
        /// </summary>
        /// <typeparam name="T">Clase a la que se va a convertir</typeparam>
        /// <param name="tbl">Tabla con los datos a convertir</param>
        /// <returns></returns>
        public static List<T> GetDatosDataTable<T>(DataTable tbl)
        {
            List<T> listResult = new List<T>();
            List<PropertyInfo> props = (
                from PropertyInfo _prop_2
                in typeof(T).GetProperties()
                where _prop_2.CanWrite && tbl.Columns.Contains(_prop_2.Name.ToString()
                )
                select _prop_2).ToList();

            foreach (DataRow row in tbl.Rows)
            {
                var _item = Activator.CreateInstance<T>();
                foreach (PropertyInfo _prop in props)
                {
                    if (row[_prop.Name.ToString()] != DBNull.Value)
                    {
                        object _value = row[_prop.Name.ToString()].ToString().Trim();
                        Type _type_val = _prop.PropertyType;

                        if (_prop.PropertyType.IsEnum)
                            _value = Enum.Parse(_type_val, _value.ToString());
                        else
                            _value = Convert.ChangeType(_value, _type_val);

                        _prop.SetValue(_item, _value, null);
                    }
                }
                listResult.Add(_item);
            }

            return listResult;
        }
    }
}