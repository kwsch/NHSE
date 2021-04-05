using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace NHSE.Core
{
    public class ItemMutator : BatchMutator<Item>
    {
        public readonly ItemReflection Reflect = ItemReflection.Default;

        public override ModifyResult Modify(Item item, IEnumerable<StringInstruction> filters, IEnumerable<StringInstruction> modifications)
        {
            var pi = Reflect.Props[Array.IndexOf(Reflect.Types, item.GetType())];
            foreach (var cmd in filters)
            {
                try
                {
                    if (!IsFilterMatch(cmd, item, pi))
                        return ModifyResult.Filtered;
                }
#pragma warning disable CA1031 // Do not catch general exception types
                // Swallow any error because this can be malformed user input.
                catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
                {
                    Debug.WriteLine($"Failed to compare: {ex.Message} - {cmd.PropertyName} {cmd.PropertyValue}");
                    return ModifyResult.Error;
                }
            }

            ModifyResult result = ModifyResult.Modified;
            foreach (var cmd in modifications)
            {
                try
                {
                    var tmp = SetProperty(cmd, item, pi);
                    if (tmp != ModifyResult.Modified)
                        result = tmp;
                }
#pragma warning disable CA1031 // Do not catch general exception types
                // Swallow any error because this can be malformed user input.
                catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
                {
                    Debug.WriteLine($"Failed to modify: {ex.Message} - {cmd.PropertyName} {cmd.PropertyValue}");
                }
            }
            return result;
        }

        /// <summary>
        /// Sets the if the <see cref="Item"/> should be filtered due to the <see cref="StringInstruction"/> provided.
        /// </summary>
        /// <param name="cmd">Command Filter</param>
        /// <param name="item">Pokémon to check.</param>
        /// <param name="props">PropertyInfo cache (optional)</param>
        /// <returns>True if filtered, else false.</returns>
        private static ModifyResult SetProperty(StringInstruction cmd, Item item, IReadOnlyDictionary<string, PropertyInfo> props)
        {
            if (SetComplexProperty(item, cmd))
                return ModifyResult.Modified;

            if (!props.TryGetValue(cmd.PropertyName, out var pi))
                return ModifyResult.Error;

            if (!pi.CanWrite)
                return ModifyResult.Error;

            object val = cmd.Random ? (object)cmd.RandomValue : cmd.PropertyValue;
            ReflectUtil.SetValue(pi, item, val);
            return ModifyResult.Modified;
        }

        private static bool SetComplexProperty(Item item, StringInstruction cmd)
        {
            // Zeroed out item?
            if (cmd.PropertyName == nameof(Item.ItemId))
            {
                if (!int.TryParse(cmd.PropertyValue, out var val))
                    return false;
                if (val is not 0 or 0xFFFE)
                    return false;
                item.Delete();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Tries to fetch the <see cref="Item"/> property from the cache of available properties.
        /// </summary>
        /// <param name="item">Pokémon to check</param>
        /// <param name="name">Property Name to check</param>
        /// <param name="pi">Property Info retrieved (if any).</param>
        /// <returns>True if has property, false if does not.</returns>
        public bool TryGetHasProperty(Item item, string name, [NotNullWhen(true)] out PropertyInfo? pi)
        {
            var type = item.GetType();
            return TryGetHasProperty(type, name, out pi);
        }

        /// <summary>
        /// Tries to fetch the <see cref="Item"/> property from the cache of available properties.
        /// </summary>
        /// <param name="type">Type to check</param>
        /// <param name="name">Property Name to check</param>
        /// <param name="pi">Property Info retrieved (if any).</param>
        /// <returns>True if has property, false if does not.</returns>
        public bool TryGetHasProperty(Type type, string name, [NotNullWhen(true)] out PropertyInfo? pi)
        {
            var index = Array.IndexOf(Reflect.Types, type);
            if (index < 0)
            {
                pi = null;
                return false;
            }
            var props = Reflect.Props[index];
            return props.TryGetValue(name, out pi);
        }

        /// <summary>
        /// Gets the type of the <see cref="Item"/> property using the saved cache of properties.
        /// </summary>
        /// <param name="propertyName">Property Name to fetch the type for</param>
        /// <param name="typeIndex">Type index. Leave empty (0) for a nonspecific format.</param>
        /// <returns>Short name of the property's type.</returns>
        public string? GetPropertyType(string propertyName, int typeIndex = 0)
        {
            if (typeIndex == 0) // Any
            {
                foreach (var p in Reflect.Props)
                {
                    if (p.TryGetValue(propertyName, out var pi))
                        return pi.PropertyType.Name;
                }
                return null;
            }

            int index = typeIndex - 1 >= Reflect.Props.Length ? 0 : typeIndex - 1; // All vs Specific
            var pr = Reflect.Props[index];
            if (!pr.TryGetValue(propertyName, out var info))
                return null;
            return info.PropertyType.Name;
        }

        /// <summary>
        /// Checks if the object is filtered by the provided <see cref="filters"/>.
        /// </summary>
        /// <param name="filters">Filters which must be satisfied.</param>
        /// <param name="item">Object to check.</param>
        /// <returns>True if <see cref="item"/> matches all filters.</returns>
        public bool IsFilterMatch(IEnumerable<StringInstruction> filters, Item item) => filters.All(z => IsFilterMatch(z, item, Reflect.Props[Array.IndexOf(Reflect.Types, item.GetType())]));

        /// <summary>
        /// Checks if the <see cref="Item"/> should be filtered due to the <see cref="StringInstruction"/> provided.
        /// </summary>
        /// <param name="cmd">Command Filter</param>
        /// <param name="item">Pokémon to check.</param>
        /// <param name="props">PropertyInfo cache (optional)</param>
        /// <returns>True if filter matches, else false.</returns>
        private static bool IsFilterMatch(StringInstruction cmd, Item item, IReadOnlyDictionary<string, PropertyInfo> props)
        {
            return IsPropertyFiltered(cmd, item, props);
        }

        /// <summary>
        /// Checks if the <see cref="Item"/> should be filtered due to the <see cref="StringInstruction"/> provided.
        /// </summary>
        /// <param name="cmd">Command Filter</param>
        /// <param name="item">Pokémon to check.</param>
        /// <param name="props">PropertyInfo cache</param>
        /// <returns>True if filtered, else false.</returns>
        private static bool IsPropertyFiltered(StringInstruction cmd, Item item, IReadOnlyDictionary<string, PropertyInfo> props)
        {
            if (!props.TryGetValue(cmd.PropertyName, out var pi))
                return false;
            if (!pi.CanRead)
                return false;
            return pi.IsValueEqual(item, cmd.PropertyValue) == cmd.Evaluator;
        }

        /// <summary>
        /// Checks if the object is filtered by the provided <see cref="filters"/>.
        /// </summary>
        /// <param name="filters">Filters which must be satisfied.</param>
        /// <param name="obj">Object to check.</param>
        /// <returns>True if <see cref="obj"/> matches all filters.</returns>
        public static bool IsFilterMatch(IEnumerable<StringInstruction> filters, object obj)
        {
            foreach (var cmd in filters)
            {
                if (!ReflectUtil.HasProperty(obj, cmd.PropertyName, out var pi))
                    return false;
                try
                {
                    if (pi.IsValueEqual(obj, cmd.PropertyValue) == cmd.Evaluator)
                        continue;
                }
#pragma warning disable CA1031 // Do not catch general exception types
                // User provided inputs can mismatch the type's required value format, and fail to be compared.
                catch (Exception e)
#pragma warning restore CA1031 // Do not catch general exception types
                {
                    Debug.WriteLine($"Unable to compare {cmd.PropertyName} to {cmd.PropertyValue}.");
                    Debug.WriteLine(e.Message);
                }
                return false;
            }
            return true;
        }
    }
}
