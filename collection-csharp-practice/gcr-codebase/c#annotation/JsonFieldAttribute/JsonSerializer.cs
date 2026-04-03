using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectFive.Annotation.JsonFieldAttribute
{
   public class JsonSerializer
    {
        public static string ToJson(object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields();

            StringBuilder json = new StringBuilder();
            json.Append("{");

            bool first = true;

            foreach (FieldInfo field in fields)
            {
                JsonField attr =
                    (JsonField)Attribute.GetCustomAttribute(
                        field, typeof(JsonField));

                if (attr != null)
                {
                    if (!first)
                        json.Append(", ");

                    string key = attr.Name ?? field.Name;
                    object value = field.GetValue(obj);

                    json.Append($"\"{key}\": ");

                    if (value is string)
                        json.Append($"\"{value}\"");
                    else
                        json.Append(value);

                    first = false;
                }
            }

            json.Append("}");
            return json.ToString();
        }
    }
}

