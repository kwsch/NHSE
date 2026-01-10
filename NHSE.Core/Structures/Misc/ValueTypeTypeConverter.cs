using System;
using System.Collections;
using System.ComponentModel;

namespace NHSE.Core
{
    /// <summary>
    /// Used for allowing a struct to be mutated in a PropertyGrid.
    /// </summary>
    public class ValueTypeTypeConverter : ExpandableObjectConverter
    {
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext? context) => true;

        public override object? CreateInstance(ITypeDescriptorContext? context, IDictionary propertyValues)
        {
            if (context?.PropertyDescriptor is not { } pd)
                return null;

            var boxed = pd.GetValue(context.Instance);
            foreach (DictionaryEntry entry in propertyValues)
            {
                if (entry.Key.ToString() is not { } propName)
                    continue;
                var pi = pd.PropertyType.GetProperty(propName);
                if (pi?.CanWrite == true)
                    pi.SetValue(boxed, Convert.ChangeType(entry.Value, pi.PropertyType), null);
            }
            return boxed;
        }
    }
}