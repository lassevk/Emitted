using System.Reflection.Emit;

using Emitted;

var method = new DynamicMethod("method", typeof(void), [typeof(string)]);
ILGenerator il = method.GetILGenerator();

Label lTooShort = il.DefineLabel();
Label lExit = il.DefineLabel();
il
   .local<string>()
   .ldstr("Hello, {0}!")
   .ldarg_0()
   .dup()
   .stloc_0()
   .call(typeof(string).GetMethod("Format", [typeof(string), typeof(string)])!)
   .call(typeof(Console).GetMethod("WriteLine", [typeof(string)])!)
   .ldstr("i = {0}")
   .ldloc_0()
   .ldlen()
   .dup()
   .ldc_i4_4()
   .ble(lTooShort)
   .box<int>()
   .call(typeof(string).GetMethod("Format", [typeof(string), typeof(object)])!)
   .call(typeof(Console).GetMethod("WriteLine", [typeof(string)])!)
   .br(lExit)
   .mark(lTooShort)
   .pop()
   .pop()
   .mark(lExit)
   .ret();

Action<string> mm = method.CreateDelegate<Action<string>>();
mm("World");
mm("Worl");