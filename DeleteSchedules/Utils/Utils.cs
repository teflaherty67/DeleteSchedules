using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteSchedules
{
    internal static class Utils
    {
        internal static RibbonPanel CreateRibbonPanel(UIControlledApplication app, string tabName, string panelName)
        {
            RibbonPanel currentPanel = GetRibbonPanelByName(app, tabName, panelName);

            if (currentPanel == null)
                currentPanel = app.CreateRibbonPanel(tabName, panelName);

            return currentPanel;
        }

        internal static List<ViewSchedule> GetAllSchedules(Document doc)
        {
            throw new NotImplementedException();
        }

        internal static List<ScheduleSheetInstance> GetAllScheduleSheetInstances(Document doc)
        {
            throw new NotImplementedException();
        }

        internal static RibbonPanel GetRibbonPanelByName(UIControlledApplication app, string tabName, string panelName)
        {
            foreach (RibbonPanel tmpPanel in app.GetRibbonPanels(tabName))
            {
                if (tmpPanel.Name == panelName)
                    return tmpPanel;
            }

            return null;
        }

        internal static List<ViewSchedule> GetSchedulesNotOnSheets(Document doc, List<ViewSchedule> allSchedules, List<ScheduleSheetInstance> sheetInstances)
        {
            throw new NotImplementedException();
        }
    }
}
