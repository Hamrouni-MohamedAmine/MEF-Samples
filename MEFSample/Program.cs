using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;

namespace MEFSample
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyCatalog catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
            foreach(ComposablePartDefinition p in container.Catalog.Parts)
            {
                Console.WriteLine(p.ToString());
            }
            Console.ReadLine();
        }
    }

    
    class ClassA : Iinterface{ }

    
    class ClassB: ClassA { }

    class ClassC : ClassB { }

    [InheritedExport]
    public interface Iinterface { }
}
