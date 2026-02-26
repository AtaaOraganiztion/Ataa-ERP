using System.Reflection;

namespace Web.Api.Permissions;

public static class PermissionsHelper
{
    public static List<KeyValuePair<string, string>> GetAll()
    {
        List<KeyValuePair<string, string>> permissions = new();

        // Get all static classes in the Permissions namespace
        IEnumerable<Type> permissionTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.Namespace == "Web.Api.Permissions" && t.IsClass && t.IsAbstract && t.IsSealed &&
                        (bool)(!t.FullName?.EndsWith("Helper"))!);

        foreach (Type type in permissionTypes)
        {
            // Get all public static fields
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(string))
                {
                    string? value = field.GetValue(null) as string;
                    if (!string.IsNullOrEmpty(value))
                    {
                        permissions.Add(new KeyValuePair<string, string>(type.FullName!.Split(".").Last(), value));
                    }
                }
            }

            //     // Get all nested types (for nested classes like Admin)
            //     Type[] nestedTypes = type.GetNestedTypes(BindingFlags.Public | BindingFlags.Static);
            //     foreach (Type nestedType in nestedTypes)
            //     {
            //         FieldInfo[] nestedFields = nestedType.GetFields(BindingFlags.Public | BindingFlags.Static);
            //         foreach (FieldInfo field in nestedFields)
            //         {
            //             if (field.FieldType == typeof(string))
            //             {
            //                 string? value = field.GetValue(null) as string;
            //                 if (!string.IsNullOrEmpty(value))
            //                 {
            //                     permissions.Add(value);
            //                 }
            //             }
            //         }
            //     }
        }

        return permissions;
    }
}
