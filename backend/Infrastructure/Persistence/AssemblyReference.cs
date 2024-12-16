using System.Reflection;

namespace Persistence;

internal class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
