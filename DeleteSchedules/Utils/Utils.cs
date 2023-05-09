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

        internal static RibbonPanel GetRibbonPanelByName(UIControlledApplication app, string tabName, string panelName)
        {
            foreach (RibbonPanel tmpPanel in app.GetRibbonPanels(tabName))
            {
                if (tmpPanel.Name == panelName)
                    return tmpPanel;
            }

            return null;
        }

        internal static List<ViewSchedule> GetAllSchedules(Document doc)
        {
            List<ViewSchedule> m_schedList = new List<ViewSchedule>();

            FilteredElementCollector curCollector = new FilteredElementCollector(doc);
            curCollector.OfClass(typeof(ViewSchedule));

            //loop through views and check if schedule - if so then put into schedule list
            foreach (ViewSchedule curView in curCollector)
            {
                if (curView.ViewType == ViewType.Schedule)
                {
                    m_schedList.Add((ViewSchedule)curView);
                }
            }

            return m_schedList;
        }

        internal static List<ScheduleSheetInstance> GetAllScheduleSheetInstances(Document doc)
        {
            FilteredElementCollector m_colSSI = new FilteredElementCollector(doc);
            m_colSSI.OfClass(typeof(ScheduleSheetInstance));

            List<ScheduleSheetInstance> m_returnList = new List<ScheduleSheetInstance>();           

            throw new NotImplementedException();
        }

        

        internal static List<ViewSchedule> GetSchedulesNotOnSheets(Document doc, List<ViewSchedule> allSchedules, List<ScheduleSheetInstance> sheetInstances)
        {
            
            
            throw new NotImplementedException();
        }

        internal static List<ViewSheet> GetAllSheets(Document doc)
        {
            //get all sheets
            FilteredElementCollector m_colViews = new FilteredElementCollector(doc);
            m_colViews.OfCategory(BuiltInCategory.OST_Sheets);

            List<ViewSheet> m_sheets = new List<ViewSheet>();
            foreach (ViewSheet x in m_colViews.ToElements())
            {
                m_sheets.Add(x);
            }

            return m_sheets;
        }
    }
}
