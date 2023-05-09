#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

#endregion

namespace DeleteSchedules
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            List<ViewSchedule> allSchedules = Utils.GetAllSchedules(doc);

            List<ScheduleSheetInstance> sheetInstances = Utils.GetAllScheduleSheetInstances(doc);

            List<ViewSchedule> SchedulesToDelete = Utils.GetSchedulesNotOnSheets(doc, allSchedules, sheetInstances);

            using(Transaction t = new Transaction(doc))
            {
                t.Start("Delete unused schedules");

                foreach (ViewSchedule schedule in SchedulesToDelete)
                {
                    doc.Delete(schedule.Id);
                }
            }

            return Result.Succeeded;
        }

        public static String GetMethod()
        {
            var method = MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            return method;
        }
    }
}
