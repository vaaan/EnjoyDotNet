using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Vaaan.SouFun.AutoFill.App.Utilities
{
    class EventRemover
    {
        public static void ClearEvent(object objectHasEvents, string eventName)
        {
            if (objectHasEvents != null)
            {
                EventInfo[] events = objectHasEvents.GetType().GetEvents(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                if ((events != null) && (events.Length >= 1))
                {
                    for (int i = 0; i < events.Length; i++)
                    {
                        try
                        {
                            EventInfo ei = events[i];
                            if (ei.Name == eventName)
                            {
                                FieldInfo fi = ei.DeclaringType.GetField(ei.Name, BindingFlags.Static | BindingFlags.Instance);
                                if (fi != null)
                                {
                                    fi.SetValue(objectHasEvents, null);
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
    }
}
