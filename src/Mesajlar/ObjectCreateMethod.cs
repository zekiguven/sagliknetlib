using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;

namespace SaglikNetLib
{
    public partial class BaseMesaj
    {
        /// <summary>
        /// http://www.ozcandegirmenci.com/post/2008/02/Create-object-instances-Faster-than-Reflection.aspx
        /// </summary>
        public class ObjectCreateMethod
        {
            delegate object MethodInvoker();
            MethodInvoker methodHandler = null;

            public ObjectCreateMethod(Type type)
            {
                CreateMethod(type.GetConstructor(Type.EmptyTypes));
            }

            public ObjectCreateMethod(ConstructorInfo target)
            {
                CreateMethod(target);
            }

            void CreateMethod(ConstructorInfo target)
            {
                DynamicMethod dynamic = new DynamicMethod(string.Empty,
                            typeof(object),
                            new Type[0],
                            target.DeclaringType);
                ILGenerator il = dynamic.GetILGenerator();
                il.DeclareLocal(target.DeclaringType);
                il.Emit(OpCodes.Newobj, target);
                il.Emit(OpCodes.Stloc_0);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Ret);

                methodHandler = (MethodInvoker)dynamic.CreateDelegate(typeof(MethodInvoker));
            }

            public object CreateInstance()
            {
                return methodHandler();
            }
        }
    }
}
