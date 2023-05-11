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

            // get all the schedules
            // get the names of all the schedules

            // get all the sheet schedule instances
            // get the names of all the sheet schedule instances

            // compare the names on the 2 lists,
            // if there is not a match add it to Schedules to delete list

            // get all the schedule names

            List<string> schedNames = Utils.GetAllScheduleNames(doc);

            List<string> schedInstances = Utils.GetAllSSINames(doc);

            List<string> schedNotUsed = Utils.GetSchedulesNotUsed(schedNames, schedInstances);

            List<ViewSchedule> SchedulesToDelete = Utils.GetSchedulesToDelete(schedNotUsed);

            using (Transaction t = new Transaction(doc))
            {
                t.Start("Delete Unused Schedules");

                foreach (ViewSchedule curSched in SchedulesToDelete)
                {
                    doc.Delete(curSched.Id);
                }

                t.Commit();
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
