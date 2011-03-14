using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTools
{
    public delegate void ThreadSafeMethod();

    public static class ThreadSafe
    {
        /// <summary>
        /// Dispara um evento utilizando segurança de thread, se o método algo
        /// oferecer suporte.
        /// </summary>
        /// <typeparam name="T">Tipo do argumento passado para o delegate.</typeparam>
        /// <param name="deleg">Delegate aonde os métodos algo estão relacionados.</param>
        /// <param name="arg">Argumento passado para o delegate.</param>
        public static void FireEvent<T>(Delegate deleg, object sender, T arg)
        {
            if (deleg != null)
            {
                // Percorre todos os métodos alvo relacionados ao delegate
                foreach (Delegate singleCast in deleg.GetInvocationList())
                {
                    // Recupera a informação de syncronização de thread do objeto aonde o método alvo está contido

                    object target = typeof(Delegate).GetField("_target", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(singleCast);


                    System.Windows.Forms.Control syncInvoke = target as System.Windows.Forms.Control;
                    ///ISynchronizeInvoke syncInvoke = target as ISynchronizeInvoke;
                    try
                    {
                        // Verifica se o método alvo tem suporte a thread segura
                        if (syncInvoke != null && syncInvoke.InvokeRequired)
                            // Chama o método alvo
                            syncInvoke.Invoke(deleg, new object[] { sender, arg });
                        else
                        {
                            // Chama o método alvo.
                            //singleCast.DynamicInvoke(new object[] { sender, arg });

                            singleCast.GetType().GetMethod("Invoke", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic).Invoke(singleCast, new object[] { sender, arg });
                        }
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// Dispara um evento utilizando segurança de thread, se o método algo
        /// oferecer suporte.
        /// </summary>
        /// <typeparam name="T">Tipo do argumento passado para o delegate.</typeparam>
        /// <param name="deleg">Delegate aonde os métodos algo estão relacionados.</param>
        /// <param name="arg">Argumento passado para o delegate.</param>
        public static void FireEvent(Delegate deleg, params object[] args)
        {
            if (deleg != null)
            {
                // Percorre todos os métodos alvo relacionados ao delegate
                foreach (Delegate singleCast in deleg.GetInvocationList())
                {
                    // Recupera a informação de syncronização de thread do objeto aonde o método alvo está contido

                    object target = typeof(Delegate).GetField("_target", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(singleCast);


                    System.Windows.Forms.Control syncInvoke = target as System.Windows.Forms.Control;
                    ///ISynchronizeInvoke syncInvoke = target as ISynchronizeInvoke;
                    //try
                    //{
                        // Verifica se o método alvo tem suporte a thread segura
                        if (syncInvoke != null && syncInvoke.InvokeRequired)
                            // Chama o método alvo
                            syncInvoke.Invoke(deleg, args);
                        else
                        {
                            // Chama o método alvo.
                            //singleCast.DynamicInvoke(new object[] { sender, arg });

                            singleCast.GetType().GetMethod("Invoke", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic).Invoke(singleCast, args);
                        }
                    /*}
                    catch { }*/
                }
            }
        }


        /// <summary>
        /// Dispara um evento utilizando segurança de thread, se o método algo
        /// oferecer suporte.
        /// </summary>
        /// <param name="deleg">Delegate aonde os métodos algo estão relacionados.</param>
        public static void FireEvent(ThreadSafeMethod deleg)
        {
            if (deleg != null)
            {
                // Percorre todos os métodos alvo relacionados ao delegate
                foreach (Delegate singleCast in deleg.GetInvocationList())
                {
                    // Recupera a informação de syncronização de thread do objeto aonde o método alvo está contido

                    object target = typeof(Delegate).GetField("_target", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(singleCast);


                    System.Windows.Forms.Control syncInvoke = target as System.Windows.Forms.Control;
                    ///ISynchronizeInvoke syncInvoke = target as ISynchronizeInvoke;
                    //try
                    //{
                        // Verifica se o método alvo tem suporte a thread segura
                        if (syncInvoke != null && syncInvoke.InvokeRequired)
                            // Chama o método alvo
                            syncInvoke.Invoke(deleg, null);
                        else
                        {
                            // Chama o método alvo.
                            //singleCast.DynamicInvoke(new object[] { sender, arg });

                            singleCast.GetType().GetMethod("Invoke", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic).Invoke(singleCast, null);
                        }
                    //}
                    //catch { }
                }
            }
        }
    }
}
