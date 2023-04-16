using System.ComponentModel;
using System.Globalization;

namespace AppHeindall.Extensions;

public static class EnumExtension
{
    public static string Descricao<T>(this T e) where T : IConvertible
    {
        string result = null;
        if (e is Enum)
        {
            Type type = e.GetType();
            {
                foreach (int value in Enum.GetValues(type))
                {
                    if (value == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        object[] customAttributes = type.GetMember(type.GetEnumName(value))[0].GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
                        if (customAttributes.Length != 0)
                        {
                            return ((DescriptionAttribute)customAttributes[0]).Description;
                        }

                        return result;
                    }
                }

                return result;
            }
        }

        return result;
    }
}
