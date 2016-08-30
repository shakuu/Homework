using System;

namespace NestedTypesDemo
{
    /// <summary>
    /// For further reading: https://msdn.microsoft.com/en-us/library/ms173120.aspx
    /// </summary>
    internal class Container
    {
        /// <summary>
        /// Create an instance of the nested type and invoke its method.
        /// </summary>
        /// <param name="nestedTypeMethodInputParameter"> Example parameter passed to the nested type's method. </param>
        internal static void InvokeNestedTypeMethod(object nestedTypeMethodInputParameter)
        {
            Container.Nested instanceOfTheNestedType = new Container.Nested();

            instanceOfTheNestedType.NestedTypeMethod(nestedTypeMethodInputParameter);
        }

        /// <summary>
        /// Example nested type.
        /// </summary>
        internal class Nested
        {
            /// <summary>
            /// Example nested type method.
            /// </summary>
            /// <param name="exampleParameter"> Parameter to print on the console. </param>
            internal void NestedTypeMethod(object exampleParameter)
            {
                var exampleParameterAsString = exampleParameter.ToString();
                Console.WriteLine(exampleParameterAsString);
            }
        }
    }
}
